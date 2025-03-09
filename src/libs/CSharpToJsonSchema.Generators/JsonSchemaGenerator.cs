using CSharpToJsonSchema.Generators.Conversion;
using CSharpToJsonSchema.Generators.JsonGen;
using H.Generators;
using H.Generators.Extensions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using CSharpToJsonSchema.Generators.Models;
using Microsoft.CodeAnalysis.Text;

namespace CSharpToJsonSchema.Generators;

[Generator]
public class JsonSchemaGenerator : IIncrementalGenerator
{
    #region Constants

    public const string Name = nameof(JsonSchemaGenerator);
    public const string Id = "OATG";

    #endregion

    #region Methods

    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        //Process Interfaces
        ProcessInterfaces(context);
        
        //Process Methods
       // ProcessMethods(context);
    }

    private void ProcessMethods(IncrementalGeneratorInitializationContext context)
    {
        var attributes =
            context.SyntaxProvider
                .ForAttributeWithMetadataNameMethodSyntax("CSharpToJsonSchema.FunctionToolAttribute")
                .SelectManyAllAttributesOfCurrentMethodSyntax()
                .SelectAndReportExceptions(PrepareMethodData, context, Id);

        attributes
            .SelectAndReportExceptions(AsFunctionTools, context, Id)
            .AddSource(context);
        
        // attributes
        //     .SelectAndReportExceptions(AsCalls, context, Id)
        //     .AddSource(context);
        
        // var generator = new JsonSourceGenerator();
        // generator.Initialize2(context);
    }

    private void ProcessInterfaces(IncrementalGeneratorInitializationContext context)
    {
        var attributes =
            context.SyntaxProvider
                .ForAttributeWithMetadataName("CSharpToJsonSchema.GenerateJsonSchemaAttribute")
                .SelectManyAllAttributesOfCurrentInterfaceSyntax()
                .SelectAndReportExceptions(PrepareData, context, Id);

        attributes
            .SelectAndReportExceptions(AsTools, context, Id)
            .AddSource(context);
        
        attributes
            .SelectAndReportExceptions(AsCalls, context, Id)
            .AddSource(context);
        
        var generator = new JsonSourceGenerator();
        generator.Initialize2(context);
    }


    private static InterfaceData PrepareData(
        (SemanticModel SemanticModel, AttributeData AttributeData, InterfaceDeclarationSyntax InterfaceSyntax, INamedTypeSymbol InterfaceSymbol) tuple)
    {
        var (_, attributeData, _, interfaceSymbol) = tuple;

        return interfaceSymbol.PrepareData(attributeData);
    }
    
    private static InterfaceData PrepareMethodData(
        (SemanticModel SemanticModel, AttributeData AttributeData, MethodDeclarationSyntax InterfaceSyntax, IMethodSymbol InterfaceSymbol) tuple)
    {
        var (_, attributeData, _, interfaceSymbol) = tuple;

        return interfaceSymbol.PrepareMethodData(attributeData);
    }

    private static FileWithName AsTools(InterfaceData @interface)
    {
        return new FileWithName(
            Name: $"{@interface.Name}.Tools.generated.cs",
            Text: Sources.GenerateClientImplementation(@interface));
    }
    private static FileWithName AsFunctionTools(InterfaceData @interface)
    {
        return new FileWithName(
            Name: $"{@interface.Name}.FunctionTools.generated.cs",
            Text: Sources.GenerateFunctionToolClientImplementation(@interface));
    }

    private static FileWithName AsCalls(InterfaceData @interface)
    {
        return new FileWithName(
            Name: $"{@interface.Name}.Calls.generated.cs",
            Text: Sources.GenerateCalls(@interface));
    }
    
   

    public static (string hintName, SourceText sourceText) AsCalls2(InterfaceData @interface)
    {
        return ($"{@interface.Name}.Calls.generated.cs", SourceText.From(Sources.GenerateCalls(@interface)));
    }


    #endregion
}