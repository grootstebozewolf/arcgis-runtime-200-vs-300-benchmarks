# arcgis-runtime-200-vs-300-benchmarks

## One-sentence goal
Measure ArcGIS Runtime 200.x vs 300.x core operation performance using isolated benchmark projects with identical workloads.

## How a deep proxy made this comparison trivial
A deep proxy boundary allows two runtime versions to be swapped behind identical service contracts with no production app changes, no DI rewiring, and no feature-level refactors.

## Setup & license instructions
1. Install .NET SDK 9.0.313 or newer .NET 9 SDK.
2. Set environment variables (PowerShell example):
   - `$env:ARCGIS_API_KEY="<your-api-key>"`
   - `$env:ARCGIS_LICENSE_KEY="<fallback-license>"`
   - `$env:ARCGIS200_LICENSE_KEY="<optional-200-license>"`
   - `$env:ARCGIS300_LICENSE_KEY="<optional-300-license>"`
3. Restore dependencies from repo root:
   - `dotnet restore src/BenchmarkRunner/BenchmarkRunner.csproj`

## Hardware used
- OS: Windows 11 (10.0.26200.8246)
- CPU: AMD Ryzen 5 5600G (6C/12T)
- SDK: .NET SDK 10.0.203
- Runtime: .NET 9.0.15 x64 RyuJIT AVX2

## Out of scope
- UI toolkit behavior and rendering fidelity
- API ergonomics and migration effort
- Network latency/service backend variability
- Caching strategy comparisons

## How to run
```bash
cd src/BenchmarkRunner
dotnet run -c Release
```

## One killer chart
- Core200 markdown report: `src/BenchmarkRunner/BenchmarkDotNet.Artifacts/results/Core200.Core200Benchmarks-report-github.md`
- Core300 markdown report: `src/BenchmarkRunner/BenchmarkDotNet.Artifacts/results/Core300.Core300Benchmarks-report-github.md`
- Core200 HTML report: `src/BenchmarkRunner/BenchmarkDotNet.Artifacts/results/Core200.Core200Benchmarks-report.html`
- Core300 HTML report: `src/BenchmarkRunner/BenchmarkDotNet.Artifacts/results/Core300.Core300Benchmarks-report.html`

## Results
| Runtime | Geometry_Project_10kPoints | Graphics_AddRemove_5k |
|---|---:|---:|
| 200.8.1 | 11.46 ms, 937.52 KB | 51.29 ms, 1484.75 KB |
| 300.0.0 | 10.75 ms, 937.55 KB | 43.48 ms, 1484.84 KB |

> These are initial local numbers. Re-run on controlled hardware for publishable final comparisons.
