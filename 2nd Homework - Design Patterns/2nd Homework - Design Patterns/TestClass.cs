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

//In order to debug a test class you have to put the breakpoint where you want and then on the test class click with the right button of the mouse and select debug tests!

namespace _2nd_Homework___Design_Patterns
{
    [TestFixture]
    public class TestClass
    {
        string requiredField = "*This field is required";
        private string digits10InPhoneMessage = "* Minimum 10 Digits starting with Country Code";

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
        public void _01_NamesRequieredValidationTest()
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
                                                         @"C:\Users\aivanov\Pictures\Test.jpg",
                                                         "OPSA",
                                                         "12345678",
                                                         "12345678");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssesrtNoNameValidationMessage(requiredField);
        }

        [Test]
        public void _02_10NumberOfDigitsInPhoneValidationTest()
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
                                                         @"C:\Users\aivanov\Pictures\Test.jpg",
                                                         "OPSA",
                                                         "12345678",
                                                         "12345678");
        
            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);
        
            regPage.AssertMinimumPhoneDigitsValidationMessage(digits10InPhoneMessage);
        }
        
        [Test]
        public void _03_InvalidMailAddressValidationTest()
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
                                                         @"C:\Users\aivanov\Pictures\Test.jpg",
                                                         "OPSA",
                                                         "12345678",
                                                         "12345678");
        
            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);
        
            regPage.AssertInvalidMailAddressValidationTest(requiredField);
        }

        [Test]
        public void _04_PassNotEnoughSymbolsValidationTest()
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
                                                         @"C:\Users\aivanov\Pictures\Test.jpg",
                                                         "OPSA",
                                                         "123",
                                                         "12345678");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertPassNotEnoughSymbolsValidationMessage("* Minimum 8 characters required");
        }

        [Test]
        public void _05_PassDoNotMatchValidationTest()
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
                                                         @"C:\Users\aivanov\Pictures\Test.jpg",
                                                         "OPSA",
                                                         "123456789",
                                                         "12345678");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertPassDoNotMatchValidationMessage("* Fields do not match");
        }

        [Test]
        //bug in website - the error message appears only when both names are missing!
        public void _06_FirstNamesRequiredValidationTest()
        {
            var regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("",
                                                         "Ivanov",
                                                         new List<bool>(new bool[] { true, false, false }),
                                                         new List<bool>(new bool[] { true, true, true }),
                                                         "Bulgaria",
                                                         "3",
                                                         "1",
                                                         "1989",
                                                         "8888888888",
                                                         "Buro",
                                                         "burkata@abv.bg",
                                                         @"C:\Users\aivanov\Pictures\Test.jpg",
                                                         "OPSA",
                                                         "12345678",
                                                         "12345678");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssesrtNoNameValidationMessage(requiredField);
        }

        [Test]
        public void _07_LastNamesRequieredValidationTest()
        {
            var regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("Ivan",
                                                         "",
                                                         new List<bool>(new bool[] { true, false, false }),
                                                         new List<bool>(new bool[] { false, true, false }),
                                                         "Bulgaria",
                                                         "3",
                                                         "1",
                                                         "1989",
                                                         "8888888888",
                                                         "Buro",
                                                         "burkata@abv.bg",
                                                         @"C:\Users\aivanov\Pictures\Test.jpg",
                                                         "OPSA",
                                                         "12345678",
                                                         "12345678");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssesrtNoNameValidationMessage(requiredField);
        }

        [Test]
        public void _08_HobbysRequieredValidationTest()
        {
            var regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("Ivan",
                                                         "Ivanov",
                                                         new List<bool>(new bool[] { true, false, false }),
                                                         new List<bool>(new bool[] { false, false, false }),
                                                         "Bulgaria",
                                                         "3",
                                                         "1",
                                                         "1989",
                                                         "8888888888",
                                                         "Buro",
                                                         "burkata@abv.bg",
                                                         @"C:\Users\aivanov\Pictures\Test.jpg",
                                                         "OPSA",
                                                         "12345678",
                                                         "12345678");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertHobbysRequieredValidationMessage(requiredField);
        }

        [Test]
        public void _09_PhoneNumberFilledInWithLettersValidationMessage()
        {
            var regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("Ivan",
                                                         "Ivanov",
                                                         new List<bool>(new bool[] { true, false, false }),
                                                         new List<bool>(new bool[] { false, false, false }),
                                                         "Bulgaria",
                                                         "3",
                                                         "1",
                                                         "1989",
                                                         "abcdefghijk",
                                                         "Buro",
                                                         "burkata@abv.bg",
                                                         @"C:\Users\aivanov\Pictures\Test.jpg",
                                                         "OPSA",
                                                         "12345678",
                                                         "12345678");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertMinimumPhoneDigitsValidationMessage(digits10InPhoneMessage);
        }

        [Test]
        public void _10_LettersAndDigitsInPhoneValidationMessage()
        {
            var regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("Ivan",
                                                         "Ivanov",
                                                         new List<bool>(new bool[] { true, false, false }),
                                                         new List<bool>(new bool[] { false, false, false }),
                                                         "Bulgaria",
                                                         "3",
                                                         "1",
                                                         "1989",
                                                         "123cdefghijk",
                                                         "Buro",
                                                         "burkata@abv.bg",
                                                         @"C:\Users\aivanov\Pictures\Test.jpg",
                                                         "OPSA",
                                                         "12345678",
                                                         "12345678");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertMinimumPhoneDigitsValidationMessage(digits10InPhoneMessage);
        }

        [Test]
        public void _11_SpecialCharacetersInPhoneValidationMessage()
        {
            var regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("Ivan",
                                                         "Ivanov",
                                                         new List<bool>(new bool[] { true, false, false }),
                                                         new List<bool>(new bool[] { false, false, false }),
                                                         "Bulgaria",
                                                         "3",
                                                         "1",
                                                         "1989",
                                                         "@#!$#%#@%^#%",
                                                         "Buro",
                                                         "burkata@abv.bg",
                                                         @"C:\Users\aivanov\Pictures\Test.jpg",
                                                         "OPSA",
                                                         "12345678",
                                                         "12345678");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertMinimumPhoneDigitsValidationMessage(digits10InPhoneMessage);
        }

        [Test]
        public void _12_LettersNumbersAndSpecialCharacetersInPhoneValidationMessage()
        {
            var regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("Ivan",
                                                         "Ivanov",
                                                         new List<bool>(new bool[] { true, false, false }),
                                                         new List<bool>(new bool[] { false, false, false }),
                                                         "Bulgaria",
                                                         "3",
                                                         "1",
                                                         "1989",
                                                         "@#!askdh$#%#@%^#%2365462354",
                                                         "Buro",
                                                         "burkata@abv.bg",
                                                         @"C:\Users\aivanov\Pictures\Test.jpg",
                                                         "OPSA",
                                                         "12345678",
                                                         "12345678");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertMinimumPhoneDigitsValidationMessage(digits10InPhoneMessage);
        }

        [Test]
        public void _13_UsernameRequieredValidationMessage()
        {
            var regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("Ivan",
                                                         "Ivanov",
                                                         new List<bool>(new bool[] { true, false, false }),
                                                         new List<bool>(new bool[] { false, false, false }),
                                                         "Bulgaria",
                                                         "3",
                                                         "1",
                                                         "1989",
                                                         "@#!askdh$#%#@%^#%2365462354",
                                                         "Buro",
                                                         "burkata@abv.bg",
                                                         @"C:\Users\aivanov\Pictures\Test.jpg",
                                                         "OPSA",
                                                         "12345678",
                                                         "12345678");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertMinimumPhoneDigitsValidationMessage(requiredField);
        }

        [Test]
        public void _14_EmailRequieredValidationMessage()
        {
            var regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("Ivan",
                                                         "Ivanov",
                                                         new List<bool>(new bool[] { true, false, false }),
                                                         new List<bool>(new bool[] { false, false, false }),
                                                         "Bulgaria",
                                                         "3",
                                                         "1",
                                                         "1989",
                                                         "1234567891011",
                                                         "Buro",
                                                         "asd\asd",
                                                         @"C:\Users\aivanov\Pictures\Test.jpg",
                                                         "OPSA",
                                                         "12345678",
                                                         "12345678");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertMailRequieredValidationMessage(requiredField);
        }

        [Test]
        public void _15_LoginFormNotPopulated()
        {
            var regPage = new RegistrationPage(this.driver);

            regPage.NavigateTo();
            regPage.SubmitButton.Click();

            regPage.AssesrtNoNameValidationMessage(requiredField);
            regPage.AssertHobbysRequieredValidationMessage(requiredField);
            regPage.AssertPhoneRequieredValidationMessage(requiredField);
            regPage.AssertUsernameRequieredValidationMessage(requiredField);
            regPage.AssertMailRequieredValidationMessage(requiredField);
            regPage.AssertPasswordRequieredValidationMessage(requiredField);
            regPage.AssertConfirmPasswordRequieredValidationMessage(requiredField);
        }

        [Test]
        public void _16_UsernameRequieredValidationMessage()
        {
            var regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("Ivan",
                                                         "Ivanov",
                                                         new List<bool>(new bool[] { true, false, false }),
                                                         new List<bool>(new bool[] { false, false, false }),
                                                         "Bulgaria",
                                                         "3",
                                                         "1",
                                                         "1989",
                                                         "1234567891011",
                                                         "",
                                                         "burkata@abv.bg",
                                                         @"C:\Users\aivanov\Pictures\Test.jpg",
                                                         "OPSA",
                                                         "12345678",
                                                         "12345678");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertUsernameRequieredValidationMessage(requiredField);
        }

        [Test]
        public void _17_NoNamesAndHobbysPopulated()
        {
            var regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("",
                                                         "",
                                                         new List<bool>(new bool[] { true, false, false }),
                                                         new List<bool>(new bool[] { false, false, false }),
                                                         "Bulgaria",
                                                         "3",
                                                         "1",
                                                         "1989",
                                                         "1234567891011",
                                                         "Buro",
                                                         "burkata@abv.bg",
                                                         @"C:\Users\aivanov\Pictures\Test.jpg",
                                                         "OPSA",
                                                         "12345678",
                                                         "12345678");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssesrtNoNameValidationMessage(requiredField);
            regPage.AssertHobbysRequieredValidationMessage(requiredField);
        }

        [Test]
        public void _18_NoNamesHobbysAndPhonePopulated()
        {
            var regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("",
                                                         "",
                                                         new List<bool>(new bool[] { true, false, false }),
                                                         new List<bool>(new bool[] { false, false, false }),
                                                         "Bulgaria",
                                                         "3",
                                                         "1",
                                                         "1989",
                                                         "",
                                                         "Buro",
                                                         "burkata@abv.bg",
                                                         @"C:\Users\aivanov\Pictures\Test.jpg",
                                                         "OPSA",
                                                         "12345678",
                                                         "12345678");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssesrtNoNameValidationMessage(requiredField);
            regPage.AssertHobbysRequieredValidationMessage(requiredField);
            regPage.AssertPhoneRequieredValidationMessage(requiredField);
        }

        [Test]
        public void _19_NoNamesHobbysPhoneAndUsernamePopulated()
        {
            var regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("",
                                                         "",
                                                         new List<bool>(new bool[] { true, false, false }),
                                                         new List<bool>(new bool[] { false, false, false }),
                                                         "Bulgaria",
                                                         "3",
                                                         "1",
                                                         "1989",
                                                         "",
                                                         "",
                                                         "burkata@abv.bg",
                                                         @"C:\Users\aivanov\Pictures\Test.jpg",
                                                         "OPSA",
                                                         "12345678",
                                                         "12345678");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssesrtNoNameValidationMessage(requiredField);
            regPage.AssertHobbysRequieredValidationMessage(requiredField);
            regPage.AssertPhoneRequieredValidationMessage(requiredField);
            regPage.AssertUsernameRequieredValidationMessage(requiredField);
        }

        [Test]
        //bug in website, hobbies error message do not appear in this combination
        public void _20_NoNamesHobbysPhoneUsernameAndPasswordPopulated()
        {
            var regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("",
                                                         "",
                                                         new List<bool>(new bool[] { true, false, false }),
                                                         new List<bool>(new bool[] { false, false, false }),
                                                         "Bulgaria",
                                                         "3",
                                                         "1",
                                                         "1989",
                                                         "",
                                                         "",
                                                         "burkata@abv.bg",
                                                         @"C:\Users\aivanov\Pictures\Test.jpg",
                                                         "OPSA",
                                                         "",
                                                         "12345678");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssesrtNoNameValidationMessage(requiredField);
            regPage.AssertHobbysRequieredValidationMessage(requiredField);
            regPage.AssertPhoneRequieredValidationMessage(requiredField);
            regPage.AssertUsernameRequieredValidationMessage(requiredField);
            regPage.AssertPasswordRequieredValidationMessage(requiredField);
        }
    }
}
