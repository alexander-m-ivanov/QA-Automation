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
            Type(regLasttName, "Petrov");
            IWebElement maritalStatus = demoTesWebDriver.FindElement(By.XPath("//*[@id=\"pie_register\"]/li[2]/div/div/input[1]"));
            maritalStatus.Click();
            List<IWebElement> hobbys = demoTesWebDriver.FindElements(By.Name("checkbox_5[]")).ToList();
            hobbys[0].Click();
            hobbys[1].Click();

            selectOption(demoTesWebDriver, "dropdown_7", "Bulgaria");
            //тестване на drop-down лист
            //IWebElement country = demoTesWebDriver.FindElement(By.Id("dropdown_7"));
            //SelectElement countryOption = new SelectElement(country);
            //countryOption.SelectByText("Bulgaria");
            selectOption(demoTesWebDriver, "mm_date_8", "3");
            selectOption(demoTesWebDriver, "dd_date_8", "3");
            selectOption(demoTesWebDriver, "yy_date_8", "1989");


            IWebElement telephone = demoTesWebDriver.FindElement(By.Id("phone_9"));
            Type(telephone, "1234567890");

            IWebElement usernameRegBox = demoTesWebDriver.FindElement(By.Id("username"));
            Type(usernameRegBox, "pinko1");

            IWebElement mailReg = demoTesWebDriver.FindElement(By.Id("email_1"));
            Type(mailReg, "guz1@guz.tv");

            IWebElement profilePic = demoTesWebDriver.FindElement(By.Id("profile_pic_10"));
            profilePic.Click();
            demoTesWebDriver.SwitchTo().ActiveElement().SendKeys(@"C:\Users\ASUS\Desktop\1\123.jpg");

            IWebElement passwordReg = demoTesWebDriver.FindElement(By.Id("password_2"));
            Type(passwordReg, "123456789");

            IWebElement confirmPassword = demoTesWebDriver.FindElement(By.Id("confirm_password_password_2"));
            Type(confirmPassword, "123456789");

            IWebElement submitReg = demoTesWebDriver.FindElement(By.Name("pie_submit"));
            submitReg.Click();
            //йъгх

            IWebElement regSuccessful = demoTesWebDriver.FindElement(By.XPath("//*[@id=\"post-49\"]/div/p"));

            Assert.AreEqual("Thank you for your registration", regSuccessful.Text);

            demoTesWebDriver.Quit();
        }

        //тестване на drop-down лист
        private void selectOption(IWebDriver dropDownDriver, string selector, string text)
        {
            IWebElement dropDown = dropDownDriver.FindElement(By.Id(selector));
            SelectElement countryOption = new SelectElement(dropDown);
            countryOption.SelectByText(text);
        }

        private void Type(IWebElement element, string text)
        {
            element.Clear();
            element.SendKeys(text);
        }
    }
}
