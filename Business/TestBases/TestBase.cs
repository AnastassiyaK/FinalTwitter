using Business.PageObjects;
using Core.FileLogs;
using Core.WebDrivers;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static Core.WebDrivers.BrowserFactory;

namespace Business.TestBases
{
    [TestFixture]
    public class TestBase
    {
        public static WebBrowser browser;
        private static FileLog log = new FileLog();
        //private static string url = "https://twitter.com/login";
        static TestBase()
        {
            browser = new WebBrowser();
        }
        //public static string Url
        //{
        //    get => url;
        //}
        //static BrowserFactory driver;
        //Environment.CurrentDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        [SetUp]
        //[TestCaseSource("WebBrowser")]
        public static void SetUpDriver()
        {
            BrowserFactory.InitBrowser(browser);
            log.WriteMessagesInFile($"Browser {browser} was initiated successfuly");
            BrowserFactory.GoToUrl(ConfigurationManager.AppSettings["URL"]);
           // BrowserFactory.GoToUrl(url);
            BrowserFactory.MaximizeWindow();
                        
        }

        [TearDown]
        public static void TearDown()
        {
            BrowserFactory.CloseBrowser();
            log.WriteMessagesInFile($"Browser {browser} was closed successfuly");
        }

    }
}
