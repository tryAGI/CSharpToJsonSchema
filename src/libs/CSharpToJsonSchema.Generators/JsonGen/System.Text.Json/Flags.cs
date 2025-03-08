namespace CSharpToJsonSchema.Generators.JsonGen.System.Text.Json;


/// <summary>
/// The generation mode for the System.Text.Json source generator.
/// </summary>
[Flags]
public enum JsonSourceGenerationMode
{
    /// <summary>
    /// When specified on <see cref="JsonSourceGenerationOptionsAttribute.GenerationMode"/>, indicates that both type-metadata initialization logic
    /// and optimized serialization logic should be generated for all types. When specified on <see cref="JsonSerializableAttribute.GenerationMode"/>,
    /// indicates that the setting on <see cref="JsonSourceGenerationOptionsAttribute.GenerationMode"/> should be used.
    /// </summary>
    Default = 0,

    /// <summary>
    /// Instructs the JSON source generator to generate type-metadata initialization logic.
    /// </summary>
    /// <remarks>
    /// This mode supports all <see cref="JsonSerializer"/> features.
    /// </remarks>
    Metadata = 1,

    /// <summary>
    /// Instructs the JSON source generator to generate optimized serialization logic.
    /// </summary>
    /// <remarks>
    /// This mode supports only a subset of <see cref="JsonSerializer"/> features.
    /// </remarks>
    Serialization = 2
}

 /// <summary>
 /// Determines how <see cref="JsonSerializer"/> handles numbers when serializing and deserializing.
 /// <remarks>
 /// The behavior of <see cref="WriteAsString"/> and <see cref="AllowNamedFloatingPointLiterals"/> is not defined by the JSON specification. Altering the default number handling can potentially produce JSON that cannot be parsed by other JSON implementations.
 /// </remarks>
 /// </summary>
 [Flags]
 public enum JsonNumberHandling
 {
     /// <summary>
     /// Numbers will only be read from <see cref="JsonTokenType.Number"/> tokens and will only be written as JSON numbers (without quotes).
     /// </summary>
     Strict = 0x0,

     /// <summary>
     /// Numbers can be read from <see cref="JsonTokenType.String"/> tokens.
     /// Does not prevent numbers from being read from <see cref="JsonTokenType.Number"/> token.
     /// Strings that have escaped characters will be unescaped before reading.
     /// Leading or trailing trivia within the string token, including whitespace, is not allowed.
     /// </summary>
     AllowReadingFromString = 0x1,

     /// <summary>
     /// Numbers will be written as JSON strings (with quotes), not as JSON numbers.
     /// <remarks>
     /// This behavior is not defined by the JSON specification. Altering the default number handling can potentially produce JSON that cannot be parsed by other JSON implementations.
     /// </remarks>
     /// </summary>
     WriteAsString = 0x2,

     /// <summary>
     /// The "NaN", "Infinity", and "-Infinity" <see cref="JsonTokenType.String"/> tokens can be read as
     /// floating-point constants, and the <see cref="float"/> and <see cref="double"/> values for these
     /// constants (such as <see cref="float.PositiveInfinity"/> and <see cref="double.NaN"/>)
     /// will be written as their corresponding JSON string representations.
     /// Strings that have escaped characters will be unescaped before reading.
     /// Leading or trailing trivia within the string token, including whitespace, is not allowed.
     /// <remarks>
     /// This behavior is not defined by the JSON specification. Altering the default number handling can potentially produce JSON that cannot be parsed by other JSON implementations.
     /// </remarks>
     /// </summary>
     AllowNamedFloatingPointLiterals = 0x4
 }
 
 /// <summary>
 /// Determines how deserialization will handle object creation for fields or properties.
 /// </summary>
 public enum JsonObjectCreationHandling
 {
     /// <summary>
     /// A new instance will always be created when deserializing a field or property.
     /// </summary>
     Replace = 0,

     /// <summary>
     /// Attempt to populate any instances already found on a deserialized field or property.
     /// </summary>
     Populate = 1,
 }
 
 /// <summary>
 /// Determines how <see cref="JsonSerializer"/> handles JSON properties that
 /// cannot be mapped to a specific .NET member when deserializing object types.
 /// </summary>
 public enum JsonUnmappedMemberHandling
 {
     /// <summary>
     /// Silently skips any unmapped properties. This is the default behavior.
     /// </summary>
     Skip = 0,

     /// <summary>
     /// Throws an exception when an unmapped property is encountered.
     /// </summary>
     Disallow = 1,
 }
 
 /// <summary>
 /// This enum defines the various ways the <see cref="Utf8JsonReader"/> can deal with comments.
 /// </summary>
 public enum JsonCommentHandling : byte
 {
     /// <summary>
     /// By default, do no allow comments within the JSON input.
     /// Comments are treated as invalid JSON if found and a
     /// <see cref="JsonException"/> is thrown.
     /// </summary>
     Disallow = 0,
     /// <summary>
     /// Allow comments within the JSON input and ignore them.
     /// The <see cref="Utf8JsonReader"/> will behave as if no comments were present.
     /// </summary>
     Skip = 1,
     /// <summary>
     /// Allow comments within the JSON input and treat them as valid tokens.
     /// While reading, the caller will be able to access the comment values.
     /// </summary>
     Allow = 2,
 }
 
 /// <summary>
 /// Defines how deserializing a type declared as an <see cref="object"/> is handled during deserialization.
 /// </summary>
 public enum JsonUnknownTypeHandling
 {
     /// <summary>
     /// A type declared as <see cref="object"/> is deserialized as a <see cref="JsonElement"/>.
     /// </summary>
     JsonElement = 0,
     /// <summary>
     /// A type declared as <see cref="object"/> is deserialized as a <see cref="JsonNode"/>.
     /// </summary>
     JsonNode = 1
 }
 
 /// <summary>
 /// When specified on <see cref="JsonSerializerOptions.DefaultIgnoreCondition"/>,
 /// determines when properties and fields across the type graph are ignored.
 /// When specified on <see cref="JsonIgnoreAttribute.Condition"/>, controls whether
 /// a property or field is ignored during serialization and deserialization. This option
 /// overrides the setting on <see cref="JsonSerializerOptions.DefaultIgnoreCondition"/>.
 /// </summary>
 public enum JsonIgnoreCondition
 {
     /// <summary>
     /// Property is never ignored during serialization or deserialization.
     /// </summary>
     Never = 0,
     /// <summary>
     /// Property is always ignored during serialization and deserialization.
     /// </summary>
     Always = 1,
     /// <summary>
     /// If the value is the default, the property is ignored during serialization.
     /// This is applied to both reference and value-type properties and fields.
     /// </summary>
     WhenWritingDefault = 2,
     /// <summary>
     /// If the value is <see langword="null"/>, the property is ignored during serialization.
     /// This is applied only to reference-type properties and fields.
     /// </summary>
     WhenWritingNull = 3,
     /// <summary>
     /// Property is ignored during serialization
     /// </summary>
     WhenWriting = 4,
     /// <summary>
     /// Property is ignored during deserialization
     /// </summary>
     WhenReading = 5,
 }
 
 /// <summary>
 /// Signifies what default options are used by <see cref="JsonSerializerOptions"/>.
 /// </summary>
 public enum JsonSerializerDefaults
 {
     /// <summary>
     /// Specifies that general-purpose values should be used. These are the same settings applied if a <see cref="JsonSerializerDefaults"/> isn't specified.
     /// </summary>
     /// <remarks>
     /// This option implies that property names are treated as case-sensitive and that "PascalCase" name formatting should be employed.
     /// </remarks>
     General = 0,
     /// <summary>
     /// Specifies that values should be used more appropriate to web-based scenarios.
     /// </summary>
     /// <remarks>
     /// This option implies that property names are treated as case-insensitive and that "camelCase" name formatting should be employed.
     /// </remarks>
     Web = 1
 }
 
 /// <summary>
 /// The <see cref="ReferenceHandler"/> to be used at run time.
 /// </summary>
 public enum JsonKnownReferenceHandler
 {
     /// <summary>
     /// Specifies that circular references should throw exceptions.
     /// </summary>
     Unspecified = 0,

     /// <summary>
     /// Specifies that the built-in <see cref="ReferenceHandler.Preserve"/> be used to handle references.
     /// </summary>
     Preserve = 1,

     /// <summary>
     /// Specifies that the built-in <see cref="ReferenceHandler.IgnoreCycles"/> be used to ignore cyclic references.
     /// </summary>
     IgnoreCycles = 2,
 }
 
 /// <summary>
 /// The <see cref="Json.JsonNamingPolicy"/> to be used at run time.
 /// </summary>
 public enum JsonKnownNamingPolicy
 {
     /// <summary>
     /// Specifies that JSON property names should not be converted.
     /// </summary>
     Unspecified = 0,

     /// <summary>
     /// Specifies that the built-in <see cref="Json.JsonNamingPolicy.CamelCase"/> be used to convert JSON property names.
     /// </summary>
     CamelCase = 1,

     /// <summary>
     /// Specifies that the built-in <see cref="Json.JsonNamingPolicy.SnakeCaseLower"/> be used to convert JSON property names.
     /// </summary>
     SnakeCaseLower = 2,

     /// <summary>
     /// Specifies that the built-in <see cref="Json.JsonNamingPolicy.SnakeCaseUpper"/> be used to convert JSON property names.
     /// </summary>
     SnakeCaseUpper = 3,

     /// <summary>
     /// Specifies that the built-in <see cref="Json.JsonNamingPolicy.KebabCaseLower"/> be used to convert JSON property names.
     /// </summary>
     KebabCaseLower = 4,

     /// <summary>
     /// Specifies that the built-in <see cref="Json.JsonNamingPolicy.KebabCaseUpper"/> be used to convert JSON property names.
     /// </summary>
     KebabCaseUpper = 5
 }