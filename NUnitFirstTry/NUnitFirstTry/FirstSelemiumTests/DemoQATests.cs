using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace FirstSelemiumTests
{
    [TestFixture]
    class DemoQaTests
    {
        [Test]
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
            IWebElement maritalStatus = demoTesWebDriver.FindElement(By.XPath("//*[@id=\"pie_register\"]/li[2]/div/div/input[1]"));
            maritalStatus.Click();
            List<IWebElement> hobbys = demoTesWebDriver.FindElements(By.Name("checkbox_5[]")).ToList();
            hobbys[0].Click();
            hobbys[1].Click();

            //тестване на drop-down лист
            IWebElement country = demoTesWebDriver.FindElement(By.Id("dropdown_7"));
            SelectElement countryOption = new SelectElement(country);
            countryOption.SelectByText("Bulgaria");

            demoTesWebDriver.Quit();
        }

        private void Type(IWebElement element, string text)
        {
            element.Clear();
            element.SendKeys(text);
        }
    }
}
