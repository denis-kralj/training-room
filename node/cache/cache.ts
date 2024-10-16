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

    const removeIfExists = (key: string) => {
        const entry = _store.get(key)

        if(entry === undefined) {
            return
        }
        if (entry === _head) {
            _head = _head.tail
            if (_head !== null) {
                _head.head = null
            }
        } else if (entry === _tail) {
            _tail = _tail.head
            if (_tail !== null) {
                _tail.tail = null
            }
        } else {
            if (entry.head !== null) {
                entry.head.tail = entry.tail
            }
            if (entry.tail !== null) {
                entry.tail.head = entry.head
            }
        }

        _store.delete(key);
    }

    return {
        get: (key: string): (T | null) => {
            const entry = _store.get(key)
            if (entry === undefined) {
                return null
            }
            moveToHead(entry)
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
            removeIfExists(key);
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