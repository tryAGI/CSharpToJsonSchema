﻿//HintName: IVariousTypesTools.Tools.generated.cs

#nullable enable

namespace CSharpToJsonSchema.IntegrationTests
{
    public static partial class VariousTypesToolsExtensions
    {
        public static global::System.Collections.Generic.IList<global::CSharpToJsonSchema.Tool> AsTools(this IVariousTypesTools functions)
        {
            return new global::System.Collections.Generic.List<global::CSharpToJsonSchema.Tool>
            {
                new global::CSharpToJsonSchema.Tool
                {
                    Name = "GetCurrentWeather3",
                    Description = "Get the current weather in a given location",
                    Strict = false,
                    Parameters = new global::CSharpToJsonSchema.OpenApiSchema
                    {
                        Type = "object",
                        Description = "Get the current weather in a given location",
                        Properties = new global::System.Collections.Generic.Dictionary<string, global::CSharpToJsonSchema.OpenApiSchema>
                        {
                            ["parameter1"] = new global::CSharpToJsonSchema.OpenApiSchema
                            {
                                Type = "integer",
                                Format = "int64",
                                Description = "",
                            },
                            ["parameter2"] = new global::CSharpToJsonSchema.OpenApiSchema
                            {
                                Type = "integer",
                                Format = "int32",
                                Description = "",
                            },
                            ["parameter3"] = new global::CSharpToJsonSchema.OpenApiSchema
                            {
                                Type = "number",
                                Format = "float",
                                Description = "",
                            },
                            ["parameter4"] = new global::CSharpToJsonSchema.OpenApiSchema
                            {
                                Type = "number",
                                Format = "double",
                                Description = "",
                            },
                            ["parameter5"] = new global::CSharpToJsonSchema.OpenApiSchema
                            {
                                Type = "boolean",
                                Description = "",
                            },
                            ["dateTime"] = new global::CSharpToJsonSchema.OpenApiSchema
                            {
                                Type = "string",
                                Format = "date-time",
                                Description = "",
                            },
                            ["date"] = new global::CSharpToJsonSchema.OpenApiSchema
                            {
                                Type = "string",
                                Format = "date",
                                Description = "",
                            }
                        },
                        Required = new string[] { "parameter1", "parameter2", "parameter3", "parameter4", "parameter5", "dateTime", "date" },
                    },
                },

                new global::CSharpToJsonSchema.Tool
                {
                    Name = "SetValue",
                    Description = "Sets the value",
                    Strict = false,
                    Parameters = new global::CSharpToJsonSchema.OpenApiSchema
                    {
                        Type = "object",
                        Description = "Sets the value",
                        Properties = new global::System.Collections.Generic.Dictionary<string, global::CSharpToJsonSchema.OpenApiSchema>
                        {
                            ["value"] = new global::CSharpToJsonSchema.OpenApiSchema
                            {
                                Type = "integer",
                                Format = "int32",
                                Description = "",
                            }
                        },
                        Required = new string[] { "value" },
                    },
                },

                new global::CSharpToJsonSchema.Tool
                {
                    Name = "GetValue",
                    Description = "Gets the value",
                    Strict = false,
                    Parameters = new global::CSharpToJsonSchema.OpenApiSchema
                    {
                        Type = "object",
                        Description = "Gets the value",
                    },
                },

                new global::CSharpToJsonSchema.Tool
                {
                    Name = "SetValueAsync",
                    Description = "Sets the value",
                    Strict = false,
                    Parameters = new global::CSharpToJsonSchema.OpenApiSchema
                    {
                        Type = "object",
                        Description = "Sets the value",
                        Properties = new global::System.Collections.Generic.Dictionary<string, global::CSharpToJsonSchema.OpenApiSchema>
                        {
                            ["value"] = new global::CSharpToJsonSchema.OpenApiSchema
                            {
                                Type = "integer",
                                Format = "int32",
                                Description = "",
                            }
                        },
                        Required = new string[] { "value" },
                    },
                },

                new global::CSharpToJsonSchema.Tool
                {
                    Name = "GetValueAsync",
                    Description = "Gets the value",
                    Strict = false,
                    Parameters = new global::CSharpToJsonSchema.OpenApiSchema
                    {
                        Type = "object",
                        Description = "Gets the value",
                    },
                },
            };
        }
    }
}