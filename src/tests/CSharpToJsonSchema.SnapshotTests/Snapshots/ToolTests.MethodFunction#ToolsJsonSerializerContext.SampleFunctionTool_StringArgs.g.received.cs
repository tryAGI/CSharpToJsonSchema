﻿//HintName: ToolsJsonSerializerContext.SampleFunctionTool_StringArgs.g.cs
// <auto-generated/>

#nullable enable annotations
#nullable disable warnings

// Suppress warnings about [Obsolete] member usage in generated code.
#pragma warning disable CS0612, CS0618

namespace CSharpToJsonSchema.IntegrationTests
{
    public partial class ToolsJsonSerializerContext
    {
        private global::System.Text.Json.Serialization.Metadata.JsonTypeInfo<global::CSharpToJsonSchema.IntegrationTests.SampleFunctionTool_StringArgs>? _SampleFunctionTool_StringArgs;
        
        /// <summary>
        /// Defines the source generated JSON serialization contract metadata for a given type.
        /// </summary>
        #nullable disable annotations // Marking the property type as nullable-oblivious.
        public global::System.Text.Json.Serialization.Metadata.JsonTypeInfo<global::CSharpToJsonSchema.IntegrationTests.SampleFunctionTool_StringArgs> SampleFunctionTool_StringArgs
        #nullable enable annotations
        {
            get => _SampleFunctionTool_StringArgs ??= (global::System.Text.Json.Serialization.Metadata.JsonTypeInfo<global::CSharpToJsonSchema.IntegrationTests.SampleFunctionTool_StringArgs>)Options.GetTypeInfo(typeof(global::CSharpToJsonSchema.IntegrationTests.SampleFunctionTool_StringArgs));
        }
        
        private global::System.Text.Json.Serialization.Metadata.JsonTypeInfo<global::CSharpToJsonSchema.IntegrationTests.SampleFunctionTool_StringArgs> Create_SampleFunctionTool_StringArgs(global::System.Text.Json.JsonSerializerOptions options)
        {
            if (!TryGetTypeInfoForRuntimeCustomConverter<global::CSharpToJsonSchema.IntegrationTests.SampleFunctionTool_StringArgs>(options, out global::System.Text.Json.Serialization.Metadata.JsonTypeInfo<global::CSharpToJsonSchema.IntegrationTests.SampleFunctionTool_StringArgs> jsonTypeInfo))
            {
                var objectInfo = new global::System.Text.Json.Serialization.Metadata.JsonObjectInfoValues<global::CSharpToJsonSchema.IntegrationTests.SampleFunctionTool_StringArgs>
                {
                    ObjectCreator = () => new global::CSharpToJsonSchema.IntegrationTests.SampleFunctionTool_StringArgs(),
                    ObjectWithParameterizedConstructorCreator = null,
                    PropertyMetadataInitializer = _ => SampleFunctionTool_StringArgsPropInit(options),
                    ConstructorParameterMetadataInitializer = null,
                    ConstructorAttributeProviderFactory = static () => typeof(global::CSharpToJsonSchema.IntegrationTests.SampleFunctionTool_StringArgs).GetConstructor(InstanceMemberBindingFlags, binder: null, global::System.Array.Empty<global::System.Type>(), modifiers: null),
                    SerializeHandler = SampleFunctionTool_StringArgsSerializeHandler,
                };
                
                jsonTypeInfo = global::System.Text.Json.Serialization.Metadata.JsonMetadataServices.CreateObjectInfo<global::CSharpToJsonSchema.IntegrationTests.SampleFunctionTool_StringArgs>(options, objectInfo);
                jsonTypeInfo.NumberHandling = null;
            }
        
            jsonTypeInfo.OriginatingResolver = this;
            return jsonTypeInfo;
        }

        private static global::System.Text.Json.Serialization.Metadata.JsonPropertyInfo[] SampleFunctionTool_StringArgsPropInit(global::System.Text.Json.JsonSerializerOptions options)
        {
            var properties = new global::System.Text.Json.Serialization.Metadata.JsonPropertyInfo[1];

            var info0 = new global::System.Text.Json.Serialization.Metadata.JsonPropertyInfoValues<string>
            {
                IsProperty = true,
                IsPublic = true,
                IsVirtual = false,
                DeclaringType = typeof(global::CSharpToJsonSchema.IntegrationTests.SampleFunctionTool_StringArgs),
                Converter = null,
                Getter = static obj => ((global::CSharpToJsonSchema.IntegrationTests.SampleFunctionTool_StringArgs)obj).Input,
                Setter = static (obj, value) => ((global::CSharpToJsonSchema.IntegrationTests.SampleFunctionTool_StringArgs)obj).Input = value!,
                IgnoreCondition = null,
                HasJsonInclude = false,
                IsExtensionData = false,
                NumberHandling = null,
                PropertyName = "Input",
                JsonPropertyName = null,
                AttributeProviderFactory = static () => typeof(global::CSharpToJsonSchema.IntegrationTests.SampleFunctionTool_StringArgs).GetProperty("Input", InstanceMemberBindingFlags, null, typeof(string), global::System.Array.Empty<global::System.Type>(), null),
            };
            
            properties[0] = global::System.Text.Json.Serialization.Metadata.JsonMetadataServices.CreatePropertyInfo<string>(options, info0);

            return properties;
        }

        // Intentionally not a static method because we create a delegate to it. Invoking delegates to instance
        // methods is almost as fast as virtual calls. Static methods need to go through a shuffle thunk.
        private void SampleFunctionTool_StringArgsSerializeHandler(global::System.Text.Json.Utf8JsonWriter writer, global::CSharpToJsonSchema.IntegrationTests.SampleFunctionTool_StringArgs? value)
        {
            if (value is null)
            {
                writer.WriteNullValue();
                return;
            }
            
            writer.WriteStartObject();

            string __value_Input = ((global::CSharpToJsonSchema.IntegrationTests.SampleFunctionTool_StringArgs)value).Input;
            if (__value_Input is not null)
            {
                writer.WriteString(PropName_input, __value_Input);
            }

            writer.WriteEndObject();
        }
    }
}
