using System;

enum CACHE_STRATEGIES {FIFO, LIFO};

public enum Strategy{
    FIFO, LIFO
};

class CacheEvaluator {
    private Cache cache;
    private string[] accessSequence;
    private int numberOfFrames;

    public CacheEvaluator(string[] accessSequence, int numberOfFrames) {
        this.accessSequence = accessSequence;
        this.numberOfFrames = numberOfFrames;
    }

    public void setStrategy(Strategy strat) {
        CacheStrategy strategy = null;
        switch (strat) {
            case Strategy.FIFO:
                strategy = new FIFO(numberOfFrames);
                break;
            case Strategy.LIFO:
                strategy = new LIFO(numberOfFrames);
                break;
            default:
                Console.WriteLine("Set stregy received invalid parameter: " + strat);
                Environment.Exit(1);
                break;
        }
        this.cache = new Cache(numberOfFrames, strategy);
    }

    public void start() {
        Console.WriteLine("Evaluating strategy: " + this.cache.getStrategy());
    
        int hits = 0;
        int misses = 0;

        foreach (string key in this.accessSequence) {
            Console.WriteLine("Read: " + key);
            Console.WriteLine("Cache before: " + this.cache.ToString());

            if (this.cache.request(new CacheElement(key)) != null) {
                hits++;
            } else {
                misses++;
            }
            Console.WriteLine("Cache after: " + this.cache.ToString());
            Console.WriteLine("Cache hits: " + hits);
            Console.WriteLine("Cache misses: " + misses);
            Console.WriteLine("------------");
        }

        Console.WriteLine("Ratio: " + (float) hits / misses);
    }
}
