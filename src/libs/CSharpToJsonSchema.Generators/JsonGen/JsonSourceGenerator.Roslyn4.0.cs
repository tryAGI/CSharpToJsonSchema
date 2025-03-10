// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Immutable;
using CSharpToJsonSchema.Generators.JsonGen.Base;
using CSharpToJsonSchema.Generators.JsonGen.Helpers;
using CSharpToJsonSchema.Generators.JsonGen.Model;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;
#if !ROSLYN4_4_OR_GREATER
#endif

namespace CSharpToJsonSchema.Generators.JsonGen
{
    /// <summary>
    /// Generates source code to optimize serialization and deserialization with JsonSerializer.
    /// </summary>
    [Generator]
    public sealed partial class JsonSourceGenerator 
    {
        //private const string JsonSerializableAttributeFullName = "CSharpToJsonSchema.Generators.JsonGen.System.Text.Json.JsonSerializableAttribute";
        private const string JsonSerializableAttributeFullName = "CSharpToJsonSchema.GenerateJsonSchemaAttribute";
        private const string FunctionToolAttributeFullName = "CSharpToJsonSchema.FunctionToolAttribute";
#if ROSLYN4_4_OR_GREATER
        public const string SourceGenerationSpecTrackingName = "SourceGenerationSpec";
#endif

         public void Initialize2(IncrementalGeneratorInitializationContext context)
        {
#if LAUNCH_DEBUGGER
            System.Diagnostics.Debugger.Launch();
#endif
            IncrementalValueProvider<KnownTypeSymbols> knownTypeSymbols = context.CompilationProvider
                .Select((compilation, _) => new KnownTypeSymbols(compilation));

            IncrementalValuesProvider<(Model.ContextGenerationSpec?, ImmutableEquatableArray<DiagnosticInfo>)>
                contextGenerationSpecs = IncrementalValueProviderExtensions.Combine(
                        context.CompilationProvider
                            .ForAttributeWithMetadataName<(InterfaceDeclarationSyntax ContextClass, SemanticModel
                                SemanticModel)>(
#if !ROSLYN4_4_OR_GREATER
                                context,
#endif
                                JsonSerializableAttributeFullName,
                                (node, _) => node is InterfaceDeclarationSyntax,
                                (context, _) =>
                                    (ContextClass: (InterfaceDeclarationSyntax)context.TargetNode, context.SemanticModel)),
                        knownTypeSymbols)
                    .Select(static (tuple, cancellationToken) =>
                    {
                        Parser parser = new(tuple.Right);
                        Model.ContextGenerationSpec? contextGenerationSpec =
                            parser.ParseContextGenerationSpec(tuple.Left.ContextClass, tuple.Left.SemanticModel,
                                cancellationToken);
                        ImmutableEquatableArray<DiagnosticInfo> diagnostics =
                            parser.Diagnostics.ToImmutableEquatableArray();
                        return (contextGenerationSpec, diagnostics);
                    })
#if ROSLYN4_4_OR_GREATER
                .WithTrackingName(SourceGenerationSpecTrackingName)
#endif
                ;

            context.RegisterSourceOutput(contextGenerationSpecs, ReportDiagnosticsAndEmitSource);
        }
         
         public void InitializeForFunctionTools(IncrementalGeneratorInitializationContext context)
        {
#if LAUNCH_DEBUGGER
            System.Diagnostics.Debugger.Launch();
#endif
            IncrementalValueProvider<KnownTypeSymbols> knownTypeSymbols = context.CompilationProvider
                .Select((compilation, _) => new KnownTypeSymbols(compilation));

            IncrementalValueProvider<(Model.ContextGenerationSpec?, ImmutableEquatableArray<DiagnosticInfo>)>
                contextGenerationSpecs = IncrementalValueProviderExtensions.Combine(
                        context.CompilationProvider
                            .ForAttributeWithMetadataName<(MethodDeclarationSyntax ContextClass, SemanticModel
                                SemanticModel)>(
#if !ROSLYN4_4_OR_GREATER
                                context,
#endif
                                FunctionToolAttributeFullName,
                                (node, _) => node is MethodDeclarationSyntax,
                                (context, _) =>
                                    (ContextClass: (MethodDeclarationSyntax)context.TargetNode, context.SemanticModel)),
                        knownTypeSymbols)
                    .Collect().Select(static (tuple,CancellationToken) =>
                    {
                        
                        var known = tuple.FirstOrDefault();
                        var knowntype = known.Right;
                        if (knowntype == null && !tuple.Any())
                        {
                            return (null, ImmutableEquatableArray<DiagnosticInfo>.Empty);
                            //knowntype =new KnownTypeSymbols(tuple.First().Left.SemanticModel.Compilation);
                        }
                        Parser parser = new(knowntype);
                        Model.ContextGenerationSpec? contextGenerationSpec =
                            parser.ParseContextGenerationSpec(tuple,CancellationToken);
                        ImmutableEquatableArray<DiagnosticInfo> diagnostics =
                            parser.Diagnostics.ToImmutableEquatableArray();
                        return (contextGenerationSpec, diagnostics);
                    })//.Select(sx=>(sx.contextGenerationSpec,sx.contextGenerationSpec))
#if ROSLYN4_4_OR_GREATER
                .WithTrackingName(SourceGenerationSpecTrackingName)
#endif
                ;

            context.RegisterSourceOutput(contextGenerationSpecs, ReportDiagnosticsAndEmitSource);
        }
         
        public void Initialize(IncrementalGeneratorInitializationContext context)
        {
#if LAUNCH_DEBUGGER
            System.Diagnostics.Debugger.Launch();
#endif
            IncrementalValueProvider<KnownTypeSymbols> knownTypeSymbols = context.CompilationProvider
                .Select((compilation, _) => new KnownTypeSymbols(compilation));

            IncrementalValuesProvider<(Model.ContextGenerationSpec?, ImmutableEquatableArray<DiagnosticInfo>)>
                contextGenerationSpecs = IncrementalValueProviderExtensions.Combine(
                        context.SyntaxProvider
                            .ForAttributeWithMetadataName<(ClassDeclarationSyntax ContextClass, SemanticModel
                                SemanticModel)>(
#if !ROSLYN4_4_OR_GREATER
                                context,
#endif
                                JsonSerializableAttributeFullName,
                                (node, _) => node is ClassDeclarationSyntax,
                                (context, _) =>
                                    (ContextClass: (ClassDeclarationSyntax)context.TargetNode, context.SemanticModel)),
                        knownTypeSymbols)
                    .Select(static (tuple, cancellationToken) =>
                    {
                        Parser parser = new(tuple.Right);
                        Model.ContextGenerationSpec? contextGenerationSpec =
                            parser.ParseContextGenerationSpec(tuple.Left.ContextClass, tuple.Left.SemanticModel,
                                cancellationToken);
                        ImmutableEquatableArray<DiagnosticInfo> diagnostics =
                            parser.Diagnostics.ToImmutableEquatableArray();
                        return (contextGenerationSpec, diagnostics);
                    })
#if ROSLYN4_4_OR_GREATER
                .WithTrackingName(SourceGenerationSpecTrackingName)
#endif
                ;

            context.RegisterSourceOutput(contextGenerationSpecs, ReportDiagnosticsAndEmitSource);
        }

        private void ReportDiagnosticsAndEmitSource(SourceProductionContext sourceProductionContext, (Model.ContextGenerationSpec? ContextGenerationSpec, ImmutableEquatableArray<DiagnosticInfo> Diagnostics) input)
        {
            // // Report any diagnostics ahead of emitting.
            // foreach (DiagnosticInfo diagnostic in input.Diagnostics)
            // {
            //     sourceProductionContext.ReportDiagnostic(diagnostic.CreateDiagnostic());
            // }

            if (input.ContextGenerationSpec is null)
            {
                return;
            }

            OnSourceEmitting?.Invoke(ImmutableArray.Create(input.ContextGenerationSpec));
            Emitter emitter = new(sourceProductionContext);
            emitter.Emit(input.ContextGenerationSpec);
        }

        /// <summary>
        /// Instrumentation helper for unit tests.
        /// </summary>
        public Action<ImmutableArray<ContextGenerationSpec>>? OnSourceEmitting { get; init; }

        private partial class Emitter
        {
            private readonly SourceProductionContext _context;

            public Emitter(SourceProductionContext context)
                => _context = context;

            private partial void AddSource(string hintName, SourceText sourceText)
                => _context.AddSource(hintName, sourceText);
        }
    }
}
