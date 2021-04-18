using System;
using System.Text;
using System.Collections.Generic;

public class Cache<Key, Value> {
    private int numberOfFrames;
    private Dictionary<Key, CacheElement<Key, Value>> cache;
    private CacheStrategy<Key> strategy;
    public Cache(int numberOfFrames, CacheStrategy<Key> cacheStrategy) {
        this.numberOfFrames = numberOfFrames;
        this.cache = new Dictionary<Key, CacheElement<Key, Value>>();
        this.strategy = cacheStrategy;
    }

    // Request an element by key from the cache
    // Returns the element if it is already stored in the cache
    // Returns null if element was not stored in the cache
    public CacheElement<Key, Value> getCacheElement(Key cacheElementKey) {
        this.strategy.keyWasAccessed(cacheElementKey);
        if (this.cacheContainsKey(cacheElementKey)) {
            CacheElement<Key, Value> element;
            this.cache.TryGetValue(cacheElementKey, out element);
            return element;
        } else {
            if (this.cacheIsFull()) {
                this.cache.Remove(this.strategy.getKeyToReplace());
            }
            this.cache.Add(cacheElementKey, new CacheElement<Key, Value>(cacheElementKey, default(Value)));
            this.strategy.addKey(cacheElementKey);
            return null;
        }
    }

    // Output current content of the cache
    public override string ToString() {
        StringBuilder stringBuilder = new StringBuilder();
        foreach (Key key in this.cache.Keys) {
            stringBuilder.Append(key);
            stringBuilder.Append(" ");
        }
        return stringBuilder.ToString();
    }

    public CacheStrategy<Key> getStrategy() {
        return this.strategy;
    }

    private bool cacheIsFull() {
        return this.cache.Count >= this.numberOfFrames;
    }

    private bool cacheContainsKey(Key cacheElement) {
        return this.cache.ContainsKey(cacheElement);
    }
}
