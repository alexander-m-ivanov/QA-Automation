using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace FirstSelemiumTests
{
    [TestFixture]
    public class SoftUni
    {
        public void EnterSoftUni()
        {
        }

        [Test]
        public void LoginSoftUni()
        {
            IWebDriver testInBrowser = new ChromeDriver();
            testInBrowser.Manage().Window.Maximize();
            testInBrowser.Url = "http://www.softuni.bg";
            IWebElement loginButton =
                testInBrowser.FindElement(By.XPath("//*[@id=\"header-nav\"]/div[2]/ul/li[2]/span/a"));
            loginButton.Click();
            IWebElement userName = testInBrowser.FindElement(By.Name("username"));
            userName.Clear();
            userName.SendKeys("xanderbg");
            IWebElement password = testInBrowser.FindElement(By.Name("password"));
            password.Clear();
            password.SendKeys("880101");
            IWebElement enterButton =
                testInBrowser.FindElement(By.XPath("/html/body/div[2]/div[2]/div[2]/div[2]/div[1]/form/input[2]"));
            enterButton.Click();

            WebDriverWait wait = new WebDriverWait
                                 (testInBrowser, TimeSpan.FromSeconds(60));
            IWebElement logo = wait.Until<IWebElement>
            ((w) => {
                return w.FindElement(By.XPath("//*[@id=\"page-header\"]/div[1]/div/div/div[1]/a/img[1]"));
            });


            //IWebElement logo =
            //    testInBrowser.FindElement(By.XPath("//*[@id=\"page-header\"]/div[1]/div/div/div[1]/a/img[1]"));

            Assert.IsTrue(logo.Displayed);
            testInBrowser.Quit();
        }
    }
}
