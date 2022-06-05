using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using Bogus;
using CSharpPerformanceBook.Benchmarks.ClassesStructsRecords;
// ReSharper disable PossibleMultipleEnumeration

namespace CSharpPerformanceBook.Benchmarks.Benchmarks;

[RankColumn, MinColumn, MaxColumn, Q1Column, Q3Column, AllStatisticsColumn]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[MarkdownExporterAttribute.GitHub]
[MemoryDiagnoser]
[RankColumn]
public class ClassVsStructVsRecordBenchmarks
{
    private readonly Faker _faker = new();
    
    [Params(10, 100, 1000)]
    public int Count { get; set; }

    private List<string> Names => Enumerable.Range(0, Count).Select(_ => _faker.Name.FirstName()).ToList();

    [Benchmark]
    public void Classes()
    {
        var classes = Names.Select(name => new PersonClass {Name = name});
        
        for (var i = 0; i < classes.Count(); i++)
        {
            var x = classes.ElementAt(i).Name;
        }
    }
    
    [Benchmark]
    public void ClassesSealed()
    {
        var classes = Names.Select(name => new PersonClassSealed {Name = name});
        
        for (var i = 0; i < classes.Count(); i++)
        {
            var x = classes.ElementAt(i).Name;
        }
    }
    
    [Benchmark]
    public void Structs()
    {
        var structs = Names.Select(name => new PersonStruct {Name = name});
        
        for (var i = 0; i < structs.Count(); i++)
        {
            var x = structs.ElementAt(i).Name;
        }
    }
    
    [Benchmark]
    public void RecordsClass()
    {
        var records = Names.Select(name => new PersonRecordClass(name));
        
        for (var i = 0; i < records.Count(); i++)
        {
            var x = records.ElementAt(i).Name;
        }
    }
    
    [Benchmark]
    public void RecordsClassSealed()
    {
        var records = Names.Select(name => new PersonRecordClassSealed(name));
        
        for (var i = 0; i < records.Count(); i++)
        {
            var x = records.ElementAt(i).Name;
        }
    }
    
    [Benchmark]
    public void RecordsStruct()
    {
        var records = Names.Select(name => new PersonRecordStruct(name));
        
        for (var i = 0; i < records.Count(); i++)
        {
            var x = records.ElementAt(i).Name;
        }
    }
}