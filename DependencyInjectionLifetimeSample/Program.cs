using System;
using DependencyInjectionLifetimeSample.Component;
using DependencyInjectionLifetimeSample.Dao;
using DependencyInjectionLifetimeSample.Logic;
using DependencyInjectionLifetimeSample.Service;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjectionLifetimeSample;

class Program
{
    public static void Main(string[] args)
    {
        ServiceCollection serviceCollection = CreateServiceCollection();
        ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

        RunAppScope(serviceProvider, "Scope No.1");
        RunAppScope(serviceProvider, "Scope No.2");
    }

    static ServiceCollection CreateServiceCollection()
    {
        ServiceCollection serviceCollection = new();

        //Singleton
        serviceCollection.AddSingleton<ISingletonComponent, Component.Component>();

        //Scope
        serviceCollection.AddScoped<IScopeComponent, Component.Component>();

        //Transient
        // serviceCollection.AddTransient<IAppService, AppService>();
        serviceCollection.AddTransient<ITransientComponent, Component.Component>();

        //--------------------------------------------------------------
        //Scope
        serviceCollection.AddScoped<ITestLogicB, TestLogicB>();

        //Transient
        serviceCollection.AddTransient<IAppService, TestService>();
        serviceCollection.AddTransient<ITestLogicA, TestLogicA>();
        serviceCollection.AddTransient<ITestDao, TestDao>();

        return serviceCollection;
    }

    static void RunAppScope(ServiceProvider serviceProvider, string name)
    {
        using IServiceScope serviceScope = serviceProvider.CreateScope();
        IServiceProvider provider = serviceScope.ServiceProvider;
        RunAppService(provider, $"({name})Service A");
        RunAppService(provider, $"({name})Service B");
        // RunAppService(provider, $"({name})Service C");
    }

    static void RunAppService(IServiceProvider serviceProvider, string name)
    {
        IAppService appService = serviceProvider.GetRequiredService<IAppService>();
        appService.Run(name);
    }
}