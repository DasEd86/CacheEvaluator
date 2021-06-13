using System.Text;
using System.Collections.Generic;

public class Cache<K, V> {
    private int numberOfFrames;
    private Dictionary<K, CacheElement<K, V>> cache;
    private CacheStrategy<K> strategy;
    public Cache(int numberOfFrames, CacheStrategy<K> cacheStrategy) {
        this.numberOfFrames = numberOfFrames;
        this.cache = new Dictionary<K, CacheElement<K, V>>();
        this.strategy = cacheStrategy;
    }

    // Request an element by key from the cache
    // Returns the element if it is already stored in the cache
    // Returns null if element was not stored in the cache
    public CacheElement<K, V> getCacheElement(K cacheElementKey) {
        if (this.cacheContainsKey(cacheElementKey)) {
            CacheElement<K, V> element;
            this.cache.TryGetValue(cacheElementKey, out element);
            this.strategy.keyWasAccessed(cacheElementKey);
            return element;
        } else {
            if (this.cacheIsFull()) {
                this.cache.Remove(this.strategy.getKeyToReplace());
            }
            this.cache.Add(cacheElementKey, new CacheElement<K, V>(cacheElementKey, default(V)));
            this.strategy.addKey(cacheElementKey);
            return null;
        }
    }

    // Output current content of the cache
    public override string ToString() {
        StringBuilder stringBuilder = new StringBuilder();
        foreach (K key in this.cache.Keys) {
            stringBuilder.Append($"{key} ");
        }
        return stringBuilder.ToString();
    }

    public CacheStrategy<K> getStrategy() {
        return this.strategy;
    }

    private bool cacheIsFull() {
        return this.cache.Count >= this.numberOfFrames;
    }

    private bool cacheContainsKey(K cacheElement) {
        return this.cache.ContainsKey(cacheElement);
    }
}
