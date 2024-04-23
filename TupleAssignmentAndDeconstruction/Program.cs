using TupleAssignmentAndDeconstruction;
using TupleAssignmentAndDeconstruction.Swap;

public class Program
{
    public static void Main(string[] args)
    {
        // IAction action = new StringValueSwap();
        IAction action = new ObjectSwap();

        action.Execute();
    }
}