using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using _2nd_Homework___Design_Patterns.Models;
using _2nd_Homework___Design_Patterns.Pages.HomePage;
using _2nd_Homework___Design_Patterns.Pages.RegistrationPage;
using System.Collections.Generic;
using System.Linq;

namespace _2nd_Homework___Design_Patterns
{
    [TestFixture]
    public class TestClass
    {
        public IWebDriver driver;

        [SetUp]
        public void Init()
        {
            this.driver = new ChromeDriver();
        }

        [TearDown]
        public void CleanUp()
        {
            this.driver.Quit();
        }

        [Test]
        public void DemoQa_1LastNameRequieredValidationTest()
        {
            var regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("",
                                                         "",
                                                         new List<bool>(new bool[] { true, false, false }),
                                                         new List<bool>(new bool[] { true, true, true }),
                                                         "Bulgaria",
                                                         "3",
                                                         "1",
                                                         "1989",
                                                         "8888888888",
                                                         "Buro",
                                                         "burkata@abv.bg",
                                                         @"C:\Users\Buro\Desktop\Seminar\Pics\enviroment.jpg",
                                                         "OPSA",
                                                         "12345678",
                                                         "12345678");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssesrtNoNameValidationMessage("*This field is required");
        }

        [Test]
        public void DemoQa_2PhoneNumberDigitsValidationTest()
        {
            var regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("Ivan",
                                                         "Petrov",
                                                         new List<bool>(new bool[] { true, false, false }),
                                                         new List<bool>(new bool[] { true, true, true }),
                                                         "Bulgaria",
                                                         "3",
                                                         "1",
                                                         "1989",
                                                         "123",
                                                         "Buro",
                                                         "burkata@abv.bg",
                                                         @"C:\Users\Buro\Desktop\Seminar\Pics\enviroment.jpg",
                                                         "OPSA",
                                                         "12345678",
                                                         "12345678");
        
            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);
        
            regPage.AssertMinimumPhoneDigitsValidationMessage("* Minimum 10 Digits starting with Country Code");
        }
        
        [Test]
        public void DemoQa_3InvalidMailAddressValidationTest()
        {
            var regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("Ventsislav",
                                                         "Ivanov",
                                                         new List<bool>(new bool[] { true, false, false }),
                                                         new List<bool>(new bool[] { true, true, true }),
                                                         "Bulgaria",
                                                         "3",
                                                         "1",
                                                         "1989",
                                                         "1234567890",
                                                         "Buro",
                                                         "123",
                                                         @"C:\Users\Buro\Desktop\Seminar\Pics\enviroment.jpg",
                                                         "OPSA",
                                                         "12345678",
                                                         "12345678");
        
            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);
        
            regPage.AssertInvalidMailAddressValidationTest("* Invalid email address");
        }

        [Test]
        public void DemoQa_4PassNotEnoughSymbolsValidationTest()
        {
            var regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("Ventsislav",
                                                         "Ivanov",
                                                         new List<bool>(new bool[] { true, false, false }),
                                                         new List<bool>(new bool[] { true, true, true }),
                                                         "Bulgaria",
                                                         "3",
                                                         "1",
                                                         "1989",
                                                         "1234567890",
                                                         "Buro",
                                                         "abv@abv.bg",
                                                         @"C:\Users\Buro\Desktop\Seminar\Pics\enviroment.jpg",
                                                         "OPSA",
                                                         "123",
                                                         "12345678");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertIPassNotEnoughSymbolsValidationMessage("* Minimum 8 characters required");
        }
    }
}
