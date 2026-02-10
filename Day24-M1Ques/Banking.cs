namespace M1Ques
{
    class BankAccount
    {
        private double balance;

        public void Deposit(double amount)
        {
            if(amount > 0)
            {
                balance += amount;
            }
        }
        public void Withdraw(double amount)
        {
            if(amount > 0 && amount <= balance)
            {
                balance -= amount;
            }
        }
        public double GetBanalce()
        {
            return balance;
        }
    }
    class Banking
    {
        public static void Main()
        {
            BankAccount b1 = new BankAccount();
            b1.Deposit(1000);
            b1.Deposit(7000);
            b1.Deposit(3000);
            b1.Withdraw(500);
            b1.Withdraw(1000);
            System.Console.WriteLine(b1.GetBanalce());
        }
    }
}