Task<int> initialTask = Task.Run(() => DoWork());
Task continuationTask = initialTask.ContinueWith(prevTask => 
    Console.WriteLine($"Result: {prevTask.Result}"));
continuationTask.Wait();

int DoWork()
{
    return 42;
}