namespace DesignPatternPractice.CreationalPatterns.AbstractFactoryPattern;

public abstract class TsmcFactory : ITsmcFactory
{
    public string OrderProcess()
    {
        IFactoryProcess factory = CreateFactory();
        string product =  factory.Process();
        string lab = Describe();
        
        return $"TSMC {lab} produce chip on : {product}";
    }
    
    protected abstract string Describe();

    protected abstract IFactoryProcess CreateFactory();
}