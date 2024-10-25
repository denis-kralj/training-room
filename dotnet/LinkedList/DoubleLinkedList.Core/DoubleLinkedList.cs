namespace DoubleLinkedList.Core;

public class DoubleLinkedList<T> where T : class
{
    public DoubleLinkedListNode<T>? Head { get; set; }
    public void Insert(T value)
    {
        var newNode = new DoubleLinkedListNode<T>(value);
        if(Head != null)
        {
            Head.Head = newNode;
        }
        newNode.Tail = Head;
        Head = newNode;
    }
}

[method: System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
public class DoubleLinkedListNode<T>(T value) where T : class
{
    public required T Value { get; set; } = value;
    public DoubleLinkedListNode<T>? Head { get; set; } = null;
    public DoubleLinkedListNode<T>? Tail { get; set; } = null;
}