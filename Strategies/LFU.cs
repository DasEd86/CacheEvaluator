using System;
using System.Linq;
using System.Collections.Generic;

public class LFU<K>: CacheStrategy<K> {
    private Dictionary<K, int> accessMap;

    public LFU(int numberOfFrames): base(numberOfFrames) {
        this.accessMap = new Dictionary<K, int>();
    }

    public override K getKeyToReplace() {
        K keyToReplace = default(K);
        int min = -1;
        Array.ForEach(this.accessMap.Keys.ToArray(), key => {
            int value = default(int);
            if(this.accessMap.TryGetValue(key, out value)) {
                if (min == -1 || value < min) {
                    min = value;
                    keyToReplace = key;
                }
            } else {
                throw new Exception($"Value for key {key} not found");
            }
        });
        return keyToReplace;
    }

    public override void keyWasAccessed(K key) {
        int num = default(int);
        if(this.accessMap.TryGetValue(key, out num)) {
            this.accessMap[key] = num + 1;
        } else {
            throw new Exception($"Value for key: {key} was not found.");
        }
    }

    public override void addKey(K key) {
        this.accessMap[key] = 1;
    }
}
