using System;

class Program
{
    static void Main()
    {
        string name;
        double salary, bonus, finalSalary;
        int experience;

        Console.Write("Enter Name: ");
        name = Console.ReadLine();

        Console.Write("Enter Salary: ");
        salary = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter Experience (years): ");
        experience = Convert.ToInt32(Console.ReadLine());

        // Determine bonus percentage using if-else
        double bonusPercent;

        if (experience < 2)
        {
            bonusPercent = 0.05;
        }
        else if (experience <= 5)
        {
            bonusPercent = 0.10;
        }
        else
        {
            bonusPercent = 0.15;
        }

        // Calculate bonus using ternary operator (conditional operator)
        bonus = salary > 0 ? salary * bonusPercent : 0;

        finalSalary = salary + bonus;

        Console.WriteLine("\nEmployee: " + name);
        Console.WriteLine("Bonus: " + bonus.ToString("C"));
        Console.WriteLine("Final Salary: " + finalSalary.ToString("C"));
    }
}