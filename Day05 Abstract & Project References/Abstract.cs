using System;
using System.Collections.Generic;
using System.Text;

namespace MyConsoleApp.Day5_Abstract___Project_References
{
    abstract class Payment
    {
        // read the payment that stores
        public decimal Amount { get; }
        // protected constructor called by only child classes
        protected Payment(decimal amount) => Amount = amount;
        // 
        public void PrintReceipt()
        {
            Console.WriteLine($"Receipt: Amount={Amount}");
        }
        // abstract method & child must implement this method
        public abstract void Pay();
    }


    class UpiPayment : Payment
    {
        // read-only property to store the UPI ID.
        public string UpiId { get; }
        // Calls the base class constructor to set Amount
        public UpiPayment(decimal amount, string upiId) : base(amount)
        {
            UpiId = upiId;
        }

        // overrides the Pay method from parent and print the Amount with UpiId
        public override void Pay()
        {
            Console.WriteLine($"Paid {Amount} via UPI ({UpiId}).");
        }
    }
    public class AbstractMain
    {
        public static void Main()
        {
            Payment payment = new UpiPayment(1000, "2239399993");
            payment.Pay();
            payment.PrintReceipt();
        }
    }
}
