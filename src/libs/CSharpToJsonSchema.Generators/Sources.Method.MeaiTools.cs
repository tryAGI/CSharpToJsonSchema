using CSharpToJsonSchema.Generators.Models;

namespace CSharpToJsonSchema.Generators;

internal static partial class Sources
{
    public static string GenerateMeaiFunctionToolForMethods(InterfaceData @interface)
    {
        if(@interface.Methods.Count == 0 || !@interface.MeaiFunctionTool)
            return string.Empty;
        var extensionsClassName = @interface.Name;
       
        return @$"
#nullable enable

namespace {@interface.Namespace}
{{
    public partial class {extensionsClassName}
    {{               
        public static implicit operator global::System.Collections.Generic.List<global::Microsoft.Extensions.AI.AITool>? ({@interface.Namespace}.{extensionsClassName} tools)
        {{
            return tools.AsMeaiTools();
        }}             

        public global::System.Collections.Generic.List<global::Microsoft.Extensions.AI.AITool> AsMeaiTools()
        {{
            var lst = new global::System.Collections.Generic.List<global::Microsoft.Extensions.AI.AITool>();
            var tools = this.AsTools();
            var calls = this.AsCalls();
            foreach (var tool in tools)
            {{
                var call = calls[tool.Name];
                lst.Add(new global::CSharpToJsonSchema.MeaiFunction(tool, call));
            }}
            return lst;
        }}
    }}
}}";
    }
    
    public static string GenerateMeaiFunctionToolForInterface(InterfaceData @interface)
    {
        if(!@interface.MeaiFunctionTool)
            return string.Empty;
        var extensionsClassName = @interface.Name.Substring(startIndex: 1) + "Extensions";
       
        return @$"
#nullable enable

namespace {@interface.Namespace}
{{
    public partial class {extensionsClassName}
    {{    
        public static global::System.Collections.Generic.List<global::Microsoft.Extensions.AI.AITool> AsMeaiTools(this {@interface.Name} service)
        {{
            var lst = new global::System.Collections.Generic.List<global::Microsoft.Extensions.AI.AITool>();
            var tools = service.AsTools();
            var calls = service.AsCalls();
            foreach (var tool in tools)
            {{
                var call = calls[tool.Name];
                lst.Add(new global::CSharpToJsonSchema.MeaiFunction(tool, call));
            }}
            return lst;
        }}
    }}
}}";
    }
}