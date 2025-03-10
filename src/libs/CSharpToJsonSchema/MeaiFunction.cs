using System.Collections.ObjectModel;
using System.Text.Json;
using System.Text.Json.Nodes;
using Microsoft.Extensions.AI;

namespace CSharpToJsonSchema;

/// <summary>
/// Represents a function that wraps a tool and provides functionality for executing the tool with specified arguments.
/// </summary>
public partial class MeaiFunction : AIFunction
{
    private readonly Tool _tool;
    private readonly Func<string, CancellationToken, Task<string>> _call;

    private JsonElement _jsonSchema;

    /// <summary>
    /// Gets the JSON schema representing the parameters of the tool.
    /// </summary>
    public override JsonElement JsonSchema => _jsonSchema;

    /// <summary>
    /// Gets the name of the tool.
    /// </summary>
    public override string Name => _tool.Name;

    /// <summary>
    /// Gets the description of the tool.
    /// </summary>
    public override string Description => _tool.Description;
   
    /// <summary>
    /// Gets additional properties associated with the tool.
    /// </summary>
    public override IReadOnlyDictionary<string, object?> AdditionalProperties => new ReadOnlyDictionary<string, object?>(_tool.AdditionalProperties);

    /// <summary>
    /// Initializes a new instance of the <see cref="MeaiFunction"/> class.
    /// </summary>
    /// <param name="tool">The tool associated with this function.</param>
    /// <param name="call">The function to execute the tool with input arguments.</param>
    public MeaiFunction(Tool tool, Func<string, CancellationToken, Task<string>> call)
    {
        this._tool = tool;
        this._call = call;

        _jsonSchema = JsonSerializer.Deserialize<JsonElement>(
            JsonSerializer.Serialize(tool.Parameters, OpenApiSchemaJsonContext.Default.OpenApiSchema),
            OpenApiSchemaJsonContext.Default.JsonElement);

        if (tool.Strict == true)
        {
            tool.AdditionalProperties.Add("Strict", true);
        }
    }

    /// <summary>
    /// Invokes the tool with the given arguments asynchronously.
    /// </summary>
    /// <param name="arguments">The arguments to pass to the tool.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation, if needed.</param>
    /// <returns>The result of the tool's execution as a deserialized object.</returns>
    protected override async Task<object?> InvokeCoreAsync(IEnumerable<KeyValuePair<string, object?>> arguments,
        CancellationToken cancellationToken)
    {
        var json = GetArgsString(arguments);

        var call = await _call(json, cancellationToken);

        return JsonSerializer.Deserialize(call, OpenApiSchemaJsonContext.Default.JsonElement);
    }

    /// <summary>
    /// Converts a collection of arguments into a JSON string.
    /// </summary>
    /// <param name="arguments">The arguments to be converted into a JSON string.</param>
    /// <returns>A JSON string representation of the arguments.</returns>
    private string GetArgsString(IEnumerable<KeyValuePair<string, object?>> arguments)
    {
        var jsonObject = new JsonObject();

        foreach (var args in arguments)
        {
            if (args.Value is JsonElement element)
            {
                if (element.ValueKind == JsonValueKind.Array)
                    jsonObject[args.Key] = JsonArray.Create(element);
                else if (element.ValueKind == JsonValueKind.Object)
                    jsonObject[args.Key] = JsonObject.Create(element);
            }
            else if (args.Value is JsonNode node)
            {
            }
        }

        return jsonObject.ToJsonString();
    }
}