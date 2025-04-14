using AlgorithmsPractice.Logics.Interface;

namespace AlgorithmsPractice.Logics;

public class RecursiveLogic : IRecursiveLogic
{
    // n! = n * (n-1)!
    public int Factorial(int n)
    {
        if (n == 0)
        {
            return 1;
        }

        return n * Factorial(n - 1);
    }

    // Fibonacci series: 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55...
    public int Fibonacci(int index)
    {
        if (index == 0)
        {
            return 0;
        }

        if (index == 1)
        {
            return 1;
        }

        return Fibonacci(index - 1) + Fibonacci(index - 2);
    }

    // A(m, n) = n + 1, if m = 0
    // A(m, n) = A(m - 1, 1), if m = 0
    // A(m, n) = A(m - 1, A(m, n - 1)), if m > 0 and n > 0p
    public int Ackermann(int m, int n)
    {
        if (m == 0)
        {
            return n + 1;
        }
        
        if (n == 0)
        {
            return Ackermann(m - 1, 1);
        }
        
        return Ackermann(m - 1, Ackermann(m, n - 1));
    }
}