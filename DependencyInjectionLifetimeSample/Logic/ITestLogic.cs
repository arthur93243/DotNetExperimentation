namespace DependencyInjectionLifetimeSample.Logic;

public interface ITestLogic
{
    public void ShowLogic();
}

public interface ITestLogicA : ITestLogic
{
}

public interface ITestLogicB : ITestLogic
{
}