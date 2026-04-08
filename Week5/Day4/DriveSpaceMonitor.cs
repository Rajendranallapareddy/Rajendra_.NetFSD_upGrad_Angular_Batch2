using System;
using System.IO;

namespace DriveSpaceMonitor
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                DriveInfo[] drives = DriveInfo.GetDrives();
                
                Console.WriteLine("=== Disk Storage Monitor ===\n");
                Console.WriteLine($"{"Drive",-10} {"Type",-12} {"Total Size (GB)",-18} {"Free Space (GB)",-18} {"Free %",-10} Status");
                Console.WriteLine(new string('-', 80));
                
                foreach (DriveInfo drive in drives)
                {
                    if (drive.IsReady)
                    {
                        double totalGB = drive.TotalSize / (1024.0 * 1024 * 1024);
                        double freeGB = drive.AvailableFreeSpace / (1024.0 * 1024 * 1024);
                        double freePercent = (drive.AvailableFreeSpace / (double)drive.TotalSize) * 100;
                        
                        string status = freePercent < 15 ? "⚠️ WARNING - Low Space!" : "✓ OK";
                        
                        Console.WriteLine($"{drive.Name,-10} {drive.DriveType,-12} {totalGB,-18:F2} {freeGB,-18:F2} {freePercent,-10:F1} {status}");
                    }
                    else
                    {
                        Console.WriteLine($"{drive.Name,-10} {drive.DriveType,-12} Not Ready");
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