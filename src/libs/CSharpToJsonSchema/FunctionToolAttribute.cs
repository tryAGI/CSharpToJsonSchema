namespace CSharpToJsonSchema;

/// <summary>
/// 
/// </summary>
[AttributeUsage(AttributeTargets.Method)]
[System.Diagnostics.Conditional("GENERATE_JSON_SCHEMA_ATTRIBUTES")]
public sealed class FunctionToolAttribute : Attribute
{
    /// <summary>
    /// 
    /// </summary>
    public bool Strict { get; set; }
    
    /// <summary>
    /// Generate Google Function Tools extensions for Google_GenerativeAI SDK
    /// </summary>
    public bool GoogleFunctionTool { get; set; }
}