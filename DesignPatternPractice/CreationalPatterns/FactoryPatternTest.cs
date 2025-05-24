using Xunit;
using FluentAssertions;

namespace DesignPatternPractice.CreationalPatterns;

public class FactoryPatternTest
{
    [Fact]
    public void TestAbstractFactoryOnLab12()
    {
        // Arrange
        AbstractFactoryPattern.ITsmcFactory factory = new AbstractFactoryPattern.Lab12();
        string expected = "TSMC Lab-12 produce chip on : Chip 5nm Process";

        // Act
        string actual = factory.OrderProcess();

        // Assert
        actual.Should().Be(expected);
    }
    
    [Fact]
    public void TestAbstractFactoryOnLab17()
    {
        // Arrange
        AbstractFactoryPattern.ITsmcFactory factory = new AbstractFactoryPattern.Lab17();
        string expected = "TSMC Lab-17 produce chip on : Chip 3nm Process";

        // Act
        string actual = factory.OrderProcess();

        // Assert
        actual.Should().Be(expected);
    }
    
    [Theory]
    [InlineData("3nm", "Chip 3nm Process")]
    [InlineData("5nm", "Chip 5nm Process")]
    public void TestFactoryMethod(string processType, string result)
    {
        // Arrange
        FactoryMethodPattern.ITsmcFactory factory = new FactoryMethodPattern.TsmcFactory();
        string expected = $"TSMC Factory: {result}";

        // Act
        string actual = factory.OrderProcess(processType);

        // Assert
        actual.Should().Be(expected);
    }
    
    [Theory]
    [InlineData("3nm", "Chip 3nm Process")]
    [InlineData("5nm", "Chip 5nm Process")]
    public void TestSimpleFactory(string processType, string result)
    {
        // Arrange
        SimpleFactoryPattern.ITsmcFactory factory = new SimpleFactoryPattern.TsmcFactory();
        string expected = $"TSMC Factory: {result}";

        // Act
        string actual = factory.OrderProcess(processType);

        // Assert
        actual.Should().Be(expected);
    }
}