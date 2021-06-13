# Cache_Evaluator
C# application that implements different caching strategies and evaluates them.

## Installation
- Install Microsoft .net SDK
- Run with "dotnet run"

## Start application
It expects three parameters
- Cache strategy: 0 – FIFO, 1 – LIFO, 2 – Random, 3 – LFU
- Number of frames in the cache
- Access sequence separated by ,

E.g.: dotnet run 2 7 1,2,3,4,5,6,7,8,9

dotnet test