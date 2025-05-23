using AlgorithmsPractice.Logics.BinaryTree;
using AlgorithmsPractice.Logics.Interface;
using FluentAssertions;

namespace AlgorithmsPractice;

public class BinaryTreeTest
{
    readonly Node root;
    
    public BinaryTreeTest()
    {
        root = new Node("A")
        {
            Left = new Node("B")
            {
                Left = new Node("D"),
                Right = new Node("E")
            },
            Right = new Node("C")
            {
                Left = new Node("F"),
                Right = new Node("G")
            }
        };
    }
    
    [Fact]
    public void TestPreOrderTraversal()
    {
        // Arrange
        IBinaryTree target = new BinaryTree(root);
        string expected = "ABDECFG";

        // Act
        string actual = target.PreOrderTraversal();

        // Assert
        actual.Should().Be(expected);
    }
    
    [Fact]
    public void TestInOrderTraversal()
    {
        // Arrange
        IBinaryTree target = new BinaryTree(root);
        string expected = "DBEAFCG";

        // Act
        string actual = target.InOrderTraversal();

        // Assert
        actual.Should().Be(expected);
    }
    
    [Fact]
    public void TestPostOrderTraversal()
    {
        // Arrange
        IBinaryTree target = new BinaryTree(root);
        string expected = "DEBFGCA";

        // Act
        string actual = target.PostOrderTraversal();

        // Assert
        actual.Should().Be(expected);
    }
    
    [Fact]
    public void TestLevelOrderTraversal()
    {
        // Arrange
        IBinaryTree target = new BinaryTree(root);
        string expected = "ABCDEFG";

        // Act
        string actual = target.LevelOrderTraversal();

        // Assert
        actual.Should().Be(expected);
    }
}