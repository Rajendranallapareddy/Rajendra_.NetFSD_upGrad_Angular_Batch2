using System;

class Program
{
    static void Main()
    {
        string name;
        int marks;

        Console.Write("Enter Name: ");
        name = Console.ReadLine();

        Console.Write("Enter Marks: ");
        marks = Convert.ToInt32(Console.ReadLine());

        if (marks < 0 || marks > 100)
        {
            Console.WriteLine("Invalid marks. Please enter marks between 0 and 100.");
        }
        else
        {
            Console.WriteLine("Student: " + name);

            if (marks >= 90)
            {
                Console.WriteLine("Grade: A");
            }
            else if (marks >= 75)
            {
                Console.WriteLine("Grade: B");
            }
            else if (marks >= 60)
            {
                Console.WriteLine("Grade: C");
            }
            else if (marks >= 50)
            {
                Console.WriteLine("Grade: D");
            }
            else
            {
                Console.WriteLine("Grade: Fail");
            }
        }
    }
}