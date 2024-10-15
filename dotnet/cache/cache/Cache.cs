namespace cache;

public class Cache<T>(int itemCapacity = 3) : ICache<T> where T : class
{
    private readonly Dictionary<string, T> _cache = new(itemCapacity);
    private LinkedList<string> _entryKeyList { get; set; } = new();
    private readonly int _itemCapacity = itemCapacity;

    public T? Get(string key)
    {
        if(_cache.TryGetValue(key, out var value)) {
            MoveToHead(key);
            return value;
        }

        return null;
    }

    public bool Has(string key)
    {
        var has = _cache.ContainsKey(key);
        if(has)
        {
            MoveToHead(key);
        }
        return has;
    }

    private void MoveToHead(string key)
    {
        if (key == _entryKeyList.First?.Value)
        {
            return;
        }

        _entryKeyList.Remove(key);
        _entryKeyList.AddFirst(key);
    }

    public void Set(string key, T value)
    {
        RemoveIfExists(key);
        EvictIfNeeded();
        _cache.Add(key, value);
        _entryKeyList.AddFirst(key);
    }

    private void EvictIfNeeded()
    {
        while (_itemCapacity <= _entryKeyList.Count && _entryKeyList.Last != null) {
            _cache.Remove(_entryKeyList.Last.Value);
            _entryKeyList.RemoveLast();
        }
    }

    private void RemoveIfExists(string key)
    {
        if(_cache.ContainsKey(key)) {
            _cache.Remove(key);
        }
    }
}
