﻿//HintName: IWeatherTools.g.cs
// <auto-generated/>

#nullable enable annotations
#nullable disable warnings

// Suppress warnings about [Obsolete] member usage in generated code.
#pragma warning disable CS0612, CS0618

namespace CSharpToJsonSchema.IntegrationTests
{
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("CSharpToJsonSchema.Generators", "0.0.0.0")]
    public partial class WeatherToolsExtensionsJsonSerializerContext
    {
        private readonly static global::System.Text.Json.JsonSerializerOptions s_defaultOptions = new(global::System.Text.Json.JsonSerializerDefaults.Web)
        {
            AllowOutOfOrderMetadataProperties = true,
            AllowTrailingCommas = false,
            DefaultBufferSize = 1024,
            DefaultIgnoreCondition = global::System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull,
            RespectNullableAnnotations = true,
            RespectRequiredConstructorParameters = false,
            IgnoreReadOnlyFields = false,
            IgnoreReadOnlyProperties = false,
            IncludeFields = false,
            MaxDepth = 64,
            NewLine = "\n",
            NumberHandling = global::System.Text.Json.Serialization.JsonNumberHandling.Strict,
            PreferredObjectCreationHandling = global::System.Text.Json.Serialization.JsonObjectCreationHandling.Replace,
            PropertyNameCaseInsensitive = false,
            PropertyNamingPolicy = global::System.Text.Json.JsonNamingPolicy.CamelCase,
            ReadCommentHandling = global::System.Text.Json.JsonCommentHandling.Disallow,
            UnknownTypeHandling = global::System.Text.Json.Serialization.JsonUnknownTypeHandling.JsonElement,
            UnmappedMemberHandling = global::System.Text.Json.Serialization.JsonUnmappedMemberHandling.Skip,
            WriteIndented = false,
            IndentCharacter = ' ',
            IndentSize = 2,
        };
        
        private const global::System.Reflection.BindingFlags InstanceMemberBindingFlags =
            global::System.Reflection.BindingFlags.Instance |
            global::System.Reflection.BindingFlags.Public |
            global::System.Reflection.BindingFlags.NonPublic;
        
        /// <summary>
        /// The default <see cref="global::System.Text.Json.Serialization.JsonSerializerContext"/> associated with a default <see cref="global::System.Text.Json.JsonSerializerOptions"/> instance.
        /// </summary>
        public static global::CSharpToJsonSchema.IntegrationTests.WeatherToolsExtensionsJsonSerializerContext Default { get; } = new global::CSharpToJsonSchema.IntegrationTests.WeatherToolsExtensionsJsonSerializerContext(new global::System.Text.Json.JsonSerializerOptions(s_defaultOptions));
        
        /// <summary>
        /// The source-generated options associated with this context.
        /// </summary>
        protected override global::System.Text.Json.JsonSerializerOptions? GeneratedSerializerOptions { get; } = s_defaultOptions;
        
        /// <inheritdoc/>
        public WeatherToolsExtensionsJsonSerializerContext() : base(null)
        {
        }
        
        /// <inheritdoc/>
        public WeatherToolsExtensionsJsonSerializerContext(global::System.Text.Json.JsonSerializerOptions options) : base(options)
        {
        }

        private static bool TryGetTypeInfoForRuntimeCustomConverter<TJsonMetadataType>(global::System.Text.Json.JsonSerializerOptions options, out global::System.Text.Json.Serialization.Metadata.JsonTypeInfo<TJsonMetadataType> jsonTypeInfo)
        {
            global::System.Text.Json.Serialization.JsonConverter? converter = GetRuntimeConverterForType(typeof(TJsonMetadataType), options);
            if (converter != null)
            {
                jsonTypeInfo = global::System.Text.Json.Serialization.Metadata.JsonMetadataServices.CreateValueInfo<TJsonMetadataType>(options, converter);
                return true;
            }
        
            jsonTypeInfo = null;
            return false;
        }
        
        private static global::System.Text.Json.Serialization.JsonConverter? GetRuntimeConverterForType(global::System.Type type, global::System.Text.Json.JsonSerializerOptions options)
        {
            for (int i = 0; i < options.Converters.Count; i++)
            {
                global::System.Text.Json.Serialization.JsonConverter? converter = options.Converters[i];
                if (converter?.CanConvert(type) == true)
                {
                    return ExpandConverter(type, converter, options, validateCanConvert: false);
                }
            }
        
            return null;
        }
        
        private static global::System.Text.Json.Serialization.JsonConverter ExpandConverter(global::System.Type type, global::System.Text.Json.Serialization.JsonConverter converter, global::System.Text.Json.JsonSerializerOptions options, bool validateCanConvert = true)
        {
            if (validateCanConvert && !converter.CanConvert(type))
            {
                throw new global::System.InvalidOperationException(string.Format("The converter '{0}' is not compatible with the type '{1}'.", converter.GetType(), type));
            }
        
            if (converter is global::System.Text.Json.Serialization.JsonConverterFactory factory)
            {
                converter = factory.CreateConverter(type, options);
                if (converter is null || converter is global::System.Text.Json.Serialization.JsonConverterFactory)
                {
                    throw new global::System.InvalidOperationException(string.Format("The converter '{0}' cannot return null or a JsonConverterFactory instance.", factory.GetType()));
                }
            }
        
            return converter;
        }
    }
}
