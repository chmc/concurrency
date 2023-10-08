namespace Concurrency;

public static class Code_05_Parallel
{
    public static void Run()
    {
        // Parallel.For
        Parallel.For(0, 10, i => Console.WriteLine($"Hello from iteration {i} on thread {Thread.CurrentThread.ManagedThreadId}"));

        // Parallel.ForEach
        List<string> items = new List<string> { "apple", "banana", "cherry" };
        Parallel.ForEach(items, item => Console.WriteLine($"Processing {item} on thread {Thread.CurrentThread.ManagedThreadId}"));
    }
}

public static class Code_06_Cancellation_and_Exception
{
    // To handle cancellation and exceptions in parallel loops, you can use 
    // the ParallelLoopState object and the ParallelOptions class:
    public static void Run()
    {
        CancellationTokenSource cts = new CancellationTokenSource();
        ParallelOptions options = new ParallelOptions
        {
            CancellationToken = cts.Token,
            MaxDegreeOfParallelism = Environment.ProcessorCount
        };

        try
        {
            Parallel.For(0, 10, options, (i, loopState) => 
            {
                if (i == 5)
                {
                    cts.Cancel();
                }

                Console.WriteLine($"Hello from iteration {i} on thread {Thread.CurrentThread.ManagedThreadId}");
            });
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Operation was canceled.");
        }
    }
}