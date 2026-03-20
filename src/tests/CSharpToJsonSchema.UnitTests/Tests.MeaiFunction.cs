using Microsoft.Extensions.AI;

namespace CSharpToJsonSchema.UnitTests;

[TestClass]
public class MeaiFunctionTests
{
    [TestMethod]
    public async Task MeaiFunction_WithNullNameAndDescription_ReturnsEmptyStrings()
    {
        var tool = new Tool
        {
            Name = null,
            Description = null,
            Parameters = new OpenApiSchema
            {
                Type = "object",
            },
        };

        var function = new MeaiFunction(
            tool,
            (json, ct) => Task.FromResult("{}"));

        function.Name.Should().Be(string.Empty);
        function.Description.Should().Be(string.Empty);
    }

    [TestMethod]
    public async Task MeaiFunction_WithValidProperties_ReturnsCorrectValues()
    {
        var tool = new Tool
        {
            Name = "get_weather",
            Description = "Gets the weather for a location",
            Parameters = new OpenApiSchema
            {
                Type = "object",
            },
        };

        var function = new MeaiFunction(
            tool,
            (json, ct) => Task.FromResult("{\"temp\": 72}"));

        function.Name.Should().Be("get_weather");
        function.Description.Should().Be("Gets the weather for a location");
    }

    [TestMethod]
    public async Task MeaiFunction_InvokeCoreAsync_ReturnsDeserializedResult()
    {
        var tool = new Tool
        {
            Name = "test_func",
            Description = "Test function",
            Parameters = new OpenApiSchema
            {
                Type = "object",
            },
        };

        var called = false;
        var function = new MeaiFunction(
            tool,
            (json, ct) =>
            {
                called = true;
                return Task.FromResult("{\"result\": true}");
            });

        var result = await function.InvokeAsync(
            new AIFunctionArguments(new Dictionary<string, object?>()),
            CancellationToken.None);

        called.Should().BeTrue();
        result.Should().NotBeNull();
    }
}
