﻿using NUnit.Framework;
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
        public void _1NamesRequieredValidationTest()
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

            regPage.AssesrtNoNameValidationMessage(requiredField);
        }

        [Test]
        public void _2_10NumberOfDigitsInPhoneValidationTest()
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
        
            regPage.AssertMinimumPhoneDigitsValidationMessage(digits10InPhoneMessage);
        }
        
        [Test]
        public void _3InvalidMailAddressValidationTest()
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
        
            regPage.AssertInvalidMailAddressValidationTest(requiredField);
        }

        [Test]
        public void _4PassNotEnoughSymbolsValidationTest()
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

            regPage.AssertPassNotEnoughSymbolsValidationMessage("* Minimum 8 characters required");
        }

        [Test]
        public void _5PassDoNotMatchValidationTest()
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
                                                         "123456789",
                                                         "12345678");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertPassDoNotMatchValidationMessage("* Fields do not match");
        }

        [Test]
        public void _6FirstNamesRequiredValidationTest()
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
                                                         @"C:\Users\Buro\Desktop\Seminar\Pics\enviroment.jpg",
                                                         "OPSA",
                                                         "12345678",
                                                         "12345678");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssesrtNoNameValidationMessage(requiredField);
        }

        [Test]
        public void _7LastNamesRequieredValidationTest()
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
                                                         @"C:\Users\Buro\Desktop\Seminar\Pics\enviroment.jpg",
                                                         "OPSA",
                                                         "12345678",
                                                         "12345678");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssesrtNoNameValidationMessage(requiredField);
        }

        [Test]
        public void _8HobbysRequieredValidationTest()
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
                                                         @"C:\Users\Buro\Desktop\Seminar\Pics\enviroment.jpg",
                                                         "OPSA",
                                                         "12345678",
                                                         "12345678");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertHobbysRequieredValidationMessage(requiredField);
        }

        [Test]
        public void _9PhoneNumberFilledInWithLettersValidationMessage()
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
                                                         @"C:\Users\Buro\Desktop\Seminar\Pics\enviroment.jpg",
                                                         "OPSA",
                                                         "12345678",
                                                         "12345678");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertMinimumPhoneDigitsValidationMessage(digits10InPhoneMessage);
        }

        [Test]
        public void _10LettersAndDigitsInPhoneValidationMessage()
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
                                                         @"C:\Users\Buro\Desktop\Seminar\Pics\enviroment.jpg",
                                                         "OPSA",
                                                         "12345678",
                                                         "12345678");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertMinimumPhoneDigitsValidationMessage(digits10InPhoneMessage);
        }

        [Test]
        public void _11SpecialCharacetersInPhoneValidationMessage()
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
                                                         @"C:\Users\Buro\Desktop\Seminar\Pics\enviroment.jpg",
                                                         "OPSA",
                                                         "12345678",
                                                         "12345678");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertMinimumPhoneDigitsValidationMessage(digits10InPhoneMessage);
        }

        [Test]
        public void _12LettersNumbersAndSpecialCharacetersInPhoneValidationMessage()
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
                                                         @"C:\Users\Buro\Desktop\Seminar\Pics\enviroment.jpg",
                                                         "OPSA",
                                                         "12345678",
                                                         "12345678");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertMinimumPhoneDigitsValidationMessage(digits10InPhoneMessage);
        }

        [Test]
        public void _12UsernameRequieredValidationMessage()
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
                                                         @"C:\Users\Buro\Desktop\Seminar\Pics\enviroment.jpg",
                                                         "OPSA",
                                                         "12345678",
                                                         "12345678");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertMinimumPhoneDigitsValidationMessage(requiredField);
        }

        [Test]
        public void _13EmailRequieredValidationMessage()
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
                                                         "",
                                                         @"C:\Users\Buro\Desktop\Seminar\Pics\enviroment.jpg",
                                                         "OPSA",
                                                         "12345678",
                                                         "12345678");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertMailRequieredValidationMessage(requiredField);
        }
    }
}
