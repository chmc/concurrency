// See https://aka.ms/new-console-template for more information
using Concurrency;

if (args.Length == 1)
{
    switch (args[0])
    {
        case "1": Code_01_Threads.Run(); break;
        case "2": Code_02_Tasks.Run(); break;
        case "3": Code_03_CancelTask.Run(); break;
        case "4": Code_04_Continue.Run(); break;
        case "5": Code_05_Parallel.Run(); break;
    }
}
else
{
    Console.WriteLine("Use argument to execute one of following options:");
    Console.WriteLine("0 - Last option");
    Console.WriteLine("1 - Threads");
    Console.WriteLine("2 - Tasks");
    Console.WriteLine("3 - Cancel Task");
    Console.WriteLine("4 - Continue");
    Console.WriteLine("5 - Parallel");
}