namespace DoubleLinkedList.Core;

public class DoubleLinkedList<T> where T : class
{
    public DoubleLinkedListNode<T>? Head { get; private set; }
    public DoubleLinkedListNode<T>? Tail { get; private set; }
    public void Insert(T value)
    {
        var newNode = new DoubleLinkedListNode<T>(value);
        if(Head == null)
        {
            Head = newNode;
            Tail = newNode;
            return;
        }

        Head.Head = newNode;
        newNode.Tail = Head;
        Head = newNode;
    }
    public void Append(T value)
    {
        var newNode = new DoubleLinkedListNode<T>(value);
        if(Head == null)
        {
            Head = newNode;
            Tail = newNode;
            return;
        }

        Tail.Tail = newNode;
        newNode.Head = Tail;
        Tail = newNode;
    }
}

[method: System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
public class DoubleLinkedListNode<T>(T value) where T : class
{
    public required T Value { get; set; } = value;
    public DoubleLinkedListNode<T>? Head { get; set; } = null;
    public DoubleLinkedListNode<T>? Tail { get; set; } = null;
}