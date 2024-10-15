# work journal

- created a new branch `practice/dotnet/lru-cache/01
- created a new solution file `dotnet new sln` in the cache directory
- created a new project via the `dotnet new classlib -n cache` command
- created a new test project via the `dotnet new nunit -n cache.tests` command
- renamed default class in `cache` to `Cache.cs`
- renamed default test class in `cache.tests` to `CacheTests.cs`
- created first test
- included `cache` project in solution
- included `cache.test` project in solution
- created interface `ICache.cs` that conforms to limitations set out int the problem description
- `Cache` now implements `ICache` with the type generic
- implemented naive version of the cache
- limit cache to only work with reference types
- add key override when using same key
- add capacity awareness
- add linked list to monitor order of items for eviction needs
- add support for moving to top of list when has is called on entry, affecting eviction order
- move entry to head of linked list when Get is called
- introduced support for time-to-live
- change internal linked list to store last accessed information
- introduced now provider
- refactor code to work with new nodes in linked list


# decisions

- choose nunit over xunit because the documentation was easier to read and the assertion writing patterns were more semantic
- decided to limit T in the cache to classes, this means that structs aren't supported in the cache, this simplifies my get logic and removes chances to return default primitives for missing cache keys
- storing actual cached valus in dictionary (quick access) and using a linked list to determine eviction/expiration
- added support for supplying a now provider, this is used for testing so that we don't have to await time in the test, but rather fake the passage of time