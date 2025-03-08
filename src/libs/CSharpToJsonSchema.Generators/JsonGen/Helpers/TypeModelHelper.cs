using Microsoft.CodeAnalysis;

namespace CSharpToJsonSchema.Generators.JsonGen.Helpers;

internal static class TypeModelHelper
{
    public static List<ITypeSymbol>? GetAllTypeArgumentsInScope(this INamedTypeSymbol type)
    {
        if (!type.IsGenericType)
        {
            return null;
        }

        List<ITypeSymbol>? args = null;
        TraverseContainingTypes(type);
        return args;

        void TraverseContainingTypes(INamedTypeSymbol current)
        {
            if (current.ContainingType is INamedTypeSymbol parent)
            {
                TraverseContainingTypes(parent);
            }

            if (!current.TypeArguments.IsEmpty)
            {
                (args ??= new()).AddRange(current.TypeArguments);
            }
        }
    }

    public static string GetFullyQualifiedName(this ITypeSymbol type) => type.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat);
}