import { it, expect } from 'vitest'
import { selectionSort } from './selection-sort'

it('sorts', () => {
    const input = [1,6,3,5,4,2]
    const expectedOutput = [1,2,3,4,5,6]
    expect(selectionSort(input)).toStrictEqual(expectedOutput)
})

it('sorts with duplicates', () => {
    const input = [1,6,1,5,4,2]
    const expectedOutput = [1,1,2,4,5,6]
    expect(selectionSort(input)).toStrictEqual(expectedOutput)
})

it('sorts with 1 element', () => {
    const input = [42]
    const expectedOutput = [42]
    expect(selectionSort(input)).toStrictEqual(expectedOutput)
})

it('sorts with multiple duplicates', () => {
    const input = [42, 24, 42, 24, 24]
    const expectedOutput = [24, 24, 24, 42, 42]
    expect(selectionSort(input)).toStrictEqual(expectedOutput)
})


it('sorts with no elements', () => {
    const input = []
    const expectedOutput = []
    expect(selectionSort(input)).toStrictEqual(expectedOutput)
})