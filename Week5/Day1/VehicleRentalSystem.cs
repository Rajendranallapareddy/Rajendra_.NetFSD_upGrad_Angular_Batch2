using System;

namespace VehicleRentalSystem
{
    // Base class
    class Vehicle
    {
        public string Brand { get; set; }
        public decimal RentalRatePerDay { get; set; }

        public Vehicle(string brand, decimal rentalRatePerDay)
        {
            Brand = brand;
            RentalRatePerDay = rentalRatePerDay;
        }

        // Virtual method for rental calculation
        public virtual decimal CalculateRental(int days)
        {
            if (days <= 0)
            {
                throw new ArgumentException("Number of rental days must be greater than zero!");
            }
            return RentalRatePerDay * days;
        }
    }

    // Derived class - Car (adds insurance charge)
    class Car : Vehicle
    {
        private const decimal INSURANCE_CHARGE = 500;

        public Car(string brand, decimal rentalRatePerDay) : base(brand, rentalRatePerDay)
        {
        }

        public override decimal CalculateRental(int days)
        {
            decimal baseRental = base.CalculateRental(days);
            decimal totalRental = baseRental + INSURANCE_CHARGE;
            return totalRental;
        }
    }

    // Derived class - Bike (5% discount)
    class Bike : Vehicle
    {
        public Bike(string brand, decimal rentalRatePerDay) : base(brand, rentalRatePerDay)
        {
        }

        public override decimal CalculateRental(int days)
        {
            decimal baseRental = base.CalculateRental(days);
            decimal discount = baseRental * 0.05m; // 5% discount
            decimal totalRental = baseRental - discount;
            return totalRental;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Vehicle Rental System ===\n");
            
            // Car rental
            Console.WriteLine("Car Rental:");
            Vehicle car = new Car("Toyota Camry", 2000);
            int days = 3;
            decimal carRental = car.CalculateRental(days);
            Console.WriteLine($"Brand: {car.Brand}");
            Console.WriteLine($"Rental Rate Per Day: ${car.RentalRatePerDay}");
            Console.WriteLine($"Days: {days}");
            Console.WriteLine($"Insurance Charge: $500");
            Console.WriteLine($"Total Rental = ${carRental}");
            
            Console.WriteLine("\n" + new string('-', 30) + "\n");
            
            // Bike rental
            Console.WriteLine("Bike Rental:");
            Vehicle bike = new Bike("Honda CB350", 1000);
            int bikeDays = 5;
            decimal bikeRental = bike.CalculateRental(bikeDays);
            Console.WriteLine($"Brand: {bike.Brand}");
            Console.WriteLine($"Rental Rate Per Day: ${bike.RentalRatePerDay}");
            Console.WriteLine($"Days: {bikeDays}");
            Console.WriteLine($"Discount: 5%");
            Console.WriteLine($"Total Rental = ${bikeRental}");
            
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}