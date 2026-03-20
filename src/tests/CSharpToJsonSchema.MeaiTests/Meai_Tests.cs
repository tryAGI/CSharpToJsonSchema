using System.ClientModel;
using CSharpToJsonSchema.MeaiTests.Services;
using GenerativeAI.Microsoft;
using Microsoft.Extensions.AI;
using OpenAI;

namespace CSharpToJsonSchema.MeaiTests;

[TestClass]
public class Meai_Tests
{
    [TestMethod]
    public async Task ShouldInvokeTheFunctions()
    {
        var key = Environment.GetEnvironmentVariable("OPEN_AI_APIKEY") is { Length: > 0 } k ? k
            : throw new AssertInconclusiveException("OPEN_AI_APIKEY environment variable is not found.");

        var client = new OpenAIClient(new ApiKeyCredential(key));

        IChatClient openAiClient = client.GetChatClient("gpt-4o-mini").AsIChatClient();

        var chatClient = new Microsoft.Extensions.AI.FunctionInvokingChatClient(openAiClient);
        var chatOptions = new ChatOptions();

        var service = new StudentRecordService();
        var tools = new Tools([service.GetStudentRecordAsync]);
        chatOptions.Tools = tools.AsMeaiTools();

        var message = new ChatMessage(ChatRole.User, "How does student john doe in senior grade is doing this year, enrollment start 01-01-2024 to 01-01-2025?");
        var response = await chatClient.GetResponseAsync(message, options: chatOptions).ConfigureAwait(false);

        response.Text.Contains("John", StringComparison.InvariantCultureIgnoreCase).Should()
            .Be(true);

        Console.WriteLine(response.Text);
    }

    [TestMethod]
    public async Task ShouldInvokeTheFunctions_NoParameters()
    {
        var key = Environment.GetEnvironmentVariable("OPEN_AI_APIKEY") is { Length: > 0 } k ? k
            : throw new AssertInconclusiveException("OPEN_AI_APIKEY environment variable is not found.");

        var client = new OpenAIClient(new ApiKeyCredential(key));

        IChatClient openAiClient = client.GetChatClient("gpt-4o-mini").AsIChatClient();

        var chatClient = new Microsoft.Extensions.AI.FunctionInvokingChatClient(openAiClient);
        var chatOptions = new ChatOptions();

        var service = new StudentRecordService();
        var tools = new Tools([service.GetStudentsListAsync]);
        chatOptions.Tools = tools.AsMeaiTools();

        var message = new ChatMessage(ChatRole.User, "Get all students records");
        var response = await chatClient.GetResponseAsync(message, options: chatOptions).ConfigureAwait(false);

        response.Text.Contains("John", StringComparison.InvariantCultureIgnoreCase).Should()
            .Be(true);

        Console.WriteLine(response.Text);
    }

    [TestMethod]
    public async Task ShouldInvokeTheFunctions_NoParameters2()
    {
        var key = Environment.GetEnvironmentVariable("OPEN_AI_APIKEY") is { Length: > 0 } k ? k
            : throw new AssertInconclusiveException("OPEN_AI_APIKEY environment variable is not found.");

        var client = new OpenAIClient(new ApiKeyCredential(key));

        IChatClient openAiClient = client.GetChatClient("gpt-4o-mini").AsIChatClient();

        var chatClient = new Microsoft.Extensions.AI.FunctionInvokingChatClient(openAiClient);
        var chatOptions = new ChatOptions();

        var service = new StudentRecordService();
        var tools = new Tools([service.GetStudentsList2]);
        chatOptions.Tools = tools.AsMeaiTools();

        var message = new ChatMessage(ChatRole.User, "Get all students records");
        var response = await chatClient.GetResponseAsync(message, options: chatOptions).ConfigureAwait(false);

        response.Text.Contains("John", StringComparison.InvariantCultureIgnoreCase).Should()
            .Be(true);

        Console.WriteLine(response.Text);
    }

    [TestMethod]
    public async Task ShouldInvokeTheBookService()
    {
        var key = Environment.GetEnvironmentVariable("GOOGLE_API_KEY") is { Length: > 0 } k ? k
            : throw new AssertInconclusiveException("GOOGLE_API_KEY environment variable is not found.");

        var prompt = "what is written on page 96 in the book 'damdamadum'";

        var chatClient = new GenerativeAIChatClient(key);
        var chatOptions = new ChatOptions();

        var service = new BookStoreService();

        chatOptions.Tools = service.AsMeaiTools();

        var message = new ChatMessage(ChatRole.User, prompt);
        var response = await chatClient.GetResponseAsync(message, options: chatOptions).ConfigureAwait(false);

        response.Text.Contains("damdamadum", StringComparison.InvariantCultureIgnoreCase).Should()
            .Be(true);

        Console.WriteLine(response.Text);
    }

    [TestMethod]
    public async Task ShouldInvokeTheBookService_NoParameters()
    {
        var key = Environment.GetEnvironmentVariable("OPEN_AI_APIKEY") is { Length: > 0 } k ? k
            : throw new AssertInconclusiveException("OPEN_AI_APIKEY environment variable is not found.");

        var prompt = "Get list of available books";

        var chatClient = new OpenAIClient(new ApiKeyCredential(key)).GetChatClient("gpt-4o-mini").AsIChatClient().AsBuilder().UseFunctionInvocation().Build();
        var chatOptions = new ChatOptions();

        var service = new BookStoreService();

        chatOptions.Tools = service.AsMeaiTools();

        var message = new ChatMessage(ChatRole.User, prompt);
        var response = await chatClient.GetResponseAsync(message, options: chatOptions).ConfigureAwait(false);

        response.Text.Contains("Five point someone", StringComparison.InvariantCultureIgnoreCase).Should()
            .Be(true);

        Console.WriteLine(response.Text);
    }
}
