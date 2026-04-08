using System;

namespace OnlineShoppingCart
{
    // Base class
    class Product
    {
        private string name;
        private decimal price;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public decimal Price
        {
            get { return price; }
            set 
            { 
                if (value < 0)
                {
                    throw new ArgumentException("Price cannot be negative!");
                }
                price = value;
            }
        }

        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        // Virtual method for discount calculation
        public virtual decimal CalculateDiscount()
        {
            return 0; // No discount by default
        }

        public decimal GetFinalPrice()
        {
            decimal discount = CalculateDiscount();
            return Price - discount;
        }

        public void DisplayProductInfo()
        {
            decimal discount = CalculateDiscount();
            decimal finalPrice = GetFinalPrice();
            Console.WriteLine($"Product: {Name}");
            Console.WriteLine($"Original Price: ${Price}");
            Console.WriteLine($"Discount: ${discount}");
            Console.WriteLine($"Final Price: ${finalPrice}");
        }
    }

    // Derived class - Electronics (5% discount)
    class Electronics : Product
    {
        public Electronics(string name, decimal price) : base(name, price)
        {
        }

        public override decimal CalculateDiscount()
        {
            return Price * 0.05m; // 5% discount
        }
    }

    // Derived class - Clothing (15% discount)
    class Clothing : Product
    {
        public Clothing(string name, decimal price) : base(name, price)
        {
        }

        public override decimal CalculateDiscount()
        {
            return Price * 0.15m; // 15% discount
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Online Shopping Cart System ===\n");
            
            // Electronics product
            Console.WriteLine("Electronics:");
            Product laptop = new Electronics("Laptop", 20000);
            laptop.DisplayProductInfo();
            
            Console.WriteLine("\n" + new string('-', 30) + "\n");
            
            // Clothing product
            Console.WriteLine("Clothing:");
            Product shirt = new Clothing("T-Shirt", 1000);
            shirt.DisplayProductInfo();
            
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}