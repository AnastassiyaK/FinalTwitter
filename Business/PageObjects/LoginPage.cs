
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
using Tests.TestDataAccess;

namespace Business.PageObjects
{
    public class LoginPage : BasePageObject
    {
        //public LoginPage(IWebDriver driver) :base(driver)
        //{
        //    PageFactory.InitElements(driver, this);   
        //}
        private static readonly FileLog log = new FileLog();
        
        //private const string url = "https://twitter.com/login";
        private const string loginInputPath = "//input[@class='js-username-field email-input js-initial-focus']";
        private const string passwordInputPath = "//input[@class='js-password-field']";
        private const string logInBtnPath = "//button[contains(@class,'submit')]";
        //private const string allertlogin = "(//div[@id='message-drawer']//span)[1]";?????
        private const string allertFailLogInPath = "//span[@class='message-text']";

        [FindsBy(How = How.XPath, Using = loginInputPath)]
        private IWebElement loginInput { get; set; }

        [FindsBy(How = How.XPath, Using = passwordInputPath)]
        private IWebElement passwordInput { get; set; }

        [FindsBy(How = How.XPath, Using = logInBtnPath)]
        private IWebElement logInBtn { get; set; }

        [FindsBy(How = How.XPath, Using = allertFailLogInPath)]
        private IWebElement allertFailLogIn { get; set; }


        public bool LogInPageOpened()
        {
            if (loginInput.Exists())
            {
                log.WriteMessagesInFile("LogIn page is opened");
                return true;

            }
            else
            {
                log.WriteMessagesInFile("LogIn page is not opened");
                return false;
            }


         }
            public bool LogInFailed()
        {
            if (allertFailLogIn.Exists())
            {
                log.WriteMessagesInFile("Incorrect credentials were entered.LogIn page is not opened");
                Extensions.TakeScreenShot(BrowserFactory.Driver,allertFailLogIn);
                return true;

            }
            else
            {
                log.WriteMessagesInFile("Correct credentials were entered.LogIn page is opened");
                return false;
            }


        }
        public void SignIn(string testName)
        {
            var userData = ExcelDataAccess.GetTestData(testName);
            loginInput.SendKeys(userData.Login);
            passwordInput.SendKeys(userData.Password);
            //loginInput.SendKeys(login);
            //passwordInput.SendKeys(password);
            log.WriteMessagesInFile($"Email: {userData.Login}, password: {userData.Password}");
            logInBtn.Click();
            //SendKeys(loginInput, login);
            //SendKeys(passwordInput, password);
        }

    }
}
