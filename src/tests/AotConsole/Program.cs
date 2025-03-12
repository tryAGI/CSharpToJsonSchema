// See https://aka.ms/new-console-template for more information

using System.ClientModel;
using CSharpToJsonSchema.MeaiTests.Services;
using Microsoft.Extensions.AI;
using OpenAI;

var key = Environment.GetEnvironmentVariable("OPEN_AI_APIKEY",EnvironmentVariableTarget.User);
if (string.IsNullOrWhiteSpace(key))
    return;
var prompt = "how does student john doe in senior grade is doing this year, enrollment start 01-01-2024 to 01-01-2025?";
        
var client = new OpenAIClient(new ApiKeyCredential(key));

Microsoft.Extensions.AI.OpenAIChatClient openAiClient = new OpenAIChatClient(client.GetChatClient("gpt-4o-mini"));

var chatClient = new FunctionInvokingChatClient(openAiClient);
var chatOptions = new ChatOptions();

var service = new StudentRecordService();

var tools = new Tools([service.GetStudentRecordAsync]);
chatOptions.Tools = tools.AsMeaiTools();
var message = new ChatMessage(ChatRole.User, prompt);
var response = await chatClient.GetResponseAsync(message,options:chatOptions).ConfigureAwait(false);
        
Console.WriteLine(response.Text);