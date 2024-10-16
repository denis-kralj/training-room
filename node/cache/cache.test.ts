import { it, expect } from 'vitest';
import { createCache } from './cache';

it('dummy test', () => {
    const cache = createCache();
    expect(cache).toBeDefined();
})