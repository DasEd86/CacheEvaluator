using System;
using System.Diagnostics;

class Program {
    static void Main(string[] args) {
        Debug.Assert(
            args.Length == 3,
            "Parameters: First: 0 FIFO, 1 LIFO, 2 Random, 3 LFU; Second: Number of frames; Third: Access sequence separator: ,");
        int strategy = Int32.Parse(args[0]);
        int numberOfFrames = Int32.Parse(args[1]);
        string[] accessSequence = args[2].Split(",");
    
        CacheEvaluator evaluator = new CacheEvaluator(accessSequence, numberOfFrames);
        evaluator.setStrategy((Strategy) strategy);
        evaluator.start();
    }
}
