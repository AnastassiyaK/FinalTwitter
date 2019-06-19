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
    public class BasePageObject
    {
        //private static IWebDriver driver;

        //public BasePageObject(IWebDriver driver)
        //{
        //    this.driver = driver;
        //    PageFactory.InitElements(driver, this);
        //}

        private static T GetPage<T>() where T: new()
        {
            var page = new T();
            PageFactory.InitElements(BrowserFactory.Driver, page);
            return page;
        }

        public static LoginPage Login
        { get => GetPage<LoginPage>(); }

        public static MainPage Main
        { get => GetPage<MainPage>(); }

        public static HomePage Home
        { get => GetPage<HomePage>(); }



    }
}
