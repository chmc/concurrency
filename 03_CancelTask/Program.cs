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

void DoWork(CancellationToken token)
{
    for (int i = 0; i < 10; i++)
    {
        token.ThrowIfCancellationRequested();
        Console.WriteLine($"{i + 1}. Hello from new task!");
        Thread.Sleep(500);
    }
}
