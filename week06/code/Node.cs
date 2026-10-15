public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        Data = data;
    }

    public void Insert(int value)
    {
        if (value == Data)
        {
            // Do not insert duplicate values.
            return;
        }

        if (value < Data)
        {
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else
        {
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        if (value == Data)
            return true;

        if (value < Data)
            return Left is not null && Left.Contains(value);

        return Right is not null && Right.Contains(value);
    }

    /// <summary>
    /// Returns the height measured in edges.
    /// A leaf node has height 0.
    /// </summary>
    public int GetHeight()
    {
        int leftHeight = Left is null ? -1 : Left.GetHeight();
        int rightHeight = Right is null ? -1 : Right.GetHeight();

        return 1 + Math.Max(leftHeight, rightHeight);
    }
}