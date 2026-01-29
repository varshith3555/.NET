using System;
using System.Collections.Generic;
using System.Text;

namespace MyConsoleApp.Day16_Practise.PettyCashManager
{
    public abstract class Transcation
    {
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string? Narration { get; set; }
        public string? Status { get; set; }

        public Transcation(decimal amount, DateTime date, string? narration)
        {
            if(amount <= 0)
            {
                throw new ArgumentException("Amount should not be negative");
            }
            this.Amount = amount;
            this.Date = date;
            this.Narration = narration;
            Status = "Pending";
        }
        public abstract void Approve();
    }

    public class ExpenseTransaction : Transcation
    {
        public string Category { get; set; }
        public string Voucher { get; set; }

        public ExpenseTransaction(string category, string voucher, decimal amount, DateTime date, string narration) : base(amount, date, narration)
        {
            if(string.IsNullOrEmpty(voucher))
            {
                throw new ArithmeticException("Voucher number is mandatory");
            }
              Category = category;
              Voucher = voucher;
        }

        public override void Approve()
        {
            Status = "Approved";
        }
    }

    public class ReimbursementTransaction : Transcation
    {
        public ReimbursementTransaction(decimal amount, string narration, DateTime date) : base(amount, date, narration)
        {
            Status = "Approved";
        }

        public override void Approve()
        {
            Status = "Approved";
        }
    }


}
