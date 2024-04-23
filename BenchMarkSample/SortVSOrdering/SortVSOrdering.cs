using BenchmarkDotNet.Attributes;

namespace BenchMarkSample.SortVSOrdering;

public class SortVSOrdering
{
    readonly List<int> forSort;
    readonly List<int> forOrdering;
    
    public SortVSOrdering()
    {
        IEnumerable<int> dataSource = NumberList();

        forSort = new(dataSource);
        forOrdering = new(dataSource);
    }
    
    [Benchmark]
    public void Ordering()
    {
        forOrdering.OrderBy(x => x).ToList();
    }
    
    [Benchmark]
    public void Sort()
    {
        forSort.Sort();
    }
    
    

    List<int> NumberList()
    {
        Random random = new();
        List<int> data = Enumerable.Range(0, 100).Select(x => random.Next(1, 999)).ToList();

        return data;
    }
}
