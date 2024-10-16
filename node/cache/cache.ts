type LinkedListCacheEntry<T> = {
    value: T
    key: string
    head: LinkedListCacheEntry<T> | null
    tail: LinkedListCacheEntry<T> | null
}

export function createCache<T>(itemLimit: number = 10) {
    const _itemLimit = itemLimit
    const _store = new Map<string, LinkedListCacheEntry<T>>()
    let _head: (LinkedListCacheEntry<T> | null) = null
    let _tail: (LinkedListCacheEntry<T> | null) = null

    const evictIfNeeded = () => {
        while (_tail !== null && _store.size >= _itemLimit) {
            _store.delete(_tail.key)
            _tail = _tail.head
            if (_store.size === 0) {
                _head = null
            }
        }
    }

    const moveToHead = (entry: LinkedListCacheEntry<T>) => {
        if (entry === _head) {
            return
        } else if (entry === _tail) {
            _tail = _tail.head
        } else {
            if (entry.head !== null) {
                entry.head.tail = entry.tail
            }
            if (entry.tail !== null) {
                entry.tail.head = entry.head
            }
        }
        entry.head = null
        entry.tail = _head
        if (_head !== null) {
            _head.head = entry
        }
        _head = entry
    }

    return {
        get: (key: string): (T | null) => {
            const entry = _store.get(key)
            if (entry === undefined) {
                return null
            }
            return entry.value
        },
        has: (key: string) => {
            const entry = _store.get(key)
            if (entry === undefined) {
                return false
            }
            moveToHead(entry)
            return true
        },
        set: (key: string, value: T) => {
            evictIfNeeded();
            const entry: LinkedListCacheEntry<T> = { value: value, key: key, head: null, tail: _head }
            _store.set(key, entry)
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