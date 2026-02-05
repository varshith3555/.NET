using System;
using System.Collections.Generic;
using System.Linq;

namespace BankAccountManagement
{
    public class BankManager
    {
        private List<Account> accounts = new List<Account>();
        private int accountCounter = 10001;
        private int transactionIdCounter = 1;

        public void CreateAccount(string holder, string type, double initialDeposit)
        {
            if (string.IsNullOrWhiteSpace(holder))
                throw new ArgumentException("Account holder name cannot be empty.");

            var account = new Account
            {
                AccountNumber = "ACC" + accountCounter++,
                AccountHolder = holder,
                AccountType = type,
                Balance = initialDeposit
            };

            if (initialDeposit > 0)
            {
                account.TransactionHistory.Add(new Transaction
                {
                    TransactionId = "TXN" + transactionIdCounter++,
                    TransactionDate = DateTime.Now,
                    Type = "Deposit",
                    Amount = initialDeposit,
                    Description = "Initial Deposit"
                });
            }

            accounts.Add(account);
        }

        public bool Deposit(string accountNumber, double amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Deposit amount must be positive.");

            var account = accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
            if (account == null)
                throw new Exception("Account not found.");

            account.Balance += amount;
            account.TransactionHistory.Add(new Transaction
            {
                TransactionId = "TXN" + transactionIdCounter++,
                TransactionDate = DateTime.Now,
                Type = "Deposit",
                Amount = amount,
                Description = "Cash Deposit"
            });

            return true;
        }

        public bool Withdraw(string accountNumber, double amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Withdrawal amount must be positive.");

            var account = accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
            if (account == null)
                throw new Exception("Account not found.");

            if (account.Balance < amount)
                return false;

            account.Balance -= amount;
            account.TransactionHistory.Add(new Transaction
            {
                TransactionId = "TXN" + transactionIdCounter++,
                TransactionDate = DateTime.Now,
                Type = "Withdrawal",
                Amount = amount,
                Description = "Cash Withdrawal"
            });

            return true;
        }

        public Dictionary<string, List<Account>> GroupAccountsByType()
        {
            var grouped = new Dictionary<string, List<Account>>();
            foreach (var account in accounts)
            {
                if (!grouped.ContainsKey(account.AccountType))
                    grouped[account.AccountType] = new List<Account>();
                grouped[account.AccountType].Add(account);
            }
            return grouped;
        }

        public List<Transaction> GetAccountStatement(string accountNumber, DateTime from, DateTime to)
        {
            var account = accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
            if (account == null)
                throw new Exception("Account not found.");

            return account.TransactionHistory
                .Where(t => t.TransactionDate >= from && t.TransactionDate <= to)
                .ToList();
        }
    }
}
