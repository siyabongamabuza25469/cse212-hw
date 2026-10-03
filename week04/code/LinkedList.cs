using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class LinkedList : IEnumerable<int>
{
    private class Node
    {
        public int Value;
        public Node? Next;

        public Node(int value)
        {
            Value = value;
            Next = null;
        }
    }

    private Node? head;
    private Node? tail;

    public void InsertHead(int value)
    {
        Node node = new Node(value)
        {
            Next = head
        };

        head = node;

        if (tail == null)
        {
            tail = node;
        }
    }

    public void InsertTail(int value)
    {
        Node node = new Node(value);

        if (tail == null)
        {
            head = node;
            tail = node;
            return;
        }

        tail.Next = node;
        tail = node;
    }

    public void RemoveTail()
    {
        if (head == null)
        {
            return;
        }

        if (head == tail)
        {
            head = null;
            tail = null;
            return;
        }

        Node current = head;

        while (current.Next != null && current.Next != tail)
        {
            current = current.Next;
        }

        current.Next = null;
        tail = current;
    }

    public void InsertAfter(int existingValue, int newValue)
    {
        Node? current = head;

        while (current != null)
        {
            if (current.Value == existingValue)
            {
                Node node = new Node(newValue)
                {
                    Next = current.Next
                };

                current.Next = node;

                if (current == tail)
                {
                    tail = node;
                }

                return;
            }

            current = current.Next;
        }
    }

    public void Remove(int value)
    {
        if (head == null)
        {
            return;
        }

        // Remove the first matching head node.
        if (head.Value == value)
        {
            head = head.Next;

            if (head == null)
            {
                tail = null;
            }

            return;
        }

        Node current = head;

        while (current.Next != null)
        {
            if (current.Next.Value == value)
            {
                if (current.Next == tail)
                {
                    tail = current;
                }

                current.Next = current.Next.Next;

                // Remove only the first matching node.
                return;
            }

            current = current.Next;
        }
    }

    public void Replace(int oldValue, int newValue)
    {
        Node? current = head;

        while (current != null)
        {
            if (current.Value == oldValue)
            {
                current.Value = newValue;
            }

            current = current.Next;
        }
    }

    public IEnumerable<int> Reverse()
    {
        return ReverseFrom(head);
    }

    private IEnumerable<int> ReverseFrom(Node? node)
    {
        if (node == null)
        {
            yield break;
        }

        foreach (int value in ReverseFrom(node.Next))
        {
            yield return value;
        }

        yield return node.Value;
    }

    public bool HeadAndTailAreNull()
    {
        return head == null && tail == null;
    }

    public bool HeadAndTailAreNotNull()
    {
        return head != null && tail != null;
    }

    public override string ToString()
    {
        StringBuilder builder = new StringBuilder("<LinkedList>{");
        Node? current = head;

        while (current != null)
        {
            builder.Append(current.Value);

            if (current.Next != null)
            {
                builder.Append(", ");
            }

            current = current.Next;
        }

        builder.Append("}");
        return builder.ToString();
    }

    public IEnumerator<int> GetEnumerator()
    {
        Node? current = head;

        while (current != null)
        {
            yield return current.Value;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

public static class EnumerableExtensions
{
    public static string AsString(this IEnumerable<int> values)
    {
        StringBuilder builder = new StringBuilder("<IEnumerable>{");
        bool first = true;

        foreach (int value in values)
        {
            if (!first)
            {
                builder.Append(", ");
            }

            builder.Append(value);
            first = false;
        }

        builder.Append("}");
        return builder.ToString();
    }
}