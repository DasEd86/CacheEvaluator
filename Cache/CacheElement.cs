public class CacheElement<K, V> {
    public K Key
    {get;}

    public V Value
    {get;}

    public CacheElement(K key, V value) {
        Key = key;
        Value = value;
    }
}
