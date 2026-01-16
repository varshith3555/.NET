namespace Day15_Practise_Questons
{
     class InsufficientWalletBalanceException : Exception
    {
        public InsufficientWalletBalanceException(string message) : base(message)
        {
        }
    }

    // EcommerceShop class
    class EcommerceShop
    {
        public string? UserName { get; set; }
        public double WalletBalance { get; set; }
        public double TotalPurchaseAmount { get; set; } 
    }

    class EcommerceShopMain
    {
        // MakePayment method
        public EcommerceShop MakePayment(string name, double balance, double amount)
        {
            if (balance < amount)
            {
                throw new InsufficientWalletBalanceException(
                    "Insufficient balance in your digital wallet"
                );
            }

            EcommerceShop shop = new EcommerceShop();
            shop.UserName = name;
            shop.WalletBalance = balance;
            shop.TotalPurchaseAmount = amount;

            return shop;
        }

        // Main method
        static void Main(string[] args)
        {
            EcommerceShopMain program = new EcommerceShopMain();

            try
            {
                EcommerceShop result = program.MakePayment("Varshith", 3000, 2000);

                if (result != null)
                {
                    Console.WriteLine("Payment successful");
                }
            }
            catch (InsufficientWalletBalanceException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}