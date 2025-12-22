using System;
using System.Collections.Generic;
using System.Text;

namespace MyConsoleApp.Day4
{
    public class Account
    {
        public string Name { get; set; }
        public int AccountId { get; set; }

        public string GetAccountDetails()
        {
            return $"I am Base account . My Id is {AccountId}";
        }

    }
    public class SalesAccount : Account
    {
        public string GetSalesAccountDetails()
        {
            string info = string.Empty;
            /// call the parent class methods using base
            info += base.GetAccountDetails();
            info += "I am from Sales Derived class ";
            return info;
        }
        public string SalesInfo { get; set; }
    }

    public class PurchaseAccount : Account
    {
        public string PurchaseInfo { get; set; }
    }
    public class AccountMain
    {
        public static void Main(string[] args)
        {
            Account account = new Account() { AccountId = 1, Name = "Account1" };
            string result = account.GetAccountDetails();
            Console.WriteLine(result);

            SalesAccount salesAccount = new SalesAccount() { AccountId = 1, Name = "Varshith", SalesInfo = "" };
            var result1 = salesAccount.GetSalesAccountDetails();
            Console.WriteLine(result1);


        }
    }
}
