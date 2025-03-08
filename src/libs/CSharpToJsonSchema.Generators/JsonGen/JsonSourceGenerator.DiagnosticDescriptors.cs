// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using CSharpToJsonSchema.Generators.JsonGen.Helpers;
using Microsoft.CodeAnalysis;

namespace CSharpToJsonSchema.Generators.JsonGen
{
    public sealed partial class JsonSourceGenerator
    {
        internal static class DiagnosticDescriptors
        {
            // Must be kept in sync with https://github.com/dotnet/runtime/blob/main/docs/project/list-of-diagnostics.md

            public static DiagnosticDescriptor TypeNotSupported { get; } = DiagnosticDescriptorHelper.Create(
                id: "SYSLIB1030",
                title: "Type is not supported",
                messageFormat: "The type {0} is not supported for JSON serialization.",
                category: JsonConstants.SystemTextJsonSourceGenerationName,
                defaultSeverity: DiagnosticSeverity.Warning,
                isEnabledByDefault: true);

            public static DiagnosticDescriptor DuplicateTypeName { get; } = DiagnosticDescriptorHelper.Create(
                id: "SYSLIB1031",
                title: "Duplicate type name detected",
                messageFormat: "The type name {0} is defined multiple times.",
                category: JsonConstants.SystemTextJsonSourceGenerationName,
                defaultSeverity: DiagnosticSeverity.Warning,
                isEnabledByDefault: true);

            public static DiagnosticDescriptor ContextClassesMustBePartial { get; } = DiagnosticDescriptorHelper.Create(
                id: "SYSLIB1032",
                title: "Context class must be partial",
                messageFormat: "The context class {0} must be declared as partial.",
                category: JsonConstants.SystemTextJsonSourceGenerationName,
                defaultSeverity: DiagnosticSeverity.Warning,
                isEnabledByDefault: true);

            public static DiagnosticDescriptor MultipleJsonConstructorAttribute { get; } = DiagnosticDescriptorHelper.Create(
                id: "SYSLIB1033",
                title: "Multiple JSON constructor attributes",
                messageFormat: "Multiple constructors in {0} cannot have the [JsonConstructor] attribute.",
                category: JsonConstants.SystemTextJsonSourceGenerationName,
                defaultSeverity: DiagnosticSeverity.Error,
                isEnabledByDefault: true);

            public static DiagnosticDescriptor JsonStringEnumConverterNotSupportedInAot { get; } = DiagnosticDescriptorHelper.Create(
                id: "SYSLIB1034",
                title: "JsonStringEnumConverter is not supported in AOT",
                messageFormat: "Using JsonStringEnumConverter is not supported in environments with Ahead-Of-Time (AOT) compilation.",
                category: JsonConstants.SystemTextJsonSourceGenerationName,
                defaultSeverity: DiagnosticSeverity.Warning,
                isEnabledByDefault: true);

            public static DiagnosticDescriptor MultipleJsonExtensionDataAttribute { get; } = DiagnosticDescriptorHelper.Create(
                id: "SYSLIB1035",
                title: "Multiple JsonExtensionData attributes",
                messageFormat: "The type {0} cannot have multiple [JsonExtensionData] properties.",
                category: JsonConstants.SystemTextJsonSourceGenerationName,
                defaultSeverity: DiagnosticSeverity.Error,
                isEnabledByDefault: true);

            public static DiagnosticDescriptor DataExtensionPropertyInvalid { get; } = DiagnosticDescriptorHelper.Create(
                id: "SYSLIB1036",
                title: "Invalid JsonExtensionData property",
                messageFormat: "The property {0} attributed with [JsonExtensionData] must be of type IDictionary<string, JsonElement> or IDictionary<string, object>.",
                category: JsonConstants.SystemTextJsonSourceGenerationName,
                defaultSeverity: DiagnosticSeverity.Error,
                isEnabledByDefault: true);

            public static DiagnosticDescriptor InaccessibleJsonIncludePropertiesNotSupported { get; } = DiagnosticDescriptorHelper.Create(
                id: "SYSLIB1038",
                title: "Inaccessible properties with [JsonInclude] are not supported",
                messageFormat: "The property {0} marked with [JsonInclude] must be accessible.",
                category: JsonConstants.SystemTextJsonSourceGenerationName,
                defaultSeverity: DiagnosticSeverity.Warning,
                isEnabledByDefault: true);

            public static DiagnosticDescriptor PolymorphismNotSupported { get; } = DiagnosticDescriptorHelper.Create(
                id: "SYSLIB1039",
                title: "Polymorphism is not supported",
                messageFormat: "Polymorphism for type {0} is not supported for JSON serialization.",
                category: JsonConstants.SystemTextJsonSourceGenerationName,
                defaultSeverity: DiagnosticSeverity.Warning,
                isEnabledByDefault: true);

            public static DiagnosticDescriptor JsonConverterAttributeInvalidType { get; } = DiagnosticDescriptorHelper.Create(
                id: "SYSLIB1220",
                title: "Invalid type in JsonConverter attribute",
                messageFormat: "The type {0} specified in [JsonConverter] is invalid or not supported.",
                category: JsonConstants.SystemTextJsonSourceGenerationName,
                defaultSeverity: DiagnosticSeverity.Warning,
                isEnabledByDefault: true);

            public static DiagnosticDescriptor JsonUnsupportedLanguageVersion { get; } = DiagnosticDescriptorHelper.Create(
                id: "SYSLIB1221",
                title: "Unsupported C# language version",
                messageFormat: "The language version does not support the required features for JSON source generation.",
                category: JsonConstants.SystemTextJsonSourceGenerationName,
                defaultSeverity: DiagnosticSeverity.Error,
                isEnabledByDefault: true);

            public static DiagnosticDescriptor JsonConstructorInaccessible { get; } = DiagnosticDescriptorHelper.Create(
                id: "SYSLIB1222",
                title: "Inaccessible JSON constructor",
                messageFormat: "The constructor marked with [JsonConstructor] in {0} is inaccessible.",
                category: JsonConstants.SystemTextJsonSourceGenerationName,
                defaultSeverity: DiagnosticSeverity.Warning,
                isEnabledByDefault: true);

            public static DiagnosticDescriptor DerivedJsonConverterAttributesNotSupported { get; } = DiagnosticDescriptorHelper.Create(
                id: "SYSLIB1223",
                title: "Derived JsonConverter attributes are not supported",
                messageFormat: "Derived attributes from [JsonConverter] in type {0} are not supported.",
                category: JsonConstants.SystemTextJsonSourceGenerationName,
                defaultSeverity: DiagnosticSeverity.Warning,
                isEnabledByDefault: true);

            public static DiagnosticDescriptor JsonSerializableAttributeOnNonContextType { get; } = DiagnosticDescriptorHelper.Create(
                id: "SYSLIB1224",
                title: "JsonSerializable attribute applied to non-context type",
                messageFormat: "[JsonSerializable] can only be applied to a source generation context type.",
                category: JsonConstants.SystemTextJsonSourceGenerationName,
                defaultSeverity: DiagnosticSeverity.Warning,
                isEnabledByDefault: true);

            public static DiagnosticDescriptor TypeContainsRefLikeMember { get; } = DiagnosticDescriptorHelper.Create(
                id: "SYSLIB1225",
                title: "Type contains ref-like members",
                messageFormat: "The type {0} cannot contain ref-like members for JSON serialization.",
                category: JsonConstants.SystemTextJsonSourceGenerationName,
                defaultSeverity: DiagnosticSeverity.Warning,
                isEnabledByDefault: true);
        }
    }
}
