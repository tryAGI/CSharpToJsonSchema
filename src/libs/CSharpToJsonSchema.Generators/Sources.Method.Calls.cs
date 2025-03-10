using CSharpToJsonSchema.Generators.Conversion;
using CSharpToJsonSchema.Generators.JsonGen.Helpers;
using CSharpToJsonSchema.Generators.Models;
using H.Generators.Extensions;

namespace CSharpToJsonSchema.Generators;

internal static partial class Sources
{
    public static string GenerateFunctionCalls(InterfaceData @interface)
    {
        if(@interface.Methods.Count == 0)
            return string.Empty;
        var extensionsClassName = @interface.Name;
        var res = @$"#nullable enable
   #pragma warning disable CS8602

namespace {@interface.Namespace}
{{








{@interface.Methods.Select(static method => $@"
    public class {method.Name}Args
    {{         
         {string.Join("\n         ", method.Parameters.Where(s=>s.Type.Name!="CancellationToken").Select(static x => $@"[global::System.ComponentModel.Description({"\""}{ToModels.GetDescription(x)}{"\""})]
          public {x.Type.ToDisplayString()}{(x.Type.IsNullableType() ? "?" : "")} {x.Name.ToPropertyName()} {{ get; set; }}{(!string.IsNullOrEmpty(ToModels.GetDefaultValue(x.Type)) ? $" = {ToModels.GetDefaultValue(x.Type)};" : "")}"))}
    }}
").Inject()}

    public partial class {extensionsClassName}
    {{
        public global::System.Collections.Generic.IReadOnlyDictionary<string, global::System.Func<string, global::System.Threading.CancellationToken, global::System.Threading.Tasks.Task<string>>> AsCalls()
        {{
            return new global::System.Collections.Generic.Dictionary<string, global::System.Func<string, global::System.Threading.CancellationToken, global::System.Threading.Tasks.Task<string>>>
            {{
{@interface.Methods.Where(static x => x is { IsAsync: false, IsVoid: false }).Select(method => $@"
                [""{method.Name}""] = (json, _) =>
                {{
                    return global::System.Threading.Tasks.Task.FromResult(Call{method.Name}(json));
                }},
").Inject()}
{@interface.Methods.Where(static x => x is { IsAsync: false, IsVoid: true }).Select(method => $@"
                [""{method.Name}""] = (json, _) =>
                {{
                    Call{method.Name}(json);

                    return global::System.Threading.Tasks.Task.FromResult(string.Empty);
                }},
").Inject()}
{@interface.Methods.Where(static x => x is { IsAsync: true, IsVoid: false }).Select(method => $@"
                [""{method.Name}""] = async (json, cancellationToken) =>
                {{
                    return await Call{method.Name}(json, cancellationToken);
                }},
").Inject()}
{@interface.Methods.Where(static x => x is { IsAsync: true, IsVoid: true }).Select(method => $@"
                [""{method.Name}""] = async (json, cancellationToken) =>
                {{
                    await Call{method.Name}(json, cancellationToken);

                    return string.Empty;
                }},
").Inject()}
            }};
        }}

{@interface.Methods.Select(method => $@"
        private {method.Name}Args As{method.Name}Args(            
            string json)
        {{
            #if NET6_0_OR_GREATER
            if(global::System.Text.Json.JsonSerializer.IsReflectionEnabledByDefault)
            {{
                #pragma disable warning IL2026, IL3050
                return global::System.Text.Json.JsonSerializer.Deserialize<{method.Name}Args>(json, new global::System.Text.Json.JsonSerializerOptions
                {{
                    PropertyNamingPolicy = global::System.Text.Json.JsonNamingPolicy.CamelCase,
                    Converters = {{{{ new global::System.Text.Json.Serialization.JsonStringEnumConverter(global::System.Text.Json.JsonNamingPolicy.CamelCase) }}}}
                }}) ??
                throw new global::System.InvalidOperationException(""Could not deserialize JSON."");
                #pragma restore warning IL2026, IL3050
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
").Inject()}

{@interface.Methods.Where(static x => x is { IsAsync: false, IsVoid: false }).Select(method => $@"
        private string Call{method.Name}(string json)
        {{
            var args = As{method.Name}Args(json);
            var func = (dynamic) Delegates[""{method.Name}""];
            var jsonResult = func.Invoke({string.Join(", ", method.Parameters.Where(s=>s.Type.Name!="CancellationToken").Select(static parameter => $@"args.{parameter.Name.ToPropertyName()}"))});

     #if NET6_0_OR_GREATER
            if(global::System.Text.Json.JsonSerializer.IsReflectionEnabledByDefault)
            {{
                #pragma disable warning IL2026, IL3050
                return global::System.Text.Json.JsonSerializer.Serialize(jsonResult, new global::System.Text.Json.JsonSerializerOptions
                {{
                    PropertyNamingPolicy = global::System.Text.Json.JsonNamingPolicy.CamelCase,
                    Converters = {{ new global::System.Text.Json.Serialization.JsonStringEnumConverter(global::System.Text.Json.JsonNamingPolicy.CamelCase) }},
                }});
                #pragma restore warning IL2026, IL3050  
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
").Inject()}
{@interface.Methods.Where(static x => x is { IsAsync: false, IsVoid: true }).Select(method => $@"
        private void Call{method.Name}(string json)
        {{
            var func = (dynamic) Delegates[""{method.Name}""];
            var args = As{method.Name}Args(json);
            func.Invoke({string.Join(", ", method.Parameters.Where(s=>s.Type.Name!="CancellationToken").Select(static parameter => $@"args.{parameter.Name.ToPropertyName()}"))});
        }}
").Inject()}

{@interface.Methods.Where(static x => x is { IsAsync: true, IsVoid: false }).Select(method => $@"
        private async global::System.Threading.Tasks.Task<string> Call{method.Name}(
            string json,
            global::System.Threading.CancellationToken cancellationToken = default)
        {{
            var args = As{method.Name}Args(json);
            var func = (dynamic) Delegates[""{method.Name}""];
            var jsonResult = await func.Invoke({string.Join(", ", method.Parameters.Where(s=>s.Type.Name!="CancellationToken")
                .Select(static parameter => $@"args.{parameter.Name.ToPropertyName()}").Append("cancellationToken"))});

           #if NET6_0_OR_GREATER
            if(global::System.Text.Json.JsonSerializer.IsReflectionEnabledByDefault)
            {{
                #pragma disable warning IL2026, IL3050
                return global::System.Text.Json.JsonSerializer.Serialize(jsonResult, new global::System.Text.Json.JsonSerializerOptions
                {{
                    PropertyNamingPolicy = global::System.Text.Json.JsonNamingPolicy.CamelCase,
                    Converters = {{ new global::System.Text.Json.Serialization.JsonStringEnumConverter(global::System.Text.Json.JsonNamingPolicy.CamelCase) }},
                }});
                #pragma restore warning IL2026, IL3050
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
        
").Inject()}

{@interface.Methods.Where(static x => x is { IsAsync: true, IsVoid: true }).Select(method => $@"
        private async global::System.Threading.Tasks.Task<string> Call{method.Name}(            
            string json,
            global::System.Threading.CancellationToken cancellationToken = default)
        {{
            var args = As{method.Name}Args(json);
            //var func = (global::System.Func<{GetInputsTypes(method)}>) Delegates[""{method.Name}""];
            var func = (dynamic) Delegates[""{method.Name}""];
            await func.Invoke({string.Join(", ", method.Parameters.Where(s=>s.Type.Name!="CancellationToken").Select(static parameter => $@"args.{parameter.Name.ToPropertyName()}"))}, cancellationToken);

            return string.Empty;
        }}
").Inject()}

        public async global::System.Threading.Tasks.Task<string> CallAsync(            
            string functionName,
            string argumentsAsJson,
            global::System.Threading.CancellationToken cancellationToken = default)
        {{
            var calls = AsCalls();
            var func = calls[functionName];

            return await func(argumentsAsJson, cancellationToken);
        }}
    }}

    public partial class {extensionsClassName}JsonSerializerContext: global::System.Text.Json.Serialization.JsonSerializerContext
    {{            
    }}
}}
#pragma warning restore CS8602
";
        return res;
    }
}