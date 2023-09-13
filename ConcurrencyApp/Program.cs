using System;
using System.Threading;

class Program
{
    static void Main() 
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
