using System.Collections.Generic;

public class FIFO<K>: CacheStrategy<K> {
    private Queue<K> internalCache;

    public FIFO(int numberOfFrames): base(numberOfFrames) {
        this.internalCache = new Queue<K>();
    }

    public override K getKeyToReplace() {
        return this.internalCache.Dequeue();
    }

    public override void keyWasAccessed(K key) { }

    public override void addKey(K key) {
        this.internalCache.Enqueue(key);
    }
}
