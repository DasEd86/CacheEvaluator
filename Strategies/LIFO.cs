using System.Collections.Generic;

public class LIFO<K>: CacheStrategy<K> {
    private Stack<K> internalCache;

    public LIFO(int numberOfFrames): base(numberOfFrames) {
        this.internalCache = new Stack<K>();
    }

    public override K getKeyToReplace() {
        return this.internalCache.Pop();
    }

    public override void keyWasAccessed(K key) { }

    public override void addKey(K key) {
        this.internalCache.Push(key);
    }
}
