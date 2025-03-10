namespace CSharpToJsonSchema.Generators.Models;

public readonly record struct InterfaceData(
    string Namespace,
    string Name,
    bool GoogleFunctionTool,
    bool MeaiFunctionTool,
    IReadOnlyCollection<MethodData> Methods);