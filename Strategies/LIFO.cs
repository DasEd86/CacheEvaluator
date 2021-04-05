using System.Collections.Generic;

class LIFO: CacheStrategy<string> {
    private Stack<string> internalCache;

    public LIFO(int numberOfFrames): base(numberOfFrames) {
        this.internalCache = new Stack<string>();
    }

    public override string getKeyToReplace() {
        return this.internalCache.Pop();
    }

    public override void keyWasAccessed(string key) { }

    public override void addKey(string key) {
        this.internalCache.Push(key);
    }
}
