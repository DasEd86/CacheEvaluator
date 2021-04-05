using System;
using System.Text;
using System.Collections.Generic;

class Cache {
    private int frames;
    private Dictionary<string, CacheElement<string, int>> cache;
    private CacheStrategy<string> strategy;
    public Cache(int numberOfFrames, CacheStrategy<string> cacheStrategy) {
        this.frames = numberOfFrames;
        this.cache = new Dictionary<string, CacheElement<string, int>>();
        this.strategy = cacheStrategy;
    }

    // Returns element if already stored in cache
    // Returns null if element is not stored in cache
    public CacheElement<string, int> getCacheElement(string cacheElementKey) {
        this.strategy.keyWasAccessed(cacheElementKey);
        if (this.cacheContainsKey(cacheElementKey)) {
            CacheElement<string, int> element;
            this.cache.TryGetValue(cacheElementKey, out element);
            return element;
        } else {
            if (this.cacheIsFull()) {
                this.cache.Remove(this.strategy.getKeyToReplace());
            }
            this.cache.Add(cacheElementKey, new CacheElement<string, int>(cacheElementKey, new Random().Next()));
            this.strategy.addKey(cacheElementKey);
            return null;
        }
    }

    // Output current content of the cache
    public override string ToString() {
        StringBuilder stringBuilder = new StringBuilder();
        foreach (string key in this.cache.Keys) {
            stringBuilder.Append(key);
            stringBuilder.Append(" ");
        }
        return stringBuilder.ToString();
    }

    public CacheStrategy<string> getStrategy() {
        return this.strategy;
    }

    private bool cacheIsFull() {
        return this.cache.Count >= this.frames;
    }

    private bool cacheContainsKey(string cacheElement) {
        return this.cache.ContainsKey(cacheElement);
    }
}
