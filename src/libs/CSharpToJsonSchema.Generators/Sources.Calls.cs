using CSharpToJsonSchema.Generators.Conversion;
using CSharpToJsonSchema.Generators.JsonGen.Helpers;
using CSharpToJsonSchema.Generators.Models;
using H.Generators;
using H.Generators.Extensions;

namespace CSharpToJsonSchema.Generators;

internal static partial class Sources
{
    public static string GenerateCalls(InterfaceData @interface)
    {
        var extensionsClassName = @interface.Name.Substring(startIndex: 1) + "Extensions";
        var res = @$"#nullable enable

namespace {@interface.Namespace}
{{
{@interface.Methods.Select(static method => $@"
    public class {method.Name}Args
    {{
         
         {string.Join("\n         ", method.Parameters.Select(static x => $@"[global::System.ComponentModel.Description({"\""}{ToModels.GetDescription(x)}{"\""})]
          public {x.Type.ToDisplayString()}{(x.Type.IsNullableType() ? "?" : "")} {x.Name.ToPropertyName()} {{ get; set; }}{(!string.IsNullOrEmpty(ToModels.GetDefaultValue(x.Type)) ? $" = {ToModels.GetDefaultValue(x.Type)};" : "")}"))}
    }}
").Inject()}

    public static partial class {extensionsClassName}
    {{
        public static global::System.Collections.Generic.IReadOnlyDictionary<string, global::System.Func<string, global::System.Threading.CancellationToken, global::System.Threading.Tasks.Task<string>>> AsCalls(this {@interface.Name} service)
        {{
            return new global::System.Collections.Generic.Dictionary<string, global::System.Func<string, global::System.Threading.CancellationToken, global::System.Threading.Tasks.Task<string>>>
            {{
{@interface.Methods.Where(static x => x is { IsAsync: false, IsVoid: false }).Select(method => $@"
                [""{method.Name}""] = (json, _) =>
                {{
                    return global::System.Threading.Tasks.Task.FromResult(service.Call{method.Name}(json));
                }},
").Inject()}
{@interface.Methods.Where(static x => x is { IsAsync: false, IsVoid: true }).Select(method => $@"
                [""{method.Name}""] = (json, _) =>
                {{
                    service.Call{method.Name}(json);

                    return global::System.Threading.Tasks.Task.FromResult(string.Empty);
                }},
").Inject()}
{@interface.Methods.Where(static x => x is { IsAsync: true, IsVoid: false }).Select(method => $@"
                [""{method.Name}""] = async (json, cancellationToken) =>
                {{
                    return await service.Call{method.Name}(json, cancellationToken);
                }},
").Inject()}
{@interface.Methods.Where(static x => x is { IsAsync: true, IsVoid: true }).Select(method => $@"
                [""{method.Name}""] = async (json, cancellationToken) =>
                {{
                    await service.Call{method.Name}(json, cancellationToken);

                    return string.Empty;
                }},
").Inject()}
            }};
        }}

{@interface.Methods.Select(method => $@"
        #pragma warning disable IL2026, IL3050
        public static {method.Name}Args As{method.Name}Args(
            this {@interface.Name} functions,
            string json)
        {{
            #if NET6_0_OR_GREATER
            if(global::System.Text.Json.JsonSerializer.IsReflectionEnabledByDefault)
            {{
               
                return global::System.Text.Json.JsonSerializer.Deserialize<{method.Name}Args>(json, new global::System.Text.Json.JsonSerializerOptions
                {{
                    PropertyNamingPolicy = global::System.Text.Json.JsonNamingPolicy.CamelCase,
                    Converters = {{{{ new global::System.Text.Json.Serialization.JsonStringEnumConverter(global::System.Text.Json.JsonNamingPolicy.CamelCase) }}}}
                }}) ??
                throw new global::System.InvalidOperationException(""Could not deserialize JSON."");
               
            }}
            else
            {{
                return global::System.Text.Json.JsonSerializer.Deserialize(json, global::{@interface.Namespace}.{extensionsClassName}JsonSerializerContext.Default.{method.Name}Args) ??
                throw new global::System.InvalidOperationException(""Could not deserialize JSON."");
            }}
            #else
            return
                global::System.Text.Json.JsonSerializer.Deserialize<{method.Name}Args>(json, new global::System.Text.Json.JsonSerializerOptions
                {{
                    PropertyNamingPolicy = global::System.Text.Json.JsonNamingPolicy.CamelCase,
                    Converters = {{{{ new global::System.Text.Json.Serialization.JsonStringEnumConverter(global::System.Text.Json.JsonNamingPolicy.CamelCase) }}}}
                }}) ??
                throw new global::System.InvalidOperationException(""Could not deserialize JSON."");
            #endif
        }}
        #pragma warning restore IL2026, IL3050
").Inject()}

{@interface.Methods.Where(static x => x is { IsAsync: false, IsVoid: false }).Select(method => $@"
        #pragma warning disable IL2026, IL3050
        public static string Call{method.Name}(this {@interface.Name} functions, string json)
        {{
            var args = functions.As{method.Name}Args(json);
            var jsonResult = functions.{method.Name}({string.Join(", ", method.Parameters.Select(static parameter => $@"args.{parameter.Name.ToPropertyName()}"))});

     #if NET6_0_OR_GREATER
            if(global::System.Text.Json.JsonSerializer.IsReflectionEnabledByDefault)
            {{
                
                return global::System.Text.Json.JsonSerializer.Serialize(jsonResult, new global::System.Text.Json.JsonSerializerOptions
                {{
                    PropertyNamingPolicy = global::System.Text.Json.JsonNamingPolicy.CamelCase,
                    Converters = {{ new global::System.Text.Json.Serialization.JsonStringEnumConverter(global::System.Text.Json.JsonNamingPolicy.CamelCase) }},
                }});
                
            }}
            else
            {{
                return global::System.Text.Json.JsonSerializer.Serialize(jsonResult, global::{@interface.Namespace}.{extensionsClassName}JsonSerializerContext.Default.GetTypeInfo(jsonResult.GetType()));       
            }}
            #else            
              return global::System.Text.Json.JsonSerializer.Serialize(jsonResult, new global::System.Text.Json.JsonSerializerOptions
                {{
                    PropertyNamingPolicy = global::System.Text.Json.JsonNamingPolicy.CamelCase,
                    Converters = {{ new global::System.Text.Json.Serialization.JsonStringEnumConverter(global::System.Text.Json.JsonNamingPolicy.CamelCase) }},
                }});
            #endif            
        }}
        #pragma warning restore IL2026, IL3050 
").Inject()}
{@interface.Methods.Where(static x => x is { IsAsync: false, IsVoid: true }).Select(method => $@"
        public static void Call{method.Name}(this {@interface.Name} functions, string json)
        {{
            var args = functions.As{method.Name}Args(json);
            functions.{method.Name}({string.Join(", ", method.Parameters.Select(static parameter => $@"args.{parameter.Name.ToPropertyName()}"))});
        }}
").Inject()}

{@interface.Methods.Where(static x => x is { IsAsync: true, IsVoid: false }).Select(method => $@"
        #pragma warning disable IL2026, IL3050
        public static async global::System.Threading.Tasks.Task<string> Call{method.Name}(
            this {@interface.Name} functions,
            string json,
            global::System.Threading.CancellationToken cancellationToken = default)
        {{
            var args = functions.As{method.Name}Args(json);
            var jsonResult = await functions.{method.Name}({string.Join(", ", method.Parameters
                .Select(static parameter => $@"args.{parameter.Name.ToPropertyName()}").Append("cancellationToken"))});

           #if NET6_0_OR_GREATER
            if(global::System.Text.Json.JsonSerializer.IsReflectionEnabledByDefault)
            {{
                
                return global::System.Text.Json.JsonSerializer.Serialize(jsonResult, new global::System.Text.Json.JsonSerializerOptions
                {{
                    PropertyNamingPolicy = global::System.Text.Json.JsonNamingPolicy.CamelCase,
                    Converters = {{ new global::System.Text.Json.Serialization.JsonStringEnumConverter(global::System.Text.Json.JsonNamingPolicy.CamelCase) }},
                }});                
            }}
            else
            {{
                return global::System.Text.Json.JsonSerializer.Serialize(jsonResult, global::{@interface.Namespace}.{extensionsClassName}JsonSerializerContext.Default.GetTypeInfo(jsonResult.GetType()));       
            }}
            #else
            return global::System.Text.Json.JsonSerializer.Serialize(jsonResult, new global::System.Text.Json.JsonSerializerOptions
            {{
                PropertyNamingPolicy = global::System.Text.Json.JsonNamingPolicy.CamelCase,
                Converters = {{ new global::System.Text.Json.Serialization.JsonStringEnumConverter(global::System.Text.Json.JsonNamingPolicy.CamelCase) }},
            }});
            #endif
            
        }}
        #pragma warning restore IL2026, IL3050
").Inject()}

{@interface.Methods.Where(static x => x is { IsAsync: true, IsVoid: true }).Select(method => $@"
        public static async global::System.Threading.Tasks.Task<string> Call{method.Name}(
            this {@interface.Name} functions,
            string json,
            global::System.Threading.CancellationToken cancellationToken = default)
        {{
            var args = functions.As{method.Name}Args(json);
            await functions.{method.Name}({string.Join(", ", method.Parameters.Select(static parameter => $@"args.{parameter.Name.ToPropertyName()}"))}, cancellationToken);

            return string.Empty;
        }}
").Inject()}

        public static async global::System.Threading.Tasks.Task<string> CallAsync(
            this {@interface.Name} service,
            string functionName,
            string argumentsAsJson,
            global::System.Threading.CancellationToken cancellationToken = default)
        {{
            var calls = service.AsCalls();
            var func = calls[functionName];

            return await func(argumentsAsJson, cancellationToken);
        }}
    }}

    public partial class {extensionsClassName}JsonSerializerContext: global::System.Text.Json.Serialization.JsonSerializerContext
    {{            
    }}
}}";
        return res;
    }
}
