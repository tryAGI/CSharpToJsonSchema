//HintName: IWeatherTools.Calls.generated.cs
#nullable enable

namespace CSharpToJsonSchema.IntegrationTests
{
    public class GetCurrentWeatherArgs
    {
         public string Location { get; set; } = string.Empty;
         public global::CSharpToJsonSchema.IntegrationTests.Unit Unit { get; set; }
    }

    public class GetCurrentWeatherAsyncArgs
    {
         public string Location { get; set; } = string.Empty;
         public global::CSharpToJsonSchema.IntegrationTests.Unit Unit { get; set; }
    }

    public static partial class WeatherToolsExtensions
    {
        public static global::System.Collections.Generic.IReadOnlyDictionary<string, global::System.Func<string, global::System.Threading.CancellationToken, global::System.Threading.Tasks.Task<string>>> AsCalls(this IWeatherTools service)
        {
            return new global::System.Collections.Generic.Dictionary<string, global::System.Func<string, global::System.Threading.CancellationToken, global::System.Threading.Tasks.Task<string>>>
            {
                ["GetCurrentWeather"] = (json, _) =>
                {
                    return global::System.Threading.Tasks.Task.FromResult(service.CallGetCurrentWeather(json));
                },
 
                ["GetCurrentWeatherAsync"] = async (json, cancellationToken) =>
                {
                    return await service.CallGetCurrentWeatherAsync(json, cancellationToken);
                },
 
            };
        }

        public static GetCurrentWeatherArgs AsGetCurrentWeatherArgs(
            this IWeatherTools functions,
            string json)
        {
            #if NET6_0_OR_GREATER
            if(global::System.Text.Json.JsonSerializer.IsReflectionEnabledByDefault)
            {
                #pragma disable warning IL2026, IL3050
                return global::System.Text.Json.JsonSerializer.Deserialize<GetCurrentWeatherArgs>(json, new global::System.Text.Json.JsonSerializerOptions
                {
                    PropertyNamingPolicy = global::System.Text.Json.JsonNamingPolicy.CamelCase,
                    Converters = {{ new global::System.Text.Json.Serialization.JsonStringEnumConverter(global::System.Text.Json.JsonNamingPolicy.CamelCase) }}
                }) ??
                throw new global::System.InvalidOperationException("Could not deserialize JSON.");
                #pragma restore warning IL2026, IL3050
            }
            else
            {
                return global::System.Text.Json.JsonSerializer.Deserialize(json, global::CSharpToJsonSchema.IntegrationTests.WeatherToolsExtensionsJsonSerializerContext.Default.GetCurrentWeatherArgs) ??
                throw new global::System.InvalidOperationException("Could not deserialize JSON.");
            }
            #else
            return
                global::System.Text.Json.JsonSerializer.Deserialize<GetCurrentWeatherArgs>(json, new global::System.Text.Json.JsonSerializerOptions
                {
                    PropertyNamingPolicy = global::System.Text.Json.JsonNamingPolicy.CamelCase,
                    Converters = {{ new global::System.Text.Json.Serialization.JsonStringEnumConverter(global::System.Text.Json.JsonNamingPolicy.CamelCase) }}
                }) ??
                throw new global::System.InvalidOperationException("Could not deserialize JSON.");
            #endif
        }

        public static GetCurrentWeatherAsyncArgs AsGetCurrentWeatherAsyncArgs(
            this IWeatherTools functions,
            string json)
        {
            #if NET6_0_OR_GREATER
            if(global::System.Text.Json.JsonSerializer.IsReflectionEnabledByDefault)
            {
                #pragma disable warning IL2026, IL3050
                return global::System.Text.Json.JsonSerializer.Deserialize<GetCurrentWeatherAsyncArgs>(json, new global::System.Text.Json.JsonSerializerOptions
                {
                    PropertyNamingPolicy = global::System.Text.Json.JsonNamingPolicy.CamelCase,
                    Converters = {{ new global::System.Text.Json.Serialization.JsonStringEnumConverter(global::System.Text.Json.JsonNamingPolicy.CamelCase) }}
                }) ??
                throw new global::System.InvalidOperationException("Could not deserialize JSON.");
                #pragma restore warning IL2026, IL3050
            }
            else
            {
                return global::System.Text.Json.JsonSerializer.Deserialize(json, global::CSharpToJsonSchema.IntegrationTests.WeatherToolsExtensionsJsonSerializerContext.Default.GetCurrentWeatherAsyncArgs) ??
                throw new global::System.InvalidOperationException("Could not deserialize JSON.");
            }
            #else
            return
                global::System.Text.Json.JsonSerializer.Deserialize<GetCurrentWeatherAsyncArgs>(json, new global::System.Text.Json.JsonSerializerOptions
                {
                    PropertyNamingPolicy = global::System.Text.Json.JsonNamingPolicy.CamelCase,
                    Converters = {{ new global::System.Text.Json.Serialization.JsonStringEnumConverter(global::System.Text.Json.JsonNamingPolicy.CamelCase) }}
                }) ??
                throw new global::System.InvalidOperationException("Could not deserialize JSON.");
            #endif
        }

        public static string CallGetCurrentWeather(this IWeatherTools functions, string json)
        {
            var args = functions.AsGetCurrentWeatherArgs(json);
            var jsonResult = functions.GetCurrentWeather(args.Location, args.Unit);

     #if NET6_0_OR_GREATER
            if(global::System.Text.Json.JsonSerializer.IsReflectionEnabledByDefault)
            {
                #pragma disable warning IL2026, IL3050
                return global::System.Text.Json.JsonSerializer.Serialize(jsonResult, new global::System.Text.Json.JsonSerializerOptions
                {
                    PropertyNamingPolicy = global::System.Text.Json.JsonNamingPolicy.CamelCase,
                    Converters = { new global::System.Text.Json.Serialization.JsonStringEnumConverter(global::System.Text.Json.JsonNamingPolicy.CamelCase) },
                });
                #pragma restore warning IL2026, IL3050  
            }
            else
            {
                return global::System.Text.Json.JsonSerializer.Serialize(jsonResult, global::CSharpToJsonSchema.IntegrationTests.WeatherToolsExtensionsJsonSerializerContext.Default.GetTypeInfo(jsonResult.GetType()));       
            }
            #else            
              return global::System.Text.Json.JsonSerializer.Serialize(jsonResult, new global::System.Text.Json.JsonSerializerOptions
                {
                    PropertyNamingPolicy = global::System.Text.Json.JsonNamingPolicy.CamelCase,
                    Converters = { new global::System.Text.Json.Serialization.JsonStringEnumConverter(global::System.Text.Json.JsonNamingPolicy.CamelCase) },
                });
            #endif            
        }
 

        public static async global::System.Threading.Tasks.Task<string> CallGetCurrentWeatherAsync(
            this IWeatherTools functions,
            string json,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            var args = functions.AsGetCurrentWeatherAsyncArgs(json);
            var jsonResult = await functions.GetCurrentWeatherAsync(args.Location, args.Unit, cancellationToken);

           #if NET6_0_OR_GREATER
            if(global::System.Text.Json.JsonSerializer.IsReflectionEnabledByDefault)
            {
                #pragma disable warning IL2026, IL3050
                return global::System.Text.Json.JsonSerializer.Serialize(jsonResult, new global::System.Text.Json.JsonSerializerOptions
                {
                    PropertyNamingPolicy = global::System.Text.Json.JsonNamingPolicy.CamelCase,
                    Converters = { new global::System.Text.Json.Serialization.JsonStringEnumConverter(global::System.Text.Json.JsonNamingPolicy.CamelCase) },
                });
                #pragma restore warning IL2026, IL3050
            }
            else
            {
                return global::System.Text.Json.JsonSerializer.Serialize(jsonResult, global::CSharpToJsonSchema.IntegrationTests.WeatherToolsExtensionsJsonSerializerContext.Default.GetTypeInfo(jsonResult.GetType()));       
            }
            #else
            return global::System.Text.Json.JsonSerializer.Serialize(jsonResult, new global::System.Text.Json.JsonSerializerOptions
            {
                PropertyNamingPolicy = global::System.Text.Json.JsonNamingPolicy.CamelCase,
                Converters = { new global::System.Text.Json.Serialization.JsonStringEnumConverter(global::System.Text.Json.JsonNamingPolicy.CamelCase) },
            });
            #endif
            
        }
        

 

        public static async global::System.Threading.Tasks.Task<string> CallAsync(
            this IWeatherTools service,
            string functionName,
            string argumentsAsJson,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            var calls = service.AsCalls();
            var func = calls[functionName];

            return await func(argumentsAsJson, cancellationToken);
        }
    }

    public partial class WeatherToolsExtensionsJsonSerializerContext: global::System.Text.Json.Serialization.JsonSerializerContext
    {            
    }
}