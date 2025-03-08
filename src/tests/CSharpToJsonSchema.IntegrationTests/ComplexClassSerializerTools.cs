using System.Text.Json.Serialization;

namespace CSharpToJsonSchema.IntegrationTests;


public partial class ComplexClassSerializerTools
{
    public string Name { get; set; }
    public int Age { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<string> Tags { get; set; }
    public Dictionary<string, object> Metadata { get; set; }
    public NestedClass Details { get; set; }

    public class NestedClass
    {
        public string Description { get; set; }
        public double Value { get; set; }
        public List<int> Numbers { get; set; }
    }
}

public partial class ComplexClassSerializerToolsJsonSerializerContext : JsonSerializerContext
{
    
}

