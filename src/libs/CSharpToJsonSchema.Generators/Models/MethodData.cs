namespace CSharpToJsonSchema.Generators.Models;

public readonly record struct MethodData(
    string Name,
    string Description,
    bool IsAsync,
    bool IsVoid,
    bool IsStrict,
    OpenApiSchema Parameters);