
using System.Threading;
using System.Threading.Tasks;

namespace CSharpToJsonSchema.IntegrationTests;
public class MethodFunctionTools
{
    [FunctionTool]
    public Task<string> SampleFunctionToolAsync(string input, CancellationToken cancellationToken = default)
    {
        return Task.FromResult("Hello world");
    }

    public Task<string> SampleFunctionToolAsync2(string input, CancellationToken cancellationToken = default)
    { 
        //SampleFunctionToolAsync;
        //var t = this.SampleFunctionToolAsync.AsTool();
        return Task.FromResult("Hello world");
    }
}