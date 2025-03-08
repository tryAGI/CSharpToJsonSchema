//HintName: IVariousTypesTools.Calls.generated.cs
#nullable enable

namespace CSharpToJsonSchema.IntegrationTests
{
    public class GetCurrentWeather3Args
    {
         public long Parameter1 { get; set; }
         public int Parameter2 { get; set; }
         public double Parameter3 { get; set; }
         public float Parameter4 { get; set; }
         public bool Parameter5 { get; set; }
         public global::System.DateTime DateTime { get; set; }
         public global::System.DateOnly Date { get; set; }
    }

    public class SetValueArgs
    {
         public int Value { get; set; }
    }

    public class GetValueArgs
    {
         
    }

    public class SetValueAsyncArgs
    {
         public int Value { get; set; }
    }

    public class GetValueAsyncArgs
    {
         
    }

    public static partial class VariousTypesToolsExtensions
    {
        public static global::System.Collections.Generic.IReadOnlyDictionary<string, global::System.Func<string, global::System.Threading.CancellationToken, global::System.Threading.Tasks.Task<string>>> AsCalls(this IVariousTypesTools service)
        {
            return new global::System.Collections.Generic.Dictionary<string, global::System.Func<string, global::System.Threading.CancellationToken, global::System.Threading.Tasks.Task<string>>>
            {
                ["GetCurrentWeather3"] = (json, _) =>
                {
                    return global::System.Threading.Tasks.Task.FromResult(service.CallGetCurrentWeather3(json));
                },

                ["GetValue"] = (json, _) =>
                {
                    return global::System.Threading.Tasks.Task.FromResult(service.CallGetValue(json));
                },
                ["SetValue"] = (json, _) =>
                {
                    service.CallSetValue(json);

                    return global::System.Threading.Tasks.Task.FromResult(string.Empty);
                },
                ["GetValueAsync"] = async (json, cancellationToken) =>
                {
                    return await service.CallGetValueAsync(json, cancellationToken);
                },
                ["SetValueAsync"] = async (json, cancellationToken) =>
                {
                    await service.CallSetValueAsync(json, cancellationToken);

                    return string.Empty;
                },
            };
        }

        public static GetCurrentWeather3Args AsGetCurrentWeather3Args(
            this IVariousTypesTools functions,
            string json)
        {
            #if NET6_0_OR_GREATER
            if(global::System.Text.Json.JsonSerializer.IsReflectionEnabledByDefault)
            {
                #pragma disable warning IL2026, IL3050
                return global::System.Text.Json.JsonSerializer.Deserialize<GetCurrentWeather3Args>(json, new global::System.Text.Json.JsonSerializerOptions
                {
                    PropertyNamingPolicy = global::System.Text.Json.JsonNamingPolicy.CamelCase,
                    Converters = {{ new global::System.Text.Json.Serialization.JsonStringEnumConverter(global::System.Text.Json.JsonNamingPolicy.CamelCase) }}
                }) ??
                throw new global::System.InvalidOperationException("Could not deserialize JSON.");
                #pragma restore warning IL2026, IL3050
            }
            else
            {
                return global::System.Text.Json.JsonSerializer.Deserialize(json, global::CSharpToJsonSchema.IntegrationTests.VariousTypesToolsExtensionsJsonSerializerContext.Default.GetCurrentWeather3Args) ??
                throw new global::System.InvalidOperationException("Could not deserialize JSON.");
            }
            #else
            return
                global::System.Text.Json.JsonSerializer.Deserialize<GetCurrentWeather3Args>(json, new global::System.Text.Json.JsonSerializerOptions
                {
                    PropertyNamingPolicy = global::System.Text.Json.JsonNamingPolicy.CamelCase,
                    Converters = {{ new global::System.Text.Json.Serialization.JsonStringEnumConverter(global::System.Text.Json.JsonNamingPolicy.CamelCase) }}
                }) ??
                throw new global::System.InvalidOperationException("Could not deserialize JSON.");
            #endif
        }

        public static SetValueArgs AsSetValueArgs(
            this IVariousTypesTools functions,
            string json)
        {
            #if NET6_0_OR_GREATER
            if(global::System.Text.Json.JsonSerializer.IsReflectionEnabledByDefault)
            {
                #pragma disable warning IL2026, IL3050
                return global::System.Text.Json.JsonSerializer.Deserialize<SetValueArgs>(json, new global::System.Text.Json.JsonSerializerOptions
                {
                    PropertyNamingPolicy = global::System.Text.Json.JsonNamingPolicy.CamelCase,
                    Converters = {{ new global::System.Text.Json.Serialization.JsonStringEnumConverter(global::System.Text.Json.JsonNamingPolicy.CamelCase) }}
                }) ??
                throw new global::System.InvalidOperationException("Could not deserialize JSON.");
                #pragma restore warning IL2026, IL3050
            }
            else
            {
                return global::System.Text.Json.JsonSerializer.Deserialize(json, global::CSharpToJsonSchema.IntegrationTests.VariousTypesToolsExtensionsJsonSerializerContext.Default.SetValueArgs) ??
                throw new global::System.InvalidOperationException("Could not deserialize JSON.");
            }
            #else
            return
                global::System.Text.Json.JsonSerializer.Deserialize<SetValueArgs>(json, new global::System.Text.Json.JsonSerializerOptions
                {
                    PropertyNamingPolicy = global::System.Text.Json.JsonNamingPolicy.CamelCase,
                    Converters = {{ new global::System.Text.Json.Serialization.JsonStringEnumConverter(global::System.Text.Json.JsonNamingPolicy.CamelCase) }}
                }) ??
                throw new global::System.InvalidOperationException("Could not deserialize JSON.");
            #endif
        }

        public static GetValueArgs AsGetValueArgs(
            this IVariousTypesTools functions,
            string json)
        {
            #if NET6_0_OR_GREATER
            if(global::System.Text.Json.JsonSerializer.IsReflectionEnabledByDefault)
            {
                #pragma disable warning IL2026, IL3050
                return global::System.Text.Json.JsonSerializer.Deserialize<GetValueArgs>(json, new global::System.Text.Json.JsonSerializerOptions
                {
                    PropertyNamingPolicy = global::System.Text.Json.JsonNamingPolicy.CamelCase,
                    Converters = {{ new global::System.Text.Json.Serialization.JsonStringEnumConverter(global::System.Text.Json.JsonNamingPolicy.CamelCase) }}
                }) ??
                throw new global::System.InvalidOperationException("Could not deserialize JSON.");
                #pragma restore warning IL2026, IL3050
            }
            else
            {
                return global::System.Text.Json.JsonSerializer.Deserialize(json, global::CSharpToJsonSchema.IntegrationTests.VariousTypesToolsExtensionsJsonSerializerContext.Default.GetValueArgs) ??
                throw new global::System.InvalidOperationException("Could not deserialize JSON.");
            }
            #else
            return
                global::System.Text.Json.JsonSerializer.Deserialize<GetValueArgs>(json, new global::System.Text.Json.JsonSerializerOptions
                {
                    PropertyNamingPolicy = global::System.Text.Json.JsonNamingPolicy.CamelCase,
                    Converters = {{ new global::System.Text.Json.Serialization.JsonStringEnumConverter(global::System.Text.Json.JsonNamingPolicy.CamelCase) }}
                }) ??
                throw new global::System.InvalidOperationException("Could not deserialize JSON.");
            #endif
        }

        public static SetValueAsyncArgs AsSetValueAsyncArgs(
            this IVariousTypesTools functions,
            string json)
        {
            #if NET6_0_OR_GREATER
            if(global::System.Text.Json.JsonSerializer.IsReflectionEnabledByDefault)
            {
                #pragma disable warning IL2026, IL3050
                return global::System.Text.Json.JsonSerializer.Deserialize<SetValueAsyncArgs>(json, new global::System.Text.Json.JsonSerializerOptions
                {
                    PropertyNamingPolicy = global::System.Text.Json.JsonNamingPolicy.CamelCase,
                    Converters = {{ new global::System.Text.Json.Serialization.JsonStringEnumConverter(global::System.Text.Json.JsonNamingPolicy.CamelCase) }}
                }) ??
                throw new global::System.InvalidOperationException("Could not deserialize JSON.");
                #pragma restore warning IL2026, IL3050
            }
            else
            {
                return global::System.Text.Json.JsonSerializer.Deserialize(json, global::CSharpToJsonSchema.IntegrationTests.VariousTypesToolsExtensionsJsonSerializerContext.Default.SetValueAsyncArgs) ??
                throw new global::System.InvalidOperationException("Could not deserialize JSON.");
            }
            #else
            return
                global::System.Text.Json.JsonSerializer.Deserialize<SetValueAsyncArgs>(json, new global::System.Text.Json.JsonSerializerOptions
                {
                    PropertyNamingPolicy = global::System.Text.Json.JsonNamingPolicy.CamelCase,
                    Converters = {{ new global::System.Text.Json.Serialization.JsonStringEnumConverter(global::System.Text.Json.JsonNamingPolicy.CamelCase) }}
                }) ??
                throw new global::System.InvalidOperationException("Could not deserialize JSON.");
            #endif
        }

        public static GetValueAsyncArgs AsGetValueAsyncArgs(
            this IVariousTypesTools functions,
            string json)
        {
            #if NET6_0_OR_GREATER
            if(global::System.Text.Json.JsonSerializer.IsReflectionEnabledByDefault)
            {
                #pragma disable warning IL2026, IL3050
                return global::System.Text.Json.JsonSerializer.Deserialize<GetValueAsyncArgs>(json, new global::System.Text.Json.JsonSerializerOptions
                {
                    PropertyNamingPolicy = global::System.Text.Json.JsonNamingPolicy.CamelCase,
                    Converters = {{ new global::System.Text.Json.Serialization.JsonStringEnumConverter(global::System.Text.Json.JsonNamingPolicy.CamelCase) }}
                }) ??
                throw new global::System.InvalidOperationException("Could not deserialize JSON.");
                #pragma restore warning IL2026, IL3050
            }
            else
            {
                return global::System.Text.Json.JsonSerializer.Deserialize(json, global::CSharpToJsonSchema.IntegrationTests.VariousTypesToolsExtensionsJsonSerializerContext.Default.GetValueAsyncArgs) ??
                throw new global::System.InvalidOperationException("Could not deserialize JSON.");
            }
            #else
            return
                global::System.Text.Json.JsonSerializer.Deserialize<GetValueAsyncArgs>(json, new global::System.Text.Json.JsonSerializerOptions
                {
                    PropertyNamingPolicy = global::System.Text.Json.JsonNamingPolicy.CamelCase,
                    Converters = {{ new global::System.Text.Json.Serialization.JsonStringEnumConverter(global::System.Text.Json.JsonNamingPolicy.CamelCase) }}
                }) ??
                throw new global::System.InvalidOperationException("Could not deserialize JSON.");
            #endif
        }

        public static string CallGetCurrentWeather3(this IVariousTypesTools functions, string json)
        {
            var args = functions.AsGetCurrentWeather3Args(json);
            var jsonResult = functions.GetCurrentWeather3(args.Parameter1, args.Parameter2, args.Parameter3, args.Parameter4, args.Parameter5, args.DateTime, args.Date);

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
                return global::System.Text.Json.JsonSerializer.Serialize(jsonResult, global::CSharpToJsonSchema.IntegrationTests.VariousTypesToolsExtensionsJsonSerializerContext.Default.GetTypeInfo(jsonResult.GetType()));       
            }
            #else            
              return global::System.Text.Json.JsonSerializer.Serialize(jsonResult, new global::System.Text.Json.JsonSerializerOptions
                {
                    PropertyNamingPolicy = global::System.Text.Json.JsonNamingPolicy.CamelCase,
                    Converters = { new global::System.Text.Json.Serialization.JsonStringEnumConverter(global::System.Text.Json.JsonNamingPolicy.CamelCase) },
                });
            #endif            
        }

        public static string CallGetValue(this IVariousTypesTools functions, string json)
        {
            var args = functions.AsGetValueArgs(json);
            var jsonResult = functions.GetValue();

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
                return global::System.Text.Json.JsonSerializer.Serialize(jsonResult, global::CSharpToJsonSchema.IntegrationTests.VariousTypesToolsExtensionsJsonSerializerContext.Default.GetTypeInfo(jsonResult.GetType()));       
            }
            #else            
              return global::System.Text.Json.JsonSerializer.Serialize(jsonResult, new global::System.Text.Json.JsonSerializerOptions
                {
                    PropertyNamingPolicy = global::System.Text.Json.JsonNamingPolicy.CamelCase,
                    Converters = { new global::System.Text.Json.Serialization.JsonStringEnumConverter(global::System.Text.Json.JsonNamingPolicy.CamelCase) },
                });
            #endif            
        }
        public static void CallSetValue(this IVariousTypesTools functions, string json)
        {
            var args = functions.AsSetValueArgs(json);
            functions.SetValue(args.Value);
        }

        public static async global::System.Threading.Tasks.Task<string> CallGetValueAsync(
            this IVariousTypesTools functions,
            string json,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            var args = functions.AsGetValueAsyncArgs(json);
            var jsonResult = await functions.GetValueAsync(cancellationToken);

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
                return global::System.Text.Json.JsonSerializer.Serialize(jsonResult, global::CSharpToJsonSchema.IntegrationTests.VariousTypesToolsExtensionsJsonSerializerContext.Default.GetTypeInfo(jsonResult.GetType()));       
            }
            #else
            return global::System.Text.Json.JsonSerializer.Serialize(jsonResult, new global::System.Text.Json.JsonSerializerOptions
            {
                PropertyNamingPolicy = global::System.Text.Json.JsonNamingPolicy.CamelCase,
                Converters = { new global::System.Text.Json.Serialization.JsonStringEnumConverter(global::System.Text.Json.JsonNamingPolicy.CamelCase) },
            });
            #endif
            
        }
        

        public static async global::System.Threading.Tasks.Task<string> CallSetValueAsync(
            this IVariousTypesTools functions,
            string json,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            var args = functions.AsSetValueAsyncArgs(json);
            await functions.SetValueAsync(args.Value, cancellationToken);

            return string.Empty;
        }

        public static async global::System.Threading.Tasks.Task<string> CallAsync(
            this IVariousTypesTools service,
            string functionName,
            string argumentsAsJson,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            var calls = service.AsCalls();
            var func = calls[functionName];

            return await func(argumentsAsJson, cancellationToken);
        }
    }

    public partial class VariousTypesToolsExtensionsJsonSerializerContext: global::System.Text.Json.Serialization.JsonSerializerContext
    {            
    }
}