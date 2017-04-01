using BankAccount;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1st_homework
{
    [TestFixture]
    public class BankAccountTests
    {
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

        //public void BankAccountWithdraw()
        //{
        //    BankAcount acc = new BankAcount(5000m);
        //
        //    Assert.AreEqual(4895, acc.Withdraw(100m), "Amount must be 4895");
        //}

        [Test]
        public void _1BankAccounTest1()
        {
            BankAcount acc = new BankAcount(1000m);
            Assert.AreNotEqual(2000, acc.Amount);
        }

        [Test]
        public void _2BankAccounTest2()
        {
            Assert.DoesNotThrow(NotANegativeValue);
        }

        //Class to test _2BankAccounTest2
        public void NotANegativeValue()
        {
            BankAcount acc = new BankAcount(3333m);
        }

        [Test]
        public void _3BankAccounTest3()
        {
            BankAcount account = new BankAcount(1000m);
            BankAcount deposit = new BankAcount(2000m);
            Assert.Greater(deposit.Amount, account.Amount);
        }

        [Test]
        public void _4BankAccounTest4()
        {
            BankAcount account = new BankAcount(1000m);
            BankAcount deposit = new BankAcount(2000m);
            Assert.GreaterOrEqual(deposit.Amount, account.Amount);
        }

        [Test]
        public void _5BankAccounTest5()
        {
            BankAcount acc = new BankAcount(3000m);
            Assert.IsFalse(acc.Amount < 2000);
        }
    }
}