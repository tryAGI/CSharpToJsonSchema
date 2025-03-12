using System.ClientModel;
using CSharpToJsonSchema.MeaiTests.Services;
using GenerativeAI.Microsoft;
using Microsoft.Extensions.AI;
using OpenAI;
using OpenAI.Models;

namespace CSharpToJsonSchema.MeaiTests;

[TestClass]
public class Meai_Tests
{
    //[TestMethod]
    public async Task ShouldInvokeTheFunctions()
    {
        var key = Environment.GetEnvironmentVariable("OPEN_AI_APIKEY",EnvironmentVariableTarget.User);
        if (string.IsNullOrWhiteSpace(key))
            return;
        
        var client = new OpenAIClient(new ApiKeyCredential(key));

        Microsoft.Extensions.AI.OpenAIChatClient openAiClient = new OpenAIChatClient(client.GetChatClient("gpt-4o-mini"));

        var chatClient = new Microsoft.Extensions.AI.FunctionInvokingChatClient(openAiClient);
        var chatOptions = new ChatOptions();

        var service = new StudentRecordService();
        var tools = new Tools([service.GetStudentRecordAsync]);
        chatOptions.Tools = tools.AsMeaiTools();
        
        var message = new ChatMessage(ChatRole.User, "How does student john doe in senior grade is doing this year, enrollment start 01-01-2024 to 01-01-2025?");
        var response = await chatClient.GetResponseAsync(message,options:chatOptions).ConfigureAwait(false);

        response.Text.Contains("John", StringComparison.InvariantCultureIgnoreCase).Should()
            .Be(true);
        
        Console.WriteLine(response.Text);
    }
    
    //[TestMethod]
    public async Task ShouldInvokeTheBookService()
    {
        var key = Environment.GetEnvironmentVariable("OPEN_AI_APIKEY",EnvironmentVariableTarget.User);
        if (string.IsNullOrWhiteSpace(key))
            return;
        var prompt = "what is written on page 96 in the book 'damdamadum'";
        
        var client = new OpenAIClient(new ApiKeyCredential(key));

        //Microsoft.Extensions.AI.OpenAIChatClient openAiClient = new OpenAIChatClient(client.GetChatClient("gpt-4o-mini"));

        var chatClient = new GenerativeAIChatClient(Environment.GetEnvironmentVariable("GOOGLE_API_KEY",EnvironmentVariableTarget.User));
        //var chatClient = new Microsoft.Extensions.AI.FunctionInvokingChatClient(openAiClient);
        var chatOptions = new ChatOptions();

        var service = new BookStoreService();
        
        chatOptions.Tools = service.AsMeaiTools();
        
        var message = new ChatMessage(ChatRole.User, prompt);
        var response = await chatClient.GetResponseAsync(message,options:chatOptions).ConfigureAwait(false);

        response.Text.Contains("damdamadum", StringComparison.InvariantCultureIgnoreCase).Should()
            .Be(true);
        
        Console.WriteLine(response.Text);
    }
}