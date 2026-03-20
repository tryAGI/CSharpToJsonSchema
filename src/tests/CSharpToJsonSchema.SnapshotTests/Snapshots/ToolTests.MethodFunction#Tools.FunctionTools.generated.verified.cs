//HintName: Tools.FunctionTools.generated.cs

#nullable enable

namespace CSharpToJsonSchema.IntegrationTests
{
    public partial class Tools
    {                 
        static Tools()
        {
            AddAllTools();
        }
        private static global::System.Collections.Generic.IDictionary<string, global::CSharpToJsonSchema.Tool>? AllTools {get; set;}
        public global::System.Collections.Generic.IList<global::CSharpToJsonSchema.Tool>? AvailableTools {get; private set;}
        private global::System.Collections.Generic.IDictionary<string,global::System.Delegate>? Delegates {get; set;}
        private static void AddAllTools()
        {
            var list = new global::System.Collections.Generic.Dictionary<string, global::CSharpToJsonSchema.Tool>();
            global::CSharpToJsonSchema.Tool tool;
                        tool = new global::CSharpToJsonSchema.Tool
            {
                Name = "SampleFunctionTool_StringAsync",
                Description = "",
                Strict = false,
                Parameters = global::CSharpToJsonSchema.SchemaBuilder.ConvertToSchema(global::CSharpToJsonSchema.IntegrationTests.ToolsJsonSerializerContext.Default.SampleFunctionTool_StringAsyncArgs,"{\"mainFunction_Desc\":\"\"}"),
            };
            if(!list.ContainsKey(tool.Name))
                list.Add("SampleFunctionTool_StringAsync",tool);
            
            tool = new global::CSharpToJsonSchema.Tool
            {
                Name = "SampleFunctionTool_NoReturnAsync",
                Description = "",
                Strict = false,
                Parameters = global::CSharpToJsonSchema.SchemaBuilder.ConvertToSchema(global::CSharpToJsonSchema.IntegrationTests.ToolsJsonSerializerContext.Default.SampleFunctionTool_NoReturnAsyncArgs,"{\"mainFunction_Desc\":\"\"}"),
            };
            if(!list.ContainsKey(tool.Name))
                list.Add("SampleFunctionTool_NoReturnAsync",tool);
            
            tool = new global::CSharpToJsonSchema.Tool
            {
                Name = "SampleFunctionTool_Void",
                Description = "",
                Strict = false,
                Parameters = global::CSharpToJsonSchema.SchemaBuilder.ConvertToSchema(global::CSharpToJsonSchema.IntegrationTests.ToolsJsonSerializerContext.Default.SampleFunctionTool_VoidArgs,"{\"mainFunction_Desc\":\"\"}"),
            };
            if(!list.ContainsKey(tool.Name))
                list.Add("SampleFunctionTool_Void",tool);
            
            tool = new global::CSharpToJsonSchema.Tool
            {
                Name = "SampleFunctionTool_String",
                Description = "",
                Strict = false,
                Parameters = global::CSharpToJsonSchema.SchemaBuilder.ConvertToSchema(global::CSharpToJsonSchema.IntegrationTests.ToolsJsonSerializerContext.Default.SampleFunctionTool_StringArgs,"{\"mainFunction_Desc\":\"\"}"),
            };
            if(!list.ContainsKey(tool.Name))
                list.Add("SampleFunctionTool_String",tool);
            
            tool = new global::CSharpToJsonSchema.Tool
            {
                Name = "SampleFunctionTool_Static_StringAsync",
                Description = "",
                Strict = false,
                Parameters = global::CSharpToJsonSchema.SchemaBuilder.ConvertToSchema(global::CSharpToJsonSchema.IntegrationTests.ToolsJsonSerializerContext.Default.SampleFunctionTool_Static_StringAsyncArgs,"{\"mainFunction_Desc\":\"\"}"),
            };
            if(!list.ContainsKey(tool.Name))
                list.Add("SampleFunctionTool_Static_StringAsync",tool);
            
            tool = new global::CSharpToJsonSchema.Tool
            {
                Name = "SampleFunctionTool_Static_NoReturnAsync",
                Description = "",
                Strict = false,
                Parameters = global::CSharpToJsonSchema.SchemaBuilder.ConvertToSchema(global::CSharpToJsonSchema.IntegrationTests.ToolsJsonSerializerContext.Default.SampleFunctionTool_Static_NoReturnAsyncArgs,"{\"mainFunction_Desc\":\"\"}"),
            };
            if(!list.ContainsKey(tool.Name))
                list.Add("SampleFunctionTool_Static_NoReturnAsync",tool);
            
            tool = new global::CSharpToJsonSchema.Tool
            {
                Name = "SampleFunctionTool_Static_Void",
                Description = "",
                Strict = false,
                Parameters = global::CSharpToJsonSchema.SchemaBuilder.ConvertToSchema(global::CSharpToJsonSchema.IntegrationTests.ToolsJsonSerializerContext.Default.SampleFunctionTool_Static_VoidArgs,"{\"mainFunction_Desc\":\"\"}"),
            };
            if(!list.ContainsKey(tool.Name))
                list.Add("SampleFunctionTool_Static_Void",tool);
            
            tool = new global::CSharpToJsonSchema.Tool
            {
                Name = "SampleFunctionTool_Static_String",
                Description = "",
                Strict = false,
                Parameters = global::CSharpToJsonSchema.SchemaBuilder.ConvertToSchema(global::CSharpToJsonSchema.IntegrationTests.ToolsJsonSerializerContext.Default.SampleFunctionTool_Static_StringArgs,"{\"mainFunction_Desc\":\"\"}"),
            };
            if(!list.ContainsKey(tool.Name))
                list.Add("SampleFunctionTool_Static_String",tool);
            
            AllTools = list;
        }       

        public void AddTool(global::System.Delegate tool)
        {
            AvailableTools ??= new global::System.Collections.Generic.List<global::CSharpToJsonSchema.Tool>();
            Delegates ??= new global::System.Collections.Generic.Dictionary<string, global::System.Delegate>();

            var name = tool.Method.Name; 
            if(AllTools == null || !AllTools.ContainsKey(name))
                throw new global::System.Exception($"Function {name} is not registered. Please make sure you have added proper attribute to the method.");
            var newTool = AllTools[name];
            AvailableTools.Add(newTool);
            if(Delegates.ContainsKey(name))
                throw new global::System.Exception($"Function {name} is already registered");
            Delegates.Add(name, tool); 
           
        }   

        public Tools(global::System.Delegate[] tools)
        {
            for(int i = 0; i < tools.Length; i++)
            {
                var x = tools[i]; 
                AddTool(x);
            }
        }
        
        public static implicit operator global::System.Collections.Generic.List<global::CSharpToJsonSchema.Tool>(CSharpToJsonSchema.IntegrationTests.Tools tools)
        {
            return tools.AsTools();
        }   

        public global::System.Collections.Generic.List<global::CSharpToJsonSchema.Tool> AsTools()
        {
            return (global::System.Collections.Generic.List<global::CSharpToJsonSchema.Tool>) (this.AvailableTools??= new global::System.Collections.Generic.List<global::CSharpToJsonSchema.Tool>());
        }   
    }   
}