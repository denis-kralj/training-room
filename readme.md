# Training room repository

## Intro
Repository dedicated to training essential coding muscles. Invest time solving the problems suggested below. Find habits worth having as a software engineer and practice them consistently.

For me personally, this is an avenue to keep my dotnet/C# and node/TypeScript skills sharp and to not let good habits go to waste.

## How to use this repository
When doing an exercise, create a new branch from `main` and keep all the work in that new branch. Do not merge it back into the `main` branch. `main` is meant to contain the readme. Main should only change when there are updates to this readme file (e.g. adding a new problem suggestion).

## Habits worth having

- create atomic commits
- document just the right amount
- refactor regularly
- write tests when it makes sense

## Problem suggestions

### LRU (least recently used) cache

#### Requirements

- cache has set capacity
- the least recently used entry gets evicted when capacity is exceeded
- the cache supports the get, set and has operations
- an entry is considered used when any of the operations target it

#### Bonus requirements

- add support for TTL (time-to-live)
- an entry that wasn't used for a period greater than the TTL supplied gets evicted as well

### Implement a linked list

#### Requirements

- allows insert (add to top)
- allows append (add to bottom)
- allows find
- allows delete
- allows length
- allows print

#### Bonus requirements

- allows removal of duplicates
