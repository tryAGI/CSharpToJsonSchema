using System.Collections.Immutable;
using Microsoft.CodeAnalysis;

namespace CSharpToJsonSchema.Generators.JsonGen.Base;

internal readonly struct GeneratorAttributeSyntaxContext
{
    /// <summary>
    /// The syntax node the attribute is attached to.  For example, with <c>[CLSCompliant] class C { }</c> this would
    /// the class declaration node.
    /// </summary>
    public SyntaxNode TargetNode { get; }

    /// <summary>
    /// The symbol that the attribute is attached to.  For example, with <c>[CLSCompliant] class C { }</c> this would be
    /// the <see cref="INamedTypeSymbol"/> for <c>"C"</c>.
    /// </summary>
    public ISymbol TargetSymbol { get; }

    /// <summary>
    /// Semantic model for the file that <see cref="TargetNode"/> is contained within.
    /// </summary>
    public SemanticModel SemanticModel { get; }

    /// <summary>
    /// <see cref="AttributeData"/>s for any matching attributes on <see cref="TargetSymbol"/>.  Always non-empty.  All
    /// these attributes will have an <see cref="AttributeData.AttributeClass"/> whose fully qualified name metadata
    /// name matches the name requested in <see cref="SyntaxValueProvider.ForAttributeWithMetadataName{T}"/>.
    /// <para>
    /// To get the entire list of attributes, use <see cref="ISymbol.GetAttributes"/> on <see cref="TargetSymbol"/>.
    /// </para>
    /// </summary>
    public ImmutableArray<AttributeData> Attributes { get; }

    
    internal GeneratorAttributeSyntaxContext(
        SyntaxNode targetNode,
        ISymbol targetSymbol,
        SemanticModel semanticModel,
        ImmutableArray<AttributeData> attributes)
    {
        TargetNode = targetNode;
        TargetSymbol = targetSymbol;
        SemanticModel = semanticModel;
        Attributes = attributes;
    }
}