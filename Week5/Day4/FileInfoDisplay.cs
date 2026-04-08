using System;
using System.IO;

namespace FileInfoDisplay
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter folder path: ");
                string folderPath = Console.ReadLine();
                
                if (!Directory.Exists(folderPath))
                {
                    Console.WriteLine("Invalid directory path!");
                    Console.ReadLine();
                    return;
                }
                
                DirectoryInfo dirInfo = new DirectoryInfo(folderPath);
                FileInfo[] files = dirInfo.GetFiles();
                
                Console.WriteLine($"\nTotal Files: {files.Length}\n");
                Console.WriteLine($"{"File Name",-30} {"Size (KB)",-15} {"Creation Date",-25}");
                Console.WriteLine(new string('-', 70));
                
                foreach (FileInfo file in files)
                {
                    Console.WriteLine($"{file.Name,-30} {(file.Length / 1024.0):F2,-15} {file.CreationTime,-25}");
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