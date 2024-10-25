using DoubleLinkedList.Core;

namespace DoubleLinkedList.Tests;

public class DoubleLinkedListTests
{
    [Test]
    public void InitializesList()
    {
        var list = new DoubleLinkedList<string>();
        Assert.That(list, Is.Not.Null);
    }

    [Test]
    public void InitializesNode()
    {
        var node = new DoubleLinkedListNode<string>("value");
        Assert.Multiple(() =>
        {
            Assert.That(node.Value, Is.EqualTo("value"));
            Assert.That(node.Head, Is.Null);
            Assert.That(node.Tail, Is.Null);
        });
    }

    [Test]
    public void InsertsNodeAsNewHead()
    {
        var list = new DoubleLinkedList<string>();
        list.Insert("value");
        Assert.That(list.Head.Value, Is.EqualTo("value"));
    }

    [Test]
    public void InsertingMultipleNodesReturnsLatestAsHead()
    {
        var list = new DoubleLinkedList<string>();
        list.Insert("value1");
        list.Insert("value2");
        list.Insert("value3");
        Assert.That(list.Head.Value, Is.EqualTo("value3"));
    }

    [Test]
    public void AppendsNodeAsNewTail()
    {
        var list = new DoubleLinkedList<string>();
        list.Append("value");
        Assert.That(list.Tail.Value, Is.EqualTo("value"));
    }

    [Test]
    public void AppendsMultipleNodesReturnsLatestAsTail()
    {
        var list = new DoubleLinkedList<string>();
        list.Append("value1");
        list.Append("value2");
        list.Append("value3");
        Assert.That(list.Tail.Value, Is.EqualTo("value3"));
    }

    [Test]
    public void UsingAppendAndInsertSequentiallyReturnsExpectedHeadAndTail()
    {
        var list = new DoubleLinkedList<string>();
        list.Append("value1");
        Assert.That(list.Head.Value, Is.EqualTo("value1"));
        Assert.That(list.Tail.Value, Is.EqualTo("value1"));
        list.Insert("value2");
        Assert.That(list.Head.Value, Is.EqualTo("value2"));
        Assert.That(list.Tail.Value, Is.EqualTo("value1"));
        list.Insert("value3");
        Assert.That(list.Head.Value, Is.EqualTo("value3"));
        Assert.That(list.Tail.Value, Is.EqualTo("value1"));
        list.Append("value4");
        Assert.That(list.Head.Value, Is.EqualTo("value3"));
        Assert.That(list.Tail.Value, Is.EqualTo("value4"));
    }
}