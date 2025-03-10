//HintName: IWeatherStrictTools.Calls.generated.cs
#nullable enable

namespace CSharpToJsonSchema.IntegrationTests
{
    public class GetCurrentWeather2Args
    {
         
         [global::System.ComponentModel.Description("The city and state, e.g. San Francisco, CA")]
          public string? Location { get; set; } = string.Empty;
         [global::System.ComponentModel.Description("")]
          public CSharpToJsonSchema.IntegrationTests.Unit2 Unit { get; set; }
    }

    public class GetCurrentWeatherAsync2Args
    {
         
         [global::System.ComponentModel.Description("The city and state, e.g. San Francisco, CA")]
          public string? Location { get; set; } = string.Empty;
         [global::System.ComponentModel.Description("")]
          public CSharpToJsonSchema.IntegrationTests.Unit2 Unit { get; set; }
    }

    public static partial class WeatherStrictToolsExtensions
    {
        public static global::System.Collections.Generic.IReadOnlyDictionary<string, global::System.Func<string, global::System.Threading.CancellationToken, global::System.Threading.Tasks.Task<string>>> AsCalls(this IWeatherStrictTools service)
        {
            return new global::System.Collections.Generic.Dictionary<string, global::System.Func<string, global::System.Threading.CancellationToken, global::System.Threading.Tasks.Task<string>>>
            {
                ["GetCurrentWeather2"] = (json, _) =>
                {
                    return global::System.Threading.Tasks.Task.FromResult(service.CallGetCurrentWeather2(json));
                },
 
                ["GetCurrentWeatherAsync2"] = async (json, cancellationToken) =>
                {
                    return await service.CallGetCurrentWeatherAsync2(json, cancellationToken);
                },
 
            };
        }

        #pragma warning disable IL2026, IL3050
        public static GetCurrentWeather2Args AsGetCurrentWeather2Args(
            this IWeatherStrictTools functions,
            string json)
        {
            #if NET6_0_OR_GREATER
            if(global::System.Text.Json.JsonSerializer.IsReflectionEnabledByDefault)
            {
               
                return global::System.Text.Json.JsonSerializer.Deserialize<GetCurrentWeather2Args>(json, new global::System.Text.Json.JsonSerializerOptions
                {
                    PropertyNamingPolicy = global::System.Text.Json.JsonNamingPolicy.CamelCase,
                    Converters = {{ new global::System.Text.Json.Serialization.JsonStringEnumConverter(global::System.Text.Json.JsonNamingPolicy.CamelCase) }}
                }) ??
                throw new global::System.InvalidOperationException("Could not deserialize JSON.");
               
            }
            else
            {
                return global::System.Text.Json.JsonSerializer.Deserialize(json, global::CSharpToJsonSchema.IntegrationTests.WeatherStrictToolsExtensionsJsonSerializerContext.Default.GetCurrentWeather2Args) ??
                throw new global::System.InvalidOperationException("Could not deserialize JSON.");
            }
            #else
            return
                global::System.Text.Json.JsonSerializer.Deserialize<GetCurrentWeather2Args>(json, new global::System.Text.Json.JsonSerializerOptions
                {
                    PropertyNamingPolicy = global::System.Text.Json.JsonNamingPolicy.CamelCase,
                    Converters = {{ new global::System.Text.Json.Serialization.JsonStringEnumConverter(global::System.Text.Json.JsonNamingPolicy.CamelCase) }}
                }) ??
                throw new global::System.InvalidOperationException("Could not deserialize JSON.");
            #endif
        }
        #pragma warning restore IL2026, IL3050

        #pragma warning disable IL2026, IL3050
        public static GetCurrentWeatherAsync2Args AsGetCurrentWeatherAsync2Args(
            this IWeatherStrictTools functions,
            string json)
        {
            #if NET6_0_OR_GREATER
            if(global::System.Text.Json.JsonSerializer.IsReflectionEnabledByDefault)
            {
               
                return global::System.Text.Json.JsonSerializer.Deserialize<GetCurrentWeatherAsync2Args>(json, new global::System.Text.Json.JsonSerializerOptions
                {
                    PropertyNamingPolicy = global::System.Text.Json.JsonNamingPolicy.CamelCase,
                    Converters = {{ new global::System.Text.Json.Serialization.JsonStringEnumConverter(global::System.Text.Json.JsonNamingPolicy.CamelCase) }}
                }) ??
                throw new global::System.InvalidOperationException("Could not deserialize JSON.");
               
            }
            else
            {
                return global::System.Text.Json.JsonSerializer.Deserialize(json, global::CSharpToJsonSchema.IntegrationTests.WeatherStrictToolsExtensionsJsonSerializerContext.Default.GetCurrentWeatherAsync2Args) ??
                throw new global::System.InvalidOperationException("Could not deserialize JSON.");
            }
            #else
            return
                global::System.Text.Json.JsonSerializer.Deserialize<GetCurrentWeatherAsync2Args>(json, new global::System.Text.Json.JsonSerializerOptions
                {
                    PropertyNamingPolicy = global::System.Text.Json.JsonNamingPolicy.CamelCase,
                    Converters = {{ new global::System.Text.Json.Serialization.JsonStringEnumConverter(global::System.Text.Json.JsonNamingPolicy.CamelCase) }}
                }) ??
                throw new global::System.InvalidOperationException("Could not deserialize JSON.");
            #endif
        }
        #pragma warning restore IL2026, IL3050

        #pragma warning disable IL2026, IL3050
        public static string CallGetCurrentWeather2(this IWeatherStrictTools functions, string json)
        {
            var args = functions.AsGetCurrentWeather2Args(json);
            var jsonResult = functions.GetCurrentWeather2(args.Location, args.Unit);

     #if NET6_0_OR_GREATER
            if(global::System.Text.Json.JsonSerializer.IsReflectionEnabledByDefault)
            {
                
                return global::System.Text.Json.JsonSerializer.Serialize(jsonResult, new global::System.Text.Json.JsonSerializerOptions
                {
                    PropertyNamingPolicy = global::System.Text.Json.JsonNamingPolicy.CamelCase,
                    Converters = { new global::System.Text.Json.Serialization.JsonStringEnumConverter(global::System.Text.Json.JsonNamingPolicy.CamelCase) },
                });
                
            }
            else
            {
                return global::System.Text.Json.JsonSerializer.Serialize(jsonResult, global::CSharpToJsonSchema.IntegrationTests.WeatherStrictToolsExtensionsJsonSerializerContext.Default.GetTypeInfo(jsonResult.GetType()));       
            }
            #else            
              return global::System.Text.Json.JsonSerializer.Serialize(jsonResult, new global::System.Text.Json.JsonSerializerOptions
                {
                    PropertyNamingPolicy = global::System.Text.Json.JsonNamingPolicy.CamelCase,
                    Converters = { new global::System.Text.Json.Serialization.JsonStringEnumConverter(global::System.Text.Json.JsonNamingPolicy.CamelCase) },
                });
            #endif            
        }
        #pragma warning restore IL2026, IL3050 
 

        #pragma warning disable IL2026, IL3050
        public static async global::System.Threading.Tasks.Task<string> CallGetCurrentWeatherAsync2(
            this IWeatherStrictTools functions,
            string json,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            var args = functions.AsGetCurrentWeatherAsync2Args(json);
            var jsonResult = await functions.GetCurrentWeatherAsync2(args.Location, args.Unit, cancellationToken);

           #if NET6_0_OR_GREATER
            if(global::System.Text.Json.JsonSerializer.IsReflectionEnabledByDefault)
            {
                
                return global::System.Text.Json.JsonSerializer.Serialize(jsonResult, new global::System.Text.Json.JsonSerializerOptions
                {
                    PropertyNamingPolicy = global::System.Text.Json.JsonNamingPolicy.CamelCase,
                    Converters = { new global::System.Text.Json.Serialization.JsonStringEnumConverter(global::System.Text.Json.JsonNamingPolicy.CamelCase) },
                });                
            }
            else
            {
                return global::System.Text.Json.JsonSerializer.Serialize(jsonResult, global::CSharpToJsonSchema.IntegrationTests.WeatherStrictToolsExtensionsJsonSerializerContext.Default.GetTypeInfo(jsonResult.GetType()));       
            }
            #else
            return global::System.Text.Json.JsonSerializer.Serialize(jsonResult, new global::System.Text.Json.JsonSerializerOptions
            {
                PropertyNamingPolicy = global::System.Text.Json.JsonNamingPolicy.CamelCase,
                Converters = { new global::System.Text.Json.Serialization.JsonStringEnumConverter(global::System.Text.Json.JsonNamingPolicy.CamelCase) },
            });
            #endif
            
        }
        #pragma warning restore IL2026, IL3050

 

        public static async global::System.Threading.Tasks.Task<string> CallAsync(
            this IWeatherStrictTools service,
            string functionName,
            string argumentsAsJson,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            var calls = service.AsCalls();
            var func = calls[functionName];

            return await func(argumentsAsJson, cancellationToken);
        }
    }

    public partial class WeatherStrictToolsExtensionsJsonSerializerContext: global::System.Text.Json.Serialization.JsonSerializerContext
    {            
    }
}