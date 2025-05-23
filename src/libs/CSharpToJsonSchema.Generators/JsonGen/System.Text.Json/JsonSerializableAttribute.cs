﻿namespace CSharpToJsonSchema.Generators.JsonGen.System.Text.Json;

sealed class JsonSerializableAttribute : JsonAttribute
{
#pragma warning disable IDE0060
    /// <summary>
    /// Initializes a new instance of <see cref="JsonSerializableAttribute"/> with the specified type.
    /// </summary>
    /// <param name="type">The type to generate source code for.</param>
    public JsonSerializableAttribute(Type type) { }
#pragma warning restore IDE0060

    /// <summary>
    /// The name of the property for the generated <see cref="JsonTypeInfo{T}"/> for
    /// the type on the generated, derived <see cref="JsonSerializerContext"/> type.
    /// </summary>
    /// <remarks>
    /// Useful to resolve a name collision with another type in the compilation closure.
    /// </remarks>
    public string? TypeInfoPropertyName { get; set; }

    /// <summary>
    /// Determines what the source generator should generate for the type. If the value is <see cref="JsonSourceGenerationMode.Default"/>,
    /// then the setting specified on <see cref="JsonSourceGenerationOptionsAttribute.GenerationMode"/> will be used.
    /// </summary>
    public JsonSourceGenerationMode GenerationMode { get; set; }
}