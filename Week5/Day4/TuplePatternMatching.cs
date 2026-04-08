using System;

namespace TuplePatternMatching
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter Employee Name: ");
                string name = Console.ReadLine();
                
                Console.Write("Enter Monthly Sales Amount: ");
                double sales = double.Parse(Console.ReadLine());
                
                Console.Write("Enter Customer Feedback Rating (1-5): ");
                int rating = int.Parse(Console.ReadLine());
                
                if (rating < 1 || rating > 5)
                {
                    Console.WriteLine("Rating must be between 1 and 5!");
                    Console.ReadLine();
                    return;
                }
                
                var employeeData = GetEmployeeData(sales, rating);
                string performance = GetPerformanceCategory(employeeData);
                
                Console.WriteLine($"\nEmployee Name: {name}");
                Console.WriteLine($"Sales Amount: {employeeData.Sales}");
                Console.WriteLine($"Rating: {employeeData.Rating}");
                Console.WriteLine($"Performance: {performance}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            
            Console.ReadLine();
        }
        
        // Method returning Tuple
        static (double Sales, int Rating) GetEmployeeData(double sales, int rating)
        {
            return (sales, rating);
        }
        
        // Pattern matching for performance category
        static string GetPerformanceCategory((double Sales, int Rating) data)
        {
            return (data.Sales, data.Rating) switch
            {
                (>= 100000, >= 4) => "High Performer",
                (>= 50000, >= 3) => "Average Performer",
                _ => "Needs Improvement"
            };
        }
    }
}