class CacheElement<Key, Value> {
    private Key key;
    private Value value;

    public CacheElement(Key key, Value value) {
        this.key = key;
        this.value = value;
    }

    public Key getKey() {
        return this.key;
    }
}
