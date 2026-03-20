using System.Text.Json.Serialization;

namespace CSharpToJsonSchema;

/// <summary>
/// Source-generated JSON serializer context for OpenAPI schema types.
/// </summary>
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