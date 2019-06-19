using Business.PageObjects;
using Business.TestBases;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tests.UserActions
{
    [TestFixture]
    class UserLogIn : TestBase
    {
        ///LoginPage loginPage = new LoginPage();

        [Test]
        [Order(1)]
        public void OpenLogInPage()
        {
            Assert.IsTrue(BasePageObject.Login.LogInPageOpened(), "LogIn page is not opened");
           
        }
     

        [Test]
        [Order(2)]
        [Description("Log in to twitter account with 3 pair of credentials")]
        [TestCaseSource("LogInMethods")]
        public void LogiIn(string method) 
        {
            //string config = ConfigurationManager.AppSettings["URL"];
            bool pageIsOpened = BasePageObject.Login.LogInPageOpened();
            if (pageIsOpened)
            {
                BasePageObject.Login.SignIn(method);
                bool loggedIn = BasePageObject.Main.IsLoggedIn();
                if (!loggedIn)
                {
                    Assert.IsTrue(BasePageObject.Login.LogInFailed(), "User is not logged in.");
                }
                else
                {
                    Assert.IsTrue(loggedIn, "User is not logged in");
                }
            }
            else
            {

                Assert.Warn("The login page was not opened");
            }
          
        }
        
        [Test]
        [Order(3)]
        [Description("Log in to twitter account with 3 pair of credentials")]
        [TestCaseSource("Cred")]
        public void CheckLogInAfterClosingAllTabs(string login, string password)
        {
            bool pageIsOpened = BasePageObject.Login.LogInPageOpened();
            if (pageIsOpened)
            {
                BasePageObject.Login.SignIn("LogIn");
                Assert.IsTrue(BasePageObject.Main.IsLoggedIn(), "User is not logged in");
                BasePageObject.Main.ReopenBrowser();
                Assert.IsTrue(BasePageObject.Main.IsLoggedIn(), "User is not logged in");
            }
            else
            {

                Assert.Warn("The login page was not opened");
            }

        }
        [Test]
        [Order(4)]
        [Description("Log out of the account")]
        [TestCaseSource("Cred")]
        public void LogOut(string method)
        {
            bool pageIsOpened = BasePageObject.Login.LogInPageOpened();
            if (pageIsOpened)
            {
                BasePageObject.Login.SignIn(method);
                Assert.IsTrue(BasePageObject.Main.IsLoggedIn(), "User is not logged in");
                BasePageObject.Main.LogOut();
                Assert.IsTrue(BasePageObject.Home.IsLoggedOut(), "User is not logged out");
            }
            else
            {

                Assert.Warn("The login page was not opened");
            }

        }
        public static object[] LogInMethods =
        {
            new object []{ "LogInCorrectCreds" },
            new object []{ "LogInIncorrectPswd" },
            new object []{ "LogInIncorrectCreds" }

        };
        
        public static object[] Cred = new object[] { LogInMethods.First() };

    }
}
