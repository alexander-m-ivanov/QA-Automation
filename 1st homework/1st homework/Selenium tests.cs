using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions.Internal;
using System.Linq.Expressions;
using System.Linq;

namespace _1st_homework
{
    [TestFixture]
    public class SoftUni
    {

        [Test]
        public void GoogleSearch()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://www.google.bg";

            IWebElement googleSearchBar = driver.FindElement(By.Id("lst-ib"));
            googleSearchBar.SendKeys("Selenium");
            googleSearchBar.SendKeys(Keys.Enter);

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            List<IWebElement> seleniumLink = driver.FindElements(By.XPath("//h3/a")).ToList();
            seleniumLink[0].Click();
            string elementHtml = seleniumLink[0].Text;
            



            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            string url = driver.Url;
            Assert.IsTrue(url == "http://www.seleniumhq.org/");

            driver.Quit();
        }
    }
}
