using System.Collections.Generic;

public class LIFO<Key>: CacheStrategy<Key> {
    private Stack<Key> internalCache;

    public LIFO(int numberOfFrames): base(numberOfFrames) {
        this.internalCache = new Stack<Key>();
    }

    public override Key getKeyToReplace() {
        return this.internalCache.Pop();
    }

    public override void keyWasAccessed(Key key) { }

    public override void addKey(Key key) {
        this.internalCache.Push(key);
    }
}
