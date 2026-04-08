using System;

namespace SafeDivisionCalculator
{
    class Calculator
    {
        // Method to perform division safely
        public double Divide(int numerator, int denominator)
        {
            try
            {
                // Attempt division
                double result = (double)numerator / denominator;
                return result;
            }
            catch (DivideByZeroException)
            {
                // Handle division by zero
                throw new DivideByZeroException("Cannot divide by zero");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Safe Division Calculator ===\n");

            Calculator calc = new Calculator();

            while (true)
            {
                try
                {
                    // Get numerator
                    Console.Write("Enter Numerator: ");
                    if (!int.TryParse(Console.ReadLine(), out int numerator))
                    {
                        Console.WriteLine("Invalid input! Please enter a valid integer.");
                        continue;
                    }

                    // Get denominator
                    Console.Write("Enter Denominator: ");
                    if (!int.TryParse(Console.ReadLine(), out int denominator))
                    {
                        Console.WriteLine("Invalid input! Please enter a valid integer.");
                        continue;
                    }

                    // Attempt division with exception handling
                    try
                    {
                        double result = calc.Divide(numerator, denominator);
                        Console.WriteLine($"\nResult: {numerator} ÷ {denominator} = {result}");
                    }
                    catch (DivideByZeroException ex)
                    {
                        Console.WriteLine($"\nError: {ex.Message}");
                    }
                    finally
                    {
                        Console.WriteLine("Operation completed safely");
                        Console.WriteLine("--------------------");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Unexpected error: {ex.Message}");
                }

                Console.Write("\nDo you want to continue? (yes/no): ");
                string choice = Console.ReadLine().ToLower();
                if (choice != "yes" && choice != "y")
                {
                    break;
                }
                Console.WriteLine();
            }

            Console.WriteLine("\nProgram ended.");
        }
    }
}