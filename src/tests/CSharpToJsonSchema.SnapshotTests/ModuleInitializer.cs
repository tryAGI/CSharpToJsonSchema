using System.Runtime.CompilerServices;
using VerifyTests;

namespace CSharpToJsonSchema.SnapshotTests;

public static class ModuleInitializer
{
    [ModuleInitializer]
    public static void Initialize()
    {
        VerifySourceGenerators.Initialize();
    }
}