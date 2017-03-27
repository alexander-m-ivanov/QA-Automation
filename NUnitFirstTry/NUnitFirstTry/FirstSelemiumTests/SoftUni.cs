using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace FirstSelemiumTests
{
    [TestFixture]
    public class SoftUni
    {
        [Test]
        public void EnterSoftUni()
        {
            IWebDriver initChrom = new ChromeDriver();

            initChrom.Url = "http://www.softuni.bg";

            initChrom.Quit();
        }
    }
}
