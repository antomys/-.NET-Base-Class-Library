using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using CSharpPerformanceBook.Benchmarks.Extensions;

namespace CSharpPerformanceBook.Benchmarks.Benchmarks;

[RankColumn, MinColumn, MaxColumn, Q1Column, Q3Column, AllStatisticsColumn]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[MarkdownExporterAttribute.GitHub]
[MemoryDiagnoser]
[RankColumn]
public class BuildStringBenchmarks
{
    private const string TestString = "test";
    
    [Params(10, 50, 100)]
    public int Count { get; set; }
    
      
    [Benchmark(Baseline = true)]
    public string BuildStringBadly()
    {
        return TestString.BuildBadly(Count);
    }
    
    [Benchmark]
    public string BuildStringBetter()
    {
        return TestString.BuildBetter(Count);
    }
    
    [Benchmark]
    public string BuildStringBetterV2()
    {
        return TestString.BuildBetterV2(Count);
    }
}