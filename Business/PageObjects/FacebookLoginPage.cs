using Core.WebDrivers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.WebDriverAction;

namespace Business.PageObjects
{
    public class FacebookLoginPage: BasePageObject
    {
        private const string inputLoginPath = "//input[@data-testid='royal_email']";
        //input login
        [FindsBy(How = How.XPath, Using = inputLoginPath)]
        private IWebElement inputLogin { get; set; }

        public bool HomePageIsOpened()
        {
            if (Extensions.WaitedForElement(BrowserFactory.Driver,inputLogin,10))
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
    }
}
