using NUnit.Framework;
using Day20BankAccount = Day20TopBrainAssessment.BankAccount;

[TestFixture]
public class BankAccountTests
{
    private Day20BankAccount bankAccount;

   [SetUp]
   public void Setup()
   {
    bankAccount = new Day20BankAccount(1000m);
   }

   [Test]
   public void Test_Deposit_ValidAmount()
   {
       decimal depositAmount = 500m;
       decimal expectedBalance = 1500m;

       bankAccount.Deposit(depositAmount);
       Assert.AreEqual(expectedBalance, bankAccount.Balance);
   }

   [Test]
   public void Test_Deposit_NegativeAmount()
   {
       decimal negativeAmount = -100m;
       Assert.Throws<System.InvalidOperationException>(() => bankAccount.Deposit(negativeAmount));
   }

   [Test]
   public void Test_Withdraw_ValidAmount()
   {
       decimal withdrawAmount = 300m;
       decimal expectedBalance = 700m;
       bankAccount.Withdraw(withdrawAmount);
       Assert.AreEqual(expectedBalance, bankAccount.Balance);
    }

   [Test]
   public void Test_Withdraw_InsufficientFunds()
   {
       decimal withdrawAmount = 1500m;
       Assert.Throws<System.InvalidOperationException>(() => bankAccount.Withdraw(withdrawAmount));
   }
}