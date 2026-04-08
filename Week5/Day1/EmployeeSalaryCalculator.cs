using System;

namespace EmployeeSalaryCalculator
{
    // Base class
    class Employee
    {
        public string Name { get; set; }
        public decimal BaseSalary { get; set; }

        public Employee(string name, decimal baseSalary)
        {
            Name = name;
            BaseSalary = baseSalary;
        }

        // Virtual method to be overridden
        public virtual decimal CalculateSalary()
        {
            return BaseSalary;
        }
    }

    // Derived class - Manager
    class Manager : Employee
    {
        public Manager(string name, decimal baseSalary) : base(name, baseSalary)
        {
        }

        public override decimal CalculateSalary()
        {
            // 20% bonus
            decimal bonus = BaseSalary * 0.20m;
            return BaseSalary + bonus;
        }
    }

    // Derived class - Developer
    class Developer : Employee
    {
        public Developer(string name, decimal baseSalary) : base(name, baseSalary)
        {
        }

        public override decimal CalculateSalary()
        {
            // 10% bonus
            decimal bonus = BaseSalary * 0.10m;
            return BaseSalary + bonus;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Employee Salary Calculator ===\n");
            
            decimal baseSalary = 50000;
            Console.WriteLine($"Base Salary: ${baseSalary}\n");
            
            // Using polymorphism
            Employee manager = new Manager("John Doe", baseSalary);
            Employee developer = new Developer("Jane Smith", baseSalary);
            
            decimal managerSalary = manager.CalculateSalary();
            decimal developerSalary = developer.CalculateSalary();
            
            Console.WriteLine($"Manager Salary = ${managerSalary}");
            Console.WriteLine($"Developer Salary = ${developerSalary}");
            
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}