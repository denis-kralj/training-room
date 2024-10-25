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
    public void InsertsNodeAsNewHead()
    {
        var list = new DoubleLinkedList<string>();
        list.Insert("value");
        Assert.That(list.Head?.Value, Is.EqualTo("value"));
    }

    [Test]
    public void InsertingMultipleNodesReturnsLatestAsHead()
    {
        var list = new DoubleLinkedList<string>();
        list.Insert("value1");
        list.Insert("value2");
        list.Insert("value3");
        Assert.That(list.Head?.Value, Is.EqualTo("value3"));
    }

    [Test]
    public void AppendsNodeAsNewTail()
    {
        var list = new DoubleLinkedList<string>();
        list.Append("value");
        Assert.That(list.Tail?.Value, Is.EqualTo("value"));
    }

    [Test]
    public void AppendsMultipleNodesReturnsLatestAsTail()
    {
        var list = new DoubleLinkedList<string>();
        list.Append("value1");
        list.Append("value2");
        list.Append("value3");
        Assert.That(list.Tail?.Value, Is.EqualTo("value3"));
    }

    [Test]
    public void UsingAppendAndInsertSequentiallyReturnsExpectedHeadAndTail()
    {
        var list = new DoubleLinkedList<string>();
        list.Append("value1");
        Assert.That(list.Head?.Value, Is.EqualTo("value1"));
        Assert.That(list.Tail?.Value, Is.EqualTo("value1"));
        list.Insert("value2");
        Assert.That(list.Head?.Value, Is.EqualTo("value2"));
        Assert.That(list.Tail?.Value, Is.EqualTo("value1"));
        list.Insert("value3");
        Assert.That(list.Head?.Value, Is.EqualTo("value3"));
        Assert.That(list.Tail?.Value, Is.EqualTo("value1"));
        list.Append("value4");
        Assert.That(list.Head?.Value, Is.EqualTo("value3"));
        Assert.That(list.Tail?.Value, Is.EqualTo("value4"));
    }

    [Test]
    public void ReturnsNewNodeWhenInserting()
    {
        var list = new DoubleLinkedList<string>();
        var node = list.Insert("value1");
        Assert.That(node, Is.Not.Null);
        Assert.That(node.Value, Is.EqualTo("value1"));
    }

    [Test]
    public void ReturnsNewNodeWhenAppending()
    {
        var list = new DoubleLinkedList<string>();
        var node = list.Append("value1");
        Assert.That(node, Is.Not.Null);
        Assert.That(node.Value, Is.EqualTo("value1"));
    }

    [Test]
    public void ReturnsCorrectNodeWhenFinding()
    {
        var list = new DoubleLinkedList<string>();
        list.Append("value1");
        var nodeSearchedFor = list.Append("value2");
        list.Append("value3");
        var found = list.Find("value2");
        Assert.That(found, Is.EqualTo(nodeSearchedFor));
    }

    [Test]
    public void ReturnsNullWhenSearchingForNonExistingValue()
    {
        var list = new DoubleLinkedList<string>();
        list.Append("value1");
        list.Append("value2");
        list.Append("value3");
        var found = list.Find("nonExistingValue");
        Assert.That(found, Is.Null);
    }

    [Test]
    public void ReturnsFirstCorrectNodeWhenFinding()
    {
        var list = new DoubleLinkedList<string>();
        var nodeSearchedFor = list.Append("value1");
        var secondNodeThatCouldBeFound = list.Append("value1");
        var found = list.Find("value1");
        Assert.That(found, Is.EqualTo(nodeSearchedFor));
        Assert.That(found, Is.Not.EqualTo(secondNodeThatCouldBeFound));
    }

    [Test]
    public void DeletesRequestedNode()
    {
        var list = new DoubleLinkedList<string>();
        list.Append("value1");
        var toDelete = list.Append("value2");
        list.Append("value3");

        list.Delete(toDelete);

        var found = list.Find("value2");

        Assert.That(found, Is.Null);
    }

    [Test]
    public void SetsHeadProperlyAfterDelete()
    {
        var list = new DoubleLinkedList<string>();
        var head = list.Append("value1");
        var tail = list.Append("value2");

        list.Delete(head);

        Assert.That(list.Head, Is.EqualTo(tail));
    }


    [Test]
    public void SetsTailProperlyAfterDelete()
    {
        var list = new DoubleLinkedList<string>();
        var head = list.Append("value1");
        var tail = list.Append("value2");

        list.Delete(tail);

        Assert.That(list.Tail, Is.EqualTo(head));
    }
}