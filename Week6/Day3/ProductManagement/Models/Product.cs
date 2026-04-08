using System;

namespace ProductManagement.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }

        public void Display()
        {
            Console.WriteLine($"ID: {ProductId,-5} | Name: {ProductName,-20} | Category: {Category,-15} | Price: ${Price,-8}");
        }
    }
}