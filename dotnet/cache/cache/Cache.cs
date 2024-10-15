namespace cache;

public class Cache<T> : ICache<T>
{
    public T? Get(string key)
    {
        throw new NotImplementedException();
    }

    public bool Has(string key)
    {
        throw new NotImplementedException();
    }

    public void Set(string key, T value)
    {
        throw new NotImplementedException();
    }
}
