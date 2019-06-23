using Core.FileLogs;
using Business.WebDriverAction;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Tests.TestDataAccess;
using Core.WebDrivers;

namespace Business.PageObjects
{
    public class Message: BasePageObject
    {
        private static readonly FileLog log = new FileLog();
        private const string messageSectionPath = "//a[@data-testid='AppTabBar_DirectMessage_Link']";
        private const string newMessageBtnPath = "//a[@href='/messages/compose']";
        private const string needConversationPath = "//div[@data-testid='conversation']//child::span//*[text()='tweet1_test']";
        private const string messagesInConversasionPath = "//div[@data-testid='messageEntry']//span";
        private const string currentUserPath = "//div[@data-testid='DashButton_ProfileIcon_Link']//span[text()]";
       //conversations block
       [FindsBy(How = How.XPath, Using = messageSectionPath)]
        private IWebElement messageSectionLink { get; set; }

        //new message button
        [FindsBy(How = How.XPath, Using = newMessageBtnPath)]
        private IWebElement newMessageBtn { get; set; }

        //needed conversation
        [FindsBy(How = How.XPath, Using = needConversationPath)]
        private IWebElement needConversationLink { get; set; }

        //messages in needed conversation
        [FindsBy(How = How.XPath, Using = messagesInConversasionPath)]
        private IWebElement messagesInConversasionAria { get; set; }
        
        //messages in needed conversation
        [FindsBy(How = How.XPath, Using = currentUserPath)]
        private IWebElement currentUserLink { get; set; }
        //TO DO
        public void SendMessage(string message,List<string> testname)
        {
            Dictionary<string, string> users = GetUsers(testname);
            Extensions.WaitedForElement(BrowserFactory.Driver,currentUserLink,10);
            if (currentUserLink.Text==users["LogInUser1"])
            {
                users.Remove("LoginUser1");
            }
            messageSectionLink.Click();


        }
        public Dictionary<string, string> GetUsers(List<string> testname)
        {
            Dictionary<string, string> users = ExcelDataAccess.GetUsersName(testname);
            return users;
        }

    }
}
