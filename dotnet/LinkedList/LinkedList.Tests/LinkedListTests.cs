namespace LinkedList.Tests;

public class LinkedListTests
{
    [Test]
    public void Dummy()
    {
        var list = new LinkedList.Core.LinkedList();
        Assert.That(list, Is.Not.Null);
    }
}