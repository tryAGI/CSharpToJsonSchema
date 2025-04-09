using System.Collections.ObjectModel;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
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
    
    private JsonSerializerOptions? _options;
   
    /// <summary>
    /// Gets additional properties associated with the tool.
    /// </summary>
    public override IReadOnlyDictionary<string, object?> AdditionalProperties => new ReadOnlyDictionary<string, object?>(_tool.AdditionalProperties);

    /// <summary>
    /// Initializes a new instance of the <see cref="MeaiFunction"/> class.
    /// </summary>
    /// <param name="tool">The tool associated with this function.</param>
    /// <param name="call">The function to execute the tool with input arguments.</param>
    public MeaiFunction(Tool tool, Func<string, CancellationToken, Task<string>> call, JsonSerializerOptions? options = null)
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

        _options = options;
    }

    
    
    private JsonSerializerOptions InitializeReflectionOptions()
    {
     #pragma warning disable IL2026, IL3050 // Reflection is used only when enabled
        if(!JsonSerializer.IsReflectionEnabledByDefault)
            throw new InvalidOperationException("JsonSerializer.IsReflectionEnabledByDefault is false, please pass in a JsonSerializerOptions instance.");
       
        _options = new JsonSerializerOptions()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            PropertyNameCaseInsensitive = true,
            Converters = { new JsonStringEnumConverter() },
            TypeInfoResolver = new DefaultJsonTypeInfoResolver()
        };
        return _options;
    #pragma warning restore IL2026, IL3050 // Reflection is used only when enabled
    }


   
    /// <summary>
    /// Invokes the tool with the given arguments asynchronously.
    /// </summary>
    /// <param name="arguments">The arguments to pass to the tool.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation, if needed.</param>
    /// <returns>The result of the tool's execution as a deserialized object.</returns>
    protected override async ValueTask<object?> InvokeCoreAsync(AIFunctionArguments arguments,
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
    protected virtual string GetArgsString(IEnumerable<KeyValuePair<string, object?>> arguments)
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
                else
                    jsonObject[args.Key] = JsonValue.Create(element);
            }
            else if (args.Value is JsonNode node)
            {
                jsonObject[args.Key] = node;
            }
            else if (args.Value is JsonValue val)
            {
                jsonObject[args.Key] = val;
            }
            else if( args.Value is JsonObject obj)
            {
                jsonObject[args.Key] = obj;
            }
            else if (args.Value is JsonArray arr)
            {
                jsonObject[args.Key] = arr;
            }
            else
            {
                 var type = args.Value?.GetType();
                // if(type.IsPrimitive)
                // {
                //     jsonObject[args.Key] = JsonValue.Create(args.Value);
                // }
                // else
                // {
                    if (_options == null)
                    {  
                        #pragma warning disable IL2026, IL3050 // Reflection is used only when enabled
                        //Fallback to Reflection
                        //This will break the AOT, Hoping for the best, IChatClient implementation only send JSON classes
                        //Or Developer is using the code generator
                        _options = InitializeReflectionOptions();
                        #pragma warning disable IL2026, IL3050 // Reflection is used only when enabled
                    }
                    var typeInfo = _options.GetTypeInfo(type);

                    var str = JsonSerializer.Serialize(args.Value, typeInfo);
                    jsonObject[args.Key] = JsonNode.Parse(str);
                //}
            }
        }

        return jsonObject.ToJsonString();
    }
}