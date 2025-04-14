using AlgorithmsPractice.Logics;
using AlgorithmsPractice.Logics.Interface;
using FluentAssertions;

namespace AlgorithmsPractice;

public class RecursiveLogicTest
{
    [Fact]
    public void TestFactorialZeroShouldBeOne()
    {
        // Arrange
        IRecursiveLogic target = new RecursiveLogic();
        int expected = 1;

        // Act
        int actual = target.Factorial(0);

        // Assert
        actual.Should().Be(expected);
    }
    
    [Theory]
    [InlineData(1, 1)]
    [InlineData(2, 2)]
    [InlineData(3, 6)]
    [InlineData(5, 120)]
    [InlineData(8, 40320)]
    public void TestFactorialNumbers(int n, int expected)
    {
        // Arrange
        IRecursiveLogic target = new RecursiveLogic();

        // Act
        int actual = target.Factorial(n);

        // Assert
        actual.Should().Be(expected);
    }
    
    [Fact]
    public void TestFibonacciZeroShouldBeZero()
    {
        // Arrange
        IRecursiveLogic target = new RecursiveLogic();
        int expected = 0;

        // Act
        int actual = target.Fibonacci(0);

        // Assert
        actual.Should().Be(expected);
    }
    
    [Fact]
    public void TestFibonacciOneShouldBeOne()
    {
        // Arrange
        IRecursiveLogic target = new RecursiveLogic();
        int expected = 1;

        // Act
        int actual = target.Fibonacci(1);

        // Assert
        actual.Should().Be(expected);
    }
    
    [Theory]
    [InlineData(2, 1)]
    [InlineData(3, 2)]
    [InlineData(4, 3)]
    [InlineData(5, 5)]
    [InlineData(6, 8)]
    [InlineData(7, 13)]
    [InlineData(10, 55)]
    public void TestFibonacciSerial(int n, int expected)
    {
        // Arrange
        IRecursiveLogic target = new RecursiveLogic();

        // Act
        int actual = target.Fibonacci(n);

        // Assert
        actual.Should().Be(expected);
    }
    
    [Fact]
    public void TestAckermannZeroZeroShouldBeOne()
    {
        // Arrange
        IRecursiveLogic target = new RecursiveLogic();
        int expected = 1;

        // Act
        int actual = target.Ackermann(0, 0);

        // Assert
        actual.Should().Be(expected);
    }
    
    [Fact]
    public void TestAckermannZeroOneShouldBeTwo()
    {
        // Arrange
        IRecursiveLogic target = new RecursiveLogic();
        int expected = 2;

        // Act
        int actual = target.Ackermann(0, 1);

        // Assert
        actual.Should().Be(expected);
    }
    
    [Fact]
    public void TestAckermannOneZeroShouldBeTwo()
    {
        // Arrange
        IRecursiveLogic target = new RecursiveLogic();
        int expected = 2;

        // Act
        int actual = target.Ackermann(1, 0);

        // Assert
        actual.Should().Be(expected);
    }
    
    [Theory]
    [InlineData(1, 1, 3)]
    [InlineData(1, 2, 4)]
    [InlineData(1, 3, 5)]
    [InlineData(1, 4, 6)]
    [InlineData(1, 5, 7)]
    [InlineData(1, 6, 8)]
    public void TestAckermannFunction(int m, int n, int expected)
    {
        // Arrange
        IRecursiveLogic target = new RecursiveLogic();

        // Act
        int actual = target.Ackermann(m, n);

        // Assert
        actual.Should().Be(expected);
    }
}