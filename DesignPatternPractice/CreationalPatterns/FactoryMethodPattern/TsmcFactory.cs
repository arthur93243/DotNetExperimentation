namespace DesignPatternPractice.CreationalPatterns.FactoryMethodPattern;

public class TsmcFactory : ITsmcFactory
{
    public string OrderProcess(string processType)
    {
        IFactoryProcess factory = CreateFactory(processType);
        string result = factory.Process();
        
        return $"TSMC Factory: {result}";
    }
    
    IFactoryProcess CreateFactory(string processType)
    {
        switch (processType)
        {
            case "3nm":
                return new Chip3NmFactory();

            case "5nm":
                return new Chip5NmFactory();
        }

        throw new ArgumentException();
    }
}