using System;
using DependencyInjectionLifetimeSample.Component;

namespace DependencyInjectionLifetimeSample.Logic;

public class TestLogicB : ComponentBase, ITestLogicB
{
    readonly ITestLogicA testLogic;
    
    public TestLogicB(ITestLogicA testLogic) : base(Guid.NewGuid())
    {
        this.testLogic = testLogic;
    }

    public void ShowLogic()
    {
        Console.WriteLine($"Show Logic B -> {GetGuid().ToString()}");
        testLogic.ShowLogic();
    }
}
