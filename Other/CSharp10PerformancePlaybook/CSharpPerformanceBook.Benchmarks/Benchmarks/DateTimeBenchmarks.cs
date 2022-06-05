using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace CSharpPerformanceBook.Benchmarks.Benchmarks;

[RankColumn, MinColumn, MaxColumn, Q1Column, Q3Column, AllStatisticsColumn]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[HtmlExporter, MarkdownExporterAttribute.GitHub]
[MemoryDiagnoser]
[RankColumn]
public class DateTimeBenchmarks
{
    private const string StringDate = "2022-02-22";

    [Benchmark(Baseline = true)]
    public int DirectCreate()
    {
        var dateTime = new DateTime(2022, 02, 22);

        return dateTime.Year;
    }
    
    [Benchmark]
    public int StringParseCreate()
    {
        var dateTime = DateTime.Parse(StringDate);

        return dateTime.Year;
    }
    
    [Benchmark]
    public int CustomParsingCreate()
    {
        var year = int.Parse(StringDate[..4]);
        var month = int.Parse(StringDate.Substring(5,2));
        var day = int.Parse(StringDate.Substring(8,2));
        
        var dateTime = new DateTime(year, month, day);

        return dateTime.Year;
    }
    
    [Benchmark]
    public int CustomParsingFastCreate()
    {
        var stringSpan = StringDate.AsSpan();
        
        var year = GetFirstIntFast(stringSpan[..4]);
        var month = GetFirstIntFast(stringSpan.Slice(5,2));
        var day = GetFirstIntFast(stringSpan.Slice(8,2));
       
        var dateTime = new DateTime(year, month, day);

        return dateTime.Year;
    }
    
    private static int GetFirstIntFast(ReadOnlySpan<char> intStr)
    {
        var sum = 0; //must be zero

        for (var i = 0; i < intStr.Length; i++)
        {
            sum = sum * 10 + (intStr[i] - 48);
        }
        
        return sum;
    }
}