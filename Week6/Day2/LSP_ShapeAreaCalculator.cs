using System;

namespace LSP_ShapeAreaCalculator
{
    // Base class - Shape
    public abstract class Shape
    {
        public abstract double CalculateArea();
    }

    // Derived class - Rectangle
    public class Rectangle : Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public override double CalculateArea()
        {
            return Width * Height;
        }
    }

    // Derived class - Circle
    public class Circle : Shape
    {
        public double Radius { get; set; }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public override double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }
    }

    class Program
    {
        static void PrintArea(Shape shape)
        {
            Console.WriteLine($"Area: {shape.CalculateArea():F2}");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("=== Shape Area Calculator ===\n");

            Shape rectangle = new Rectangle(10, 5);
            Console.Write("Rectangle (10 x 5): ");
            PrintArea(rectangle);

            Shape circle = new Circle(7);
            Console.Write("Circle (Radius = 7): ");
            PrintArea(circle);

            Console.ReadLine();
        }
    }
}