using CSharpToJsonSchema.Generators.Models;
using H.Generators.Extensions;

namespace CSharpToJsonSchema.Generators;

internal static partial class Sources
{
    public static string GenerateGoogleFunctionToolForMethods(InterfaceData @interface)
    {
        if(@interface.Methods.Count == 0 || !@interface.GoogleFunctionTool)
            return string.Empty;
        var extensionsClassName = @interface.Name;
       
        return @$"
#nullable enable

namespace {@interface.Namespace}
{{
    public partial class {extensionsClassName}
    {{               
        public static implicit operator global::GenerativeAI.Tools.GenericFunctionTool ({@interface.Namespace}.{extensionsClassName} tools)
        {{
            return tools.AsGoogleFunctionTool();
        }}   

        public global::GenerativeAI.Tools.GenericFunctionTool AsGoogleFunctionTool()
        {{
            return new global::GenerativeAI.Tools.GenericFunctionTool(this.AsTools(), this.AsCalls());
        }}
    }}
}}";
    }
    
    public static string GenerateGoogleFunctionToolForInterface(InterfaceData @interface)
    {
        if(!@interface.GoogleFunctionTool)
            return string.Empty;
        var extensionsClassName = @interface.Name.Substring(startIndex: 1) + "Extensions";
       
        return @$"
#nullable enable

namespace {@interface.Namespace}
{{
    public static partial class {extensionsClassName}
    {{    
        public static global::GenerativeAI.Core.IFunctionTool AsGoogleFunctionTool(this {@interface.Name} service)
        {{
            return new global::GenerativeAI.Tools.GenericFunctionTool(service.AsTools(), service.AsCalls());
        }}
    }}
}}";
    }
}