using System;

namespace ISP_OfficePrinter
{
    // Segregated interfaces
    public interface IPrinter
    {
        void Print(string content);
    }

    public interface IScanner
    {
        void Scan(string content);
    }

    public interface IFax
    {
        void Fax(string content);
    }

    // Basic Printer - Only implements IPrinter
    public class BasicPrinter : IPrinter
    {
        public void Print(string content)
        {
            Console.WriteLine($"Printing: {content}");
        }
    }

    // Advanced Printer - Implements all interfaces
    public class AdvancedPrinter : IPrinter, IScanner, IFax
    {
        public void Print(string content)
        {
            Console.WriteLine($"Printing: {content}");
        }

        public void Scan(string content)
        {
            Console.WriteLine($"Scanning: {content}");
        }

        public void Fax(string content)
        {
            Console.WriteLine($"Faxing: {content}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Office Printer System ===\n");

            Console.WriteLine("Basic Printer:");
            BasicPrinter basic = new BasicPrinter();
            basic.Print("Document.pdf");

            Console.WriteLine("\nAdvanced Printer:");
            AdvancedPrinter advanced = new AdvancedPrinter();
            advanced.Print("Report.docx");
            advanced.Scan("Image.jpg");
            advanced.Fax("Contract.pdf");

            Console.ReadLine();
        }
    }
}