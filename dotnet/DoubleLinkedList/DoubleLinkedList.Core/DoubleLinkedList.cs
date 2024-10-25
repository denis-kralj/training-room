namespace DoubleLinkedList.Core;

public class DoubleLinkedList<T> where T : class
{
    public DoubleLinkedListNode<T>? Head { get; private set; }
    public DoubleLinkedListNode<T>? Tail { get; private set; }
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
        if (Head == null)
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
}

[method: System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
public class DoubleLinkedListNode<T>(T value) where T : class
{
    public required T Value { get; set; } = value;
    public DoubleLinkedListNode<T>? Head { get; set; } = null;
    public DoubleLinkedListNode<T>? Tail { get; set; } = null;
}