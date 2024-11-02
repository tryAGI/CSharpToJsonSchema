# CSharpToJsonSchema

[![Nuget package](https://img.shields.io/nuget/vpre/CSharpToJsonSchema)](https://www.nuget.org/packages/CSharpToJsonSchema/)
[![dotnet](https://github.com/tryAGI/CSharpToJsonSchema/actions/workflows/dotnet.yml/badge.svg?branch=main)](https://github.com/tryAGI/CSharpToJsonSchema/actions/workflows/dotnet.yml)
[![License: MIT](https://img.shields.io/github/license/tryAGI/CSharpToJsonSchema)](https://github.com/tryAGI/CSharpToJsonSchema/blob/main/LICENSE.txt)
[![Discord](https://img.shields.io/discord/1115206893015662663?label=Discord&logo=discord&logoColor=white&color=d82679)](https://discord.gg/Ca2xhfBf3v)

## Features 🔥
- Source generator to define functions natively through C# interfaces
- Doesn't use Reflection
- All modern .NET features - nullability, trimming, NativeAOT, etc.
- Tested for compatibility with OpenAI/Ollama/Anthropic/LangChain/Gemini

## Usage
```csharp
using CSharpToJsonSchema;

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

[GenerateJsonSchema(Strict = true)] // false by default. You can't use parameters with default values in Strict mode.
public interface IWeatherFunctions
{
    [Description("Get the current weather in a given location")]
    public Task<Weather> GetCurrentWeatherAsync(
        [Description("The city and state, e.g. San Francisco, CA")] string location,
        Unit unit,
        CancellationToken cancellationToken = default);
}

public class WeatherService : IWeatherFunctions
{
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
}

var tools = service.AsTools();
```

## Support

Priority place for bugs: https://github.com/tryAGI/CSharpToJsonSchema/issues  
Priority place for ideas and general questions: https://github.com/tryAGI/CSharpToJsonSchema/discussions  
Discord: https://discord.gg/Ca2xhfBf3v

## Acknowledgments

![JetBrains logo](https://resources.jetbrains.com/storage/products/company/brand/logos/jetbrains.png)

This project is supported by JetBrains through the [Open Source Support Program](https://jb.gg/OpenSourceSupport).

![CodeRabbit logo](https://opengraph.githubassets.com/1c51002d7d0bbe0c4fd72ff8f2e58192702f73a7037102f77e4dbb98ac00ea8f/marketplace/coderabbitai)

This project is supported by CodeRabbit through the [Open Source Support Program](https://github.com/marketplace/coderabbitai).