using System;
using System.Threading;

class Program
{
    static void Main() 
    {
        Task newTask = Task.Run(() => DoWork());
        newTask.Wait();
    }

    static void DoWork()
    {
        Console.WriteLine("Hello from new task!");
    }
}
