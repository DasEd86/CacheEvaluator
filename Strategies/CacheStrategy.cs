abstract class CacheStrategy<Key> {
    protected int numberOfFrames;

    public CacheStrategy(int frames) {
        this.numberOfFrames = frames;
    }

    // Returns the key that has to be replaced in case of cache miss
    public abstract Key getKeyToReplace();

    // Record that this key was accessed. Used by strategies such as LRU/LFU
    public abstract void keyWasAccessed(Key key);
    
    // Adds new key to the cache
    public abstract void addKey(Key key);
}
