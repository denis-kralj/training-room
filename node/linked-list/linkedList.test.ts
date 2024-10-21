import { expect, it } from 'vitest'
import { createLinkedList } from './linkedList'

it('initializes', () => {
    const linkedList = createLinkedList()
    expect(linkedList).toBeDefined()
})

it('does not allow inserting a null value', () => {
    const linkedList = createLinkedList<null>()
    expect(() => linkedList.insert(null)).toThrow()
})

it('does not allow inserting an undefined value', () => {
    const linkedList = createLinkedList<undefined>()
    expect(() => linkedList.insert(undefined)).toThrow()
})

it('does not allow inserting an undefined value in an array', () => {
    const linkedList = createLinkedList<undefined>()
    expect(() => linkedList.insert([undefined])).toThrow()
})

it('allows inserting of a single value', () => {
    const linkedList = createLinkedList<string>()
    linkedList.insert("value1")
    expect(linkedList.getHeadValue()).toBe("value1")
})

it('allows inserting of an empty list', () => {
    const linkedList = createLinkedList<string>()
    linkedList.insert([])
    expect(linkedList.getHeadValue()).toBe(null)
})

it('allows inserting of a collection of elements', () => {
    const linkedList = createLinkedList<string>()
    linkedList.insert(["a", "b", "c"])
    expect(linkedList.getHeadValue()).toBe("c")
})

it('does not allow appending a null value', () => {
    const linkedList = createLinkedList<null>()
    expect(() => linkedList.append(null)).toThrow()
})

it('does not allow appending an undefined value', () => {
    const linkedList = createLinkedList<undefined>()
    expect(() => linkedList.append(undefined)).toThrow()
})

it('does not allow appending an undefined value in an array', () => {
    const linkedList = createLinkedList<undefined>()
    expect(() => linkedList.append([undefined])).toThrow()
})

it('allows appending of a single value', () => {
    const linkedList = createLinkedList<string>()
    linkedList.append("value1")
    expect(linkedList.getTailValue()).toBe("value1")
})

it('allows appending of a list of values', () => {
    const linkedList = createLinkedList<string>()
    linkedList.append(["value1", "value2"])
    expect(linkedList.getTailValue()).toBe("value2")
})

it('allows appending of an empty list of values', () => {
    const linkedList = createLinkedList<string>()
    linkedList.append([])
    expect(linkedList.getTailValue()).toBe(null)
})

it('appending to an empty list sets head and tail correctly', () => {
    const linkedList = createLinkedList<string>()
    linkedList.append(["value1", "value2"])
    expect(linkedList.getHeadValue()).toBe("value1")
    expect(linkedList.getTailValue()).toBe("value2")
})

it('appending and inserting sets head and tail correctly', () => {
    const linkedList = createLinkedList<string>()
    linkedList.insert("value1")
    linkedList.insert("value2")
    linkedList.append("value3")
    linkedList.append("value4")
    linkedList.insert("value5")
    linkedList.append("value6")
    expect(linkedList.getHeadValue()).toBe("value5")
    expect(linkedList.getTailValue()).toBe("value6")
})

it('appending and inserting collections sets head and tail correctly', () => {
    const linkedList = createLinkedList<string>()
    linkedList.insert(["value1","value11"])
    linkedList.insert(["value2","value22"])
    linkedList.append(["value3","value33"])
    linkedList.append(["value4","value44"])
    linkedList.insert(["value5","value55"])
    linkedList.append(["value6","value66"])
    expect(linkedList.getHeadValue()).toBe("value55")
    expect(linkedList.getTailValue()).toBe("value66")
})

it('prints out stored values', () => {
    const linkedList = createLinkedList<string>()
    linkedList.insert("value1")
    linkedList.insert("value2")
    linkedList.append("value3")
    linkedList.append("value4")
    linkedList.insert(["value5","value55"])
    linkedList.append("value6")

    expect(linkedList.print()).toBe("value55 value5 value2 value1 value3 value4 value6")
})

it('prints out empty list correctly', () => {
    const linkedList = createLinkedList<string>()
    expect(linkedList.print()).toBe("")
})

it('counts elements in list correctly', () => {
    const linkedList = createLinkedList<string>()
    linkedList.insert("value1")
    linkedList.insert("value2")
    linkedList.append("value3")
    linkedList.append("value4")
    linkedList.insert(["value5","value55"])
    linkedList.append("value6")

    expect(linkedList.getCount()).toBe(7)
})

it('finds the node with the search value', () => {
    const linkedList = createLinkedList<string>()
    linkedList.insert("value1")
    linkedList.insert("value2")
    linkedList.append("value3")
    linkedList.append("value4")
    linkedList.insert(["value5","value55"])
    linkedList.append("value6")

    expect(linkedList.find("value3")).toHaveProperty('value', "value3")
})

it('returns null if search term is not found', () => {
    const linkedList = createLinkedList<string>()
    linkedList.insert("value1")

    expect(linkedList.find("value3")).toBeNull()
})

it('returns null if searching an empty list', () => {
    const linkedList = createLinkedList<string>()
    expect(linkedList.find("value3")).toBeNull()
})

it('deletes the element that matches', () => {
    const linkedList = createLinkedList<string>()
    linkedList.insert("value1")
    linkedList.delete("value1")

    expect(linkedList.getCount()).toBe(0)
})

it('deletes all the elements that match', () => {
    const linkedList = createLinkedList<string>()
    linkedList.insert("value1")
    linkedList.insert("value2")
    linkedList.insert("value1")
    linkedList.delete("value1")

    expect(linkedList.getCount()).toBe(1)
})

it('delete adjust head and tail as needed', () => {
    const linkedList = createLinkedList<string>()
    linkedList.insert("value1")
    linkedList.append("value2")
    linkedList.insert("value3")
    linkedList.append("value4")
    linkedList.insert("value5")
    linkedList.delete("value1")
    linkedList.delete("value3")
    linkedList.delete("value5")

    expect(linkedList.getHeadValue()).toBe("value2")
    expect(linkedList.getTailValue()).toBe("value4")
})