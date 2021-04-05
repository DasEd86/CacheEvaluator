using System.Collections.Generic;

class FIFO: CacheStrategy<string> {
    private Queue<string> internalCache;

    public FIFO(int numberOfFrames): base(numberOfFrames) {
        this.internalCache = new Queue<string>();
    }

    public override string getKeyToReplace() {
        return this.internalCache.Dequeue();
    }

    public override void keyWasAccessed(string key) { }

    public override void addKey(string key) {
        this.internalCache.Enqueue(key);
    }
}
