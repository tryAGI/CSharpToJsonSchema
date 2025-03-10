using System.Collections.Immutable;
using System.Diagnostics;
using CSharpToJsonSchema.Generators.JsonGen.Helpers;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace CSharpToJsonSchema.Generators.JsonGen.Base;

internal static partial class SyntaxValueProviderExtensions
{
#if false

    // Deviation from roslyn.  We do not support attributes that are nested or generic.  That's ok as that's not a
    // scenario that ever arises in our generators.

    private static readonly char[] s_nestedTypeNameSeparators = new char[] { '+' };

    private static readonly SymbolDisplayFormat s_metadataDisplayFormat =
        SymbolDisplayFormat.QualifiedNameArityFormat.AddCompilerInternalOptions(SymbolDisplayCompilerInternalOptions.UsePlusForNestedTypes);

#endif

    /// <summary>
    /// Creates an <see cref="IncrementalValuesProvider{T}"/> that can provide a transform over all <see
    /// cref="SyntaxNode"/>s if that node has an attribute on it that binds to a <see cref="INamedTypeSymbol"/> with the
    /// same fully-qualified metadata as the provided <paramref name="fullyQualifiedMetadataName"/>. <paramref
    /// name="fullyQualifiedMetadataName"/> should be the fully-qualified, metadata name of the attribute, including the
    /// <c>Attribute</c> suffix.  For example <c>"System.CLSCompliantAttribute</c> for <see
    /// cref="CLSCompliantAttribute"/>.
    /// </summary>
    /// <param name="predicate">A function that determines if the given <see cref="SyntaxNode"/> attribute target (<see
    /// cref="GeneratorAttributeSyntaxContext.TargetNode"/>) should be transformed.  Nodes that do not pass this
    /// predicate will not have their attributes looked at at all.</param>
    /// <param name="transform">A function that performs the transform. This will only be passed nodes that return <see
    /// langword="true"/> for <paramref name="predicate"/> and which have a matching <see cref="AttributeData"/> whose
    /// <see cref="AttributeData.AttributeClass"/> has the same fully qualified, metadata name as <paramref
    /// name="fullyQualifiedMetadataName"/>.</param>
    public static IncrementalValuesProvider<T> ForAttributeWithMetadataName<T>(
        this IncrementalValueProvider<Compilation> @this,
        IncrementalGeneratorInitializationContext context,
        string fullyQualifiedMetadataName,
        Func<SyntaxNode, CancellationToken, bool> predicate,
        Func<GeneratorAttributeSyntaxContext, CancellationToken, T> transform)
    {
#if false

        // Deviation from roslyn.  We do not support attributes that are nested or generic.  That's ok as that's not a
        // scenario that ever arises in our generators.

        var metadataName = fullyQualifiedMetadataName.Contains('+')
            ? MetadataTypeName.FromFullName(fullyQualifiedMetadataName.Split(s_nestedTypeNameSeparators).Last())
            : MetadataTypeName.FromFullName(fullyQualifiedMetadataName);

        var nodesWithAttributesMatchingSimpleName = @this.ForAttributeWithSimpleName(context, metadataName.UnmangledTypeName, predicate);

#else

        var lastDotIndex = fullyQualifiedMetadataName.LastIndexOf('.');
        Debug.Assert(lastDotIndex > 0);
        var unmangledTypeName = fullyQualifiedMetadataName.Substring(lastDotIndex + 1);

        var nodesWithAttributesMatchingSimpleName = @this.ForAttributeWithSimpleName(context, unmangledTypeName, predicate);

#endif

        var compilationAndGroupedNodesProvider = nodesWithAttributesMatchingSimpleName
                .Combine(context.CompilationProvider)
            /*.WithTrackingName("compilationAndGroupedNodes_ForAttributeWithMetadataName")*/;

        var syntaxHelper = CSharpSyntaxHelper.Instance;
        var finalProvider = compilationAndGroupedNodesProvider.SelectMany((tuple, cancellationToken) =>
        {
            var ((syntaxTree, syntaxNodes), compilation) = tuple;
            Debug.Assert(syntaxNodes.All(n => n.SyntaxTree == syntaxTree));

            using var result = new ValueListBuilder<T>(Span<T>.Empty);
            if (!syntaxNodes.IsEmpty)
            {
                var semanticModel = compilation.GetSemanticModel(syntaxTree);

                foreach (var targetNode in syntaxNodes)
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    var targetSymbol =
                        targetNode is ICompilationUnitSyntax compilationUnit ? semanticModel.Compilation.Assembly :
                        syntaxHelper.IsLambdaExpression(targetNode) ? semanticModel.GetSymbolInfo(targetNode, cancellationToken).Symbol :
                        semanticModel.GetDeclaredSymbol(targetNode, cancellationToken);
                    if (targetSymbol is null)
                        continue;

                    var attributes = getMatchingAttributes(targetNode, targetSymbol, fullyQualifiedMetadataName);
                    if (attributes.Length > 0)
                    {
                        result.Append(transform(
                            new GeneratorAttributeSyntaxContext(targetNode, targetSymbol, semanticModel, attributes),
                            cancellationToken));
                    }
                }
            }

            return result.AsSpan().ToImmutableArray();
        })/*.WithTrackingName("result_ForAttributeWithMetadataName")*/;

        return finalProvider;

        static ImmutableArray<AttributeData> getMatchingAttributes(
            SyntaxNode attributeTarget,
            ISymbol symbol,
            string fullyQualifiedMetadataName)
        {
            var targetSyntaxTree = attributeTarget.SyntaxTree;
            var result = new ValueListBuilder<AttributeData>(Span<AttributeData>.Empty);

            try
            {
                addMatchingAttributes(ref result, symbol.GetAttributes());
                addMatchingAttributes(ref result, (symbol as IMethodSymbol)?.GetReturnTypeAttributes());

                if (symbol is IAssemblySymbol assemblySymbol)
                {
                    foreach (var module in assemblySymbol.Modules)
                        addMatchingAttributes(ref result, module.GetAttributes());
                }

                return result.AsSpan().ToImmutableArray();
            }
            finally
            {
                result.Dispose();
            }

            void addMatchingAttributes(
                ref ValueListBuilder<AttributeData> result,
                ImmutableArray<AttributeData>? attributes)
            {
                if (!attributes.HasValue)
                    return;

                foreach (var attribute in attributes.Value)
                {
                    if (attribute.ApplicationSyntaxReference?.SyntaxTree == targetSyntaxTree &&
                        attribute.AttributeClass?.ToDisplayString(/*s_metadataDisplayFormat*/) == fullyQualifiedMetadataName)
                    {
                        result.Append(attribute);
                    }
                }
            }
        }
    }
    
    /// <summary>
    /// Creates an <see cref="IncrementalValuesProvider{T}"/> that can provide a transform over all <see
    /// cref="SyntaxNode"/>s if that node has an attribute on it that binds to a <see cref="INamedTypeSymbol"/> with the
    /// same fully-qualified metadata as the provided <paramref name="fullyQualifiedMetadataName"/>. <paramref
    /// name="fullyQualifiedMetadataName"/> should be the fully-qualified, metadata name of the attribute, including the
    /// <c>Attribute</c> suffix.  For example <c>"System.CLSCompliantAttribute</c> for <see
    /// cref="CLSCompliantAttribute"/>.
    /// </summary>
    /// <param name="predicate">A function that determines if the given <see cref="SyntaxNode"/> attribute target (<see
    /// cref="GeneratorAttributeSyntaxContext.TargetNode"/>) should be transformed.  Nodes that do not pass this
    /// predicate will not have their attributes looked at at all.</param>
    /// <param name="transform">A function that performs the transform. This will only be passed nodes that return <see
    /// langword="true"/> for <paramref name="predicate"/> and which have a matching <see cref="AttributeData"/> whose
    /// <see cref="AttributeData.AttributeClass"/> has the same fully qualified, metadata name as <paramref
    /// name="fullyQualifiedMetadataName"/>.</param>
    public static IncrementalValuesProvider<T> ForAttributeWithMetadataName<T>(
        this SyntaxValueProvider @this,
        IncrementalGeneratorInitializationContext context,
        string fullyQualifiedMetadataName,
        Func<SyntaxNode, CancellationToken, bool> predicate,
        Func<GeneratorAttributeSyntaxContext, CancellationToken, T> transform)
    {
#if false

        // Deviation from roslyn.  We do not support attributes that are nested or generic.  That's ok as that's not a
        // scenario that ever arises in our generators.

        var metadataName = fullyQualifiedMetadataName.Contains('+')
            ? MetadataTypeName.FromFullName(fullyQualifiedMetadataName.Split(s_nestedTypeNameSeparators).Last())
            : MetadataTypeName.FromFullName(fullyQualifiedMetadataName);

        var nodesWithAttributesMatchingSimpleName = @this.ForAttributeWithSimpleName(context, metadataName.UnmangledTypeName, predicate);

#else

        var lastDotIndex = fullyQualifiedMetadataName.LastIndexOf('.');
        Debug.Assert(lastDotIndex > 0);
        var unmangledTypeName = fullyQualifiedMetadataName.Substring(lastDotIndex + 1);

        var nodesWithAttributesMatchingSimpleName = @this.ForAttributeWithSimpleName(context, unmangledTypeName, predicate);

#endif

        var compilationAndGroupedNodesProvider = nodesWithAttributesMatchingSimpleName
                .Combine(context.CompilationProvider)
            /*.WithTrackingName("compilationAndGroupedNodes_ForAttributeWithMetadataName")*/;

        var syntaxHelper = CSharpSyntaxHelper.Instance;
        var finalProvider = compilationAndGroupedNodesProvider.SelectMany((tuple, cancellationToken) =>
        {
            var ((syntaxTree, syntaxNodes), compilation) = tuple;
            Debug.Assert(syntaxNodes.All(n => n.SyntaxTree == syntaxTree));

            using var result = new ValueListBuilder<T>(Span<T>.Empty);
            if (!syntaxNodes.IsEmpty)
            {
                var semanticModel = compilation.GetSemanticModel(syntaxTree);

                foreach (var targetNode in syntaxNodes)
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    var targetSymbol =
                        targetNode is ICompilationUnitSyntax compilationUnit ? semanticModel.Compilation.Assembly :
                        syntaxHelper.IsLambdaExpression(targetNode) ? semanticModel.GetSymbolInfo(targetNode, cancellationToken).Symbol :
                        semanticModel.GetDeclaredSymbol(targetNode, cancellationToken);
                    if (targetSymbol is null)
                        continue;

                    var attributes = getMatchingAttributes(targetNode, targetSymbol, fullyQualifiedMetadataName);
                    if (attributes.Length > 0)
                    {
                        result.Append(transform(
                            new GeneratorAttributeSyntaxContext(targetNode, targetSymbol, semanticModel, attributes),
                            cancellationToken));
                    }
                }
            }

            return result.AsSpan().ToImmutableArray();
        })/*.WithTrackingName("result_ForAttributeWithMetadataName")*/;

        return finalProvider;

        static ImmutableArray<AttributeData> getMatchingAttributes(
            SyntaxNode attributeTarget,
            ISymbol symbol,
            string fullyQualifiedMetadataName)
        {
            var targetSyntaxTree = attributeTarget.SyntaxTree;
            var result = new ValueListBuilder<AttributeData>(Span<AttributeData>.Empty);

            try
            {
                addMatchingAttributes(ref result, symbol.GetAttributes());
                addMatchingAttributes(ref result, (symbol as IMethodSymbol)?.GetReturnTypeAttributes());

                if (symbol is IAssemblySymbol assemblySymbol)
                {
                    foreach (var module in assemblySymbol.Modules)
                        addMatchingAttributes(ref result, module.GetAttributes());
                }

                return result.AsSpan().ToImmutableArray();
            }
            finally
            {
                result.Dispose();
            }

            void addMatchingAttributes(
                ref ValueListBuilder<AttributeData> result,
                ImmutableArray<AttributeData>? attributes)
            {
                if (!attributes.HasValue)
                    return;

                foreach (var attribute in attributes.Value)
                {
                    if (attribute.ApplicationSyntaxReference?.SyntaxTree == targetSyntaxTree &&
                        attribute.AttributeClass?.ToDisplayString(/*s_metadataDisplayFormat*/) == fullyQualifiedMetadataName)
                    {
                        result.Append(attribute);
                    }
                }
            }
        }
    }
}