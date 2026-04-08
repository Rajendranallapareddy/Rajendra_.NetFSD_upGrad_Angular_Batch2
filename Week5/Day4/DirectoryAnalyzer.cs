using System;
using System.IO;

namespace DirectoryAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter root directory path: ");
                string rootPath = Console.ReadLine();
                
                if (!Directory.Exists(rootPath))
                {
                    Console.WriteLine("Invalid directory path!");
                    Console.ReadLine();
                    return;
                }
                
                DirectoryInfo rootDir = new DirectoryInfo(rootPath);
                DirectoryInfo[] subDirs = rootDir.GetDirectories();
                
                Console.WriteLine($"\nAnalyzing: {rootPath}\n");
                Console.WriteLine($"{"Folder Name",-40} {"File Count",-15}");
                Console.WriteLine(new string('-', 55));
                
                foreach (DirectoryInfo dir in subDirs)
                {
                    try
                    {
                        FileInfo[] files = dir.GetFiles();
                        Console.WriteLine($"{dir.Name,-40} {files.Length,-15}");
                    }
                    catch (UnauthorizedAccessException)
                    {
                        Console.WriteLine($"{dir.Name,-40} Access Denied");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            
            Console.ReadLine();
        }
    }
}