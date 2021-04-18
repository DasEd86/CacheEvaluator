using System;
using System.Collections.Generic;

public class RandomCache<Key>: CacheStrategy<Key> {
    private List<Key> internalCache;

    public RandomCache(int numberOfFrames): base(numberOfFrames) {
        this.internalCache = new List<Key>(numberOfFrames);
    }

    public override Key getKeyToReplace() {
        Key key = this.internalCache[new Random().Next(this.numberOfFrames)];
        this.internalCache.Remove(key);
        return key;
    }

    public override void keyWasAccessed(Key key) { }

    public override void addKey(Key key) {
        this.internalCache.Add(key);
    }
}
