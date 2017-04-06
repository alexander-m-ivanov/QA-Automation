using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2nd_Homework___Design_Patterns.Pages.HomePage
{
    public partial class HomePage
    {
        [FindsBy(How = How.Id, Using = "menu-item-374")]
        public IWebElement RegirstratonButton { get; set; }
    }
}