abstract class CacheStrategy {
    private int numberOfFrames;

    public CacheStrategy(int frames) {
        this.numberOfFrames = frames;
    }

    // Returns the key that has to be replaced in case of cache miss
    public abstract string getKeyToReplace();

    // Record that this key was accessed. Used by strategies such as LRU/LFU
    public abstract void keyWasAccessed(string key);
    
    // Adds new key to the cache
    public abstract void addKey(string key);
}
