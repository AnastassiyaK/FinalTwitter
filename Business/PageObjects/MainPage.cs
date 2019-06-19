using Business.WebDriverAction;
using Core.FileLogs;
using Core.WebDrivers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.PageObjects
{
    public class MainPage : BasePageObject
    {
        //public MainPage(IWebDriver driver) : base(driver)
        //{
        //}
        private static readonly FileLog log = new FileLog();

        private const string newTweetIputPath = "//span[contains(text(),'happening?')]";
        private const string newTweetTextBoxPath = "//div[@data-testid='tweetTextarea_0']";  
        private const string sendTweetButtonPath = "//div[@data-testid='tweetButton']";
        private const string newPictureInputPath = "//div[contains(@id,'Tweetstorm-tweet-box-0')]/descendant::input[@class='file-input js-tooltip']";
        //private const string newTweetModalWindowPath = "//div[contains(@class,'js-new-items-bar-container')]";
        //private const string firstTweetOnPagePath = "(//div[@class='js-tweet-text-container'])[1]";
        private const string userIconPath = "//div[contains(@aria-label,'Profile')]";
        private const string signOutButtonPath = "//a[@href='/logout']";
        private const string homeLinkPath = "//nav[@aria-label='Primary']";
        private const string popUpLogOutPath= "//div[@data-testid='confirmationSheetConfirm']";
        private const string seeNewTweetBarPath = "//div[contains(@class,'new-tweets-bar')]";
        private const string allTweetsSectionPath = "//div[contains(@aria-label,'Home')]";
        private const string lastTweetsPath ="//div[contains(@aria-label,'Conversation')]//child::span";
        private const string singleTweetPath = "//div[@lang='et']";

        //home link on the page
        [FindsBy(How = How.XPath, Using = homeLinkPath)]
        private IWebElement homeLink;       
        //button to enter text
        [FindsBy(How = How.XPath, Using = newTweetIputPath)]
        private IWebElement newTweetInput;
        //new tweet area
        [FindsBy(How = How.XPath, Using = newTweetTextBoxPath)]
        private IWebElement newTweetTextBox;
        //button to send tweet
        [FindsBy(How = How.XPath, Using = sendTweetButtonPath)]
        private IWebElement sendTweetBtn;
        //input to send a pic
        [FindsBy(How = How.XPath, Using = newPictureInputPath)]
        private IWebElement sendPicInput;
        //user profile link
        [FindsBy(How = How.XPath, Using = userIconPath)]
        private IWebElement currentUserLink;
        //sign out button
        [FindsBy(How = How.XPath, Using = signOutButtonPath)]
        private IWebElement userSignOutBtn;
        //modal window for sign out    
        [FindsBy(How = How.XPath, Using = popUpLogOutPath)]
        private IWebElement userSignOutPopUpBtn;
        //pop up "new tweet" NOT USED
        [FindsBy(How = How.XPath, Using = seeNewTweetBarPath)]
        private IWebElement seeNewTweetBarBtn;
        //all tweets on the page of current user
        [FindsBy(How = How.XPath, Using = allTweetsSectionPath)]
        private IWebElement allTweetsSection;
        //last tweet on page opened in new  window
        [FindsBy(How = How.XPath, Using = lastTweetsPath)]
        private IWebElement lastTweets;
        //single tweet 
        [FindsBy(How = How.XPath, Using = singleTweetPath)]
        private IWebElement singleTweet; 

        //}
        //public bool OnPage()
        //{
        //    return BrowserFactory.Title.Contains("Home"); 
        //}
        public bool IsLoggedIn()
        {
            Extensions.WaitedForElement(BrowserFactory.Driver, homeLink,10);
            if (homeLink.Exists()) 
            {
                log.WriteMessagesInFile("User is successfully logged in");
                return true;
            }
            else
            {
                log.WriteMessagesInFile("User is not logged in");
                return false;
            }
           
        }
        public void ReopenBrowser()
        {
            BrowserFactory.ReopenTab();
            BrowserFactory.GoToUrl(ConfigurationManager.AppSettings["URL"]);
            //BrowserFactory.GoToUrl(TestBases.TestBase.Url);
        }
        public void LogOut()
        {
            currentUserLink.Click();
            Extensions.WaitedForElement(BrowserFactory.Driver, userSignOutBtn, 5);
            userSignOutBtn.Click();
            Extensions.WaitedForElement(BrowserFactory.Driver, userSignOutPopUpBtn, 5);
            userSignOutPopUpBtn.Click();
            log.WriteMessagesInFile("User was signed out");
        }
        public void SendTweetWithText(string message)
        {
            Extensions.WaitedForElement(BrowserFactory.Driver, newTweetInput, 5);
            newTweetInput.Click();
            BrowserFactory.SwitchToElement();
            Extensions.WaitedForElement(BrowserFactory.Driver, newTweetTextBox, 5);
            newTweetTextBox.Click();
            newTweetTextBox.SendKeys(message);
            log.WriteMessagesInFile($"Sending {message} as a new tweet");
            sendTweetBtn.Click();
            Extensions.WaitedForElement(BrowserFactory.Driver, seeNewTweetBarBtn, 10);
        }
        public bool IsLastTweet(string message)
        {
            Extensions.ScrollToTheBottom(BrowserFactory.Driver);
            Extensions.ScrollToTheTop(BrowserFactory.Driver);
            // string lastTweet = Collection[0].Text;
            //allTweetsSection;
            IList<IWebElement> list = allTweetsSection.FindElements(By.TagName("article"));
            list[0].Click();
            Extensions.WaitedForElement(BrowserFactory.Driver, singleTweet, 5); 
            if (message == singleTweet.Text)
            {
                log.WriteMessagesInFile($"The {message} was sent as tweet and the last tweet is .Checking for last tweet was successfull");

            return true;
            }
            else
            {

                log.WriteMessagesInFile($"The {message} was sent as tweet and the last tweet is .Something went wrong");
                return false;
            }

        }



    }
}
