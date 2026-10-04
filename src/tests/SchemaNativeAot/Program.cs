using System.Text.Json;
using System.Text.Json.Serialization;
using CSharpToJsonSchema;

if (JsonSerializer.IsReflectionEnabledByDefault)
{
    throw new InvalidOperationException("This regression requires reflection serialization to be disabled.");
}

foreach (var strict in new[] { false, true })
{
    var schema = TypeToSchemaHelpers.AsJsonSchema(SchemaContext.Default.Request, strict);
    var properties = schema.Properties ?? throw new InvalidOperationException("Object properties are missing.");
    var required = schema.Required ?? throw new InvalidOperationException("Required properties are missing.");
    var details = properties["Details"].Properties ?? throw new InvalidOperationException("Nested properties are missing.");
    var items = properties["Values"].Items ?? throw new InvalidOperationException("Array items are missing.");
    var modes = properties["Mode"].Enum ?? throw new InvalidOperationException("Enum names are missing.");
    if (schema.Type != "object" ||
        !required.SequenceEqual(new[] { "name", "Details", "Values", "Mode" }) ||
        properties["name"].Type != "string" ||
        details["Count"].Type != "integer" ||
        details["Count"].Format != (strict ? null : "int32") ||
        items.Type != "number" ||
        items.Format != (strict ? null : "double") ||
        !modes.SequenceEqual(new[] { "Off", "On" }))
    {
        throw new InvalidOperationException("Source-generated schema shape differs from the expected contract.");
    }

    var json = JsonSerializer.Serialize(schema, SchemaContext.Default.OpenApiSchema);
    using var document = JsonDocument.Parse(json);
    if (document.RootElement.GetProperty("properties").GetProperty("name").GetProperty("type").GetString() != "string")
    {
        throw new InvalidOperationException("Schema serialization did not retain the source-generated property name.");
    }
}

return 0;

internal sealed class Request
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;
    public Details Details { get; set; } = new();
    public double[] Values { get; set; } = [];
    public Mode Mode { get; set; }
}

internal sealed class Details
{
    public int Count { get; set; }
}

internal enum Mode { Off, On }

[JsonSourceGenerationOptions(Converters = [typeof(JsonStringEnumConverter<Mode>)])]
[JsonSerializable(typeof(Request))]
[JsonSerializable(typeof(OpenApiSchema))]
internal sealed partial class SchemaContext : JsonSerializerContext;
