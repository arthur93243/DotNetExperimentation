using System;
using DependencyInjectionLifetimeSample.Component;

namespace DependencyInjectionLifetimeSample.Service;

public class AppService : IAppService
{
    readonly ISingletonComponent singletonComponent;
    readonly IScopeComponent scopeComponent;
    readonly ITransientComponent transientComponent;
    
    public AppService(
        ISingletonComponent singletonComponent,
        IScopeComponent scopeComponent,
        ITransientComponent transientComponent)
    {
        this.singletonComponent = singletonComponent;
        this.scopeComponent = scopeComponent;
        this.transientComponent = transientComponent;
    }

    public void Run(string serviceName)
    {
        Console.WriteLine($"{serviceName} - (Start) >>>>>>>>>>>>>>>>>>>>>>>>>");
        
        Console.WriteLine($"{serviceName} - Singleton Component: {singletonComponent.GetGuid().ToString()}");
        Console.WriteLine($"{serviceName} - Scope Component: {scopeComponent.GetGuid().ToString()}");
        Console.WriteLine($"{serviceName} - Transient Component: {transientComponent.GetGuid().ToString()}");
        
        Console.WriteLine("(End) <<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
    }
}
