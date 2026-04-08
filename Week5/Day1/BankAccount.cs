using System;

namespace BankAccountManagement
{
    class BankAccount
    {
        // Private fields
        private string accountNumber;
        private decimal balance;

        // Public properties with controlled access
        public string AccountNumber
        {
            get { return accountNumber; }
            set { accountNumber = value; }
        }

        public decimal Balance
        {
            get { return balance; }
            private set { balance = value; }
        }

        // Constructor
        public BankAccount(string accountNumber, decimal initialBalance = 0)
        {
            this.accountNumber = accountNumber;
            this.balance = initialBalance;
        }

        // Deposit method with validation
        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Error: Deposit amount must be greater than zero.");
                return;
            }
            
            balance += amount;
            Console.WriteLine($"Successfully deposited: ${amount}");
            DisplayBalance();
        }

        // Withdraw method with validation
        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Error: Withdrawal amount must be greater than zero.");
                return;
            }
            
            if (amount > balance)
            {
                Console.WriteLine("Error: Insufficient balance!");
                return;
            }
            
            balance -= amount;
            Console.WriteLine($"Successfully withdrew: ${amount}");
            DisplayBalance();
        }

        // Display current balance
        private void DisplayBalance()
        {
            Console.WriteLine($"Current Balance = ${balance}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Bank Account Management System ===\n");
            
            // Create a bank account
            BankAccount account = new BankAccount("ACC12345", 0);
            Console.WriteLine($"Account Number: {account.AccountNumber}");
            
            // Deposit money
            Console.WriteLine("\nDepositing $5000...");
            account.Deposit(5000);
            
            // Withdraw money
            Console.WriteLine("\nWithdrawing $2000...");
            account.Withdraw(2000);
            
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}