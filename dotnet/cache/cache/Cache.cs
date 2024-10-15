namespace cache;

public class Cache<T>(int itemCapacity = 3, int timeToLiveMilliseconds = 5000, Func<DateTime>? nowProvider = null) : ICache<T> where T : class
{
    private static Func<DateTime> _defaultNowProvider = () => DateTime.UtcNow;
    private readonly Dictionary<string, CacheEntry> _cache = new(itemCapacity);
    private readonly LinkedList<string> _entryKeyList = new();
    private readonly int _itemCapacity = itemCapacity;
    private readonly int _timeToLiveMilliseconds = timeToLiveMilliseconds;
    private readonly Func<DateTime> _nowProvider = nowProvider ?? _defaultNowProvider;


    public T? Get(string key)
    {
        if(_cache.TryGetValue(key, out var value)) {
            MoveToHead(key);
            value.LastAccessed = _nowProvider();
            return value.Entry;
        }

        return null;
    }

    public bool Has(string key)
    {
        ExpireIfNeeded();
        if(_cache.TryGetValue(key, out var value)) {
            MoveToHead(key);
            value.LastAccessed = _nowProvider();
            return true;
        }

        return false;
    }

    private void ExpireIfNeeded()
    {
        while (
            _entryKeyList.Last != null &&
            _cache.TryGetValue(_entryKeyList.Last.Value, out var entry) &&
            IsExpired(entry.LastAccessed))
        {
            _cache.Remove(_entryKeyList.Last.Value);
            _entryKeyList.RemoveLast();
        }
    }

    private bool IsExpired(DateTime lastAccessed)
    {
        return (_nowProvider() - lastAccessed).TotalMilliseconds > _timeToLiveMilliseconds;
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
        _cache.Add(key, new CacheEntry { Entry = value, LastAccessed = _nowProvider() });
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
            _entryKeyList.Remove(key);
        }
    }

    class CacheEntry
    {
        public required T Entry { get; set; }
        public DateTime LastAccessed { get; set; }
    }
}
