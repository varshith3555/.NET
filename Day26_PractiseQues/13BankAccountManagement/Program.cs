using System;

namespace BankAccountManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bank Account Management System");
            var bankManager = new BankManager();

            // Create accounts
            bankManager.CreateAccount("Alice Johnson", "Savings", 5000);
            bankManager.CreateAccount("Bob Smith", "Current", 10000);
            bankManager.CreateAccount("Charlie Brown", "Savings", 7500);
            bankManager.CreateAccount("Diana Prince", "Fixed", 20000);
            bankManager.CreateAccount("Eve Davis", "Current", 3000);

            // Perform transactions
            Console.WriteLine("Performing Transactions:");

            bool dep1 = bankManager.Deposit("ACC10001", 2000);
            Console.WriteLine($"Deposit $2000 to ACC10001: {(dep1 ? "Success" : "Failed")}");

            bool with1 = bankManager.Withdraw("ACC10001", 1500);
            Console.WriteLine($"Withdraw $1500 from ACC10001: {(with1 ? "Success" : "Failed")}");

            bool dep2 = bankManager.Deposit("ACC10002", 5000);
            Console.WriteLine($"Deposit $5000 to ACC10002: {(dep2 ? "Success" : "Failed")}");

            bool with2 = bankManager.Withdraw("ACC10002", 3000);
            Console.WriteLine($"Withdraw $3000 from ACC10002: {(with2 ? "Success" : "Failed")}");

            // Display accounts by type
            Console.WriteLine("\nAccounts by Type:");
            var grouped = bankManager.GroupAccountsByType();
            foreach (var type in grouped)
            {
                Console.WriteLine($"\n{type.Key}:");
                foreach (var account in type.Value)
                {
                    Console.WriteLine($"  - {account.AccountHolder} ({account.AccountNumber}) | Balance: ${account.Balance:F2}");
                }
            }

            // Display account statement
            Console.WriteLine("\nAccount Statement for ACC10001:");
            var statement = bankManager.GetAccountStatement("ACC10001", DateTime.Now.AddDays(-1), DateTime.Now.AddDays(1));
            foreach (var transaction in statement)
            {
                Console.WriteLine($"  {transaction.TransactionDate:yyyy-MM-dd HH:mm} | {transaction.Type} | ${transaction.Amount:F2} | {transaction.Description}");
            }
        }
    }
}
