using System;

namespace BankWithdrawalSystem
{
    // Custom Exception Class
    public class InsufficientBalanceException : Exception
    {
        // Default constructor
        public InsufficientBalanceException() : base()
        {
        }

        // Constructor with message
        public InsufficientBalanceException(string message) : base(message)
        {
        }

        // Constructor with message and inner exception
        public InsufficientBalanceException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }
    }

    // Bank Account Class
    class BankAccount
    {
        private double balance;
        private string accountNumber;

        public BankAccount(string accountNumber, double initialBalance)
        {
            this.accountNumber = accountNumber;
            this.balance = initialBalance;
            Console.WriteLine($"Account Created: {accountNumber}");
            Console.WriteLine($"Initial Balance: ${balance}");
        }

        public double Balance
        {
            get { return balance; }
        }

        // Withdraw method with custom exception
        public void Withdraw(double amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Withdrawal amount must be greater than zero!");
            }

            if (amount > balance)
            {
                throw new InsufficientBalanceException(
                    $"Withdrawal amount (${amount}) exceeds available balance (${balance})");
            }

            balance -= amount;
            Console.WriteLine($"\nSuccessfully withdrew: ${amount}");
            Console.WriteLine($"Remaining Balance: ${balance}");
        }

        public void Deposit(double amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Deposit amount must be greater than zero!");
            }
            
            balance += amount;
            Console.WriteLine($"\nSuccessfully deposited: ${amount}");
            Console.WriteLine($"New Balance: ${balance}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Bank Withdrawal System with Custom Exception ===\n");

            // Create bank account
            BankAccount account = new BankAccount("ACC123456", 3000);
            
            Console.WriteLine("\n" + new string('-', 50) + "\n");

            while (true)
            {
                Console.WriteLine("\n--- Menu ---");
                Console.WriteLine("1. Check Balance");
                Console.WriteLine("2. Deposit Money");
                Console.WriteLine("3. Withdraw Money");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine($"\nCurrent Balance: ${account.Balance}");
                        break;

                    case "2":
                        Console.Write("\nEnter amount to deposit: ");
                        if (double.TryParse(Console.ReadLine(), out double depositAmount))
                        {
                            try
                            {
                                account.Deposit(depositAmount);
                            }
                            catch (ArgumentException ex)
                            {
                                Console.WriteLine($"\nError: {ex.Message}");
                            }
                            finally
                            {
                                Console.WriteLine("Deposit operation completed");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid amount!");
                        }
                        break;

                    case "3":
                        Console.Write("\nEnter amount to withdraw: ");
                        if (double.TryParse(Console.ReadLine(), out double withdrawAmount))
                        {
                            try
                            {
                                account.Withdraw(withdrawAmount);
                            }
                            catch (InsufficientBalanceException ex)
                            {
                                Console.WriteLine($"\nError: {ex.Message}");
                            }
                            catch (ArgumentException ex)
                            {
                                Console.WriteLine($"\nError: {ex.Message}");
                            }
                            finally
                            {
                                Console.WriteLine("Withdrawal operation completed");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid amount!");
                        }
                        break;

                    case "4":
                        Console.WriteLine("\nThank you for using our banking system!");
                        Console.WriteLine("Final Balance: $" + account.Balance);
                        return;

                    default:
                        Console.WriteLine("Invalid choice! Please try again.");
                        break;
                }
            }
        }
    }
}