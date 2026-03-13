# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

C# source generator library that produces JSON Schema definitions from C# interfaces and methods, enabling native function/tool definitions for AI APIs (OpenAI, Anthropic, Ollama, Gemini, LangChain). Published as [CSharpToJsonSchema](https://www.nuget.org/packages/CSharpToJsonSchema/) on NuGet.

## Build Commands

```bash
# Build the solution
dotnet build CSharpToJsonSchema.slnx

# Build for release (also produces NuGet package)
dotnet build CSharpToJsonSchema.slnx -c Release

# Run unit tests
dotnet test src/tests/CSharpToJsonSchema.UnitTests/CSharpToJsonSchema.UnitTests.csproj

# Run snapshot tests
dotnet test src/tests/CSharpToJsonSchema.SnapshotTests/CSharpToJsonSchema.SnapshotTests.csproj

# Run integration tests
dotnet test src/tests/CSharpToJsonSchema.IntegrationTests/CSharpToJsonSchema.IntegrationTests.csproj

# Run AOT compatibility tests
dotnet test src/tests/CSharpToJsonSchema.AotTests/CSharpToJsonSchema.AotTests.csproj

# Run MEAI (Microsoft.Extensions.AI) tests
dotnet test src/tests/CSharpToJsonSchema.MeaiTests/CSharpToJsonSchema.MeaiTests.csproj

# Run all tests
dotnet test CSharpToJsonSchema.slnx
```

## Architecture

### Project Layout

| Project | Purpose |
|---------|---------|
| `src/libs/CSharpToJsonSchema/` | Main library -- runtime types (`Tool`, `Tools`, `GenerateJsonSchemaAttribute`, `FunctionToolAttribute`, etc.) |
| `src/libs/CSharpToJsonSchema.Generators/` | Roslyn source generator (netstandard2.0) -- generates JSON schema and tool wiring code at compile time |
| `src/tests/CSharpToJsonSchema.UnitTests/` | Unit tests |
| `src/tests/CSharpToJsonSchema.SnapshotTests/` | Snapshot tests (Verify-based) |
| `src/tests/CSharpToJsonSchema.IntegrationTests/` | Integration tests |
| `src/tests/CSharpToJsonSchema.AotTests/` | NativeAOT/trimming compatibility tests |
| `src/tests/CSharpToJsonSchema.MeaiTests/` | Microsoft.Extensions.AI integration tests |
| `src/tests/AotConsole/` | AOT console test app |
| `src/helpers/TrimmingHelper/` | Trimming validation helper |

### How It Works

1. Users annotate an interface with `[GenerateJsonSchema]` or individual methods with `[FunctionTool]`
2. The Roslyn source generator (`CSharpToJsonSchema.Generators`) runs at compile time
3. It produces JSON Schema definitions for each method's parameters
4. Generated extension methods (e.g., `AsTools()`) let users pass tools to AI APIs
5. No reflection is used at runtime -- everything is source-generated

### Key Types

- `[GenerateJsonSchema]` -- attribute for interfaces (supports `Strict` mode)
- `[FunctionTool]` -- attribute for individual methods
- `[Description]` -- describes parameters and methods for the schema
- `Tools` -- runtime container for tool definitions, supports implicit conversion to `List<Tool>`
- `Tool` -- represents a single function/tool with its JSON Schema

### Build Configuration

- **Main library targets:** `netstandard2.0`, `net4.6.2`, `net8.0`, `net9.0`
- **Generator targets:** `netstandard2.0` (Roslyn analyzer requirement)
- **Language:** C# with nullable reference types
- **AOT/Trimming:** Compatible on net6.0+ (`IsAotCompatible`, `IsTrimmable`)
- **Dependencies:** `Microsoft.Extensions.AI.Abstractions`, `System.Text.Json`, `Microsoft.CodeAnalysis.CSharp` (generator)
- **Signing:** Strong-named assemblies via `src/key.snk`
- **Versioning:** Semantic versioning from git tags via MinVer
- **Testing:** MSTest + FluentAssertions (unit), Verify (snapshot)

### CI/CD

- Uses shared workflows from `HavenDV/workflows` repo
- Dependabot updates NuGet packages (auto-merged)
