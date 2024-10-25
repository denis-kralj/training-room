using System.Text;

namespace DoubleLinkedList.Core;

public class DoubleLinkedList<T> where T : class
{
    public DoubleLinkedListNode<T>? Head { get; private set; }
    public DoubleLinkedListNode<T>? Tail { get; private set; }
    public int Count
    {
        get
        {
            var current = Head;
            var count = 0;
            while (current != null)
            {
                count++;
                current = current.Tail;
            }
            return count;
        }
    }
    public DoubleLinkedListNode<T> Insert(T value)
    {
        var newNode = new DoubleLinkedListNode<T>(value);
        if (Head == null)
        {
            Head = newNode;
            Tail = newNode;
            return newNode;
        }

        Head.Head = newNode;
        newNode.Tail = Head;
        Head = newNode;
        return newNode;
    }
    public DoubleLinkedListNode<T> Append(T value)
    {
        var newNode = new DoubleLinkedListNode<T>(value);
        if (Tail == null)
        {
            Head = newNode;
            Tail = newNode;
            return newNode;
        }

        Tail.Tail = newNode;
        newNode.Head = Tail;
        Tail = newNode;
        return newNode;
    }

    public DoubleLinkedListNode<T>? Find(T value)
    {
        var current = Head;
        while (current != null)
        {
            if (current.Value == value)
            {
                return current;
            }
            current = current.Tail;
        }
        return null;
    }

    public void Delete(DoubleLinkedListNode<T> toDelete)
    {
        if (Head == toDelete)
        {
            Head = toDelete.Tail;
        }

        if (Tail == toDelete)
        {
            Tail = Tail.Head;
        }

        if (toDelete.Head != null)
        {
            toDelete.Head.Tail = toDelete.Tail;
        }

        if (toDelete.Tail != null)
        {
            toDelete.Tail.Head = toDelete.Head;
        }
    }

    public string Print()
    {
        var stringBuilder = new StringBuilder("[");

        var current = Head;

        while (current != null)
        {
            stringBuilder.Append(current.Value.ToString());
            current = current.Tail;
            if (current != null)
            {
                stringBuilder.Append(", ");
            }
        }

        stringBuilder.Append(']');

        return stringBuilder.ToString();
    }

    public string PrintReverse()
    {
        var stringBuilder = new StringBuilder("[");

        var current = Tail;

        while (current != null)
        {
            stringBuilder.Append(current.Value.ToString());
            current = current.Head;
            if (current != null)
            {
                stringBuilder.Append(", ");
            }
        }

        stringBuilder.Append(']');

        return stringBuilder.ToString();
    }
}

public class DoubleLinkedListNode<T> where T : class
{
    [System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
    internal DoubleLinkedListNode(T value)
    {
        Value = value;
    }
    public required T Value { get; set; }
    public DoubleLinkedListNode<T>? Head { get; internal set; } = null;
    public DoubleLinkedListNode<T>? Tail { get; internal set; } = null;
}