using System.Text.Json.Serialization;

namespace CSharpToJsonSchema;

[JsonSerializable(typeof(OpenApiSchema))]
[JsonSerializable(typeof(IDictionary<string, OpenApiSchema>))]
[JsonSerializable(typeof(IDictionary<string, string>))]
[JsonSerializable(typeof(Tool))]
[JsonSerializable(typeof(List<Tool>))]
[JsonSourceGenerationOptions(NumberHandling = JsonNumberHandling.Strict, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull)]
public partial class OpenApiSchemaJsonContext:JsonSerializerContext
{
    
}