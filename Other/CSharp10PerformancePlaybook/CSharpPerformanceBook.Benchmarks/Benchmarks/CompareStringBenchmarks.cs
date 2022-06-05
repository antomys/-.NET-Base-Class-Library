using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace CSharpPerformanceBook.Benchmarks.Benchmarks;

[RankColumn, MinColumn, MaxColumn, Q1Column, Q3Column, AllStatisticsColumn]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[MarkdownExporterAttribute.GitHub]
[MemoryDiagnoser]
[RankColumn]
public class CompareStringBenchmarks
{
    private const string TestString = "test";

    [Benchmark(Baseline = true)]
    public bool EqualityComparison()
    {
        return TestString == "test";
    }
    
    [Benchmark]
    public bool EqualsCommonComparison()
    {
        return TestString.Equals("test");
    }
    
    [Benchmark]
    public bool EqualsOrdinalIgnoreCaseComparison()
    {
        return TestString.Equals("test", StringComparison.OrdinalIgnoreCase);
    }
    
    [Benchmark]
    public bool EqualsOrdinalComparison()
    {
        return TestString.Equals("test", StringComparison.Ordinal);
    }
    
    [Benchmark]
    public bool EqualsCurrentCultureIgnoreCaseComparison()
    {
        return TestString.Equals("test", StringComparison.CurrentCultureIgnoreCase);
    }
    
    [Benchmark]
    public bool EqualsInvariantCultureIgnoreCaseComparison()
    {
        return TestString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
    }
    
    [Benchmark]
    public int StringCompareCommonComparison()
    {
        // ReSharper disable once StringCompareIsCultureSpecific.1
        return string.Compare(TestString, "test");
    }
    
    [Benchmark]
    public int StringCompareOrdinalComparison()
    {
        return string.CompareOrdinal(TestString, "test");
    }
}