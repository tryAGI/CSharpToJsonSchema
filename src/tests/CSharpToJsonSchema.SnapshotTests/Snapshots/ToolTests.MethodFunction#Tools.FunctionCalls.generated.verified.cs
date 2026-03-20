//HintName: Tools.FunctionCalls.generated.cs
#nullable enable
   #pragma warning disable CS8602,CS8600

namespace CSharpToJsonSchema.IntegrationTests
{








    public class SampleFunctionTool_StringAsyncArgs
    {         
         [global::System.ComponentModel.Description("")]
          public string? Input { get; set; } = string.Empty;
    }

    public class SampleFunctionTool_NoReturnAsyncArgs
    {         
         [global::System.ComponentModel.Description("")]
          public string? Input { get; set; } = string.Empty;
    }

    public class SampleFunctionTool_VoidArgs
    {         
         [global::System.ComponentModel.Description("")]
          public string? Input { get; set; } = string.Empty;
    }

    public class SampleFunctionTool_StringArgs
    {         
         [global::System.ComponentModel.Description("")]
          public string? Input { get; set; } = string.Empty;
    }

    public class SampleFunctionTool_Static_StringAsyncArgs
    {         
         [global::System.ComponentModel.Description("")]
          public string? Input { get; set; } = string.Empty;
    }

    public class SampleFunctionTool_Static_NoReturnAsyncArgs
    {         
         [global::System.ComponentModel.Description("")]
          public string? Input { get; set; } = string.Empty;
    }

    public class SampleFunctionTool_Static_VoidArgs
    {         
         [global::System.ComponentModel.Description("")]
          public string? Input { get; set; } = string.Empty;
    }

    public class SampleFunctionTool_Static_StringArgs
    {         
         [global::System.ComponentModel.Description("")]
          public string? Input { get; set; } = string.Empty;
    }

    public partial class Tools
    {
        public global::System.Collections.Generic.IReadOnlyDictionary<string, global::System.Func<string, global::System.Threading.CancellationToken, global::System.Threading.Tasks.Task<string>>> AsCalls()
        {
            return new global::System.Collections.Generic.Dictionary<string, global::System.Func<string, global::System.Threading.CancellationToken, global::System.Threading.Tasks.Task<string>>>
            {
                ["SampleFunctionTool_String"] = (json, _) =>
                {
                    return global::System.Threading.Tasks.Task.FromResult(CallSampleFunctionTool_String(json));
                },

                ["SampleFunctionTool_Static_String"] = (json, _) =>
                {
                    return global::System.Threading.Tasks.Task.FromResult(CallSampleFunctionTool_Static_String(json));
                },
                ["SampleFunctionTool_Void"] = (json, _) =>
                {
                    CallSampleFunctionTool_Void(json);

                    return global::System.Threading.Tasks.Task.FromResult(string.Empty);
                },

                ["SampleFunctionTool_Static_Void"] = (json, _) =>
                {
                    CallSampleFunctionTool_Static_Void(json);

                    return global::System.Threading.Tasks.Task.FromResult(string.Empty);
                },
                ["SampleFunctionTool_StringAsync"] = async (json, cancellationToken) =>
                {
                    return await CallSampleFunctionTool_StringAsync(json, cancellationToken);
                },

                ["SampleFunctionTool_Static_StringAsync"] = async (json, cancellationToken) =>
                {
                    return await CallSampleFunctionTool_Static_StringAsync(json, cancellationToken);
                },
                ["SampleFunctionTool_NoReturnAsync"] = async (json, cancellationToken) =>
                {
                    await CallSampleFunctionTool_NoReturnAsync(json, cancellationToken);

                    return string.Empty;
                },

                ["SampleFunctionTool_Static_NoReturnAsync"] = async (json, cancellationToken) =>
                {
                    await CallSampleFunctionTool_Static_NoReturnAsync(json, cancellationToken);

                    return string.Empty;
                },
            };
        }

        private SampleFunctionTool_StringAsyncArgs AsSampleFunctionTool_StringAsyncArgs(            
            string json)
        {
            #if NET6_0_OR_GREATER
            if(global::System.Text.Json.JsonSerializer.IsReflectionEnabledByDefault)
            {
                #pragma warning disable IL2026, IL3050
                return global::System.Text.Json.JsonSerializer.Deserialize<SampleFunctionTool_StringAsyncArgs>(json, new global::System.Text.Json.JsonSerializerOptions
                {
                    PropertyNamingPolicy = global::System.Text.Json.JsonNamingPolicy.CamelCase,
                    Converters = {{ new global::System.Text.Json.Serialization.JsonStringEnumConverter(global::System.Text.Json.JsonNamingPolicy.CamelCase) }}
                }) ??
                throw new global::System.InvalidOperationException("Could not deserialize JSON.");
                #pragma warning restore IL2026, IL3050
            }
            else
            {
                return global::System.Text.Json.JsonSerializer.Deserialize(json, global::CSharpToJsonSchema.IntegrationTests.ToolsJsonSerializerContext.Default.SampleFunctionTool_StringAsyncArgs) ??
                throw new global::System.InvalidOperationException("Could not deserialize JSON.");
            }
            #else
            return
                global::System.Text.Json.JsonSerializer.Deserialize<SampleFunctionTool_StringAsyncArgs>(json, new global::System.Text.Json.JsonSerializerOptions
                {
                    PropertyNamingPolicy = global::System.Text.Json.JsonNamingPolicy.CamelCase,
                    Converters = {{ new global::System.Text.Json.Serialization.JsonStringEnumConverter(global::System.Text.Json.JsonNamingPolicy.CamelCase) }}
                }) ??
                throw new global::System.InvalidOperationException("Could not deserialize JSON.");
            #endif
        }

        private SampleFunctionTool_NoReturnAsyncArgs AsSampleFunctionTool_NoReturnAsyncArgs(            
            string json)
        {
            #if NET6_0_OR_GREATER
            if(global::System.Text.Json.JsonSerializer.IsReflectionEnabledByDefault)
            {
                #pragma warning disable IL2026, IL3050
                return global::System.Text.Json.JsonSerializer.Deserialize<SampleFunctionTool_NoReturnAsyncArgs>(json, new global::System.Text.Json.JsonSerializerOptions
                {
                    PropertyNamingPolicy = global::System.Text.Json.JsonNamingPolicy.CamelCase,
                    Converters = {{ new global::System.Text.Json.Serialization.JsonStringEnumConverter(global::System.Text.Json.JsonNamingPolicy.CamelCase) }}
                }) ??
                throw new global::System.InvalidOperationException("Could not deserialize JSON.");
                #pragma warning restore IL2026, IL3050
            }
            else
            {
                return global::System.Text.Json.JsonSerializer.Deserialize(json, global::CSharpToJsonSchema.IntegrationTests.ToolsJsonSerializerContext.Default.SampleFunctionTool_NoReturnAsyncArgs) ??
                throw new global::System.InvalidOperationException("Could not deserialize JSON.");
            }
            #else
            return
                global::System.Text.Json.JsonSerializer.Deserialize<SampleFunctionTool_NoReturnAsyncArgs>(json, new global::System.Text.Json.JsonSerializerOptions
                {
                    PropertyNamingPolicy = global::System.Text.Json.JsonNamingPolicy.CamelCase,
                    Converters = {{ new global::System.Text.Json.Serialization.JsonStringEnumConverter(global::System.Text.Json.JsonNamingPolicy.CamelCase) }}
                }) ??
                throw new global::System.InvalidOperationException("Could not deserialize JSON.");
            #endif
        }

        private SampleFunctionTool_VoidArgs AsSampleFunctionTool_VoidArgs(            
            string json)
        {
            #if NET6_0_OR_GREATER
            if(global::System.Text.Json.JsonSerializer.IsReflectionEnabledByDefault)
            {
                #pragma warning disable IL2026, IL3050
                return global::System.Text.Json.JsonSerializer.Deserialize<SampleFunctionTool_VoidArgs>(json, new global::System.Text.Json.JsonSerializerOptions
                {
                    PropertyNamingPolicy = global::System.Text.Json.JsonNamingPolicy.CamelCase,
                    Converters = {{ new global::System.Text.Json.Serialization.JsonStringEnumConverter(global::System.Text.Json.JsonNamingPolicy.CamelCase) }}
                }) ??
                throw new global::System.InvalidOperationException("Could not deserialize JSON.");
                #pragma warning restore IL2026, IL3050
            }
            else
            {
                return global::System.Text.Json.JsonSerializer.Deserialize(json, global::CSharpToJsonSchema.IntegrationTests.ToolsJsonSerializerContext.Default.SampleFunctionTool_VoidArgs) ??
                throw new global::System.InvalidOperationException("Could not deserialize JSON.");
            }
            #else
            return
                global::System.Text.Json.JsonSerializer.Deserialize<SampleFunctionTool_VoidArgs>(json, new global::System.Text.Json.JsonSerializerOptions
                {
                    PropertyNamingPolicy = global::System.Text.Json.JsonNamingPolicy.CamelCase,
                    Converters = {{ new global::System.Text.Json.Serialization.JsonStringEnumConverter(global::System.Text.Json.JsonNamingPolicy.CamelCase) }}
                }) ??
                throw new global::System.InvalidOperationException("Could not deserialize JSON.");
            #endif
        }

        private SampleFunctionTool_StringArgs AsSampleFunctionTool_StringArgs(            
            string json)
        {
            #if NET6_0_OR_GREATER
            if(global::System.Text.Json.JsonSerializer.IsReflectionEnabledByDefault)
            {
                #pragma warning disable IL2026, IL3050
                return global::System.Text.Json.JsonSerializer.Deserialize<SampleFunctionTool_StringArgs>(json, new global::System.Text.Json.JsonSerializerOptions
                {
                    PropertyNamingPolicy = global::System.Text.Json.JsonNamingPolicy.CamelCase,
                    Converters = {{ new global::System.Text.Json.Serialization.JsonStringEnumConverter(global::System.Text.Json.JsonNamingPolicy.CamelCase) }}
                }) ??
                throw new global::System.InvalidOperationException("Could not deserialize JSON.");
                #pragma warning restore IL2026, IL3050
            }
            else
            {
                return global::System.Text.Json.JsonSerializer.Deserialize(json, global::CSharpToJsonSchema.IntegrationTests.ToolsJsonSerializerContext.Default.SampleFunctionTool_StringArgs) ??
                throw new global::System.InvalidOperationException("Could not deserialize JSON.");
            }
            #else
            return
                global::System.Text.Json.JsonSerializer.Deserialize<SampleFunctionTool_StringArgs>(json, new global::System.Text.Json.JsonSerializerOptions
                {
                    PropertyNamingPolicy = global::System.Text.Json.JsonNamingPolicy.CamelCase,
                    Converters = {{ new global::System.Text.Json.Serialization.JsonStringEnumConverter(global::System.Text.Json.JsonNamingPolicy.CamelCase) }}
                }) ??
                throw new global::System.InvalidOperationException("Could not deserialize JSON.");
            #endif
        }

        private SampleFunctionTool_Static_StringAsyncArgs AsSampleFunctionTool_Static_StringAsyncArgs(            
            string json)
        {
            #if NET6_0_OR_GREATER
            if(global::System.Text.Json.JsonSerializer.IsReflectionEnabledByDefault)
            {
                #pragma warning disable IL2026, IL3050
                return global::System.Text.Json.JsonSerializer.Deserialize<SampleFunctionTool_Static_StringAsyncArgs>(json, new global::System.Text.Json.JsonSerializerOptions
                {
                    PropertyNamingPolicy = global::System.Text.Json.JsonNamingPolicy.CamelCase,
                    Converters = {{ new global::System.Text.Json.Serialization.JsonStringEnumConverter(global::System.Text.Json.JsonNamingPolicy.CamelCase) }}
                }) ??
                throw new global::System.InvalidOperationException("Could not deserialize JSON.");
                #pragma warning restore IL2026, IL3050
            }
            else
            {
                return global::System.Text.Json.JsonSerializer.Deserialize(json, global::CSharpToJsonSchema.IntegrationTests.ToolsJsonSerializerContext.Default.SampleFunctionTool_Static_StringAsyncArgs) ??
                throw new global::System.InvalidOperationException("Could not deserialize JSON.");
            }
            #else
            return
                global::System.Text.Json.JsonSerializer.Deserialize<SampleFunctionTool_Static_StringAsyncArgs>(json, new global::System.Text.Json.JsonSerializerOptions
                {
                    PropertyNamingPolicy = global::System.Text.Json.JsonNamingPolicy.CamelCase,
                    Converters = {{ new global::System.Text.Json.Serialization.JsonStringEnumConverter(global::System.Text.Json.JsonNamingPolicy.CamelCase) }}
                }) ??
                throw new global::System.InvalidOperationException("Could not deserialize JSON.");
            #endif
        }

        private SampleFunctionTool_Static_NoReturnAsyncArgs AsSampleFunctionTool_Static_NoReturnAsyncArgs(            
            string json)
        {
            #if NET6_0_OR_GREATER
            if(global::System.Text.Json.JsonSerializer.IsReflectionEnabledByDefault)
            {
                #pragma warning disable IL2026, IL3050
                return global::System.Text.Json.JsonSerializer.Deserialize<SampleFunctionTool_Static_NoReturnAsyncArgs>(json, new global::System.Text.Json.JsonSerializerOptions
                {
                    PropertyNamingPolicy = global::System.Text.Json.JsonNamingPolicy.CamelCase,
                    Converters = {{ new global::System.Text.Json.Serialization.JsonStringEnumConverter(global::System.Text.Json.JsonNamingPolicy.CamelCase) }}
                }) ??
                throw new global::System.InvalidOperationException("Could not deserialize JSON.");
                #pragma warning restore IL2026, IL3050
            }
            else
            {
                return global::System.Text.Json.JsonSerializer.Deserialize(json, global::CSharpToJsonSchema.IntegrationTests.ToolsJsonSerializerContext.Default.SampleFunctionTool_Static_NoReturnAsyncArgs) ??
                throw new global::System.InvalidOperationException("Could not deserialize JSON.");
            }
            #else
            return
                global::System.Text.Json.JsonSerializer.Deserialize<SampleFunctionTool_Static_NoReturnAsyncArgs>(json, new global::System.Text.Json.JsonSerializerOptions
                {
                    PropertyNamingPolicy = global::System.Text.Json.JsonNamingPolicy.CamelCase,
                    Converters = {{ new global::System.Text.Json.Serialization.JsonStringEnumConverter(global::System.Text.Json.JsonNamingPolicy.CamelCase) }}
                }) ??
                throw new global::System.InvalidOperationException("Could not deserialize JSON.");
            #endif
        }

        private SampleFunctionTool_Static_VoidArgs AsSampleFunctionTool_Static_VoidArgs(            
            string json)
        {
            #if NET6_0_OR_GREATER
            if(global::System.Text.Json.JsonSerializer.IsReflectionEnabledByDefault)
            {
                #pragma warning disable IL2026, IL3050
                return global::System.Text.Json.JsonSerializer.Deserialize<SampleFunctionTool_Static_VoidArgs>(json, new global::System.Text.Json.JsonSerializerOptions
                {
                    PropertyNamingPolicy = global::System.Text.Json.JsonNamingPolicy.CamelCase,
                    Converters = {{ new global::System.Text.Json.Serialization.JsonStringEnumConverter(global::System.Text.Json.JsonNamingPolicy.CamelCase) }}
                }) ??
                throw new global::System.InvalidOperationException("Could not deserialize JSON.");
                #pragma warning restore IL2026, IL3050
            }
            else
            {
                return global::System.Text.Json.JsonSerializer.Deserialize(json, global::CSharpToJsonSchema.IntegrationTests.ToolsJsonSerializerContext.Default.SampleFunctionTool_Static_VoidArgs) ??
                throw new global::System.InvalidOperationException("Could not deserialize JSON.");
            }
            #else
            return
                global::System.Text.Json.JsonSerializer.Deserialize<SampleFunctionTool_Static_VoidArgs>(json, new global::System.Text.Json.JsonSerializerOptions
                {
                    PropertyNamingPolicy = global::System.Text.Json.JsonNamingPolicy.CamelCase,
                    Converters = {{ new global::System.Text.Json.Serialization.JsonStringEnumConverter(global::System.Text.Json.JsonNamingPolicy.CamelCase) }}
                }) ??
                throw new global::System.InvalidOperationException("Could not deserialize JSON.");
            #endif
        }

        private SampleFunctionTool_Static_StringArgs AsSampleFunctionTool_Static_StringArgs(            
            string json)
        {
            #if NET6_0_OR_GREATER
            if(global::System.Text.Json.JsonSerializer.IsReflectionEnabledByDefault)
            {
                #pragma warning disable IL2026, IL3050
                return global::System.Text.Json.JsonSerializer.Deserialize<SampleFunctionTool_Static_StringArgs>(json, new global::System.Text.Json.JsonSerializerOptions
                {
                    PropertyNamingPolicy = global::System.Text.Json.JsonNamingPolicy.CamelCase,
                    Converters = {{ new global::System.Text.Json.Serialization.JsonStringEnumConverter(global::System.Text.Json.JsonNamingPolicy.CamelCase) }}
                }) ??
                throw new global::System.InvalidOperationException("Could not deserialize JSON.");
                #pragma warning restore IL2026, IL3050
            }
            else
            {
                return global::System.Text.Json.JsonSerializer.Deserialize(json, global::CSharpToJsonSchema.IntegrationTests.ToolsJsonSerializerContext.Default.SampleFunctionTool_Static_StringArgs) ??
                throw new global::System.InvalidOperationException("Could not deserialize JSON.");
            }
            #else
            return
                global::System.Text.Json.JsonSerializer.Deserialize<SampleFunctionTool_Static_StringArgs>(json, new global::System.Text.Json.JsonSerializerOptions
                {
                    PropertyNamingPolicy = global::System.Text.Json.JsonNamingPolicy.CamelCase,
                    Converters = {{ new global::System.Text.Json.Serialization.JsonStringEnumConverter(global::System.Text.Json.JsonNamingPolicy.CamelCase) }}
                }) ??
                throw new global::System.InvalidOperationException("Could not deserialize JSON.");
            #endif
        }

        private string CallSampleFunctionTool_String(string json)
        {
            var args = AsSampleFunctionTool_StringArgs(json);
            var func = Delegates["SampleFunctionTool_String"];
            var jsonResult = (string) func.DynamicInvoke(args.Input);

     #if NET6_0_OR_GREATER
            if(global::System.Text.Json.JsonSerializer.IsReflectionEnabledByDefault)
            {
                #pragma warning disable IL2026, IL3050
                return global::System.Text.Json.JsonSerializer.Serialize(jsonResult, new global::System.Text.Json.JsonSerializerOptions
                {
                    PropertyNamingPolicy = global::System.Text.Json.JsonNamingPolicy.CamelCase,
                    Converters = { new global::System.Text.Json.Serialization.JsonStringEnumConverter(global::System.Text.Json.JsonNamingPolicy.CamelCase) },
                });
                #pragma warning restore IL2026, IL3050  
            }
            else
            {
                return global::System.Text.Json.JsonSerializer.Serialize(jsonResult, global::CSharpToJsonSchema.IntegrationTests.ToolsJsonSerializerContext.Default.GetTypeInfo(jsonResult.GetType()));       
            }
            #else            
              return global::System.Text.Json.JsonSerializer.Serialize(jsonResult, new global::System.Text.Json.JsonSerializerOptions
                {
                    PropertyNamingPolicy = global::System.Text.Json.JsonNamingPolicy.CamelCase,
                    Converters = { new global::System.Text.Json.Serialization.JsonStringEnumConverter(global::System.Text.Json.JsonNamingPolicy.CamelCase) },
                });
            #endif            
        }

        private string CallSampleFunctionTool_Static_String(string json)
        {
            var args = AsSampleFunctionTool_Static_StringArgs(json);
            var func = Delegates["SampleFunctionTool_Static_String"];
            var jsonResult = (string) func.DynamicInvoke(args.Input);

     #if NET6_0_OR_GREATER
            if(global::System.Text.Json.JsonSerializer.IsReflectionEnabledByDefault)
            {
                #pragma warning disable IL2026, IL3050
                return global::System.Text.Json.JsonSerializer.Serialize(jsonResult, new global::System.Text.Json.JsonSerializerOptions
                {
                    PropertyNamingPolicy = global::System.Text.Json.JsonNamingPolicy.CamelCase,
                    Converters = { new global::System.Text.Json.Serialization.JsonStringEnumConverter(global::System.Text.Json.JsonNamingPolicy.CamelCase) },
                });
                #pragma warning restore IL2026, IL3050  
            }
            else
            {
                return global::System.Text.Json.JsonSerializer.Serialize(jsonResult, global::CSharpToJsonSchema.IntegrationTests.ToolsJsonSerializerContext.Default.GetTypeInfo(jsonResult.GetType()));       
            }
            #else            
              return global::System.Text.Json.JsonSerializer.Serialize(jsonResult, new global::System.Text.Json.JsonSerializerOptions
                {
                    PropertyNamingPolicy = global::System.Text.Json.JsonNamingPolicy.CamelCase,
                    Converters = { new global::System.Text.Json.Serialization.JsonStringEnumConverter(global::System.Text.Json.JsonNamingPolicy.CamelCase) },
                });
            #endif            
        }
        private void CallSampleFunctionTool_Void(string json)
        {
            var func = Delegates["SampleFunctionTool_Void"];
            var args = AsSampleFunctionTool_VoidArgs(json);
            func.DynamicInvoke(args.Input);
        }

        private void CallSampleFunctionTool_Static_Void(string json)
        {
            var func = Delegates["SampleFunctionTool_Static_Void"];
            var args = AsSampleFunctionTool_Static_VoidArgs(json);
            func.DynamicInvoke(args.Input);
        }

        private async global::System.Threading.Tasks.Task<string> CallSampleFunctionTool_StringAsync(
            string json,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            var args = AsSampleFunctionTool_StringAsyncArgs(json);
            var func = Delegates["SampleFunctionTool_StringAsync"];
            var jsonResult = await ((global::System.Threading.Tasks.Task<string>)func.DynamicInvoke(args.Input, cancellationToken));

           #if NET6_0_OR_GREATER
            if(global::System.Text.Json.JsonSerializer.IsReflectionEnabledByDefault)
            {
                #pragma warning disable IL2026, IL3050
                return global::System.Text.Json.JsonSerializer.Serialize(jsonResult, new global::System.Text.Json.JsonSerializerOptions
                {
                    PropertyNamingPolicy = global::System.Text.Json.JsonNamingPolicy.CamelCase,
                    Converters = { new global::System.Text.Json.Serialization.JsonStringEnumConverter(global::System.Text.Json.JsonNamingPolicy.CamelCase) },
                });
                #pragma warning restore IL2026, IL3050
            }
            else
            {
                return global::System.Text.Json.JsonSerializer.Serialize(jsonResult, global::CSharpToJsonSchema.IntegrationTests.ToolsJsonSerializerContext.Default.GetTypeInfo(jsonResult.GetType()));       
            }
            #else
            return global::System.Text.Json.JsonSerializer.Serialize(jsonResult, new global::System.Text.Json.JsonSerializerOptions
            {
                PropertyNamingPolicy = global::System.Text.Json.JsonNamingPolicy.CamelCase,
                Converters = { new global::System.Text.Json.Serialization.JsonStringEnumConverter(global::System.Text.Json.JsonNamingPolicy.CamelCase) },
            });
            #endif
            
        }
        

        private async global::System.Threading.Tasks.Task<string> CallSampleFunctionTool_Static_StringAsync(
            string json,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            var args = AsSampleFunctionTool_Static_StringAsyncArgs(json);
            var func = Delegates["SampleFunctionTool_Static_StringAsync"];
            var jsonResult = await ((global::System.Threading.Tasks.Task<string>)func.DynamicInvoke(args.Input, cancellationToken));

           #if NET6_0_OR_GREATER
            if(global::System.Text.Json.JsonSerializer.IsReflectionEnabledByDefault)
            {
                #pragma warning disable IL2026, IL3050
                return global::System.Text.Json.JsonSerializer.Serialize(jsonResult, new global::System.Text.Json.JsonSerializerOptions
                {
                    PropertyNamingPolicy = global::System.Text.Json.JsonNamingPolicy.CamelCase,
                    Converters = { new global::System.Text.Json.Serialization.JsonStringEnumConverter(global::System.Text.Json.JsonNamingPolicy.CamelCase) },
                });
                #pragma warning restore IL2026, IL3050
            }
            else
            {
                return global::System.Text.Json.JsonSerializer.Serialize(jsonResult, global::CSharpToJsonSchema.IntegrationTests.ToolsJsonSerializerContext.Default.GetTypeInfo(jsonResult.GetType()));       
            }
            #else
            return global::System.Text.Json.JsonSerializer.Serialize(jsonResult, new global::System.Text.Json.JsonSerializerOptions
            {
                PropertyNamingPolicy = global::System.Text.Json.JsonNamingPolicy.CamelCase,
                Converters = { new global::System.Text.Json.Serialization.JsonStringEnumConverter(global::System.Text.Json.JsonNamingPolicy.CamelCase) },
            });
            #endif
            
        }
        

        private async global::System.Threading.Tasks.Task<string> CallSampleFunctionTool_NoReturnAsync(            
            string json,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            var args = AsSampleFunctionTool_NoReturnAsyncArgs(json);
            var func = Delegates["SampleFunctionTool_NoReturnAsync"];
            await ((global::System.Threading.Tasks.Task)func.DynamicInvoke(args.Input, cancellationToken));

            return string.Empty;
        }

        private async global::System.Threading.Tasks.Task<string> CallSampleFunctionTool_Static_NoReturnAsync(            
            string json,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            var args = AsSampleFunctionTool_Static_NoReturnAsyncArgs(json);
            var func = Delegates["SampleFunctionTool_Static_NoReturnAsync"];
            await ((global::System.Threading.Tasks.Task)func.DynamicInvoke(args.Input, cancellationToken));

            return string.Empty;
        }

        public async global::System.Threading.Tasks.Task<string> CallAsync(            
            string functionName,
            string argumentsAsJson,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            var calls = AsCalls();
            var func = calls[functionName];

            return await func(argumentsAsJson, cancellationToken);
        }
    }

    public partial class ToolsJsonSerializerContext: global::System.Text.Json.Serialization.JsonSerializerContext
    {            
    }
}
#pragma warning restore CS8602,CS8600
