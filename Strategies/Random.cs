using System;
using System.Collections.Generic;

public class RandomCache<K>: CacheStrategy<K> {
    private List<K> internalCache;

    public RandomCache(int numberOfFrames): base(numberOfFrames) {
        this.internalCache = new List<K>(numberOfFrames);
    }

    public override K getKeyToReplace() {
        K key = this.internalCache[new Random().Next(this.numberOfFrames)];
        this.internalCache.Remove(key);
        return key;
    }

    public override void keyWasAccessed(K key) { }

    public override void addKey(K key) {
        this.internalCache.Add(key);
    }
}
