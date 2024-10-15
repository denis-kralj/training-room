namespace cache;

public class Cache<T>(int itemCapacity = 3, int timeToLiveMilliseconds = 5000, Func<DateTime>? nowProvider = null) : ICache<T> where T : class
{
    private static Func<DateTime> _defaultNowProvider = () => DateTime.UtcNow;
    private readonly Dictionary<string, T> _cache = new(itemCapacity);
    private readonly LinkedList<NodeValue> _entryKeyList = new();
    private readonly int _itemCapacity = itemCapacity;
    private readonly int _timeToLiveMilliseconds = timeToLiveMilliseconds;
    private readonly Func<DateTime> _nowProvider = nowProvider ?? _defaultNowProvider;


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
        ExpireIfNeeded();
        var has = _cache.ContainsKey(key);
        if(has)
        {
            MoveToHead(key);
        }
        return has;
    }

    private void ExpireIfNeeded()
    {
        while (_entryKeyList.Last != null && IsExpired(_entryKeyList.Last.Value.LastAccessed)) {
            _cache.Remove(_entryKeyList.Last.Value.Key);
            _entryKeyList.RemoveLast();
        }
    }

    private bool IsExpired(DateTime lastAccessed)
    {
        return (_nowProvider() - lastAccessed).TotalMilliseconds > _timeToLiveMilliseconds;
    }

    private void MoveToHead(string key)
    {
        if (key == _entryKeyList.First?.Value.Key)
        {
            return;
        }
        var entry =_entryKeyList.First(e => e.Key == key);
        _entryKeyList.Remove(entry);
        entry.LastAccessed = _nowProvider();
        _entryKeyList.AddFirst(entry);
    }

    public void Set(string key, T value)
    {
        RemoveIfExists(key);
        EvictIfNeeded();
        _cache.Add(key, value);
        _entryKeyList.AddFirst(new NodeValue { Key = key, LastAccessed = _nowProvider() });
    }

    private void EvictIfNeeded()
    {
        while (_itemCapacity <= _entryKeyList.Count && _entryKeyList.Last != null) {
            _cache.Remove(_entryKeyList.Last.Value.Key);
            _entryKeyList.RemoveLast();
        }
    }

    private void RemoveIfExists(string key)
    {
        if(_cache.ContainsKey(key)) {
            _cache.Remove(key);
            var entry = _entryKeyList.First(e => e.Key == key);
            _entryKeyList.Remove(entry);
        }
    }

    class NodeValue
    {
        public required string Key { get; set; }
        public DateTime LastAccessed { get; set; }
    }
}
