using CSharpToJsonSchema.Generators.Conversion;
using CSharpToJsonSchema.Generators.Models;
using H.Generators.Extensions;
using Microsoft.CodeAnalysis;

namespace CSharpToJsonSchema.Generators;

internal static partial class Sources
{
    public static string GenerateFunctionToolClientImplementation(InterfaceData @interface)
    {
        if(@interface.Methods.Count == 0)
            return string.Empty;
        var extensionsClassName = @interface.Name;
        var constructorsToAdd = new List<MethodData>();
        HashSet<string> methods = new();
        foreach (var method in @interface.Methods)
        {
            if (methods.Add(GetInputsTypes(method)))
            {
                constructorsToAdd.Add(method);
            }
        }
        //var methodName = @interface.Methods.First().Name;
        //var funcsToAdd = @interface.Methods.Select(GetInputsTypes).Distinct().ToList();
        return @$"
#nullable enable

namespace {@interface.Namespace}
{{
    public partial class {extensionsClassName}
    {{                 
        static {extensionsClassName}()
        {{
            AddAllTools();
        }}
        private static global::System.Collections.Generic.IDictionary<string, global::CSharpToJsonSchema.Tool>? AllTools {{get; set;}}
        public global::System.Collections.Generic.IList<global::CSharpToJsonSchema.Tool>? AvailableTools {{get; private set;}}
        private global::System.Collections.Generic.IDictionary<string,global::System.Delegate>? Delegates {{get; set;}}
        private static void AddAllTools()
        {{
            var list = new global::System.Collections.Generic.Dictionary<string, global::CSharpToJsonSchema.Tool>();
            global::CSharpToJsonSchema.Tool tool;
            {@interface.Methods.Select(method => $@"
            tool = new global::CSharpToJsonSchema.Tool
            {{
                Name = ""{method.Name}"",
                Description = ""{method.Description}"",
                Strict = {(method.IsStrict ? "true" : "false")},
                Parameters = global::CSharpToJsonSchema.SchemaBuilder.ConvertToSchema(global::{@interface.Namespace}.{extensionsClassName}JsonSerializerContext.Default.{method.Name}Args,{"\""}{GetDictionaryString(method)}{"\""}),
            }};
            if(!list.ContainsKey(tool.Name))
                list.Add(""{method.Name}"",tool);
            ").Inject()}
            AllTools = list;
        }}       

        public void AddTool(global::System.Delegate tool)
        {{
            AvailableTools ??= new global::System.Collections.Generic.List<global::CSharpToJsonSchema.Tool>();
            Delegates ??= new global::System.Collections.Generic.Dictionary<string, global::System.Delegate>();

            var name = tool.Method.Name; 
            if(AllTools == null || !AllTools.ContainsKey(name))
                throw new global::System.Exception({"$\"Function {name} is not registered. Please make sure you have added proper attribute to the method.\""});
            var newTool = AllTools[name];
            AvailableTools.Add(newTool);
            if(Delegates.ContainsKey(name))
                throw new global::System.Exception({"$\"Function {name} is already registered\""});
            Delegates.Add(name, tool); 
           
        }}   

        public Tools(global::System.Delegate[] tools)
        {{
            for(int i = 0; i < tools.Length; i++)
            {{
                var x = tools[i]; 
                AddTool(x);
            }}
        }}
        
        public static implicit operator global::System.Collections.Generic.List<global::CSharpToJsonSchema.Tool>({@interface.Namespace}.{extensionsClassName} tools)
        {{
            return tools.AsTools();
        }}   

        public global::System.Collections.Generic.List<global::CSharpToJsonSchema.Tool> AsTools()
        {{
            return (global::System.Collections.Generic.List<global::CSharpToJsonSchema.Tool>) (this.AvailableTools??= new global::System.Collections.Generic.List<global::CSharpToJsonSchema.Tool>());
        }}   
    }}   
}}";
    }
    
    private static string GetInputsTypes(MethodData first, bool addReturnType = true)
    {
        var f = first.Parameters.Select(s => s.Type.ToDisplayString()).ToList();
        if(addReturnType)
            f.Add(first.ReturnType.ToDisplayString());
        return string.Join(", ", f);
    }
    
    private static string GetDelegateInputsTypes(MethodData first, bool addReturnType = true)
    {
        var f = first.Parameters.Select(s => $"{s.Type.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat)} {s.Name}"+(s.HasExplicitDefaultValue? $" = " + (s.Type.Name == "CancellationToken"?"default":s.ExplicitDefaultValue?.ToString()) :"")).ToList();
        if(addReturnType)
            f.Add(first.ReturnType.ToDisplayString());
        return string.Join(", ", f);
    }
}