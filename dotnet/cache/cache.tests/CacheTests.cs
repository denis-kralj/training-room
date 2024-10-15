namespace cache.tests;

public class CacheTests
{
    [Test]
    public void FirstTest()
    {
        Assert.That(new Cache(), Is.Not.Null);
    }
}