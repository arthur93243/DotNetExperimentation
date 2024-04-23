// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Running;
using BenchMarkSample.EmptyVSNewList;
using BenchMarkSample.MaxByVSDescending;
using BenchMarkSample.SortVSOrdering;

class Program
{
    public static void Main(string[] args)
    {
        // RunSortVSOrdering();
        // RunEmptyVSNewList();
        MaxByVSDescending();
    }

    static void RunEmptyVSNewList()
    {
        BenchmarkRunner.Run<EmptyVSNewList>();
    }
    
    static void RunSortVSOrdering()
    {
        BenchmarkRunner.Run<SortVSOrdering>();
    }

    static void MaxByVSDescending()
    {
        BenchmarkRunner.Run<MaxByVSDescending>();
    }
}
