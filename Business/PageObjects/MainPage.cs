﻿using Business.WebDriverAction;
using Core.FileLogs;
using Core.WebDrivers;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
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
        private const string popUpNewTweetPath = "//div[@aria-labelledby='modal-header']";
        private const string newTweetTextBoxPath = "//div[@data-testid='tweetTextarea_0']";  
        private const string sendTweetBtnPath = "//div[@data-testid='tweetButton']";
        private const string newPictureInputPath = "//div[contains(@id,'Tweetstorm-tweet-box-0')]/descendant::input[@class='file-input js-tooltip']";
        //private const string newTweetModalWindowPath = "//div[contains(@class,'js-new-items-bar-container')]";
        //private const string firstTweetOnPagePath = "(//div[@class='js-tweet-text-container'])[1]";
        private const string userIconPath = "//div[contains(@aria-label,'Profile')]";
        private const string signOutBtnPath = "//a[@href='/logout']";
        private const string homeLinkPath = "//nav[@aria-label='Primary']";
        private const string popUpLogOutPath= "//div[@data-testid='confirmationSheetConfirm']";
        private const string seeNewTweetBarPath = "//div[contains(@class,'new-tweets-bar')]";
        private const string allTweetsSectionPath = "//div[contains(@aria-label,'Home')]";
        private const string lastTweetsPath ="//div[contains(@aria-label,'Conversation')]//child::span";
        private const string singleTweetPath = "//div[@lang]";
        ////div[contains(@aria-label,'photos')]//child::div//*[@d]
        private const string addPicBtnPath = "//div[contains(@aria-label,'photos')]";
        private const string addGifBtnPath = "//div[contains(@aria-label,'GIF')] ";
        private const string confirmGifBtnPath = "//span[text()='Add']";
        private const string searchFieldGifPath = "//form[contains(@aria-label,'Search for GIFs')]//child::input";
        private const string firstGifBtnPath = "//input[@aria-label='Auto-play GIFs']//following::img[1]";
        private const string addCommentBtnPath = "//div[@aria-label='Add Tweet']";
        private const string optionMoreTweetBtnPath = "//div[@data-testid='caret']";
        private const string deleteTweetBtnPath = "//span[text()='Delete']";
        private const string confirmDeleteTweetBtnPath = "//div[@data-testid='confirmationSheetConfirm']";
        private const string sentTweetPicPath="//div[@data-testid='tweetTextarea_0']//following::img[1]";
        private const string sentGifPath = "//div[@data-testid='tweetTextarea_0']//following::video[1]";
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
        [FindsBy(How = How.XPath, Using = sendTweetBtnPath)]
        private IWebElement sendTweetBtn;
        //input to send a pic
        [FindsBy(How = How.XPath, Using = newPictureInputPath)]
        private IWebElement sendPicInput;
        //user profile link
        [FindsBy(How = How.XPath, Using = userIconPath)]
        private IWebElement currentUserLink;
        //sign out button
        [FindsBy(How = How.XPath, Using = signOutBtnPath)]
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
        //send pic button
        [FindsBy(How = How.XPath, Using = addPicBtnPath)]
        private IWebElement addPicBtn;
        //send gif button
        [FindsBy(How = How.XPath, Using = addGifBtnPath)]
        private IWebElement addGifBtn;
        //search gifs field
        [FindsBy(How = How.XPath, Using =searchFieldGifPath)]
        private IWebElement searchFieldGif;
        //first gif 
        [FindsBy(How = How.XPath, Using = firstGifBtnPath)]
        private IWebElement firstGifBtn;
        //add comment 
        [FindsBy(How = How.XPath, Using = addCommentBtnPath)]
        private IWebElement addCommentBtn;
        //option more on tweet
        [FindsBy(How = How.XPath, Using = optionMoreTweetBtnPath)]
        private IWebElement optionMoreTweetBtn;
        //delete btn in tweet menu
        [FindsBy(How = How.XPath, Using = deleteTweetBtnPath)]
        private IWebElement deleteTweetBtn;
        //confirm delete btn in tweet menu
        [FindsBy(How = How.XPath, Using = confirmDeleteTweetBtnPath)]
        private IWebElement confirmDeleteTweetBtn;
        //sent pic 
        [FindsBy(How = How.XPath, Using = sentTweetPicPath)]
        private IWebElement sentTweetPicField;
        //sent gif
        [FindsBy(How = How.XPath, Using = sentGifPath)]
        private IWebElement sentGifField;        
        //confirm gif 
        [FindsBy(How = How.XPath, Using = confirmGifBtnPath)]
        private IWebElement confirmGifBtn;
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
        public void SendTweet(string message,string item)
        {
            Extensions.WaitedForElement(BrowserFactory.Driver, newTweetInput, 5);
            newTweetInput.Click();
            BrowserFactory.SwitchToElement();
            Extensions.WaitedForElement(BrowserFactory.Driver, newTweetTextBox, 5);
            newTweetTextBox.Click();
            newTweetTextBox.SendKeys(message);
            switch (item)
            {
                case "pic":
                    Actions builder = new Actions(BrowserFactory.Driver);
                    builder.SendKeys(addPicBtn, "path").Perform();
                    BrowserFactory.SwitchToElement();
                    builder.SendKeys(@"E:\Epam_training\picForTest.jpg");
                    builder.SendKeys(Keys.Enter);
                    // addPicBtn.SendKeys(System.IO.Path.GetFullPath(@"E:\Epam_training\picForTest.jpg"));
                    Extensions.WaitedForElement(BrowserFactory.Driver, sentTweetPicField, 5);
                   
                    break;
                case "gif":
                    addGifBtn.Click();
                    Extensions.WaitedForElement(BrowserFactory.Driver, searchFieldGif, 5);
                    searchFieldGif.Click();
                    searchFieldGif.SendKeys("dog");
                    searchFieldGif.SendKeys(Keys.Enter);
                    Extensions.WaitedForElement(BrowserFactory.Driver, firstGifBtn, 5);
                    firstGifBtn.Click();
                    confirmGifBtn.Click();
                    Extensions.WaitedForElement(BrowserFactory.Driver, sentGifField, 5);
                    break;
                case "comment":
                    addPicBtn.SendKeys(@"E:\Epam_training.picForTest.jpg");
                    Extensions.WaitedForElement(BrowserFactory.Driver, sentTweetPicField, 5);
                    break;
                default:                    
                    log.WriteMessagesInFile($"Sending {message} as a new tweet");
                    break;

            }
           
            sendTweetBtn.Click();
            Extensions.WaitedForElementDisapear(BrowserFactory.Driver, By.XPath(popUpNewTweetPath), 10);
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
