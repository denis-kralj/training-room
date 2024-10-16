type LinkedListCacheEntry<T> = {
    value: T
    key: string
    head: LinkedListCacheEntry<T> | null
    tail: LinkedListCacheEntry<T> | null
}

export function createCache<T>(itemLimit: number = 10) {
    const _itemLimit = itemLimit
    const _store = new Map<string, T>()
    let _head: (LinkedListCacheEntry<T> | null) = null
    let _tail: (LinkedListCacheEntry<T> | null) = null

    const evictIfNeeded = () => {
        while (_tail !== null && _store.size >= _itemLimit) {
            _store.delete(_tail.key)
            _tail = _tail.head
            if(_store.size === 0) {
                _head = null
            }
        }
    }

    return {
        get: (key: string): (T | null) => { return _store.get(key) ?? null },
        has: (key: string) => { return _store.has(key) },
        set: (key: string, value: T) => {
            evictIfNeeded();
            _store.set(key, value)
            const entry: LinkedListCacheEntry<T> = { value: value, key: key, head: null, tail: _head }
            if (_head !== null) {
                _head.head = entry
            }
            if (_tail === null) {
                _tail = entry
            }
            _head = entry
        },
    }
}