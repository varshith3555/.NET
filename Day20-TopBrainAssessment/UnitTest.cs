using NUnit.Framework;

namespace Day20TopBrainAssessment
{
    [TestFixture]
    public class UnitTest
    {
        private BankAccount bankAccount;

        [SetUp]
        public void Setup()
        {
            bankAccount = new BankAccount(1000m);
        }

        [Test]
        public void Test_Deposit_ValidAmount()
        {
            bankAccount.Deposit(500m);
            Assert.AreEqual(1500m, bankAccount.Balance);
        }

        [Test]
        public void Test_Deposit_NegativeAmount()
        {
            Assert.Throws<System.Exception>(() => bankAccount.Deposit(-100m));
        }

        [Test]
        public void Test_Withdraw_ValidAmount()
        {
            bankAccount.Withdraw(300m);
            Assert.AreEqual(700m, bankAccount.Balance);
        }

        [Test]
        public void Test_Withdraw_InsufficientFunds()
        {
            Assert.Throws<System.Exception>(() => bankAccount.Withdraw(1500m));
        }
    }
}