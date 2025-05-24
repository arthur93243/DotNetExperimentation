namespace DesignPatternPractice.CreationalPatterns.SimpleFactoryPattern;

public class TsmcFactory : ITsmcFactory
{
    public string OrderProcess(string processType)
    {
        string result = CreateChip(processType);
        return $"TSMC Factory: {result}";
    }
    
    string CreateChip(string processType)
    {
        switch (processType)
        {
            case "3nm":
                return "Chip 3nm Process";
            
            case "5nm":
                return "Chip 5nm Process";
        }
        
        throw new ArgumentException();
    }
}