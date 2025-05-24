namespace DesignPatternPractice.CreationalPatterns.AbstractFactoryPattern;

public class Lab12 : TsmcFactory
{
    protected override string Describe()
    {
        return "Lab-12";
    }

    protected override IFactoryProcess CreateFactory()
    {
        return new Chip5NmFactory();
    }
}