namespace CSharpToJsonSchema.IntegrationTests;

public class MethodFunctionTools_Tests
{
    [Fact]
    public async Task Should_SampleFunctionTool_StringAsync()
    {
        var mf = new MethodFunctionTools();
        var tools = new Tools([mf.SampleFunctionTool_StringAsync]);
        var value = await tools.CallAsync(nameof(mf.SampleFunctionTool_StringAsync), "{\"input\":\"test\"}");

        Assert.Equal(value, "\"Hello world\"");
        
    }

    [Fact]
    public async Task Should_SampleFunctionTool_NoReturnAsync()
    {
        var mf = new MethodFunctionTools();

        var tools = new Tools([mf.SampleFunctionTool_NoReturnAsync]);
        await tools.CallAsync(nameof(mf.SampleFunctionTool_NoReturnAsync), "{\"input\":\"test\"}");
    }

    [Fact]
    public async Task Should_SampleFunctionTool_String()
    {
        var mf = new MethodFunctionTools();
        var tools = new Tools([mf.SampleFunctionTool_String]);
        var value = await tools.CallAsync(nameof(mf.SampleFunctionTool_String), "{\"input\":\"test\"}");

        Assert.Equal(value, "\"Hello world from string return\"");
    }

    [Fact]
    public async Task Should_SampleFunctionTool_Void()
    {
        var mf = new MethodFunctionTools();
        var tools = new Tools([mf.SampleFunctionTool_Void]);
        await tools.CallAsync(nameof(mf.SampleFunctionTool_Void), "{\"input\":\"test\"}");
    }
    
    //Static Methods
    
    [Fact]
    public async Task Should_SampleFunctionTool_Static_StringAsync()
    {
   
        var tools = new Tools([MethodFunctionTools.SampleFunctionTool_Static_StringAsync]);
        var value = await tools.CallAsync(nameof(MethodFunctionTools.SampleFunctionTool_Static_StringAsync), "{\"input\":\"test\"}");

        Assert.Equal(value, "\"Hello world\"");
    }

    [Fact]
    public async Task Should_SampleFunctionTool_Static_NoReturnAsync()
    {
        var tools = new Tools([MethodFunctionTools.SampleFunctionTool_Static_NoReturnAsync]);
        await tools.CallAsync(nameof(MethodFunctionTools.SampleFunctionTool_Static_NoReturnAsync), "{\"input\":\"test\"}");
    }

    [Fact]
    public async Task Should_SampleFunctionTool_Static_String()
    {
        var tools = new Tools([MethodFunctionTools.SampleFunctionTool_Static_String]);
        var value = await tools.CallAsync(nameof(MethodFunctionTools.SampleFunctionTool_Static_String), "{\"input\":\"test\"}");
        Assert.Equal(value, "\"Hello world from string return\"");
    }
    
    [Fact]
    public async Task Should_SampleFunctionTool_Static_Void()
    {
        var tools = new Tools([MethodFunctionTools.SampleFunctionTool_Static_Void]);
        await tools.CallAsync(nameof(MethodFunctionTools.SampleFunctionTool_Static_Void), "{\"input\":\"test\"}");
       
    }
    
}