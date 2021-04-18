public abstract class CacheStrategy<Key> {
    protected int numberOfFrames;

    public CacheStrategy(int frames) {
        this.numberOfFrames = frames;
    }

    // Returns key to be replaced in case of cache miss
    public abstract Key getKeyToReplace();

    // Records that key was accessed
    public abstract void keyWasAccessed(Key key);
    
    // Adds key to cache
    public abstract void addKey(Key key);
}
