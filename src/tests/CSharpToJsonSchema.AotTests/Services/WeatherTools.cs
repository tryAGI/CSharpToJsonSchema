using CSharpToJsonSchema.AotTests;

namespace CSharpToJsonSchema.IntegrationTests.Services;

// ReSharper disable RedundantUsingDirective
using System.Threading;
using System.Threading.Tasks;
using DescriptionAttribute = System.ComponentModel.DescriptionAttribute;

public enum Unit
{
    Celsius,
    Fahrenheit,
}

public class Weather
{
    public string Location { get; set; } = string.Empty;
    public double Temperature { get; set; }
    public Unit Unit { get; set; }
    public string Description { get; set; } = string.Empty;
}

[GenerateJsonSchema]
public interface IWeatherTools
{
    [Description("Get the current weather in a given location")]
    public Weather GetCurrentWeather(
        [Description("The city and state, e.g. San Francisco, CA")] string location,
        Unit unit = Unit.Celsius);
    
    [Description("Get the current weather in a given location")]
    public Task<Weather> GetCurrentWeatherAsync(
        [Description("The city and state, e.g. San Francisco, CA")] string location,
        Unit unit = Unit.Celsius,
        CancellationToken cancellationToken = default);

    [Description("Get Complex Data type")]
    public Task<ComplexClassSerializerTools> GetComplexDataType(
        [Description("The city and state, e.g. San Francisco, CA")] Weather weatherToTest,
        Unit unit = Unit.Celsius,
        CancellationToken cancellationToken = default);
}

public class WeatherService : IWeatherTools
{
    public Weather GetCurrentWeather(string location, Unit unit = Unit.Celsius)
    {
        return new Weather
        {
            Location = location,
            Temperature = 22.0,
            Unit = unit,
            Description = "Sunny",
        };
    }
    
    public Task<Weather> GetCurrentWeatherAsync(string location, Unit unit = Unit.Celsius, CancellationToken cancellationToken = default)
    {
        return Task.FromResult(new Weather
        {
            Location = location,
            Temperature = 22.0,
            Unit = unit,
            Description = "Sunny",
        });
    }

    public async Task<ComplexClassSerializerTools> GetComplexDataType(Weather weatherName, Unit unit = Unit.Celsius, CancellationToken cancellationToken = default)
    {
        return new ComplexClassSerializerTools()
        {
            Name = "Example Name",
            Age = 30,
            IsActive = true,
            CreatedAt = DateTime.UtcNow,
            Tags = new List<string> { "tag1", "tag2", "tag3" },
            Metadata = new Dictionary<string, object>
            {
                { "Key1", "Value1" },
                { "Key2", 12345 },
                { "Key3", true }
            },
            Details = new ComplexClassSerializerTools.NestedClass
            {
                Description = "Nested description",
                Value = 99.99,
                Numbers = new List<int> { 1, 2, 3, 4, 5 }
            }
        };
    }
}