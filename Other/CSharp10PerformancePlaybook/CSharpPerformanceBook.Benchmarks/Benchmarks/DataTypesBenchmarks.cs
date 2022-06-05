using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace CSharpPerformanceBook.Benchmarks.Benchmarks;

[RankColumn, MinColumn, MaxColumn, Q1Column, Q3Column, AllStatisticsColumn]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[MarkdownExporterAttribute.GitHub]
[MemoryDiagnoser]
[RankColumn]
public class DataTypesBenchmarks
{
    [Benchmark(Baseline = true)]
    public void TypeInt()
    {
        int x = 200;

        for (var i = 0; i < x; i++)
        {
            var y = i;
            y++;
        }
    }
    
    [Benchmark]
    public void TypeByte()
    {
        byte x = 200;

        for (var i = 0; i < x; i++)
        {
            var y = i;
            y++;
        }
    }
    
    [Benchmark]
    public void TypeFloat()
    {
        float x = 200;

        for (var i = 0; i < x; i++)
        {
            var y = i;
            y++;
        }
    }
    
    [Benchmark]
    public void TypeUint()
    {
        uint x = 200;

        for (var i = 0; i < x; i++)
        {
            var y = i;
            y++;
        }
    }
    
    [Benchmark]
    public void TypeShort()
    {
        short x = 200;

        for (var i = 0; i < x; i++)
        {
            var y = i;
            y++;
        }
    }
    
    [Benchmark]
    public void TypeDouble()
    {
        double x = 200;

        for (var i = 0; i < x; i++)
        {
            var y = i;
            y++;
        }
    }
    
    [Benchmark]
    public void TypeDecimal()
    {
        decimal x = 200;

        for (var i = 0; i < x; i++)
        {
            var y = i;
            y++;
        }
    }
}