
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.WebDrivers
{
    public class BrowserFactory 
    {
        private static IWebDriver driver;

        public static IWebDriver Driver
        {
            get
            {
                if (driver == null)
                    throw new NullReferenceException("The WebDriver browser instance was not initialized. You should first call the method InitBrowser.");
                return driver;
            }
            private set
            {
                driver = value;
            }
        }

        public static string Title
        {
            get { return driver.Title; }
        }
        public static ISearchContext WebDriver
        {
            get { return driver; }
        }
        //Initiating of WebDriver
        public static void InitBrowser(WebBrowser name)
        {
            switch (name)
            {
                case WebBrowser.Chrome:
                    driver = new ChromeDriver();
                    break;
                //case WebBrowser.Firefox:
                //    driver = new FirefoxDriver();
                //    break;
                //case WebBrowser.IE:
                //case WebBrowser.InternetExplorer:
                //    InternetExplorerOptions ieOption = new InternetExplorerOptions();
                //    ieOption.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
                //    ieOption.EnsureCleanSession = true;
                //    ieOption.RequireWindowFocus = true;
                //    driver = new InternetExplorerDriver(@"./", ieOption);
                //    break;
                default:
                    ChromeOptions chromeOption = new ChromeOptions();
                    string location = @"./";
                    chromeOption.AddArguments("--disable-extensions");
                    driver = new ChromeDriver(location, chromeOption);
                    break;

            }
        }


        //Closing of Browser
        public static void CloseBrowser()
        {
            driver.Quit();
        }
        //Switching to element
        public static void SwitchToElement()
        {
            driver.SwitchTo().ActiveElement();
        }
        //Switching to Default
        public static void ReturnToDefaultPage()
        {
            driver.SwitchTo().DefaultContent();
        }
        //Closing of current tab in browser
        public static void CloseCurrentTab()
        {
            driver.Close();
        }

        //Go to Url
        public static void GoToUrl(string url)
        {
            driver.Navigate().GoToUrl(url);
            
        }
        //Maximize window
        public static void MaximizeWindow()
        {
            driver.Manage().Window.Maximize();
        }

        //Refresh current tab (f5)
        public static void RefreshCurrentTab()
        {
            driver.Navigate().Refresh();
        }
        //
        //public string GetElementText(IWebElement element)
        //{
        //    return element.Text;
        //}
        ////Click IWebElement
        //public void ClickOnElement(IWebElement element)
        //{
        //    element.Click();
        //}
        ////Send Keys
        //public void SendKeys(IWebElement element, string key)
        //{
        //    element.SendKeys(key);
        //}

        //Closing of tabs in browser and add just one new
        public static void ReopenTab()
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("window.open();");
            driver.SwitchTo().Window(driver.WindowHandles.First());

            int tabs = driver.WindowHandles.Count();
            for (int i = 1; i <= tabs; i++)
            {
                if (i != tabs)
                {
                    driver.Close();
                }
                else
                {
                    driver.SwitchTo().Window(driver.WindowHandles.Last());
                    //driver.Navigate().GoToUrl("http://www.google.com");
                }
            }
        }
        public static void OpenNewTab()
        {
            //driver.FindElement(By.CssSelector("body")).SendKeys(Keys.Control + "t");
            ((IJavaScriptExecutor)driver).ExecuteScript("window.open();");
            driver.SwitchTo().Window(driver.WindowHandles.Last());

        }
        public static void CloseTab()
        {
            driver.Close();
            driver.SwitchTo().Window(driver.WindowHandles.Last());

        }
        public enum WebBrowser
        {
            //if need to execute test in different browsers
            //IE,
            //InternetExplorer,
            //Firefox,
            Chrome
            //TO DO : Create a collection from some file and fullfill the collection from tests.
        }
    

    }
}
