using System.ComponentModel;
using CSharpToJsonSchema.Generators.JsonGen.Helpers;
using CSharpToJsonSchema.Generators.Models;
using Microsoft.CodeAnalysis;

namespace CSharpToJsonSchema.Generators.Conversion;

public static class ToModels
{
    public static InterfaceData PrepareData(
        this INamedTypeSymbol interfaceSymbol,
        AttributeData attributeData)
    {
        interfaceSymbol = interfaceSymbol ?? throw new ArgumentNullException(nameof(interfaceSymbol));
        attributeData = attributeData ?? throw new ArgumentNullException(nameof(attributeData));

        var isStrict = attributeData.NamedArguments.FirstOrDefault(x => x.Key == "Strict").Value.Value is bool strict &&
                       strict;
        var generateGoogleFunctionTool = attributeData.NamedArguments.FirstOrDefault(x => x.Key == "GoogleFunctionTool").Value.Value is bool googleFunctionTool &&
                                         googleFunctionTool;
        var methods = interfaceSymbol
            .GetMembers()
            .OfType<IMethodSymbol>()
            .Where(static x => x.MethodKind == MethodKind.Ordinary)
            .Select(x =>
            {
                var parameters = x.Parameters
                    .Where(static x => x.Type.MetadataName != "CancellationToken")
                    .ToArray();

                return new MethodData(
                    Name: x.Name,
                    Description: GetDescription(x),
                    IsAsync: x.IsAsync || x.ReturnType.Name == "Task",
                    IsVoid: x.ReturnsVoid || x.ReturnType.MetadataName == "Task",
                    IsStrict: isStrict,
                    Parameters: parameters.Select(static y => y).ToArray(),
                    Descriptions: parameters.Select(static l => GetParameterDescriptions(l)).SelectMany(s => s)
                        .ToDictionary(s => s.Key, s => s.Value),
                    ReturnType: x.ReturnType
                );
            })
            .ToArray();

        return new InterfaceData(
            Namespace: interfaceSymbol.ContainingNamespace.ToDisplayString(),
            Name: interfaceSymbol.ToDisplayString(SymbolDisplayFormat.MinimallyQualifiedFormat),
            GoogleFunctionTool:generateGoogleFunctionTool,
            Methods: methods);
    }

    public static InterfaceData PrepareMethodData(
        List<(IMethodSymbol, AttributeData)> list)
    {
        //interfaceSymbol = interfaceSymbol ?? throw new ArgumentNullException(nameof(interfaceSymbol));
        list = list ?? throw new ArgumentNullException(nameof(list));

        var namespaceName = "CSharpToJsonSchema";
        var className = "Tools";
        List<MethodData> methodList = new();
        List<string> namespaces = new();
        bool generateGoogleFunctionTools = false;
        foreach (var l in list)
        {
            var (interfaceSymbol, attributeData) = l;
            var isStrict = attributeData.NamedArguments.FirstOrDefault(x => x.Key == "Strict").Value.Value is bool strict &&
                           strict;
            var ggft = attributeData.NamedArguments.FirstOrDefault(x => x.Key == "GoogleFunctionTool").Value.Value is bool googleFunctionTool &&
                                              googleFunctionTool;
            if(ggft)
                generateGoogleFunctionTools = true;
            
            var x = interfaceSymbol;
            var parameters = x.Parameters
                //.Where(static x => x.Type.MetadataName != "CancellationToken")
                .ToArray();

            var methodData = new MethodData(
                Name: x.Name,
                Description: GetDescription(x),
                IsAsync: x.IsAsync || x.ReturnType.Name == "Task",
                IsVoid: x.ReturnsVoid || x.ReturnType.MetadataName == "Task",
                IsStrict: isStrict,
                Parameters: parameters.Select(static y => y).ToArray(),
                Descriptions: parameters.Select(static l => GetParameterDescriptions(l)).SelectMany(s => s)
                    .ToDictionary(s => s.Key, s => s.Value),
                ReturnType:x.ReturnType
            );
            methodList.Add(methodData);
            namespaces.Add(interfaceSymbol.ContainingNamespace.ToDisplayString());
        }

        return new InterfaceData(
            Namespace: GetCommonRootNamespace(namespaces)??namespaceName,
            Name: className,
            GoogleFunctionTool: generateGoogleFunctionTools,
            Methods: methodList.ToArray());
    }
    public static string? GetCommonRootNamespace(IEnumerable<string> namespaces)
    {
        // Convert the list of namespaces to a list of arrays split by "."
        var splitNamespaces = namespaces
            .Select(ns => ns.Split('.'))
            .ToList();

        if (!splitNamespaces.Any() || !splitNamespaces[0].Any())
        {
            return null;
        }

        // Start with the first namespace parts
        var firstNsParts = splitNamespaces[0];
        var commonParts = new List<string>();

        // For each index in the first namespace
        for (int i = 0; i < firstNsParts.Length; i++)
        {
            // Check if every other namespace has the same part at this index
            string currentPart = firstNsParts[i];
            if (splitNamespaces.All(nsArr => nsArr.Length > i && nsArr[i] == currentPart))
            {
                commonParts.Add(currentPart);
            }
            else
            {
                // Stop the moment there is a mismatch
                break;
            }
        }

        return string.Join(".", commonParts);
    }


    // private static Dictionary<string, bool> GetIsRequired(IParameterSymbol[] parameters, Dictionary<string, bool>? dics = null)
    // {
    //     dics ??= new Dictionary<string, bool>();
    //
    //     foreach (var parameter in parameters)
    //     {
    //         if (dics.TryAdd(parameter.Name, IsRequired(parameter)))
    //         {
    //             if (parameter is IParameterSymbol namedTypeSymbol)
    //             {
    //                 GetIsRequired(namedTypeSymbol.Type.GetMembers().OfType<IPropertySymbol>().ToArray(),dics)
    //             }
    //         }
    //     }
    //
    //     return dics;
    // }
    //
    // private static bool IsRequired(ISymbol parameter)
    // {
    //     return false;
    //     //parameter.GetAttributes().OfType<global::System.ComponentModel.D.RequiredAttribute>()
    // }

    private static List<KeyValuePair<string, string>> GetParameterDescriptions(IParameterSymbol parameters,
        Dictionary<string, string>? dics = null)
    {
        dics ??= new Dictionary<string, string>();


        if (dics.TryAdd(parameters.Name.ToCamelCase(), GetDescription(parameters)))
        {
            if (parameters is IParameterSymbol namedTypeSymbol)
            {
                GetParameterDescriptions(namedTypeSymbol.Type.GetMembers().OfType<IPropertySymbol>().ToArray(), dics);
            }
        }

        return dics.Select(x => new KeyValuePair<string, string>(x.Key, x.Value)).ToList();
    }

    private static Dictionary<string, string> GetParameterDescriptions(IPropertySymbol[] parameters,
        Dictionary<string, string>? dics = null)
    {
        dics ??= new Dictionary<string, string>();

        foreach (var parameter in parameters)
        {
            var description = GetDescription(parameter);
            if (string.IsNullOrWhiteSpace(description)) continue;

            if (dics.TryAdd(parameter.Name, description))
            {
                if (parameter is IPropertySymbol namedTypeSymbol)
                {
                    GetParameterDescriptions(namedTypeSymbol.Type.GetMembers().OfType<IPropertySymbol>().ToArray(),
                        dics);
                }
            }
        }

        return dics;
    }

    private static OpenApiSchema ToParameterData(ITypeSymbol typeSymbol, string? name = null,
        string? description = null, bool isRequired = true)
    {
        string schemaType;
        string? format = null;
        var properties = Array.Empty<OpenApiSchema>();
        OpenApiSchema? arrayItem = null;
        switch (typeSymbol.TypeKind)
        {
            case TypeKind.Enum:
                schemaType = "string";
                break;

            case TypeKind.Structure:
                switch (typeSymbol.SpecialType)
                {
                    case SpecialType.System_Int32:
                        schemaType = "integer";
                        format = "int32";
                        break;

                    case SpecialType.System_Int64:
                        schemaType = "integer";
                        format = "int64";
                        break;

                    case SpecialType.System_Single:
                        schemaType = "number";
                        format = "double";
                        break;

                    case SpecialType.System_Double:
                        schemaType = "number";
                        format = "float";
                        break;

                    case SpecialType.System_DateTime:
                        schemaType = "string";
                        format = "date-time";
                        break;

                    case SpecialType.System_Boolean:
                        schemaType = "boolean";
                        break;

                    case SpecialType.None:
                        switch (typeSymbol.Name)
                        {
                            case "DateOnly":
                                schemaType = "string";
                                format = "date";
                                break;

                            default:
                                throw new NotImplementedException($"{typeSymbol.Name} is not implemented.");
                        }

                        break;

                    default:
                        throw new NotImplementedException($"{typeSymbol.SpecialType} is not implemented.");
                }

                break;

            case TypeKind.Class:
                switch (typeSymbol.SpecialType)
                {
                    case SpecialType.System_String:
                        schemaType = "string";
                        break;


                    case SpecialType.None:
                        schemaType = "object";
                        properties = typeSymbol.GetMembers()
                            .OfType<IPropertySymbol>()
                            .Select(static y => ToParameterData(
                                typeSymbol: y.Type,
                                name: y.Name,
                                description: GetDescription(y),
                                isRequired: true))
                            .ToArray();
                        break;

                    default:
                        throw new NotImplementedException($"{typeSymbol.SpecialType} is not implemented.");
                }

                break;

            case TypeKind.Interface when typeSymbol.MetadataName == "IReadOnlyCollection`1":
                schemaType = "array";
                arrayItem = (typeSymbol as INamedTypeSymbol)?.TypeArguments
                    .Select(static y => ToParameterData(y))
                    .FirstOrDefault();
                break;

            case TypeKind.Array:
                schemaType = "array";
                arrayItem = ToParameterData((typeSymbol as IArrayTypeSymbol)?.ElementType!);
                break;

            default:
                throw new NotImplementedException($"{typeSymbol.TypeKind} is not implemented.");
        }

        return new OpenApiSchema(
            Name: !string.IsNullOrWhiteSpace(name)
                ? name!
                : typeSymbol.Name,
            Description: !string.IsNullOrWhiteSpace(description)
                ? description!
                : GetDescription(typeSymbol),
            Type: typeSymbol.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat),
            DefaultValue: GetDefaultValue(typeSymbol),
            SchemaType: schemaType,
            Format: format,
            Properties: properties,
            ArrayItem: arrayItem != null ? [arrayItem.Value] : Array.Empty<OpenApiSchema>(),
            EnumValues: typeSymbol.TypeKind == TypeKind.Enum
                ? typeSymbol
                    .GetMembers()
                    .OfType<IFieldSymbol>()
                    .Select(static x => x.Name.ToLowerInvariant())
                    .ToArray()
                : [],
            IsNullable: IsNullable(typeSymbol),
            IsRequired: isRequired);
    }

    private static bool IsNullable(ITypeSymbol typeSymbol)
    {
        if (typeSymbol.TypeKind == TypeKind.Enum)
        {
            return false;
        }

        if (typeSymbol.TypeKind == TypeKind.Structure)
        {
            return false;
        }

        return typeSymbol.SpecialType switch
        {
            SpecialType.System_String => false,
            _ => true,
        };
    }

    public static string GetDefaultValue(this ITypeSymbol typeSymbol)
    {
        switch (typeSymbol.SpecialType)
        {
            case SpecialType.System_String:
                return "string.Empty";

            default:
                return string.Empty;
        }
    }

    public static string GetDescription(ISymbol symbol)
    {
        return symbol.GetAttributes()
            .FirstOrDefault(static x => x.AttributeClass?.Name == nameof(DescriptionAttribute))?
            .ConstructorArguments.First().Value?.ToString() ?? string.Empty;
    }
}