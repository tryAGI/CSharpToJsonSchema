using System.Text.Json;
using System.Text.Json.Nodes;
using Microsoft.Extensions.AI;

namespace CSharpToJsonSchema;

public partial class MeaiFunction : AIFunction
{
    private readonly Tool _tool;
    private readonly Func<string, CancellationToken, Task<string>> _call;
    
    private JsonElement _jsonSchema;
    public override JsonElement JsonSchema => _jsonSchema;
    public override string Name => _tool.Name;
    public override string Description => _tool.Description;
    
    public MeaiFunction(Tool tool, Func<string, CancellationToken, Task<string>> call)
    {
        this._tool = tool;
        this._call = call;
        
        _jsonSchema = JsonSerializer.Deserialize<JsonElement>(JsonSerializer.Serialize(tool.Parameters, OpenApiSchemaJsonContext.Default.OpenApiSchema),OpenApiSchemaJsonContext.Default.JsonElement);
    }
    protected override async Task<object?> InvokeCoreAsync(IEnumerable<KeyValuePair<string, object?>> arguments,
        CancellationToken cancellationToken)
    {
        try
        {
            var json = GetArgsString(arguments);

            var call = await _call(json, cancellationToken);
            
            return JsonSerializer.Deserialize(call, OpenApiSchemaJsonContext.Default.JsonElement);
        }catch(Exception e)
        {
            return e.Message;
        }
    }

    private string GetArgsString(IEnumerable<KeyValuePair<string, object?>> arguments)
    {
        var jsonObject = new JsonObject();

        foreach (var args in arguments)
        {
            if (args.Value is JsonElement element)
            {
                if(element.ValueKind == JsonValueKind.Array)
                    jsonObject[args.Key] = JsonArray.Create(element);
                else if(element.ValueKind == JsonValueKind.Object)
                    jsonObject[args.Key] = JsonObject.Create(element);
            }
            else if (args.Value is JsonNode node)
            {
                jsonObject[args.Key] = node;
            }
        }

        return jsonObject.ToJsonString();
    }
}