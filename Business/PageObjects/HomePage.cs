using Business.WebDriverAction;
using Core.FileLogs;
using Core.WebDrivers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.PageObjects
{
    public class HomePage
    {
        private static readonly FileLog log = new FileLog();
        private const string loginButtonPath = "//a[contains(@class,'StaticLoggedOutHomePage-input')]";

        [FindsBy(How = How.XPath, Using = loginButtonPath)]
        private IWebElement loginButton { get; set; }

        public bool IsLoggedOut()
        {
            Extensions.WaitedForElement(BrowserFactory.Driver, loginButton, 10);
            if (loginButton.Exists())
            {
                log.WriteMessagesInFile("User is successfully logged out");
                return true;
            }
            else
            {
                log.WriteMessagesInFile("User is not logged out");
                return false;
            }

        }

    }
}
