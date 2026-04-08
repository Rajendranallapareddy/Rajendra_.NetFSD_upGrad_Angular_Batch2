using System;
using System.Threading.Tasks;

namespace AsyncFileLogger
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Main thread started...");

            // Simulate multiple log events
            await WriteLogAsync("User logged in");
            await WriteLogAsync("User viewed product page");
            await WriteLogAsync("User added item to cart");
            await WriteLogAsync("User completed checkout");
            await WriteLogAsync("User logged out");

            Console.WriteLine("Main thread completed. Press any key to exit.");
            Console.ReadLine();
        }

        static async Task WriteLogAsync(string message)
        {
            Console.WriteLine($"Logging started: {message}");
            
            // Simulate asynchronous file writing
            await Task.Delay(1000);
            
            Console.WriteLine($"Log written: {DateTime.Now}: {message}");
        }
    }
}