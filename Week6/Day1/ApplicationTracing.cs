using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace ApplicationTracing
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Configure trace listener to write to file
            string logFile = @"C:\Logs\OrderTrace.log";
            Directory.CreateDirectory(Path.GetDirectoryName(logFile));
            
            TextWriterTraceListener listener = new TextWriterTraceListener(logFile);
            Trace.Listeners.Add(listener);
            
            Trace.AutoFlush = true;
            
            Console.WriteLine("=== Order Processing with Tracing ===\n");
            Console.Write("Enter Order ID: ");
            string orderId = Console.ReadLine();
            
            Trace.TraceInformation($"Order {orderId}: Processing started at {DateTime.Now}");
            
            await ProcessOrderAsync(orderId);
            
            Trace.TraceInformation($"Order {orderId}: Processing completed at {DateTime.Now}");
            
            Console.WriteLine($"\nTrace log saved to: {logFile}");
            Console.ReadLine();
        }
        
        static async Task ProcessOrderAsync(string orderId)
        {
            // Step 1: Validate Order
            Trace.WriteLine($"Order {orderId}: Step 1 - Validating Order");
            Console.WriteLine($"Validating order {orderId}...");
            await Task.Delay(500);
            bool isValid = ValidateOrder(orderId);
            
            if (!isValid)
            {
                Trace.TraceError($"Order {orderId}: Validation failed!");
                Console.WriteLine("Order validation failed!");
                return;
            }
            Trace.TraceInformation($"Order {orderId}: Validation successful");
            
            // Step 2: Process Payment
            Trace.WriteLine($"Order {orderId}: Step 2 - Processing Payment");
            Console.WriteLine($"Processing payment for {orderId}...");
            await Task.Delay(800);
            bool paymentSuccess = ProcessPayment(orderId);
            
            if (!paymentSuccess)
            {
                Trace.TraceError($"Order {orderId}: Payment processing failed!");
                Console.WriteLine("Payment failed!");
                return;
            }
            Trace.TraceInformation($"Order {orderId}: Payment successful");
            
            // Step 3: Update Inventory
            Trace.WriteLine($"Order {orderId}: Step 3 - Updating Inventory");
            Console.WriteLine($"Updating inventory for {orderId}...");
            await Task.Delay(600);
            UpdateInventory(orderId);
            Trace.TraceInformation($"Order {orderId}: Inventory updated");
            
            // Step 4: Generate Invoice
            Trace.WriteLine($"Order {orderId}: Step 4 - Generating Invoice");
            Console.WriteLine($"Generating invoice for {orderId}...");
            await Task.Delay(400);
            GenerateInvoice(orderId);
            Trace.TraceInformation($"Order {orderId}: Invoice generated");
            
            Console.WriteLine($"Order {orderId} processed successfully!");
        }
        
        static bool ValidateOrder(string orderId)
        {
            // Simulate validation logic
            return true;
        }
        
        static bool ProcessPayment(string orderId)
        {
            // Simulate payment processing
            return true;
        }
        
        static void UpdateInventory(string orderId)
        {
            // Simulate inventory update
        }
        
        static void GenerateInvoice(string orderId)
        {
            // Simulate invoice generation
        }
    }
}