using System;
using ProductManagement.Data;
using ProductManagement.Models;

namespace ProductManagement
{
    class Program
    {
        static ProductRepository repository = new ProductRepository();

        static void Main(string[] args)
        {
            Console.WriteLine("╔════════════════════════════════════════╗");
            Console.WriteLine("║     Product Management System         ║");
            Console.WriteLine("║        (ADO.NET with Stored Procs)    ║");
            Console.WriteLine("╚════════════════════════════════════════╝");

            while (true)
            {
                Console.WriteLine("\n┌──────────────────────────────────────┐");
                Console.WriteLine("│              MAIN MENU               │");
                Console.WriteLine("├──────────────────────────────────────┤");
                Console.WriteLine("│ 1. Add New Product                   │");
                Console.WriteLine("│ 2. View All Products                 │");
                Console.WriteLine("│ 3. Update Product                    │");
                Console.WriteLine("│ 4. Delete Product                    │");
                Console.WriteLine("│ 5. Exit                              │");
                Console.WriteLine("└──────────────────────────────────────┘");
                Console.Write("Enter your choice (1-5): ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        InsertProduct();
                        break;
                    case "2":
                        ViewAllProducts();
                        break;
                    case "3":
                        UpdateProduct();
                        break;
                    case "4":
                        DeleteProduct();
                        break;
                    case "5":
                        Console.WriteLine("\nExiting application. Goodbye!");
                        return;
                    default:
                        Console.WriteLine("❌ Invalid choice! Please enter 1-5.");
                        break;
                }
            }
        }

        static void InsertProduct()
        {
            Console.WriteLine("\n--- Add New Product ---");

            Console.Write("Enter Product Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Category: ");
            string category = Console.ReadLine();

            Console.Write("Enter Price: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal price))
            {
                Console.WriteLine("❌ Invalid price!");
                return;
            }

            repository.InsertProduct(name, category, price);
        }

        static void ViewAllProducts()
        {
            Console.WriteLine("\n--- All Products ---");

            var products = repository.GetAllProducts();

            if (products.Count == 0)
            {
                Console.WriteLine("No products found in database!");
                return;
            }

            Console.WriteLine($"\n{"ID",-5} {"Product Name",-22} {"Category",-17} {"Price",-10}");
            Console.WriteLine(new string('-', 55));

            foreach (var product in products)
            {
                product.Display();
            }

            Console.WriteLine($"\nTotal Products: {products.Count}");
        }

        static void UpdateProduct()
        {
            Console.WriteLine("\n--- Update Product ---");

            ViewAllProducts();

            Console.Write("\nEnter Product ID to update: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("❌ Invalid ID!");
                return;
            }

            if (!repository.ProductExists(id))
            {
                Console.WriteLine("❌ Product not found!");
                return;
            }

            Console.Write("Enter New Product Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter New Category: ");
            string category = Console.ReadLine();

            Console.Write("Enter New Price: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal price))
            {
                Console.WriteLine("❌ Invalid price!");
                return;
            }

            repository.UpdateProduct(id, name, category, price);
        }

        static void DeleteProduct()
        {
            Console.WriteLine("\n--- Delete Product ---");

            ViewAllProducts();

            Console.Write("\nEnter Product ID to delete: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("❌ Invalid ID!");
                return;
            }

            if (!repository.ProductExists(id))
            {
                Console.WriteLine("❌ Product not found!");
                return;
            }

            Console.Write("Are you sure? (Y/N): ");
            string confirm = Console.ReadLine();
            
            if (confirm.ToLower() == "y")
            {
                repository.DeleteProduct(id);
            }
            else
            {
                Console.WriteLine("Deletion cancelled.");
            }
        }
    }
}