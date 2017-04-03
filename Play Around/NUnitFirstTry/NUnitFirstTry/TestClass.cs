using ConsoleApplication1;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitFirstTry
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        public void BankAccountEquals()
        {
            BankAcount acc = new BankAcount(3333m);
            Assert.AreEqual(3333, acc.Amount, "Amount must be 3333");
        }

        [Test]
        public void BankAccountDepositCannotBeNegativeValue()
        {
            Assert.Throws(typeof(ArgumentException), NegativeAmountOnAccount);
        }

        //Class to test BankAccountDepositCannotBeNegativeValue
        public void NegativeAmountOnAccount()
        {
            BankAcount acc = new BankAcount(-3333m);
        }

       public void BankAccountWithdraw()
       {
           BankAcount acc = new BankAcount(5000m);
       
           Assert.AreEqual(4895, acc.Withdraw(100), "Amount must be 4895");
       }

        [Test]
        public void BankAccountDoesNotEquals()
        {
            BankAcount acc = new BankAcount(1000m);
            Assert.AreNotEqual(2000, acc.Amount);
        }
    }
}