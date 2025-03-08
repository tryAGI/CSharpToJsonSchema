using Microsoft.CodeAnalysis;

namespace CSharpToJsonSchema.Generators.Models;

public sealed class ClassData
{
    public INamedTypeSymbol ClassSymbol { get; }
        
    public ClassData(INamedTypeSymbol classSymbol)
    {
        ClassSymbol = classSymbol;
    }

    /// <summary>
    /// The name of the class where JSON type info will be generated.
    /// </summary>
    public string Name => ClassSymbol.Name;

    /// <summary>
    /// The namespace of the class.
    /// </summary>
    public string Namespace => ClassSymbol.ContainingNamespace.IsGlobalNamespace 
        ? string.Empty 
        : ClassSymbol.ContainingNamespace.ToString();
}
