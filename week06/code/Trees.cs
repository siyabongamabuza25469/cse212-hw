using System;

public static class Trees
{
    /// <summary>
    /// Given a sorted list, create a balanced binary search tree.
    /// </summary>
    public static BinarySearchTree CreateTreeFromSortedList(
        int[] sortedNumbers)
    {
        if (sortedNumbers == null)
            throw new ArgumentNullException(nameof(sortedNumbers));

        var tree = new BinarySearchTree();

        AddMiddleValues(
            sortedNumbers,
            0,
            sortedNumbers.Length - 1,
            tree);

        return tree;
    }

    private static void AddMiddleValues(
        int[] values,
        int first,
        int last,
        BinarySearchTree tree)
    {
        if (first > last)
            return;

        // This midpoint choice gives the expected balanced shape for
        // both even- and odd-sized arrays.
        int middle = first + (last - first + 1) / 2;

        tree.Insert(values[middle]);

        AddMiddleValues(values, first, middle - 1, tree);
        AddMiddleValues(values, middle + 1, last, tree);
    }
}