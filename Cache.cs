using System.Collections.Generic;
using System.Text;

class Cache {
    private int frames;
    private Dictionary<string, CacheElement> cache;
    private CacheStrategy strategy;
    public Cache(int numberOfFrames, CacheStrategy cacheStrategy) {
        this.frames = numberOfFrames;
        this.cache = new Dictionary<string, CacheElement>();
        this.strategy = cacheStrategy;
    }

    // Returns element if already stored in cache
    // Returns null if element is not stored in cache
    public CacheElement request(CacheElement cacheElement) {
        this.strategy.keyWasAccessed(cacheElement.getKey());
        if (this.cacheContainsKey(cacheElement)) {
            CacheElement element;
            this.cache.TryGetValue(cacheElement.getKey(), out element);
            return element;
        } else {
            // Get key to replace and add new key
            if (this.cacheIsFull()) {
                this.cache.Remove(this.strategy.getKeyToReplace());
            }
            this.cache.Add(cacheElement.getKey(), cacheElement);
            this.strategy.addKey(cacheElement.getKey());
            return null;
        }
    }

    // Write current content of the cache
    public override string ToString() {
        StringBuilder stringBuilder = new StringBuilder();
        foreach (string key in this.cache.Keys) {
            stringBuilder.Append(key);
            stringBuilder.Append(" ");
        }
        return stringBuilder.ToString();
    }

    public CacheStrategy getStrategy() {
        return this.strategy;
    }

    private bool cacheIsFull() {
        return this.cache.Count >= this.frames;
    }

    private bool cacheContainsKey(CacheElement cacheElement) {
        return this.cache.ContainsKey(cacheElement.getKey());
    }
}
