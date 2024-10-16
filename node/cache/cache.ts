export function createCache<T>() {
    const _store = new Map<string, T>()
    return {
        get: (key: string): (T | null) => { return _store.get(key) ?? null },
        set: (key: string, value: T) => { _store.set(key, value) },
        has: (key: string) => { return _store.has(key) },
    }
}