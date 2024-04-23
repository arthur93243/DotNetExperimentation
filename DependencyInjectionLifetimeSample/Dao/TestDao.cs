using System;
using DependencyInjectionLifetimeSample.Component;

namespace DependencyInjectionLifetimeSample.Dao;

public class TestDao : ComponentBase, ITestDao
{
    public TestDao() : base(Guid.NewGuid())
    {
    }

    public void ShowDao()
    {
        Console.WriteLine($"Show Dao -> {GetGuid().ToString()}");
    }
}
