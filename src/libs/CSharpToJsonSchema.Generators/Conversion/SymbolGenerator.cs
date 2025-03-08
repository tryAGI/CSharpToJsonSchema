using CSharpToJsonSchema.Generators.JsonGen.Helpers;
using CSharpToJsonSchema.Generators.Models;
using H.Generators.Extensions;

namespace CSharpToJsonSchema.Generators.Conversion;

using System;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

public static class SymbolGenerator
{
    public static ITypeSymbol? GenerateParameterBasedClassSymbol(
        string rootNamespace,
        IMethodSymbol methodSymbol,
        Compilation originalCompilation)
    {
        
        
        // Example: we create a class name
        var className = $"{methodSymbol.Name}Args";
        
        // Build property declarations based on method parameters
        var properties = methodSymbol
            .Parameters
            .Where(s=>s.Type.Name != "CancellationToken")
            .Select(p =>
            {
               
                var propertyTypeName = p.Type.ToDisplayString(); // or another approach
                var decleration =  SyntaxFactory.PropertyDeclaration(
                         SyntaxFactory.ParseTypeName(propertyTypeName),
                         p.Name.ToPropertyName())
                    .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
                    .WithAccessorList(
                        SyntaxFactory.AccessorList(
                            SyntaxFactory.List(new[]
                            {
                                SyntaxFactory.AccessorDeclaration(SyntaxKind.GetAccessorDeclaration)
                                    .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken)),
                                SyntaxFactory.AccessorDeclaration(SyntaxKind.SetAccessorDeclaration)
                                    .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken))
                            })
                        )
                    );
                if (p.Type.TypeKind == TypeKind.Enum)
                {
                    //decleration = decleration.AddAttributeLists(AttributeList(SingletonSeparatedList(GetConverter(propertyTypeName))));
                }
                return decleration;
            })
            .ToArray();

        // Build a class declaration
        var classDecl = SyntaxFactory.ClassDeclaration(className)
            .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
            .AddMembers(properties);

        // We create a compilation unit holding our new class
        
        

        var namespaceName =rootNamespace; // choose your own
        var ns = SyntaxFactory.NamespaceDeclaration(SyntaxFactory.IdentifierName(namespaceName))
            .AddMembers(classDecl);

        var compilationUnit = SyntaxFactory.CompilationUnit()
            .AddMembers(ns) // if ns is a NamespaceDeclarationSyntax
            .NormalizeWhitespace();
        
        var parseOptions = CSharpParseOptions.Default.WithLanguageVersion(originalCompilation.GetLanguageVersion()?? LanguageVersion.Default);
        var syntaxTree =CSharpSyntaxTree.Create(compilationUnit,parseOptions);
        //CSharpSyntaxTree.Create(ns.NormalizeWhitespace());

        // Now we need to add this syntax tree to a new or existing compilation
        var assemblyName = "TemporaryAssembly";
        var compilation = originalCompilation
            .AddSyntaxTrees(syntaxTree);
            //.WithAssemblyName(assemblyName);
        

        // Get the semantic model for our newly added syntax tree
        var semanticModel = compilation.GetSemanticModel(syntaxTree);

        // Find the class syntax node in the syntax tree
        var classNode = syntaxTree.GetRoot().DescendantNodes()
            .OfType<ClassDeclarationSyntax>()
            .FirstOrDefault();

        if (classNode == null) return null;

        // Retrieve the ITypeSymbol from the semantic model
        var classSymbol = semanticModel.GetDeclaredSymbol(classNode) as ITypeSymbol;
        return classSymbol;
    }

    public static AttributeSyntax GetConverter(string propertyType)
    {
        // 1. Create the attribute: [JsonConverter(typeof(StringEnumJsonConverter<T>))]
        var converterAttribute =
            Attribute(
                    IdentifierName("System.Text.Json.Serialization.JsonConverterAttribute")
                )
                .WithArgumentList(
                    AttributeArgumentList(
                        SingletonSeparatedList(
                            AttributeArgument(
                                TypeOfExpression(
                                    GenericName(
                                            Identifier("System.Text.Json.Serialization.JsonStringEnumConverter")
                                        )
                                        .WithTypeArgumentList(
                                            TypeArgumentList(
                                                SingletonSeparatedList<TypeSyntax>(
                                                    IdentifierName(propertyType) 
                                                )
                                            )
                                        )
                                )
                            )
                        )
                    )
                );
        return converterAttribute;

    }
}