namespace cache.tests;

public class CacheTests
{
    [Test]
    public void HasReturnsFalseForNonExistingKey()
    {
        var cache = new Cache<string>();
        Assert.That(cache.Has("nonExistingKey"), Is.False);
    }

    [Test]
    public void HasReturnsTrueForExistingKey()
    {
        var cache = new Cache<string>();
        cache.Set("key1", "value1");
        Assert.That(cache.Has("key1"), Is.True);
    }

    [Test]
    public void SetStoresProperValueInCache()
    {
        var cache = new Cache<string>();
        cache.Set("key1", "value1");
        Assert.That(cache.Get("key1"), Is.EqualTo("value1"));
    }

    [Test]
    public void GetReturnsNullForNonExistingKey()
    {
        var cache = new Cache<string>();
        Assert.That(cache.Get("nonExistingKey"), Is.Null);
    }
}