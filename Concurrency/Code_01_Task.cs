namespace Concurrency;

public static class Code_01_Threads
{
    public static void Run()
    {
        Thread newThread = new Thread(DoWork);
        Console.WriteLine($"Thread state: {newThread.ThreadState}");
        newThread.Start();
        Console.WriteLine($"Thread state: {newThread.ThreadState}");
    }

    static void DoWork()
    {
        Console.WriteLine("Hello from new thread!");
    }
}

public static class Code_02_Tasks
{
    public static void Run()
    {
        Task newTask = Task.Run(() => DoWork());
        newTask.Wait();
    }

    static void DoWork()
    {
        Console.WriteLine("Hello from new task!");
    }
}

public static class Code_03_CancelTask
{
    public static void Run()
    {
        CancellationTokenSource cts = new CancellationTokenSource();
        CancellationToken token = cts.Token;

        Task newTask = Task.Run(() => DoWork(token));
        cts.CancelAfter(TimeSpan.FromSeconds(2));
        try
        {
            newTask.Wait();
        }
        catch (AggregateException ex)
        {
            Console.WriteLine("Task was canceled. ", ex.ToString());
        }

    }

    static void DoWork(CancellationToken token)
    {
        Console.WriteLine("Loop from 0 - 10");
        for (int i = 0; i < 10; i++)
        {
            token.ThrowIfCancellationRequested();
            Console.WriteLine($"{i + 1}. Hello from new task!");
            Thread.Sleep(500);
        }
    }
}

public static class Code_04_Continue
{
    public static void Run()
    {
        Task<int> initialTask = Task.Run(() => DoWork());
        Task continuationTask = initialTask.ContinueWith(prevTask =>
            Console.WriteLine($"Result: {prevTask.Result}"));
        continuationTask.Wait();
    }

    static int DoWork()
    {
        return 42;
    }
}
