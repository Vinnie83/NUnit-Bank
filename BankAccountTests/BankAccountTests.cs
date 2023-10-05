using Bank;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;

namespace BankAccountTests
{
    public class BankAccountTests
    {

        private BankAccount bankAccount;

        [SetUp]
        public void Setup()
        {
            this.bankAccount = new BankAccount(1000);
        }

        [Test]

        public void Test_GetAmount_PositiveValue()
        {
            decimal initAmount = 1000;
            decimal expectedAmount = 1000;

            bankAccount = new BankAccount(initAmount);

            var actual = bankAccount.Amount;

            Assert.AreEqual(expectedAmount, actual);

        }

        [Test]

        public void Test_GetAmount_PositiveValueZero()
        {


            decimal initAmount = 0;
            decimal expectedAmount = 0;

            bankAccount = new BankAccount(initAmount);

            var actual = bankAccount.Amount;

            Assert.AreEqual(expectedAmount, actual);

        }

        [Test]

        public void Test_GetAmount_PositiveValueNegative()
        {
            decimal initAmount = -1000;

            string message = "Amount cannot be negative!";


            Assert.That(() => new BankAccount(initAmount),
                Throws.ArgumentException.With.Message.EqualTo(message));

        }

        [Test]

        public void Test_Deposit_PositiveValue()
        {


            decimal initAmount = 1000;
            decimal deposit = 500;
            decimal expectedAmount = 1500;

            bankAccount = new BankAccount(initAmount);

            bankAccount.Deposit(deposit);

            Assert.That(bankAccount.Amount, Is.EqualTo(expectedAmount));

        }

        [Test]

        public void Test_Deposit_NegativeValue()
        {


            decimal initAmount = 1000;
            decimal deposit = -1000;

            string message = "Deposit cannot be negative or zero!";

            Assert.That(() => new BankAccount(initAmount).Deposit(deposit),
                Throws.ArgumentException.With.Message.EqualTo(message));

        }

        [Test]

        public void Test_Deposit_ZeroValue()
        {


            decimal initAmount = 1000;
            decimal deposit = 0;

            string message = "Deposit cannot be negative or zero!";

            Assert.That(() => new BankAccount(initAmount).Deposit(deposit),
                Throws.ArgumentException.With.Message.EqualTo(message));

        }

        [Test]

        public void Test_Withdraw_PositiveValue()
        {


            decimal initAmount = 1000;
            decimal deposit = 500;
            decimal withdraw = 800;
            decimal expectedAmount = 684;

            bankAccount = new BankAccount(initAmount);

            bankAccount.Deposit(deposit);

            bankAccount.Withdraw(withdraw);

            var value = bankAccount.Amount;

           
            Assert.That(value, Is.EqualTo(expectedAmount));

        }

        [Test]

        public void Test_Withdraw_PositiveValueAlt()
        {


            decimal initAmount = 2000;
            decimal deposit = 1000;
            decimal withdraw = 1500;
            decimal expectedAmount = 1425;

            bankAccount = new BankAccount(initAmount);

            bankAccount.Deposit(deposit);

            bankAccount.Withdraw(withdraw);

            var value = bankAccount.Amount;


            Assert.That(value, Is.EqualTo(expectedAmount));

        }

        [Test]

        public void Test_Withdraw_NegativeValue()
        {


            decimal initAmount = 1000;
            decimal deposit = 1000;
            decimal withdraw = - 1000;
            string message = "Withdrawal cannot be negative or zero!";

            bankAccount = new BankAccount(initAmount);

            bankAccount.Deposit(deposit);

            Assert.That(() => bankAccount.Withdraw(withdraw),
                Throws.ArgumentException.With.Message.EqualTo(message));

        }

        [Test]

        public void Test_Withdraw_ZeroValue()
        {


            decimal initAmount = 1000;
            decimal deposit = 1000;
            decimal withdraw = 0;
            string message = "Withdrawal cannot be negative or zero!";

            bankAccount = new BankAccount(initAmount);

            bankAccount.Deposit(deposit);

            Assert.That(() => bankAccount.Withdraw(withdraw),
                Throws.ArgumentException.With.Message.EqualTo(message));

        }

        [Test]

        public void Test_Withdraw_ExceedValue()
        {


            decimal initAmount = 1000;
            decimal deposit = 1000;
            decimal withdraw = 3000;
            string message = "Withdrawal exceeds account balance!";

            bankAccount = new BankAccount(initAmount);

            bankAccount.Deposit(deposit);

            Assert.That(() => bankAccount.Withdraw(withdraw),
                Throws.ArgumentException.With.Message.EqualTo(message));

        }


    }
}