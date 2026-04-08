using System;

namespace DebugDiscountCalculation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Product Name: ");
            string productName = Console.ReadLine();

            Console.Write("Enter Product Price: ");
            double price = double.Parse(Console.ReadLine());

            Console.Write("Enter Discount Percentage: ");
            double discountPercent = double.Parse(Console.ReadLine());

            // Place breakpoint here to inspect values
            double discountAmount = price * discountPercent / 100;
            double finalPrice = price - discountAmount;

            Console.WriteLine($"\nProduct: {productName}");
            Console.WriteLine($"Original Price: ${price}");
            Console.WriteLine($"Discount: {discountPercent}%");
            Console.WriteLine($"Discount Amount: ${discountAmount}");
            Console.WriteLine($"Final Price: ${finalPrice}");

            Console.ReadLine();
        }
    }
}