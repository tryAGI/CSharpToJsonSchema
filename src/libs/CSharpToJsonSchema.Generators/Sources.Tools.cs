﻿using System.Text;
using CSharpToJsonSchema.Generators.Conversion;
using CSharpToJsonSchema.Generators.Models;
using H.Generators;
using H.Generators.Extensions;
using Microsoft.CodeAnalysis.CSharp;

namespace CSharpToJsonSchema.Generators;

internal static partial class Sources
{
    /// <summary>
    /// https://swagger.io/docs/specification/data-models/data-types/
    /// </summary>
    /// <param name="parameter"></param>
    /// <param name="depth"></param>
    /// <returns></returns>
    public static string GenerateOpenApiSchema(OpenApiSchema parameter, int depth = 0)
    {
        var indent = new string(' ', depth * 4);
        const string name = "global::CSharpToJsonSchema.OpenApiSchema";
        if (parameter.ArrayItem.Count != 0)
        {
            return $@"new {name}
{indent}                    {{
{indent}                        Type = ""{parameter.SchemaType}"",
{indent}                        Description = ""{parameter.Description}"",
{indent}                        Items = {GenerateOpenApiSchema(parameter.ArrayItem.First(), depth: depth + 1)},
{indent}                    }}";
        }
        if (parameter.Properties.Count != 0)
        {
            return $@"new {name}
{indent}                    {{
{indent}                        Type = ""{parameter.SchemaType}"",
{indent}                        Description = ""{parameter.Description}"",
{indent}                        Properties = new global::System.Collections.Generic.Dictionary<string, global::CSharpToJsonSchema.OpenApiSchema>
{indent}                        {{
{indent}                            {string.Join(",\n                            " + indent, parameter.Properties.Select(x => $@"[""{x.Name}""] = " + GenerateOpenApiSchema(x, depth: depth + 2)))}
{indent}                        }},
{indent}                        Required = new string[] {{ {string.Join(", ", parameter.Properties
                                    .Where(static x => x.IsRequired)
                                    .Select(static x => $"\"{x.Name}\""))} }},
{indent}                    }}";
        }

        if (parameter.EnumValues.Count != 0)
        {
            return $@"new {name}
{indent}                    {{
{indent}                        Type = ""{parameter.SchemaType}"",
{indent}                        Description = ""{parameter.Description}"",
{indent}                        Enum = new string[] {{ {string.Join(", ", parameter.EnumValues.Select(static x => $"\"{x}\""))} }},
{indent}                    }}";
        }

        return $@"new {name}
{indent}                    {{
{indent}                        Type = ""{parameter.SchemaType}"",{(parameter.Format != null ? $@"
{indent}                        Format = ""{parameter.Format}""," : "")}
{indent}                        Description = ""{parameter.Description}"",
{indent}                    }}";
    }

    public static string GenerateClientImplementation(InterfaceData @interface)
    {
        var extensionsClassName = @interface.Name.Substring(startIndex: 1) + "Extensions";

        return @$"
#nullable enable

namespace {@interface.Namespace}
{{
    public static partial class {extensionsClassName}
    {{
        public static global::System.Collections.Generic.IList<global::CSharpToJsonSchema.Tool> AsTools(this {@interface.Name} functions)
        {{
            return new global::System.Collections.Generic.List<global::CSharpToJsonSchema.Tool>
            {{
{@interface.Methods.Select(method => $@"
                new global::CSharpToJsonSchema.Tool
                {{
                    Name = ""{method.Name}"",
                    Description = ""{GetDescriptionStringAsValidCSharp(method.Description)}"",
                    Strict = {(method.IsStrict ? "true" : "false")},
                    Parameters = global::CSharpToJsonSchema.SchemaBuilder.ConvertToSchema(global::{@interface.Namespace}.{extensionsClassName}JsonSerializerContext.Default.{method.Name}Args,{"\""}{GetDictionaryString(method)}{"\""}),
                }},
").Inject()}
            }};
        }}
    }}
}}";
    }



    private static string GetDictionaryString(MethodData data)
    {
        StringBuilder sb = new StringBuilder();

        var methodDescriptions = new Dictionary<string, string>();
        methodDescriptions.Add("MainFunction_Desc", GetDescriptionStringAsValidCSharp(data.Description));
        sb.Append('{');
        var lst = methodDescriptions.Select(s => $"\"{s.Key.ToCamelCase()}\":\"{s.Value}\"");
        sb.Append(string.Join(", ", lst));
        sb.Append('}');

        return sb.ToString().Replace("\"", "\\\"");
    }

    public static string GetDescriptionStringAsValidCSharp(string description)
    {
        return SymbolDisplay.FormatLiteral(description, quote: false);
    }
}
