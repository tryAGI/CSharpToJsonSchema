//HintName: IWeatherStrictTools.Tools.generated.cs

#nullable enable

namespace CSharpToJsonSchema.IntegrationTests
{
    public static partial class WeatherStrictToolsExtensions
    {
        public static global::System.Collections.Generic.IList<global::CSharpToJsonSchema.Tool> AsTools(this IWeatherStrictTools functions)
        {
            return new global::System.Collections.Generic.List<global::CSharpToJsonSchema.Tool>
            {
                new global::CSharpToJsonSchema.Tool
                {
                    Name = "GetCurrentWeather2",
                    Description = "Get the current weather in a given location",
                    Strict = true,
                    Parameters = global::CSharpToJsonSchema.SchemaBuilder.ConvertToSchema(global::CSharpToJsonSchema.IntegrationTests.WeatherStrictToolsExtensionsJsonSerializerContext.Default.GetCurrentWeather2Args,"{\"mainFunction_Desc\":\"Get the current weather in a given location\"}"),
                },

                new global::CSharpToJsonSchema.Tool
                {
                    Name = "GetCurrentWeatherAsync2",
                    Description = "Get the current weather in a given location",
                    Strict = true,
                    Parameters = global::CSharpToJsonSchema.SchemaBuilder.ConvertToSchema(global::CSharpToJsonSchema.IntegrationTests.WeatherStrictToolsExtensionsJsonSerializerContext.Default.GetCurrentWeatherAsync2Args,"{\"mainFunction_Desc\":\"Get the current weather in a given location\"}"),
                },
            };
        }
    }
}