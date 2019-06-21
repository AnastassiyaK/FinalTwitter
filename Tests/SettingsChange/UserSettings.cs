using Business.PageObjects;
using Business.TestBases;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.SettingsChange
{
    [TestFixture]
    class UserSettings: TestBase
    {
        [SetUp]
        public static void LogIn()
        {
            BasePageObject.Login.SignIn("LogInCorrectCreds");
        }

        [TearDown]
        public static void LogOut()
        {
            BasePageObject.Main.LogOut();
        }

        [Test]
        [Order(1)]
        [Description("Changing language")]
        public void ChangeLanguage()
        {
            BasePageObject.Main.ChangeLanguage("ru");
            Assert.IsTrue(BasePageObject.Main.LanguageIsChanged(), "Language was not changed");
        }

    }
}
