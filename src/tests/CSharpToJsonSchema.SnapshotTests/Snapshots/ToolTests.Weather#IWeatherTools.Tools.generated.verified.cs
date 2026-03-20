//HintName: IWeatherTools.Tools.generated.cs

#nullable enable

namespace CSharpToJsonSchema.IntegrationTests
{
    public static partial class WeatherToolsExtensions
    {
        public static global::System.Collections.Generic.IList<global::CSharpToJsonSchema.Tool> AsTools(this IWeatherTools functions)
        {
            return new global::System.Collections.Generic.List<global::CSharpToJsonSchema.Tool>
            {
                new global::CSharpToJsonSchema.Tool
                {
                    Name = "GetCurrentWeather",
                    Description = "Get the current weather in a given location",
                    Strict = false,
                    Parameters = global::CSharpToJsonSchema.SchemaBuilder.ConvertToSchema(global::CSharpToJsonSchema.IntegrationTests.WeatherToolsExtensionsJsonSerializerContext.Default.GetCurrentWeatherArgs,"{\"mainFunction_Desc\":\"Get the current weather in a given location\"}"),
                },

                new global::CSharpToJsonSchema.Tool
                {
                    Name = "GetCurrentWeatherAsync",
                    Description = "Get the current weather in a given location",
                    Strict = false,
                    Parameters = global::CSharpToJsonSchema.SchemaBuilder.ConvertToSchema(global::CSharpToJsonSchema.IntegrationTests.WeatherToolsExtensionsJsonSerializerContext.Default.GetCurrentWeatherAsyncArgs,"{\"mainFunction_Desc\":\"Get the current weather in a given location\"}"),
                },
            };
        }
    }
}