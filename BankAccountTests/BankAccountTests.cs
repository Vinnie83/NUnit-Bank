using Bank;

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

        public void Test_Amount_Validinput()
        {
               
            var initAmount = new decimal (1000);
            var expectedAmount = new decimal(1000);
            bankAccount = new BankAccount(initAmount);

            var actual = bankAccount.Amount;

            Assert.AreEqual(expectedAmount, actual);

        }

      
    }
}