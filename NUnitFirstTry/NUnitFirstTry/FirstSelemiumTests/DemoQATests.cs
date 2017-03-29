using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace FirstSelemiumTests
{
    [TestFixture]
    class DemoQaTests
    {
        public void RegisterWithValidData()
        {
            IWebDriver demoTesWebDriver = new ChromeDriver();
            demoTesWebDriver.Manage().Window.Maximize();
            demoTesWebDriver.Url = "http://www.demoqa.com/";
            IWebElement regButton = demoTesWebDriver.FindElement(By.Id("menu-item-374"));
            regButton.Click();
            IWebElement regFirstName = demoTesWebDriver.FindElement(By.Id("name_3_firstname"));
            Type(regFirstName, "Ivan");
            IWebElement regLasttName = demoTesWebDriver.FindElement(By.Id("name_3_lastname"));
            Type(regFirstName, "Petrov");
        }

        private void Type(IWebElement element, string text)
        {
            element.Clear();
            element.SendKeys(text);
        }
    }
}
