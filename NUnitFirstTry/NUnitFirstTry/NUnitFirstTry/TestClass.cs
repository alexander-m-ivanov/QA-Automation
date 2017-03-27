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
        public void BankAccountDepositWithPositiveValue()
        {
            BankAcount acc = new BankAcount(3333m);
            Assert.AreEqual(2222, acc.Amount, "Amount must be 3333");
        }
    }
}