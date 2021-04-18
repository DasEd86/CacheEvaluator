using System.Collections.Generic;

public class FIFO<Key>: CacheStrategy<Key> {
    private Queue<Key> internalCache;

    public FIFO(int numberOfFrames): base(numberOfFrames) {
        this.internalCache = new Queue<Key>();
    }

    public override Key getKeyToReplace() {
        return this.internalCache.Dequeue();
    }

    public override void keyWasAccessed(Key key) { }

    public override void addKey(Key key) {
        this.internalCache.Enqueue(key);
    }
}
