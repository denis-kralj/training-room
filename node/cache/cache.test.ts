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
})

describe('`get()` method', () => {
    it('retrieves correct value from cache', () => {
        const cache = createCache()
        cache.set('key1', 'value1')
        expect(cache.get('key1')).toBe('value1')
    })
})