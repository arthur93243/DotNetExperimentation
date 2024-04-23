using BenchmarkDotNet.Attributes;

namespace BenchMarkSample.EmptyVSNewList;

[MaxColumn, MinColumn, MeanColumn]
public class EmptyVSNewList
{
    [Benchmark]
    public void GetByEmptyToList()
    {
        Enumerable.Empty<Foo>().ToList();
    }
    
    [Benchmark]
    public void GetByEmpty()
    {
        Enumerable.Empty<Foo>();
    }
    
    [Benchmark]
    public void GetByNewList()
    {
        new List<Foo>();
    }
}
