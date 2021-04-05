using System;
using System.Diagnostics;

class Program {
    static void Main(string[] args) {
        Debug.Assert(args.Length == 3, "First parameter: Access sequence separator: ,; Second parameter: Number of frames; Third parameter: Strategy 0 FIFO, 1 LIFO");
        string[] accessSequence = args[0].Split(",");
        int numberOfFrames = Int32.Parse(args[1]);
        int strategy = Int32.Parse(args[2]);
    
        CacheEvaluator evaluator = new CacheEvaluator(accessSequence, numberOfFrames);
        evaluator.setStrategy((Strategy)strategy);
        evaluator.start();
    }
}
