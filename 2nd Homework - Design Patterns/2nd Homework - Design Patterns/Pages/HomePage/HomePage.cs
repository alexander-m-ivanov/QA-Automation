using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2nd_Homework___Design_Patterns.Pages.HomePage
{
    public partial class HomePage : BasePage
    {
        public HomePage(IWebDriver driver)
            : base(driver)
        {
        }

        public void NavigateTo()
        {
            this.Driver.Navigate().GoToUrl("http://www.demoqa.com");
        }
    }
}