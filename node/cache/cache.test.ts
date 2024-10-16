import { it, expect, describe } from 'vitest'
import { createCache } from './cache'

describe('`has()` method', () => {
    it('returns `false` for non existing key', () => {
        const cache = createCache()
        expect(cache.has('nonExistingKey')).toBe(false)
    })
})

describe('`set()` method', () => {
    it('saves key to cache', () => {
        const cache = createCache()
        cache.set('key1', 'value1')
        expect(cache.has('key1')).toBe(true)
    })
    it('evicts entries when capacity is reached', () => {
        const cache = createCache(1)
        cache.set('key1', 'value1')
        cache.set('key2', 'value2')
        expect(cache.has('key1')).toBe(false)
        expect(cache.has('key2')).toBe(true)
    })
    it('overwrites value for existing key in cache', () => {
        const cache = createCache()
        cache.set('key1', 'value1')
        cache.set('key1', 'value11')
        expect(cache.get('key1')).toBe('value11')
    })
    it('overwrites value for existing key in cache considering eviction', () => {
        const cache = createCache(1)
        cache.set('key1', 'value1')
        cache.set('key1', 'value11')
        expect(cache.get('key1')).toBe('value11')
    })
})

describe('`get()` method', () => {
    it('retrieves correct value from cache', () => {
        const cache = createCache()
        cache.set('key1', 'value1')
        expect(cache.get('key1')).toBe('value1')
    })
})