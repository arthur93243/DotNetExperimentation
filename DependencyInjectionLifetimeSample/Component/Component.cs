using System;

namespace DependencyInjectionLifetimeSample.Component;

public class Component : ComponentBase, ISingletonComponent, IScopeComponent, ITransientComponent
{
    public Component() : base(Guid.NewGuid())
    {
    }
}
