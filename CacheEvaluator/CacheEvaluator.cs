using System;

public enum Strategy{
    FIFO, LIFO, RANDOM, LFU
};

public class CacheEvaluator {
    private Cache<string, int> cache;
    private string[] accessSequence;
    private int numberOfFrames;

    public CacheEvaluator(string[] accessSequence, int numberOfFrames) {
        this.accessSequence = accessSequence;
        this.numberOfFrames = numberOfFrames;
    }

    public void setStrategy(Strategy cacheStrategy) {
        CacheStrategy<string> strategy = null;
        switch (cacheStrategy) {
            case Strategy.FIFO:
                strategy = new FIFO<string>(numberOfFrames);
                break;
            case Strategy.LIFO:
                strategy = new LIFO<string>(numberOfFrames);
                break;
            case Strategy.RANDOM:
                strategy = new RandomCache<string>(numberOfFrames);
                break;
            case Strategy.LFU:
                strategy = new LFU<string>(numberOfFrames);
                break;
            default:
                throw new Exception($"setStrategy() received invalid parameter: {cacheStrategy}");
        }
        this.cache = new Cache<string, int>(numberOfFrames, strategy);
    }

    public void start() {
        Console.WriteLine($"Evaluate: {this.cache.getStrategy()}");
    
        int hits = 0;
        int misses = 0;

        foreach (string key in this.accessSequence) {
            Console.WriteLine($"Read: {key}");
            Console.WriteLine($"Cache before: {this.cache.ToString()}");

            if (this.cache.getCacheElement(key) != null) {
                hits++;
            } else {
                misses++;
            }
            Console.WriteLine($"Cache after: {this.cache.ToString()}");
            Console.WriteLine($"Cache hits: {hits}");
            Console.WriteLine($"Cache misses: {misses}");
            Console.WriteLine("------------");
        }

        Console.WriteLine($"Ratio: {(float) hits / misses}");
    }
}
