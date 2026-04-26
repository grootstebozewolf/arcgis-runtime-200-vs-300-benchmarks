# Contributing

## Scope
Contributions should keep this repository focused on deterministic ArcGIS Runtime core benchmarks only.

## Guidelines
- Keep benchmark classes explicit and zero-DI.
- Do not add runtime [Params] switching; keep separate benchmark classes per runtime line.
- Keep workloads comparable between Core200 and Core300.
- Avoid introducing UI dependencies into benchmark hot paths.
- Provide before/after benchmark evidence for any performance-related PR.

## Development
1. `dotnet restore src/BenchmarkRunner/BenchmarkRunner.csproj`
2. `dotnet run -c Release --project src/BenchmarkRunner/BenchmarkRunner.csproj`
3. Attach updated BenchmarkDotNet result artifacts in PR description.

## Pull requests
Include:
- what changed
- why it changed
- measured impact (if any)
- environment details (CPU, OS, SDK/runtime versions)
