using System.Text.RegularExpressions;

public class InsufficientBalanceException : Exception
{
    public InsufficientBalanceException(string message) : base(message)
    {
        
    }
}
public class MinimumBalanceException : Exception
{
    public MinimumBalanceException(string message) : base(message)
    {
        
    }
}
public class InvalidTransactionException : Exception
{
    public InvalidTransactionException(string message) : base(message)
    {
        
    }
}
public abstract class BankAccount
{
    public int AccountNumber { get; set; }
    public string CustomerName { get; set; }
    public decimal Balance { get; set; }
    public List<string> TransactionHistory { get; set; }

    public BankAccount()
    {
        TransactionHistory = new List<string>();
    }

    public virtual void Deposit(double amount)
    {
        if (amount <= 0)
        {
            throw new InsufficientBalanceException("Amount must be greater than 0");
        }
        Balance += (decimal)amount;
        TransactionHistory.Add($"Deposited: {amount} on {DateTime.Now}. Balance: {Balance}");
    }

    public virtual void Withdraw(double amount)
    {
        if (amount <= 0)
        {
            throw new InvalidTransactionException("Withdrawal amount must be greater than 0");
        }
    }

    public abstract void CalculateInterest();

    public virtual void DisplayTransactionHistory()
    {
        Console.WriteLine($"\n--- Transaction History for {CustomerName} (Account: {AccountNumber}) ---");
        foreach (var transaction in TransactionHistory)
        {
            Console.WriteLine(transaction);
        }
    }
}

class SavingsAccount : BankAccount
{
    private const decimal MINIMUM_BALANCE = 1000;
    private const decimal INTEREST_RATE = 0.04m; 
    public override void Withdraw(double amount)
    {
        base.Withdraw(amount);
        if (amount <= 0)
        {
            throw new InvalidTransactionException("Withdrawal amount must be greater than 0");
        }
        if (Balance - (decimal)amount < MINIMUM_BALANCE)
        {
            throw new MinimumBalanceException($"Cannot withdraw. Minimum balance of {MINIMUM_BALANCE} must be maintained.");
        }
        if (Balance < (decimal)amount)
        {
            throw new InsufficientBalanceException("Insufficient balance for withdrawal");
        }
        Balance -= (decimal)amount;
        TransactionHistory.Add($"Withdrawn: {amount} on {DateTime.Now}. Balance: {Balance}");
    }

    public override void CalculateInterest()
    {
        decimal interest = Balance * INTEREST_RATE;
        Balance += interest;
        Console.WriteLine($"Interest calculated for {CustomerName}: {interest}. New Balance: {Balance}");
        TransactionHistory.Add($"Interest added: {interest} on {DateTime.Now}. Balance: {Balance}");
    }
}

class CurrentAccount : BankAccount
{
    private const decimal OVERDRAFT_LIMIT = 10000;
    private const decimal INTEREST_RATE = 0.02m;

    public override void Withdraw(double amount)
    {
        base.Withdraw(amount);
        if (amount <= 0)
        {
            throw new InvalidTransactionException("Withdrawal amount must be greater than 0");
        }
        if (Balance - (decimal)amount < -OVERDRAFT_LIMIT)
        {
            throw new InsufficientBalanceException($"Cannot withdraw. Overdraft limit of {OVERDRAFT_LIMIT} exceeded");
        }
        Balance -= (decimal)amount;
        TransactionHistory.Add($"Withdrawn: {amount} on {DateTime.Now}. Balance: {Balance}");
    }

    public override void CalculateInterest()
    {
        decimal interest = Balance * INTEREST_RATE;
        Balance += interest;
        Console.WriteLine($"Interest calculated for {CustomerName}: {interest}. New Balance: {Balance}");
        TransactionHistory.Add($"Interest added: {interest} on {DateTime.Now}. Balance: {Balance}");
    }
}

class LoanAccount : BankAccount
{
    private const decimal INTEREST_RATE = 0.08m; 
    private decimal LoanAmount { get; set; }

    public LoanAccount(decimal loanAmount)
    {
        LoanAmount = loanAmount;
        Balance = loanAmount;
    }

    public override void Deposit(double amount)
    {
        throw new InvalidTransactionException("Cannot deposit in Loan Account. Use Withdraw to pay loan.");
    }

    public override void Withdraw(double amount)
    {
        base.Withdraw(amount);
        if (amount <= 0)
        {
            throw new InvalidTransactionException("Payment amount must be greater than 0");
        }
        Balance -= (decimal)amount;
        TransactionHistory.Add($"Loan payment: {amount} on {DateTime.Now}. Remaining loan: {Balance}");
    }

    public override void CalculateInterest()
    {
        decimal interest = Balance * INTEREST_RATE;
        Balance += interest;
        Console.WriteLine($"Interest calculated for {CustomerName}: {interest}. Total loan: {Balance}");
        TransactionHistory.Add($"Interest added: {interest} on {DateTime.Now}. Total loan: {Balance}");
    }
}

class Program
{
    static List<BankAccount> accounts = new List<BankAccount>();
    static void Main()
    {
        int choice;
        do
        {
            DisplayMenu();
            choice = GetChoice();

            switch (choice)
            {
                case 1:
                    CreateAccount();
                    break;
                case 2:
                    DepositAmount();
                    break;
                case 3:
                    WithdrawAmount();
                    break;
                case 4:
                    CalculateInterestForAll();
                    break;
                case 5:
                    TransferMoney();
                    break;
                case 6:
                    DisplayTransactionHist();
                    break;
                case 7:
                    RunLINQQueries();
                    break;
                case 8:
                    DisplayAllAccounts();
                    break;
                case 0:
                    Console.WriteLine("Thank you for using Smart Banking System!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        } while (choice != 0);
    }

    static void DisplayMenu()
    {
        Console.WriteLine("1. Create Account");
        Console.WriteLine("2. Deposit Amount");
        Console.WriteLine("3. Withdraw Amount");
        Console.WriteLine("4. Calculate Interest");
        Console.WriteLine("5. Transfer Money");
        Console.WriteLine("6. Display Transaction History");
        Console.WriteLine("7. Run LINQ Queries");
        Console.WriteLine("8. Display All Accounts");
        Console.WriteLine("0. Exit");
    }

    static int GetChoice()
    {
        Console.Write("Enter your choice: ");
        if (int.TryParse(Console.ReadLine(), out int choice))
            return choice;
        return -1;
    }

    static void CreateAccount()
    {
        Console.WriteLine("\nCreate New Account");
        Console.Write("Enter Account Number: ");
        int accountNumber = int.Parse(Console.ReadLine());

        Console.Write("Enter Customer Name: ");
        string customerName = Console.ReadLine();

        Console.WriteLine("Select Account Type:");
        Console.WriteLine("1. Savings Account");
        Console.WriteLine("2. Current Account");
        Console.WriteLine("3. Loan Account");
        Console.Write("Enter choice: ");
        int accountType = int.Parse(Console.ReadLine());

        BankAccount account = null;

        try
        {
            switch (accountType)
            {
                case 1:
                    Console.Write("Enter initial balance: ");
                    decimal savingsBalance = decimal.Parse(Console.ReadLine());
                    account = new SavingsAccount { AccountNumber = accountNumber, CustomerName = customerName, Balance = savingsBalance };
                    account.TransactionHistory.Add($"Account created on {DateTime.Now}. Initial Balance: {savingsBalance}");
                    break;
                case 2:
                    Console.Write("Enter initial balance: ");
                    decimal currentBalance = decimal.Parse(Console.ReadLine());
                    account = new CurrentAccount { AccountNumber = accountNumber, CustomerName = customerName, Balance = currentBalance };
                    account.TransactionHistory.Add($"Account created on {DateTime.Now}. Initial Balance: {currentBalance}");
                    break;
                case 3:
                    Console.Write("Enter loan amount: ");
                    decimal loanAmount = decimal.Parse(Console.ReadLine());
                    account = new LoanAccount(loanAmount) { AccountNumber = accountNumber, CustomerName = customerName };
                    account.TransactionHistory.Add($"Loan account created on {DateTime.Now}. Loan Amount: {loanAmount}");
                    break;
                default:
                    Console.WriteLine("Invalid account type!");
                    return;
            }
            accounts.Add(account);
            Console.WriteLine($"Account created successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void DepositAmount()
    {
        Console.WriteLine("\n Deposit Amount");
        BankAccount account = FindAccount();
        if (account == null) return;

        try
        {
            Console.Write("Enter amount to deposit: ");
            double amount = double.Parse(Console.ReadLine());
            account.Deposit(amount);
            Console.WriteLine($"Successfully deposited {amount}. New Balance: {account.Balance}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void WithdrawAmount()
    {
        Console.WriteLine("\n Withdraw Amount");
        BankAccount account = FindAccount();
        if (account == null) return;

        try
        {
            Console.Write("Enter amount to withdraw: ");
            double amount = double.Parse(Console.ReadLine());
            account.Withdraw(amount);
            Console.WriteLine($"Successfully withdrawn {amount}. New Balance: {account.Balance}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void CalculateInterestForAll()
    {
        Console.WriteLine("\n Calculate Interest");
        if (accounts.Count == 0)
        {
            Console.WriteLine("No accounts available!");
            return;
        }
        foreach (var account in accounts)
        {
            account.CalculateInterest();
        }
    }

    static void TransferMoney()
    {
        Console.WriteLine("\n Transfer Money");
        Console.Write("Enter Source Account Number: ");
        int sourceAccountNumber = int.Parse(Console.ReadLine());
        BankAccount sourceAccount = accounts.FirstOrDefault(a => a.AccountNumber == sourceAccountNumber);

        if (sourceAccount == null)
        {
            Console.WriteLine("Source account not found!");
            return;
        }

        Console.Write("Enter Destination Account Number: ");
        int destAccountNumber = int.Parse(Console.ReadLine());
        BankAccount destAccount = accounts.FirstOrDefault(a => a.AccountNumber == destAccountNumber);

        if (destAccount == null)
        {
            Console.WriteLine("Destination account not found!");
            return;
        }

        try
        {
            Console.Write("Enter transfer amount: ");
            double amount = double.Parse(Console.ReadLine());

            if (sourceAccount is LoanAccount)
            {
                throw new InvalidTransactionException("Cannot transfer from Loan Account");
            }
            sourceAccount.Withdraw(amount);
            destAccount.Deposit(amount);
            Console.WriteLine($"Successfully transferred {amount} from {sourceAccount.CustomerName} to {destAccount.CustomerName}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void DisplayTransactionHist()
    {
        Console.WriteLine("\n Display Transaction History");
        BankAccount account = FindAccount();
        if (account == null) return;
        account.DisplayTransactionHistory();
    }

    static void RunLINQQueries()
    {
        if (accounts.Count == 0)
        {
            Console.WriteLine("No accounts available!");
            return;
        }

        Console.WriteLine("\n LINQ Queries");
        Console.WriteLine("\n1. Accounts with balance > 50,000:");
        var highBalanceAccounts = accounts.Where(a => a.Balance > 50000).ToList();
        if (highBalanceAccounts.Count == 0)
            Console.WriteLine("   No accounts found");
        else
            foreach (var acc in highBalanceAccounts)
                Console.WriteLine($"   {acc.CustomerName} ({acc.GetType().Name}) - Balance: {acc.Balance}");

        // Query 2: Total bank balance
        Console.WriteLine("\n2. Total Bank Balance:");
        decimal totalBalance = accounts.Sum(a => a.Balance);
        Console.WriteLine($"   Total Balance: {totalBalance}");

        // Query 3: Top 3 highest balance accounts
        Console.WriteLine("\n3. Top 3 Highest Balance Accounts:");
        var topAccounts = accounts.OrderByDescending(a => a.Balance).Take(3).ToList();
        if (topAccounts.Count == 0)
            Console.WriteLine("   No accounts found");
        else
            foreach (var acc in topAccounts)
                Console.WriteLine($"   {acc.CustomerName} - Balance: {acc.Balance}");

        // Query 4: Group accounts by account type
        Console.WriteLine("\n4. Accounts Grouped by Type:");
        var groupedAccounts = accounts.GroupBy(a => a.GetType().Name).ToList();
        foreach (var group in groupedAccounts)
        {
            Console.WriteLine($"   {group.Key}: {group.Count()} account(s)");
            foreach (var acc in group)
                Console.WriteLine($"      - {acc.CustomerName}");
        }

        // Query 5: Customers whose name starts with 'R'
        Console.WriteLine("\n5. Customers whose name starts with 'R':");
        var rCustomers = accounts.Where(a => a.CustomerName.StartsWith("R")).ToList();
        if (rCustomers.Count == 0)
            Console.WriteLine("   No customers found");
        else
            foreach (var acc in rCustomers)
                Console.WriteLine($"   {acc.CustomerName} - Balance: {acc.Balance}");
    }

    static void DisplayAllAccounts()
    {
        Console.WriteLine("\n All Accounts");
        if (accounts.Count == 0)
        {
            Console.WriteLine("No accounts available!");
            return;
        }

        foreach (var account in accounts)
        {
            Console.WriteLine($"\nAccount Number: {account.AccountNumber}");
            Console.WriteLine($"Customer Name: {account.CustomerName}");
            Console.WriteLine($"Account Type: {account.GetType().Name}");
            Console.WriteLine($"Balance: {account.Balance}");
        }
    }

    static BankAccount FindAccount()
    {
        Console.Write("Enter Account Number: ");
        if (int.TryParse(Console.ReadLine(), out int accountNumber))
        {
            BankAccount account = accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
            if (account == null)
                Console.WriteLine("Account not found!");
            return account;
        }
        Console.WriteLine("Invalid account number!");
        return null;
    }
}


