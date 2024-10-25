namespace DoubleLinkedList.Core;

public class DoubleLinkedList<T> where T : class
{

}

[method: System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
public class DoubleLinkedListNode<T>(T value) where T : class
{
    public required T Value { get; set; } = value;
    public DoubleLinkedListNode<T>? Head { get; set; }
    public DoubleLinkedListNode<T>? Tail { get; set; }
}