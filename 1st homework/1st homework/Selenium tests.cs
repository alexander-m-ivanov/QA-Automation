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
            
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            string url = driver.Url;
            Assert.IsTrue(url == "http://www.seleniumhq.org/");
            Assert.AreEqual("Selenium - Web Browser Automation", driver.Title);
            driver.Quit();
        }

        [Test]
        public void QaAutomatoinCoursePageOnSoftuniTest()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "http://www.softuni.bg";

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            IWebElement navigateMenu = driver.FindElement(By.XPath("//*[@id=\"header-nav\"]/div[1]/ul/li[2]/a/span"));
            navigateMenu.Click();

            IWebElement clickOnCourse =
                driver.FindElement(
                    By.XPath("//*[@id=\"header-nav\"]/div[1]/ul/li[2]/div/div/div/div[2]/div[2]/ul/li[6]/a"));
            clickOnCourse.Click();

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            IWebElement heading1 =
                driver.FindElement(By.ClassName("page-title"));
            string heading1Text = heading1.Text;

            IWebElement heading2 =
                driver.FindElement(By.ClassName("content-title"));
            string heading2Text = heading1.Text;

            Assert.AreEqual(heading1Text, heading2Text);

            driver.Quit();
        }

        [Test]
        public void DemoQaRegistrationPageTest()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "http://www.demoqa.com";

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            IWebElement registrationButton = driver.FindElement(By.XPath("//*[@id=\"menu-item-374\"]/a"));
            registrationButton.Click();

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            string url = driver.Url;

            Assert.IsTrue(url == "http://demoqa.com/registration/");

            driver.Quit();
        }

        [Test]
        public void DemoQa_1LastNameRequieredValidationTest()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "http://demoqa.com/registration/";

            IWebElement submitRegButton = driver.FindElement(By.XPath("//*[@id=\"pie_register\"]/li[14]/div/input"));
            submitRegButton.Click();

            IWebElement validationMessage =
                driver.FindElement(By.XPath("//*[@id=\"pie_register\"]/li[1]/div[1]/div[2]/span"));
            string validationMessageText = validationMessage.Text;

            Assert.IsTrue(validationMessageText == "* This field is required");

            driver.Quit();
        }

        [Test]
        public void DemoQa_2PhoneNumberDigitsValidationTest()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "http://demoqa.com/registration/";

            IWebElement phoneNumberField = driver.FindElement(By.XPath("//*[@id=\"phone_9\"]"));
            phoneNumberField.SendKeys("123");

            IWebElement submitRegButton = driver.FindElement(By.XPath("//*[@id=\"pie_register\"]/li[14]/div/input"));
            submitRegButton.Click();

            IWebElement validationMessage =
                driver.FindElement(By.XPath("//*[@id=\"pie_register\"]/li[6]/div/div/span"));
            string validationMessageText = validationMessage.Text;

            Assert.IsTrue(validationMessageText == "* Minimum 10 Digits starting with Country Code");

            driver.Quit();
        }

        [Test]
        public void DemoQa_3InvalidMailAddressValidationTest()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "http://demoqa.com/registration/";

            IWebElement mailAddressField = driver.FindElement(By.XPath("//*[@id=\"email_1\"]"));
            mailAddressField.SendKeys("123");

            IWebElement submitRegButton = driver.FindElement(By.XPath("//*[@id=\"pie_register\"]/li[14]/div/input"));
            submitRegButton.Click();

            IWebElement validationMessage =
                driver.FindElement(By.XPath("//*[@id=\"pie_register\"]/li[8]/div/div/span"));
            string validationMessageText = validationMessage.Text;

            Assert.IsTrue(validationMessageText == "* Invalid email address");

            driver.Quit();
        }

        [Test]
        public void DemoQa_4PassNotEnoughSymbolsValidationTest()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "http://demoqa.com/registration/";

            IWebElement passwordField = driver.FindElement(By.Id("password_2"));
            passwordField.SendKeys("123");

            IWebElement clickOnEmptySpace = driver.FindElement(By.Id("pie_register"));
            clickOnEmptySpace.Click();

            IWebElement validationMessage =
                driver.FindElement(By.XPath("//*[@id=\"pie_register\"]/li[11]/div/div/span"));
            string validationMessageText = validationMessage.Text;

            Assert.IsTrue(validationMessageText == "* Minimum 8 characters required");

            driver.Quit();
        }

        [Test]
        public void DemoQa_5PassDoNotMatchValidationTest()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "http://demoqa.com/registration/";

            IWebElement passwordField = driver.FindElement(By.Id("password_2"));
            passwordField.SendKeys("12345678");

            IWebElement passwordConfirmField = driver.FindElement(By.Id("confirm_password_password_2"));
            passwordConfirmField.SendKeys("123456789");

            IWebElement clickOnEmptySpace = driver.FindElement(By.Id("pie_register"));
            clickOnEmptySpace.Click();

            IWebElement validationMessage =
                driver.FindElement(By.XPath("//*[@id=\"pie_register\"]/li[12]/div/div/span"));
            string validationMessageText = validationMessage.Text;

            Assert.IsTrue(validationMessageText == "* Fields do not match");

            driver.Quit();
        }
    }
}
