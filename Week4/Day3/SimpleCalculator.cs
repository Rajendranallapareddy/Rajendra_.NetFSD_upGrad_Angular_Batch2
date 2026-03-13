using System;

class Program
{
    static void Main()
    {
        double num1, num2;
        char op;

        Console.Write("Enter First Number: ");
        num1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter Second Number: ");
        num2 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter Operator (+, -, *, /): ");
        op = Convert.ToChar(Console.ReadLine());

        double result;

        switch (op)
        {
            case '+':
                result = num1 + num2;
                Console.WriteLine("Result: " + result);
                break;

            case '-':
                result = num1 - num2;
                Console.WriteLine("Result: " + result);
                break;

            case '*':
                result = num1 * num2;
                Console.WriteLine("Result: " + result);
                break;

            case '/':
                if (num2 == 0)
                {
                    Console.WriteLine("Error: Division by zero is not allowed.");
                }
                else
                {
                    result = num1 / num2;
                    Console.WriteLine("Result: " + result);
                }
                break;

            default:
                Console.WriteLine("Invalid operator.");
                break;
        }
    }
}