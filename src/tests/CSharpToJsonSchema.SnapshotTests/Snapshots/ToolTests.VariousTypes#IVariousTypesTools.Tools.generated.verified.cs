//HintName: IVariousTypesTools.Tools.generated.cs

#nullable enable

namespace CSharpToJsonSchema.IntegrationTests
{
    public static partial class VariousTypesToolsExtensions
    {
        public static global::System.Collections.Generic.IList<global::CSharpToJsonSchema.Tool> AsTools(this IVariousTypesTools functions)
        {
            return new global::System.Collections.Generic.List<global::CSharpToJsonSchema.Tool>
            {
                new global::CSharpToJsonSchema.Tool
                {
                    Name = "GetCurrentWeather3",
                    Description = "Get the current weather in a given location",
                    Strict = false,
                    Parameters = global::CSharpToJsonSchema.SchemaBuilder.ConvertToSchema(global::CSharpToJsonSchema.IntegrationTests.VariousTypesToolsExtensionsJsonSerializerContext.Default.GetCurrentWeather3Args,"{\"mainFunction_Desc\":\"Get the current weather in a given location\"}"),
                },

                new global::CSharpToJsonSchema.Tool
                {
                    Name = "SetValue",
                    Description = "Sets the value",
                    Strict = false,
                    Parameters = global::CSharpToJsonSchema.SchemaBuilder.ConvertToSchema(global::CSharpToJsonSchema.IntegrationTests.VariousTypesToolsExtensionsJsonSerializerContext.Default.SetValueArgs,"{\"mainFunction_Desc\":\"Sets the value\"}"),
                },

                new global::CSharpToJsonSchema.Tool
                {
                    Name = "GetValue",
                    Description = "Gets the value",
                    Strict = false,
                    Parameters = global::CSharpToJsonSchema.SchemaBuilder.ConvertToSchema(global::CSharpToJsonSchema.IntegrationTests.VariousTypesToolsExtensionsJsonSerializerContext.Default.GetValueArgs,"{\"mainFunction_Desc\":\"Gets the value\"}"),
                },

                new global::CSharpToJsonSchema.Tool
                {
                    Name = "SetValueAsync",
                    Description = "Sets the value",
                    Strict = false,
                    Parameters = global::CSharpToJsonSchema.SchemaBuilder.ConvertToSchema(global::CSharpToJsonSchema.IntegrationTests.VariousTypesToolsExtensionsJsonSerializerContext.Default.SetValueAsyncArgs,"{\"mainFunction_Desc\":\"Sets the value\"}"),
                },

                new global::CSharpToJsonSchema.Tool
                {
                    Name = "GetValueAsync",
                    Description = "Gets the value",
                    Strict = false,
                    Parameters = global::CSharpToJsonSchema.SchemaBuilder.ConvertToSchema(global::CSharpToJsonSchema.IntegrationTests.VariousTypesToolsExtensionsJsonSerializerContext.Default.GetValueAsyncArgs,"{\"mainFunction_Desc\":\"Gets the value\"}"),
                },
            };
        }
    }
}