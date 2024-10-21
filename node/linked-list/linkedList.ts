export type ListNode<T> = {
    value: T
    tail: ListNode<T> | null
}

export type LinkedList<T> = {
    insert: (value: T | T[]) => void
    append: (value: T | T[]) => void
    getHeadValue: () => T | null
    getTailValue: () => T | null
    print: () => string
    getCount: () => number
    find: (value: T) => ListNode<T> | null
    delete: (value: T) => void
}


export const createLinkedList = <T>(): LinkedList<T> => {
    let head: ListNode<T> | null = null

    const setAsHead = (value: T) => {
        if (value === null || value === undefined) {
            throw new Error('value cannot be `null` or `undefined`')
        }
        if (head === null) {
            head = { tail: null, value }
        } else {
            head = { tail: head, value }
        }
    }

    const getTailNode = () => {
        if (head === null) {
            return null
        }

        let currentTail = head

        while (currentTail.tail !== null) {
            currentTail = currentTail.tail
        }

        return currentTail
    }

    return {
        insert: (value: T | T[]) => {
            if (value === null || value === undefined) {
                throw new Error('value cannot be `null` or `undefined`')
            }
            const collection = Array.isArray(value) ? value : [value]
            collection.map(setAsHead)
        },
        getHeadValue: () => {
            return head === null ? null : head.value
        },
        append: (value: T | T[]) => {
            if (value === null || value === undefined) {
                throw new Error('value cannot be `null` or `undefined`')
            }

            const collection = Array.isArray(value) ? value : [value]

            if (collection.length === 0) {
                return
            }
            let currentNode: ListNode<T> | null = null
            let headOfNewTail: ListNode<T> | null = null

            for (let i = 0; i < collection.length; i++) {
                if (collection[i] === null || collection[i] === undefined) {
                    throw new Error('value cannot be `null` or `undefined`')
                }

                const node = { value: collection[i], tail: null }

                if (headOfNewTail === null) {
                    headOfNewTail = node
                }

                if (currentNode === null) {
                    currentNode = node
                } else {
                    currentNode.tail = node
                    currentNode = node
                }
            }

            const tail = getTailNode()

            if (tail === null) {
                head = headOfNewTail
            } else {
                tail.tail = headOfNewTail
            }
        },
        getTailValue: () => {
            if (head === null) {
                return null
            }

            let current = head

            while (current.tail !== null) {
                current = current.tail
            }

            return current.value
        },
        print: () => {
            if (head === null) {
                return ""
            }

            let current: ListNode<T> | null = head
            let result = ""

            while (current !== null) {
                result += `${current.value}${current.tail !== null ? ' ' : ''}`
                current = current.tail
            }

            return result
        },
        getCount: () => {
            let count = 0;
            let current = head;

            while (current !== null) {
                count++
                current = current.tail
            }

            return count
        },
        find: (value: T) => {
            if (value === null || value === undefined) {
                return null
            }
            let result: ListNode<T> | null = null

            let currentNode = head

            while (currentNode !== null) {
                if (currentNode.value === value) {
                    result = currentNode
                    break
                }
                currentNode = currentNode.tail
            }

            return result
        },
        delete: (value: T) => {
            if (value === null || value === undefined) {
                return
            }

            while (head !== null && head.value === value) {
                head = head.tail
            }

            if (head === null) {
                return
            }

            let previous = head
            let current = head.tail

            while (current !== null) {
                if (current.value === value) {
                    previous.tail = current.tail
                }
                previous = current
                current = current.tail
            }
        }
    }
}