using Microsoft.CodeAnalysis;

namespace CSharpToJsonSchema.Generators.JsonGen.Helpers
{
    internal static partial class DiagnosticDescriptorHelper
    {
        public static DiagnosticDescriptor Create(
            string id,
            LocalizableString title,
            LocalizableString messageFormat,
            string category,
            DiagnosticSeverity defaultSeverity,
            bool isEnabledByDefault,
            LocalizableString? description = null,
            params string[] customTags)
        {
            string helpLink = $"https://learn.microsoft.com/dotnet/fundamentals/syslib-diagnostics/{id.ToLowerInvariant()}";

            return new DiagnosticDescriptor(id, title, messageFormat, category, defaultSeverity, isEnabledByDefault, description, helpLink, customTags);
        }
    }
}