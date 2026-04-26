using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;

namespace Core300;

[InProcess]
[RankColumn, MemoryDiagnoser, IterationCount(10), WarmupCount(3)]
public class Core300Benchmarks
{
    private readonly IGisService _service = new ArcGis300Service();

    [GlobalSetup]
    public void Setup() => _service.Initialize();

    [Benchmark(Baseline = true)]
    public void Geometry_Project_10kPoints() => _service.Project10kPoints();

    [Benchmark]
    public void Graphics_AddRemove_5k() => _service.AddRemoveGraphics(5000);
}
