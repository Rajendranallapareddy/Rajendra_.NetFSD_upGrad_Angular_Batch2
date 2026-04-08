using System;
using System.IO;
using System.Text;

namespace FileStreamWriter
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"C:\Logs\messages.txt";
            
            // Ensure directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(filePath));
            
            while (true)
            {
                try
                {
                    Console.Write("Enter a message (or type 'exit' to quit): ");
                    string message = Console.ReadLine();
                    
                    if (message.ToLower() == "exit")
                        break;
                    
                    // Write message to file using FileStream
                    using (FileStream fs = new FileStream(filePath, FileMode.Append, FileAccess.Write))
                    {
                        byte[] data = Encoding.UTF8.GetBytes($"{DateTime.Now}: {message}\n");
                        fs.Write(data, 0, data.Length);
                    }
                    
                    Console.WriteLine("Message written successfully!\n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            
            Console.WriteLine("\nAll messages saved to: " + filePath);
            Console.ReadLine();
        }
    }
}