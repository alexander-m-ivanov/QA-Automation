using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2nd_Homework___Design_Patterns.Pages.RegistrationPage
{
    public static class RegistrationPageAsserter
    {
        public static void AssesrtNoNameValidationMessage(this RegistrationPage page, string text)
        {
            Assert.IsTrue(page.NoNameValidationMessage.Displayed);
        }

        public static void AssertMinimumPhoneDigitsValidationMessage(this RegistrationPage page, string text)
        {
            Assert.IsTrue(page.MinimumPhoneDigitsValidationMessage.Displayed);
        }

        public static void AssertInvalidMailAddressValidationTest(this RegistrationPage page, string text)
        {
            Assert.IsTrue(page.InvalidMailValidationMessage.Displayed);
        }

        public static void AssertIPassNotEnoughSymbolsValidationMessage(this RegistrationPage page, string text)
        {
            Assert.IsTrue(page.PassNotEnoughSymbolsValidationMessage.Displayed);
        }
    }
}