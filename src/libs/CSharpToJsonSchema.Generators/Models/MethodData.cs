using CSharpToJsonSchema.Generators.Core;

namespace H.Generators;

public readonly record struct MethodData(
    string Name,
    string Description,
    bool IsAsync,
    bool IsVoid,
    bool IsStrict,
    OpenApiSchema Parameters);