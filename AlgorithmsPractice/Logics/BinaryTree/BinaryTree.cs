using AlgorithmsPractice.Logics.Interface;

namespace AlgorithmsPractice.Logics.BinaryTree;

public class BinaryTree(Node root) : IBinaryTree
{
    public string PreOrderTraversal()
    {
        return GetPreOrderTraversalValue(root);
    }
    
    public string InOrderTraversal()
    {
        return GetInOrderTraversalValue(root);
    }
    
    public string PostOrderTraversal()
    {
        return GetPostOrderTraversalValue(root);
        // Test(root);
        // return string.Empty;
    }

    public string LevelOrderTraversal()
    {
        return GetLevelOrderTraversalValue(root);
    }
    
    string GetPreOrderTraversalValue(Node root)
    {
        // Pre-order traversal: Root -> Left -> Right
        string result = string.Empty;
        Stack<Node> stack = new();
        stack.Push(root);

        while (stack.Count > 0)
        {
            Node current = stack.Pop();
            result += current.GetValue();

            if (current.HasRight)
            {
                stack.Push(current.Right);
            }

            if (current.HasLeft)
            {
                stack.Push(current.Left);
            }
        }

        return result;
    }
    
    string GetInOrderTraversalValue(Node root)
    {
        string result = string.Empty;
        Stack<Node> stack = new();
        Node current = root;
        bool done = false;
        
        while (!done)
        {
            if (current != null)
            {
                stack.Push(current);
                current = current.Left;
            }
            else
            {
                if (stack.Count > 0)
                {
                    current = stack.Pop();
                    result += current.GetValue();
                    current = current.Right;
                }
                else
                {
                    done = true;
                }
            }
        }

        return result;
    }
    
    string GetPostOrderTraversalValue(Node root)
    {
        // Post-order traversal: Left -> Right -> Root
        string result = string.Empty;
        Stack<Node> stack = new();
        bool done = false;
        
        Node current = root;
        stack.Push(current);

        while (!done)
        {
            if (current.HasRight)
            {
                stack.Push(current.Right);
                current = current.Right;
            }
            
            if (current.HasLeft)
            {
                stack.Push(current.Left);
                current = current.Left;
            }
            
            if (current.IsLeaf)
            {
                current = stack.Pop();
                result += current.GetValue();
                
                current = stack.Pop();
            }
            else
            {
                done = true;
            }
        }

        return result;
    }

    void Test(Node node)
    {
        if (node.HasLeft)
        {
            Test(node.Left);
        }

        if (node.HasRight)
        {
            Test(node.Right);
        }
        
        Console.Write(node.GetValue());
    }
    
    string GetLevelOrderTraversalValue(Node root)
    {
        string result = string.Empty;
        Queue<Node> queue = new();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            Node current = queue.Dequeue();
            result += current.GetValue();

            if (current.Left != null)
            {
                queue.Enqueue(current.Left);
            }

            if (current.Right != null)
            {
                queue.Enqueue(current.Right);
            }
        }

        return result;
    }
}