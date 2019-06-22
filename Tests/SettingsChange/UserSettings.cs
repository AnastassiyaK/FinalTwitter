using Business.PageObjects;
using Business.TestBases;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.SetUp;

namespace Tests.SettingsChange
{
    [TestFixture]
    class UserSettings: SetUpClass
    {
        [Test]
        [Order(1)]
        [Description("Changing language")]
        public void ChangeLanguage()
        {
            BasePageObject.Main.ChangeLanguage("ru");
            Assert.IsTrue(BasePageObject.Main.LanguageIsChanged("ru"), "Language was not changed");
            BasePageObject.Main.ChangeLanguage("en");
            Assert.IsTrue(BasePageObject.Main.LanguageIsChanged("en"), "Language was not changed");
        }

    }
}
