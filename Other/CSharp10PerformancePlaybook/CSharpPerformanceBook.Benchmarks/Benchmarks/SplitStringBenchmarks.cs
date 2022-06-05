using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using CSharpPerformanceBook.Benchmarks.Extensions;

namespace CSharpPerformanceBook.Benchmarks.Benchmarks;

[RankColumn, MinColumn, MaxColumn, Q1Column, Q3Column, AllStatisticsColumn]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[MarkdownExporterAttribute.GitHub]
[MemoryDiagnoser]
[RankColumn]
public class SplitStringBenchmarks
{
    private const string ToSplitString = "Volokhovych, Ihor";

    [Benchmark(Baseline = true)]
    public void NaiveSplitStringCommon()
    {
        var _ = ToSplitString.NaiveSplitStringCommon();
    }
    
    [Benchmark]
    public void NaiveSplitStringOrdinalIgnoreCase()
    {
        var _ = ToSplitString.NaiveSplitStringOrdinalIgnoreCase();
    }
    
    [Benchmark]
    public void NaiveSplitStringOrdinal()
    {
        var _ = ToSplitString.NaiveSplitStringOrdinal();
    }
    
    [Benchmark]
    public void NaiveSplitStringCurrentCultureIgnoreCase()
    {
        var _ = ToSplitString.NaiveSplitStringCurrentCultureIgnoreCase();
    }
    
    [Benchmark]
    public void NaiveSplitStringInvariantCultureIgnoreCase()
    {
        var _ = ToSplitString.NaiveSplitStringInvariantCultureIgnoreCase();
    }

    [Benchmark]
    public void StringSplitString()
    {
        var _ = ToSplitString.StringSplitString();
    }
    
    [Benchmark]
    public void SpanSplitString()
    {
        var _ = ToSplitString.SpanSplitString();
    }
}