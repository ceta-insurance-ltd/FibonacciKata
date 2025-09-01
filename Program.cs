using System.Diagnostics;

namespace FibonacciKata;

class Program
{
    static void Main(string[] args)
    {
        int limit = args.Length > 0 && int.TryParse(args[0], out var input) ? input : 10000;

        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();

        var startingMemory = GC.GetTotalMemory(true);
        var watch = Stopwatch.StartNew();

        var result = Fibonacci(limit);

        watch.Stop();
        var finalMemory = GC.GetTotalMemory(true);
        var memoryUsed = finalMemory - startingMemory;

        Console.WriteLine($"\n-- Result: {result}");
        Console.WriteLine($"-- Time elapsed: {watch.ElapsedMilliseconds} ms");
        Console.WriteLine($"-- Memory used: {memoryUsed:N0} bytes");
    }

    static long Fibonacci(int limit)
    {
        throw new NotImplementedException("Implement me");
    }
}
