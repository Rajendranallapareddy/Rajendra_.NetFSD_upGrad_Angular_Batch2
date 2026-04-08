using System;
using System.Threading.Tasks;

namespace AsyncOrderProcessing
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("=== Order Processing System ===\n");
            Console.Write("Enter Order ID: ");
            string orderId = Console.ReadLine();

            Console.WriteLine($"\nProcessing Order: {orderId}\n");

            await ProcessOrderAsync(orderId);

            Console.WriteLine($"\nOrder {orderId} processing completed!");
            Console.ReadLine();
        }

        static async Task ProcessOrderAsync(string orderId)
        {
            bool paymentVerified = await VerifyPaymentAsync(orderId);
            
            if (paymentVerified)
            {
                bool inventoryAvailable = await CheckInventoryAsync(orderId);
                
                if (inventoryAvailable)
                {
                    await ConfirmOrderAsync(orderId);
                }
                else
                {
                    Console.WriteLine($"Order {orderId}: Inventory check failed!");
                }
            }
            else
            {
                Console.WriteLine($"Order {orderId}: Payment verification failed!");
            }
        }

        static async Task<bool> VerifyPaymentAsync(string orderId)
        {
            Console.WriteLine($"{orderId}: Verifying payment...");
            await Task.Delay(1500);
            Console.WriteLine($"{orderId}: Payment verified successfully.");
            return true;
        }

        static async Task<bool> CheckInventoryAsync(string orderId)
        {
            Console.WriteLine($"{orderId}: Checking inventory...");
            await Task.Delay(1200);
            Console.WriteLine($"{orderId}: Inventory available.");
            return true;
        }

        static async Task ConfirmOrderAsync(string orderId)
        {
            Console.WriteLine($"{orderId}: Confirming order...");
            await Task.Delay(1000);
            Console.WriteLine($"{orderId}: Order confirmed!");
        }
    }
}