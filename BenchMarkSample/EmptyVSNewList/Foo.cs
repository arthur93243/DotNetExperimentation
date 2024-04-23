namespace BenchMarkSample.EmptyVSNewList;

public class Foo
{
    public Guid Id { get; }
    public string Bar1 { get; set; }
    public string Bar2 { get; set; }
    public string Bar3 { get; set; }
    public string Bar4 { get; set; }
    public string Bar5 { get; set; }

    public Foo()
    {
        Id = Guid.NewGuid();
    }
}
