using System;
using System.Collections.Generic;

public class BinarySearchTree
{
    private TreeNode? _root;

    /// <summary>
    /// Inserts a value into the tree.
    /// Duplicate values are ignored.
    /// </summary>
    public void Insert(int value)
    {
        _root = Insert(_root, value);
    }

    private static TreeNode Insert(TreeNode? node, int value)
    {
        if (node == null)
            return new TreeNode(value);

        if (value < node.Data)
        {
            node.Left = Insert(node.Left, value);
        }
        else if (value > node.Data)
        {
            node.Right = Insert(node.Right, value);
        }

        return node;
    }

    /// <summary>
    /// Returns true when the tree contains the specified value.
    /// </summary>
    public bool Contains(int value)
    {
        TreeNode? current = _root;

        while (current != null)
        {
            if (value == current.Data)
                return true;

            current = value < current.Data
                ? current.Left
                : current.Right;
        }

        return false;
    }

    /// <summary>
    /// Returns the tree height in levels.
    /// Empty tree: 0
    /// Single-node tree: 1
    /// </summary>
    public int GetHeight()
    {
        return GetHeight(_root);
    }

    private static int GetHeight(TreeNode? node)
    {
        if (node == null)
            return 0;

        return 1 + Math.Max(
            GetHeight(node.Left),
            GetHeight(node.Right));
    }

    /// <summary>
    /// Reverses the tree by recursively swapping every node's
    /// left and right subtrees.
    /// </summary>
    public BinarySearchTree Reverse()
    {
        Reverse(_root);
        return this;
    }

    private static void Reverse(TreeNode? node)
    {
        if (node == null)
            return;

        (node.Left, node.Right) = (node.Right, node.Left);

        Reverse(node.Left);
        Reverse(node.Right);
    }

    /// <summary>
    /// Returns the tree values in pre-order form.
    /// </summary>
    public string AsString()
    {
        var values = new List<int>();
        AddPreOrder(_root, values);

        return $"<IEnumerable>{{{string.Join(", ", values)}}}";
    }

    /// <summary>
    /// Returns the tree values in sorted/in-order form.
    /// </summary>
    public override string ToString()
    {
        var values = new List<int>();
        AddInOrder(_root, values);

        return $"<Bst>{{{string.Join(", ", values)}}}";
    }

    private static void AddPreOrder(
        TreeNode? node,
        List<int> values)
    {
        if (node == null)
            return;

        values.Add(node.Data);
        AddPreOrder(node.Left, values);
        AddPreOrder(node.Right, values);
    }

    private static void AddInOrder(
        TreeNode? node,
        List<int> values)
    {
        if (node == null)
            return;

        AddInOrder(node.Left, values);
        values.Add(node.Data);
        AddInOrder(node.Right, values);
    }

    private sealed class TreeNode
    {
        public int Data { get; }

        public TreeNode? Left { get; set; }

        public TreeNode? Right { get; set; }

        public TreeNode(int data)
        {
            Data = data;
        }
    }
}