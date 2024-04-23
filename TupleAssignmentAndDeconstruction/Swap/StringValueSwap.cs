namespace TupleAssignmentAndDeconstruction.Swap;

public class StringValueSwap : IAction
{
    public void Execute()
    {
        string a = "Hello";
        string b = "World";

        Console.WriteLine("Before:");
        Console.WriteLine($"a: {a}, b: {b}");

        // Swap the values of a and b
        (a, b) = (b, a);

        Console.WriteLine("After:");
        Console.WriteLine($"a: {a}, b: {b}");
    }
}