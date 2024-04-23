using System;
using DependencyInjectionLifetimeSample.Component;
using DependencyInjectionLifetimeSample.Dao;

namespace DependencyInjectionLifetimeSample.Logic;

public class TestLogicA : ComponentBase, ITestLogicA
{
    readonly ITestDao testDao;

    public TestLogicA(ITestDao testDao) : base(Guid.NewGuid())
    {
        this.testDao = testDao;
    }

    public void ShowLogic()
    {
        testDao.ShowDao();
        Console.WriteLine($"Show Logic A -> {GetGuid().ToString()}");
    }
}
