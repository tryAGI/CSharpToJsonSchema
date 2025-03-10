
using System.Threading;
using System.Threading.Tasks;

namespace CSharpToJsonSchema.IntegrationTests;
public class MethodFunctionTools
{
    [FunctionTool]
    public Task<string> SampleFunctionTool_StringAsync(string input, CancellationToken cancellationToken = default)
    {
        return Task.FromResult("Hello world");
    }
    
    [FunctionTool]
    public Task SampleFunctionTool_NoReturnAsync(string input, CancellationToken cancellationToken = default)
    {
        return Task.CompletedTask;
    }
    
    [FunctionTool]
    public void SampleFunctionTool_Void(string input)
    {
        
    }
    
    [FunctionTool]
    public string SampleFunctionTool_String(string input)
    {
        return "Hello world from string return";
    }
    
    
    [FunctionTool]
    public static Task<string> SampleFunctionTool_Static_StringAsync(string input, CancellationToken cancellationToken = default)
    {
        return Task.FromResult("Hello world");
    }
    
    [FunctionTool]
    public static Task SampleFunctionTool_Static_NoReturnAsync(string input, CancellationToken cancellationToken = default)
    {
        return Task.CompletedTask;
    }
    
    [FunctionTool]
    public static void SampleFunctionTool_Static_Void(string input)
    {
        
    }
    
    [FunctionTool]
    public static string SampleFunctionTool_Static_String(string input)
    {
        return "Hello world from string return";
    }
}