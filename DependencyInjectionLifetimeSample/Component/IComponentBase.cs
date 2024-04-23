using System;

namespace DependencyInjectionLifetimeSample.Component;

public interface IComponentBase
{
    Guid GetGuid();
    void ShowGuid();
}

public interface ISingletonComponent : IComponentBase
{
    
}

public interface IScopeComponent : IComponentBase
{
    
}

public interface ITransientComponent : IComponentBase
{
    
}
