// Parallel.For
Parallel.For(0, 10, i => Console.WriteLine($"Hello from iteration {i} on thread {Thread.CurrentThread.ManagedThreadId}"));

// Parallel.ForEach
List<string> items = new List<string> { "apple", "banana", "cherry" };
Parallel.ForEach(items, item => Console.WriteLine($"Processing {item} on thread {Thread.CurrentThread.ManagedThreadId}"));
