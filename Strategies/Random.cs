using System;
using System.Collections.Generic;

class RandomCache: CacheStrategy<string> {
    private List<string> internalCache;

    public RandomCache(int numberOfFrames): base(numberOfFrames) {
        this.internalCache = new List<string>(numberOfFrames);
    }

    public override string getKeyToReplace() {
        string key = this.internalCache[new Random().Next(this.numberOfFrames)];
        this.internalCache.Remove(key);
        return key;
    }

    public override void keyWasAccessed(string key) { }

    public override void addKey(string key) {
        this.internalCache.Add(key);
    }
}
