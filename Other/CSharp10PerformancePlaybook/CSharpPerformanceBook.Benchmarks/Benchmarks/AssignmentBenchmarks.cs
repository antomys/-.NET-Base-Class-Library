using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using Bogus;
using CSharpPerformanceBook.Benchmarks.ClassesStructsRecords;

namespace CSharpPerformanceBook.Benchmarks.Benchmarks;

[RankColumn, MinColumn, MaxColumn, Q1Column, Q3Column, AllStatisticsColumn]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[MarkdownExporterAttribute.GitHub]
[MemoryDiagnoser]
[ShortRunJob]
[RankColumn]
public class AssignmentBenchmarks
{
    private readonly Faker _faker = new();
    
    [Params(10, 100, 1000)]
    public int Count { get; set; }

    private List<string> Names => Enumerable.Range(0, Count).Select(_ => _faker.Name.FirstName()).ToList();

    [Benchmark]
    public void PropertyAssignmentClass()
    {
        foreach (var name in Names)
        {
            var person = new PersonClassSealed();

            person.Name = name;
        }
    }
    
    [Benchmark]
    public void DirectAssignmentClass()
    {
        foreach (var name in Names)
        {
            var person = new PersonClassSealed();

            person.name = name;
        }
    }
    
    [Benchmark]
    public void PropertyAssignmentStruct()
    {
        foreach (var name in Names)
        {
            var person = new PersonStruct();

            person.Name = name;
        }
    }
    
    [Benchmark]
    public void DirectAssignmentStruct()
    {
        foreach (var name in Names)
        {
            var person = new PersonStruct();

            person.name = name;
        }
    }
}