namespace DesignPatternPractice.CreationalPatterns.AbstractFactoryPattern;

public class Lab17 : TsmcFactory
{
    protected override string Describe()
    {
        return "Lab-17";
    }

    protected override IFactoryProcess CreateFactory()
    {
        return new Chip3NmFactory();
    }
}