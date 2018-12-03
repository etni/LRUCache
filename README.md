LRU Cache Sample Project
=================

This is a simple implementation of a LRU cache. It supports the following operations: `get` and `set`. 


`get(key)` - Get the value. If not exists will return `null`.

`put(key, value)` - Sets or inserts the value if the key is not already in the cache. When the cache reaches its capacity, it will `evict` or invalidate the least recently used item before inserting a new item.

## Sample use: 

```csharp
var cache = new LRUCache( 3 /* capacity */);

cache.put("a", "a");
cache.put("b", "b");
cache.get("a");   // returns "a"
cache.put("c", "c");
cache.put("d","d"); // evicts key "b"


```

