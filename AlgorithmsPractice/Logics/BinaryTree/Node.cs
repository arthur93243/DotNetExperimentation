namespace AlgorithmsPractice.Logics.BinaryTree;

public class Node(string value)
{
    public Node? Left { get; set; }
    public Node? Right { get; set; }
    public bool HasLeft => Left != null;
    public bool HasRight => Right != null;
    public bool IsLeaf => !HasLeft && !HasRight;
    
    public string GetValue()
    {
        return value;
    }
}