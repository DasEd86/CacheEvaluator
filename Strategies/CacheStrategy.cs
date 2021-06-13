public abstract class CacheStrategy<K> {
    protected int numberOfFrames;

    public CacheStrategy(int frames) {
        this.numberOfFrames = frames;
    }

    // Returns key to be replaced in case of cache miss
    public abstract K getKeyToReplace();

    // Records that key was accessed
    public abstract void keyWasAccessed(K key);
    
    // Adds key to cache
    public abstract void addKey(K key);
}
