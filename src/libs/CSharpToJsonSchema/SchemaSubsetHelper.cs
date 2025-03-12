using System.ComponentModel;
using System.Reflection;
using System.Text.Json.Nodes;
using System.Text.Json.Schema;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;

namespace CSharpToJsonSchema;

public static class SchemaBuilder
{
   
    public static OpenApiSchema ConvertToSchema(JsonTypeInfo type, string descriptionString)
    {
        var typeInfo = type;

        var dics = JsonSerializer.Deserialize(descriptionString,
            OpenApiSchemaJsonContext.Default.IDictionaryStringString);
        List<string> required = new List<string>();
        var x = typeInfo.GetJsonSchemaAsNode(
            exporterOptions: new JsonSchemaExporterOptions()
            {
                TransformSchemaNode = (context, schema) =>
                {
                    if (context.TypeInfo.Type.IsEnum)
                    {
                        schema["type"] = "string";
                    }
                
                    ExtractDescription(context, schema, dics);
                    if (context.PropertyInfo == null)
                        return schema;
               
                    return schema;
                },
            });
        
        var schema = JsonSerializer.Deserialize(x.ToJsonString(), OpenApiSchemaJsonContext.Default.OpenApiSchema);

        foreach (var re in schema.Properties)
        {
            required.Add(re.Key);
        }
       
        var mainDescription = schema.Description ?? (dics.TryGetValue("mainFunction_Desc", out var desc) ? desc : "");
        return new OpenApiSchema()
        {
            Description = mainDescription,
            Properties = schema.Properties,
            Required = required,
            Type = "object"
        };
    }
    
    private static void ExtractDescription(JsonSchemaExporterContext context, JsonNode schema, IDictionary<string, string> dics)
    {
        // Determine if a type or property and extract the relevant attribute provider.
        ICustomAttributeProvider? attributeProvider = context.PropertyInfo is not null
            ? context.PropertyInfo.AttributeProvider
            : context.TypeInfo.Type;

        // Look up any description attributes.
        DescriptionAttribute? descriptionAttr = attributeProvider?
            .GetCustomAttributes(inherit: true)
            .Select(attr => attr as DescriptionAttribute)
            .FirstOrDefault(attr => attr is not null);

        var description = descriptionAttr?.Description;
        if (string.IsNullOrEmpty(description))
        {
            if (context.PropertyInfo is null)
            {
                var propertyName = ToCamelCase(context.TypeInfo.Type.Name);
                dics.TryGetValue(propertyName, out description);
            }
        }

        FixType(schema);
        
        // Apply description attribute to the generated schema.
        if (description is not null)
        {
            if (schema is not JsonObject jObj)
            {
                // Handle the case where the schema is a Boolean.
                JsonValueKind valueKind = schema.GetValueKind();
                
                schema = jObj = new JsonObject();
                if (valueKind is JsonValueKind.False)
                {
                    jObj.Add("not", true);
                }
            }
            
            jObj.Insert(0, "description", description);
        }
    }

    private static void FixType(JsonNode schema)
    {
        // If "type" is an array, remove "null" and collapse if it leaves only one type
        var typeValue = schema["type"];
        if (typeValue!= null && typeValue is JsonArray array)
        {
            if (array.Count == 2)
            {
                var notNullTypes = array.Where(x => x is not null && x.GetValue<string>() != "null").ToList();
                if (notNullTypes.Count == 1)
                {
                    schema["type"] = notNullTypes[0]!.GetValue<string>();
                    schema["nullable"] = true;
                }
                else
                {
                    throw new InvalidOperationException(
                        $"LLM's API for strucutured output requires every property to have one defined type, not multiple options. Path: {schema.GetPath()} Schema: {schema.ToJsonString()}");
                }
            }
            else if (array.Count > 2)
            {
                throw new InvalidOperationException(
                    $"LLM's API for strucutured output requires every property to have one defined type, not multiple options. Path: {schema.GetPath()} Schema: {schema.ToJsonString()}");
            }
        }
    }
    public static string ToCamelCase(string str)
    {
        if (!string.IsNullOrEmpty(str) && str.Length > 1)
        {
            return char.ToLowerInvariant(str[0]) + str.Substring(1);
        }

        return str.ToLowerInvariant();
    }
}