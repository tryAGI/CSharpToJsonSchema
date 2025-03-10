using System.Text.Json.Serialization;

namespace CSharpToJsonSchema;

[JsonSerializable(typeof(OpenApiSchema))]
[JsonSerializable(typeof(IDictionary<string, OpenApiSchema>))]
[JsonSerializable(typeof(IDictionary<string, string>))]
[JsonSerializable(typeof(Tool))]
[JsonSerializable(typeof(List<Tool>))]
[JsonSerializable(typeof(JsonElement))]
[JsonSourceGenerationOptions(NumberHandling = JsonNumberHandling.Strict, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,WriteIndented = false)]
public partial class OpenApiSchemaJsonContext:JsonSerializerContext
{
    
}