using System;
using DependencyInjectionLifetimeSample.Logic;

namespace DependencyInjectionLifetimeSample.Service;

public class TestService : IAppService
{
    readonly ITestLogicB testLogicB;
    
    public TestService(ITestLogicB testLogicB)
    {
        this.testLogicB = testLogicB;
    }
    
    public void Run(string serviceName)
    {
        Console.WriteLine($"{serviceName} -> (Start) >>>>>>>>>>");
        Console.WriteLine("WorkFlow: LogicB -> Dao -> LogicA");
        
        testLogicB.ShowLogic();
        
        Console.WriteLine($"{serviceName} -> (End) <<<<<<<<<<");
    }
}
