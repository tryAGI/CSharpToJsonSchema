using System.Text.Json.Serialization;

namespace CSharpToJsonSchema;

[JsonSerializable(typeof(OpenApiSchema))]
[JsonSerializable(typeof(IDictionary<string, OpenApiSchema>))]
[JsonSerializable(typeof(IDictionary<string, string>))]
public partial class OpenApiSchemaJsonContext:JsonSerializerContext
{
    
}