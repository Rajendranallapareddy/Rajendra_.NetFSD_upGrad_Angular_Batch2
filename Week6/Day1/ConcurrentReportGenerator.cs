using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConcurrentReportGenerator
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Starting all reports concurrently...\n");

            Task salesTask = GenerateSalesReportAsync();
            Task inventoryTask = GenerateInventoryReportAsync();
            Task customerTask = GenerateCustomerReportAsync();

            // Wait for all tasks to complete
            await Task.WhenAll(salesTask, inventoryTask, customerTask);

            Console.WriteLine("\nAll reports completed successfully!");
            Console.ReadLine();
        }

        static async Task GenerateSalesReportAsync()
        {
            Console.WriteLine("Sales Report started...");
            await Task.Delay(2000);
            Console.WriteLine("Sales Report finished.");
        }

        static async Task GenerateInventoryReportAsync()
        {
            Console.WriteLine("Inventory Report started...");
            await Task.Delay(1500);
            Console.WriteLine("Inventory Report finished.");
        }

        static async Task GenerateCustomerReportAsync()
        {
            Console.WriteLine("Customer Report started...");
            await Task.Delay(1800);
            Console.WriteLine("Customer Report finished.");
        }
    }
}