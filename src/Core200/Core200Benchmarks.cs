using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;

namespace Core200;

[InProcess]
[RankColumn, MemoryDiagnoser, IterationCount(10), WarmupCount(3)]
public class Core200Benchmarks
{
    private readonly IGisService _service = new ArcGis200Service();

    [GlobalSetup]
    public void Setup() => _service.Initialize();

    [Benchmark(Baseline = true)]
    public void Geometry_Project_10kPoints() => _service.Project10kPoints();

    [Benchmark]
    public void Graphics_AddRemove_5k() => _service.AddRemoveGraphics(5000);
}
