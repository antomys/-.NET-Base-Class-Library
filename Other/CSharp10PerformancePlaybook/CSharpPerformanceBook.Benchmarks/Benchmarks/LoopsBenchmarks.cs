using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using Bogus;

namespace CSharpPerformanceBook.Benchmarks.Benchmarks;

[RankColumn, MinColumn, MaxColumn, Q1Column, Q3Column, AllStatisticsColumn]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[MarkdownExporterAttribute.GitHub]
[MemoryDiagnoser]
[RankColumn]
public class LoopsBenchmarks
{
    private readonly Faker _faker = new();
    
    [Params(1, 10, 100, 1000)]
    public int Count { get; set; }

    private string[] Names => Enumerable.Range(0, Count).Select(_ => _faker.Name.FirstName()).ToArray();

    [Benchmark]
    public void ForLoop()
    {
        for (var i = 0; i < Names.Length; i++)
        {
            var x = Names[i];
        }
    }
    
    [Benchmark]
    public void ForeachLoop()
    {
        foreach (var x in Names)
        {
            ;
        }
    }
}