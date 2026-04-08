using System;

namespace Singleton_ConfigurationManager
{
    public class ConfigurationManager
    {
        private static ConfigurationManager instance = null;
        private static readonly object lockObject = new object();

        // Configuration properties
        public string ApplicationName { get; private set; }
        public string Version { get; private set; }
        public string DatabaseConnectionString { get; private set; }

        // Private constructor
        private ConfigurationManager()
        {
            // Load configuration values
            ApplicationName = "Inventory Management System";
            Version = "2.0.1";
            DatabaseConnectionString = "Server=localhost;Database=InventoryDB;User Id=sa;Password=secure123";
        }

        // Thread-safe GetInstance method
        public static ConfigurationManager GetInstance()
        {
            if (instance == null)
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new ConfigurationManager();
                    }
                }
            }
            return instance;
        }

        public void DisplayConfiguration()
        {
            Console.WriteLine($"Application Name: {ApplicationName}");
            Console.WriteLine($"Version: {Version}");
            Console.WriteLine($"Connection String: {DatabaseConnectionString}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Configuration Manager (Singleton Pattern) ===\n");

            // Get first instance
            ConfigurationManager config1 = ConfigurationManager.GetInstance();
            Console.WriteLine("First Instance:");
            config1.DisplayConfiguration();

            Console.WriteLine("\n--- Getting second instance ---");
            
            // Get second instance
            ConfigurationManager config2 = ConfigurationManager.GetInstance();
            Console.WriteLine("Second Instance:");
            config2.DisplayConfiguration();

            // Verify both references point to same object
            Console.WriteLine($"\nAre both instances same? {ReferenceEquals(config1, config2)}");

            Console.ReadLine();
        }
    }
}