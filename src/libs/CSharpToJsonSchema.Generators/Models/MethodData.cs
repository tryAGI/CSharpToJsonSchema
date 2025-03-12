using Microsoft.CodeAnalysis;

namespace CSharpToJsonSchema.Generators.Models;

public readonly record struct MethodData(
    string Name,
    string Description,
    bool IsAsync,
    bool IsVoid,
    bool IsStrict,
    IParameterSymbol[] Parameters,
    ITypeSymbol ReturnType);
    
public readonly record struct PropertyMetadata(string Name, string Description, bool IsRequired);