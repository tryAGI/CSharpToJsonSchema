// ReSharper disable RedundantUsingDirective
using System;
using System.Threading;
using System.Threading.Tasks;
using DescriptionAttribute = System.ComponentModel.DescriptionAttribute;

namespace CSharpToJsonSchema.IntegrationTests;

[GenerateJsonSchema]
public interface IVariousTypesTools
{
    [Description("Get the current weather in a given location")]
    public bool GetCurrentWeather(
        long parameter1,
        int parameter2,
        double parameter3,
        float parameter4,
        bool parameter5,
        DateTime dateTime,
        DateOnly date);
    
    [Description("Sets the value")]
    public void SetValue(int value);
    
    [Description("Gets the value")]
    public int GetValue();
    
    [Description("Sets the value")]
    public Task SetValueAsync(int value, CancellationToken cancellationToken = default);
    
    [Description("Gets the value")]
    public Task<int> GetValueAsync(CancellationToken cancellationToken = default);
}

public class VariousTypesService : IVariousTypesTools
{
    public bool GetCurrentWeather(
        long parameter1,
        int parameter2,
        double parameter3,
        float parameter4,
        bool parameter5,
        DateTime dateTime,
        DateOnly date)
    {
        return true;
    }

    public void SetValue(int value)
    {
        throw new NotImplementedException();
    }

    public int GetValue()
    {
        throw new NotImplementedException();
    }

    public Task SetValueAsync(int value, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<int> GetValueAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}