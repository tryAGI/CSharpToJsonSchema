using CSharpToJsonSchema.Generators;
using H.Generators.Tests.Extensions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace CSharpToJsonSchema.SnapshotTests;

public static class TestHelper
{
    public static async Task CheckSourceAsync(
        this VerifyBase verifier,
        string source,
        CancellationToken cancellationToken = default)
    {
        var referenceAssemblies = LatestReferenceAssemblies.Net90;
        var references = await referenceAssemblies.ResolveAsync(null, cancellationToken);
        references = references
            .Add(MetadataReference.CreateFromFile(typeof(CSharpToJsonSchema.GenerateJsonSchemaAttribute).Assembly.Location));

        var compilation = (Compilation)CSharpCompilation.Create(
            assemblyName: "Tests",
            syntaxTrees: new[]
            {
                CSharpSyntaxTree.ParseText(source, cancellationToken: cancellationToken),
            },
            references: references,
            options: new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));
        var driver = CSharpGeneratorDriver
            .Create(new JsonSchemaGenerator())
            .RunGeneratorsAndUpdateCompilation(compilation, out compilation, out _, cancellationToken);
        var diagnostics = compilation.GetDiagnostics(cancellationToken);

        await Task.WhenAll(
            verifier
                .Verify(diagnostics)
                .AutoVerify()
                .UseDirectory("Snapshots")
                .UseTextForParameters("Diagnostics"),
                
            verifier
                .Verify(driver)
                .AutoVerify()
                .UseDirectory("Snapshots"));
    }
}