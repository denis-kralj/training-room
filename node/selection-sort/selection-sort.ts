export const selectionSort = (list: number[]): number[] => {
    const clone = [...list]
    for(let i = 0;i < clone.length; i++) {
        let smallestIndex = -1
        for(let j = i+1; j < clone.length; j++) {
            if (smallestIndex === -1)
            {
                smallestIndex = j
                continue
            }

            if (clone[smallestIndex] > clone[j]) {
                smallestIndex = j
            }
        }
        if(clone[i] > clone[smallestIndex]) {
            const smaller = clone[smallestIndex]
            const bigger = clone[i]
            clone[i] = smaller
            clone[smallestIndex] = bigger
        }
    }

    return clone
}