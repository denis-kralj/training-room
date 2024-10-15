namespace cache;

public class Cache<T> : ICache<T> where T : class
{
    private readonly Dictionary<string, T> _cache = [];
    public T? Get(string key)
    {
        if(_cache.TryGetValue(key, out var value)) {
            return value;
        }

        return null;
    }

    public bool Has(string key)
    {
        return _cache.ContainsKey(key);
    }

    public void Set(string key, T value)
    {
        RemoveIfExists(key);
        _cache.Add(key, value);
    }

    private void RemoveIfExists(string key)
    {
        if(_cache.ContainsKey(key)) {
            _cache.Remove(key);
        }
    }
}
