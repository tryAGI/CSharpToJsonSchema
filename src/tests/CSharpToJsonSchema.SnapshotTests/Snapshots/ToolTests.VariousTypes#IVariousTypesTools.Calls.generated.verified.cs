//HintName: IVariousTypesTools.Calls.generated.cs
#nullable enable

namespace CSharpToJsonSchema.IntegrationTests
{
    public static partial class VariousTypesToolsExtensions
    {
        public class GetCurrentWeatherArgs
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

        public static global::System.Collections.Generic.IReadOnlyDictionary<string, global::System.Func<string, global::System.Threading.CancellationToken, global::System.Threading.Tasks.Task<string>>> AsCalls(this IVariousTypesTools service)
        {
            return new global::System.Collections.Generic.Dictionary<string, global::System.Func<string, global::System.Threading.CancellationToken, global::System.Threading.Tasks.Task<string>>>
            {
                ["GetCurrentWeather"] = (json, _) =>
                {
                    return global::System.Threading.Tasks.Task.FromResult(service.CallGetCurrentWeather(json));
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

        public static VariousTypesToolsExtensions.GetCurrentWeatherArgs AsGetCurrentWeatherArgs(
            this IVariousTypesTools functions,
            string json)
        {
            return
                global::System.Text.Json.JsonSerializer.Deserialize<VariousTypesToolsExtensions.GetCurrentWeatherArgs>(json, new global::System.Text.Json.JsonSerializerOptions
                {
                    PropertyNamingPolicy = global::System.Text.Json.JsonNamingPolicy.CamelCase,
                    Converters = {{ new global::System.Text.Json.Serialization.JsonStringEnumConverter(global::System.Text.Json.JsonNamingPolicy.CamelCase) }}
                }) ??
                throw new global::System.InvalidOperationException("Could not deserialize JSON.");
        }

        public static VariousTypesToolsExtensions.SetValueArgs AsSetValueArgs(
            this IVariousTypesTools functions,
            string json)
        {
            return
                global::System.Text.Json.JsonSerializer.Deserialize<VariousTypesToolsExtensions.SetValueArgs>(json, new global::System.Text.Json.JsonSerializerOptions
                {
                    PropertyNamingPolicy = global::System.Text.Json.JsonNamingPolicy.CamelCase,
                    Converters = {{ new global::System.Text.Json.Serialization.JsonStringEnumConverter(global::System.Text.Json.JsonNamingPolicy.CamelCase) }}
                }) ??
                throw new global::System.InvalidOperationException("Could not deserialize JSON.");
        }

        public static VariousTypesToolsExtensions.GetValueArgs AsGetValueArgs(
            this IVariousTypesTools functions,
            string json)
        {
            return
                global::System.Text.Json.JsonSerializer.Deserialize<VariousTypesToolsExtensions.GetValueArgs>(json, new global::System.Text.Json.JsonSerializerOptions
                {
                    PropertyNamingPolicy = global::System.Text.Json.JsonNamingPolicy.CamelCase,
                    Converters = {{ new global::System.Text.Json.Serialization.JsonStringEnumConverter(global::System.Text.Json.JsonNamingPolicy.CamelCase) }}
                }) ??
                throw new global::System.InvalidOperationException("Could not deserialize JSON.");
        }

        public static VariousTypesToolsExtensions.SetValueAsyncArgs AsSetValueAsyncArgs(
            this IVariousTypesTools functions,
            string json)
        {
            return
                global::System.Text.Json.JsonSerializer.Deserialize<VariousTypesToolsExtensions.SetValueAsyncArgs>(json, new global::System.Text.Json.JsonSerializerOptions
                {
                    PropertyNamingPolicy = global::System.Text.Json.JsonNamingPolicy.CamelCase,
                    Converters = {{ new global::System.Text.Json.Serialization.JsonStringEnumConverter(global::System.Text.Json.JsonNamingPolicy.CamelCase) }}
                }) ??
                throw new global::System.InvalidOperationException("Could not deserialize JSON.");
        }

        public static VariousTypesToolsExtensions.GetValueAsyncArgs AsGetValueAsyncArgs(
            this IVariousTypesTools functions,
            string json)
        {
            return
                global::System.Text.Json.JsonSerializer.Deserialize<VariousTypesToolsExtensions.GetValueAsyncArgs>(json, new global::System.Text.Json.JsonSerializerOptions
                {
                    PropertyNamingPolicy = global::System.Text.Json.JsonNamingPolicy.CamelCase,
                    Converters = {{ new global::System.Text.Json.Serialization.JsonStringEnumConverter(global::System.Text.Json.JsonNamingPolicy.CamelCase) }}
                }) ??
                throw new global::System.InvalidOperationException("Could not deserialize JSON.");
        }

        public static string CallGetCurrentWeather(this IVariousTypesTools functions, string json)
        {
            var args = functions.AsGetCurrentWeatherArgs(json);
            var jsonResult = functions.GetCurrentWeather(args.Parameter1, args.Parameter2, args.Parameter3, args.Parameter4, args.Parameter5, args.DateTime, args.Date);

            return global::System.Text.Json.JsonSerializer.Serialize(jsonResult, new global::System.Text.Json.JsonSerializerOptions
            {
                PropertyNamingPolicy = global::System.Text.Json.JsonNamingPolicy.CamelCase,
                Converters = { new global::System.Text.Json.Serialization.JsonStringEnumConverter(global::System.Text.Json.JsonNamingPolicy.CamelCase) },
            });
        }

        public static string CallGetValue(this IVariousTypesTools functions, string json)
        {
            var args = functions.AsGetValueArgs(json);
            var jsonResult = functions.GetValue();

            return global::System.Text.Json.JsonSerializer.Serialize(jsonResult, new global::System.Text.Json.JsonSerializerOptions
            {
                PropertyNamingPolicy = global::System.Text.Json.JsonNamingPolicy.CamelCase,
                Converters = { new global::System.Text.Json.Serialization.JsonStringEnumConverter(global::System.Text.Json.JsonNamingPolicy.CamelCase) },
            });
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

            return global::System.Text.Json.JsonSerializer.Serialize(jsonResult, new global::System.Text.Json.JsonSerializerOptions
            {
                PropertyNamingPolicy = global::System.Text.Json.JsonNamingPolicy.CamelCase,
                Converters = { new global::System.Text.Json.Serialization.JsonStringEnumConverter(global::System.Text.Json.JsonNamingPolicy.CamelCase) },
            });
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
}