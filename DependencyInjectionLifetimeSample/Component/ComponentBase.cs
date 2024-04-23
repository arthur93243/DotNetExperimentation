using System;

namespace DependencyInjectionLifetimeSample.Component;

public class ComponentBase : IComponentBase
{
    protected readonly Guid guid;
    
    public ComponentBase(Guid guid)
    {
        this.guid = guid;
    }
    
    public Guid GetGuid()
    {
        return guid;
    }

    public void ShowGuid()
    {
        Console.WriteLine(guid.ToString());
    }
}
