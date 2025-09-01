using System.Diagnostics;

namespace FibonacciKata;

class Program
{
    static void Main(string[] args)
    {
        var limit = args.Length > 0 && int.TryParse(args[0], out var input) ? input : 10000;

        const string header =
            "| Fibonacci(n) | Result       | Time (ms) | Memory (bytes) |\n" +
            "|--------------|--------------|-----------|----------------|";

        Console.WriteLine();
        Console.WriteLine(header);

        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();

        var startingMemory = GC.GetTotalMemory(true);
        var watch = Stopwatch.StartNew();

        var result = Fibonacci(limit);

        watch.Stop();
        var finalMemory = GC.GetTotalMemory(true);
        var memoryUsed = finalMemory - startingMemory;

        var resultOutput = string.Create(72, (limit, result, watch.ElapsedMilliseconds, memoryUsed),
            static (span, state) =>
            {
                var (n, result, time, memory) = state;
                var s = FormattableString.Invariant(
                    $"| {n,-12} | {result,-12} | {time,-9} | {memory,-14:N0} |");
                s.AsSpan().CopyTo(span);
            });

        Console.WriteLine(resultOutput);
    }

    static long Fibonacci(int limit)
    {
        throw new NotImplementedException("Implement me");
    }
}
