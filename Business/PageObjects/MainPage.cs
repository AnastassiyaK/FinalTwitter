using Business.WebDriverAction;
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
        private const string newTweetIputPath = "//a[@href='/compose/tweet' and not(@data-testid)]";
        private const string popUpNewTweetPath = "//div[@aria-labelledby='modal-header']";
        private const string newTweetTextBoxPath = "//div[@data-testid='tweetTextarea_0']";
        private const string firstCommentTextBoxPath = "//div[@data-testid='tweetTextarea_1']";
        private const string sendTweetBtnPath = "//div[@data-testid='tweetButton']";
        private const string newPictureInputPath = "//div[contains(@id,'Tweetstorm-tweet-box-0')]/descendant::input[@class='file-input js-tooltip']";
        private const string userIconPath = "//div[@data-testid='DashButton_ProfileIcon_Link']";
        private const string signOutBtnPath = "//a[@data-testid='logout']";
        private const string homeLinkPath = "//a[@data-testid='AppTabBar_Home_Link']";
        private const string popUpLogOutPath= "//div[@data-testid='confirmationSheetConfirm']";
        private const string seeNewTweetBarPath = "//div[contains(@class,'new-tweets-bar')]";
        private const string allTweetsSectionPath = "//div[@data-testid='primaryColumn']";
        private const string prefixSectionPath = "//article//time[@datetime]";
        private const string lastTweetPath = "(//div[@data-testid='primaryColumn']//article//time[@datetime])[1]";
        private const string singleTweetPath = "(//div[@data-testid='primaryColumn']//article[@data-testid='tweetDetail']//div[@lang]//span)[1]";
        private const string linkTweetPath = "//div[@data-testid='primaryColumn']//article[@data-testid='tweetDetail']//div[@lang]//span//following-sibling::a";
        private const string firstcommentPath = "(//div[@data-testid='primaryColumn']//article//div[@data-testid='tweet'])[1]//div[@lang]//span";
        private const string addPicBtnPath = "//div[@data-testid='toolBar']//following::input[1][@accept]";
        private const string addGifBtnPath = "//div[contains(@aria-label,'GIF')] ";
        private const string confirmGifBtnPath = "//div[@aria-labelledby='modal-header']//h2[@id='modal-header']//following::div[@role='button'][1]";
        private const string searchFieldGifPath = "//form[contains(@aria-label,'GIF')]//input[@data-testid='SearchBox_Search_Input']";
        private const string firstGifBtnPath = "//input[contains(@aria-label,'GIF')]//following::img[1]";
        private const string addCommentBtnPath = "//div[@data-testid='addButton']";
        private const string optionMoreTweetBtnPath = "//div[@data-testid='caret']";
        private const string deleteTweetBtnPath = "//div[@data-testid='pin']//following-sibling::div[@role='menuitem'][2]";
        private const string confirmDeleteTweetBtnPath = "//div[@data-testid='confirmationSheetConfirm']";
        private const string sentTweetPicPath="//div[@data-testid='tweetTextarea_0']//following::img[1]";
        private const string sentGifPath = "//div[@data-testid='tweetTextarea_0']//following::video[1]";
        private const string alertNewTweetPath = "//div[@data-testid='toast']//a[@href]";
        private const string alertPath = "//div[@data-testid='toast']";
        private const string settingsUserPath = "//a[@href='/settings']";
        private const string settingsLanguagePath = "//a[@href='/settings/language']";
        private const string selectLanguagePath = "//select[@aria-label]";
        private const string russianLanguagePath = "//select[@aria-label]//option[@value='ru']";
        private const string englishLanguagePath = "//select[@aria-label]//option[@value='en']";
        private const string confirmChangeLanguagePath = "//div[@data-testid='settingsDetailSave']";
        private const string sectionChangeLanguagePath = "//section[@aria-labelledby='detail-header']";
        private const string messagesPath = "//a[@data-testid='AppTabBar_DirectMessage_Link']";
        //private const string ChangeLanguagePath = "//div[@data-testid='settingsDetailSave']//child::span[text()!='Save']";

        //home link on the page
        [FindsBy(How = How.XPath, Using = homeLinkPath)]
        private IWebElement homeLink;    
        
        //button to enter text
        [FindsBy(How = How.XPath, Using = newTweetIputPath)]
        private IWebElement newTweetInput;

        //new tweet area
        [FindsBy(How = How.XPath, Using = newTweetTextBoxPath)]
        private IWebElement newTweetTextBox;

        //first comment to the tweet area
        [FindsBy(How = How.XPath, Using = firstCommentTextBoxPath)]
        private IWebElement firstCommentTextBox;

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

        //alert new tweet was sent
        [FindsBy(How = How.XPath, Using = alertNewTweetPath)]
        private IWebElement alertNewTweetAlert;

        //users settings
        [FindsBy(How = How.XPath, Using = settingsUserPath)]
        private IWebElement settingsUserLink;

        //change language link
        [FindsBy(How = How.XPath, Using = settingsLanguagePath)]
        private IWebElement settingsLanguageLink;

        //selector language link
        [FindsBy(How = How.XPath, Using = selectLanguagePath)]
        private IWebElement selectLanguageBox;

        //russian language
        [FindsBy(How = How.XPath, Using = russianLanguagePath)]
        private IWebElement russianLanguageOption;

        //english language
        [FindsBy(How = How.XPath, Using = englishLanguagePath)]
        private IWebElement englishLanguageOption;

        //english language
        [FindsBy(How = How.XPath, Using = confirmChangeLanguagePath)]
        private IWebElement confirmChangeLanguageBtn;

        //section languages
        [FindsBy(How = How.XPath, Using = sectionChangeLanguagePath)]
        private IWebElement sectionChangeLanguage;

        //last tweet on page opened in new  window
        [FindsBy(How = How.XPath, Using = lastTweetPath)]
        private IWebElement lastTweetLink;

        //first comment to the tweet
        [FindsBy(How = How.XPath, Using = firstcommentPath)]
        private IWebElement firstcommentLink;

        //first link to the tweet
        [FindsBy(How = How.XPath, Using = linkTweetPath)]
        private IWebElement linkTweet;

        //messages link
        [FindsBy(How = How.XPath, Using = messagesPath)]
        private IWebElement messagesLink;

        

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
            Extensions.WaitedForElementDisapear(BrowserFactory.Driver, By.XPath(popUpLogOutPath), 10);
            if(BasePageObject.Home.IsLogOut())
            {
                log.WriteMessagesInFile("User was signed out");
            }
            
        }
        
        public void SendTweet(string message,string item,string [] pics)
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
                    //Actions builder = new Actions(BrowserFactory.Driver);
                    //builder.SendKeys(addPicBtn, "path").Perform();
                    //BrowserFactory.SwitchToElement();
                    //builder.SendKeys(@"E:\Epam_training\picForTest.jpg");
                    //builder.SendKeys(Keys.Enter);
                    addPicBtn.SendKeys(System.IO.Path.GetFullPath(@"E:\Epam_training\GitProjectTwitter\Tests\PicsForTweet\picForTest.jpg"));
                    Extensions.WaitedForElement(BrowserFactory.Driver, sentTweetPicField, 5);
                    Extensions.TakeScreenShot(BrowserFactory.Driver, sentTweetPicField);
                    break;
                case "several pics":
                    if(pics.Count()!=0)
                    {
                        foreach (string image in pics)

                        {
                            addPicBtn.SendKeys(System.IO.Path.GetFullPath(image));
                            Extensions.WaitedForElement(BrowserFactory.Driver, sentTweetPicField, 5);
                            Extensions.TakeScreenShot(BrowserFactory.Driver, sentTweetPicField);
                        }
                        
                    }                
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
                    addCommentBtn.Click();
                    firstCommentTextBox.Click();
                    firstCommentTextBox.SendKeys(message+$" {item}");
                    Extensions.WaitedForElement(BrowserFactory.Driver, sentTweetPicField, 5);
                    break;
                default:                    
                    log.WriteMessagesInFile($"Sending {message} as a new tweet");
                    break;

            }
            log.WriteMessagesInFile($"Sending tweet with {item}");
            sendTweetBtn.Click();
            Extensions.WaitedForElementDisapear(BrowserFactory.Driver, By.XPath(popUpNewTweetPath), 10);
            alertNewTweetAlert.Click();
            log.WriteMessagesInFile("Tweet was sent successfully");
        }
        public bool IsLastTweet(string message,bool link)
        {
            
            if (!singleTweet.Exists())
            {
                lastTweetLink.Click();
            }
                        
            Extensions.WaitedForElement(BrowserFactory.Driver, singleTweet, 5);
            if (link)
            {
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
            else
            {
                var a = singleTweet.Text + linkTweet.GetAttribute("title");
                if (message == (singleTweet.Text+linkTweet.GetAttribute("title")))
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
        public void ChangeLanguage(string language)
        {
            if (IsLoggedIn())
            {
                if (!(sectionChangeLanguage.Exists()))
                {
                    currentUserLink.Click();
                    settingsUserLink.Click();
                    Extensions.WaitedForElement(BrowserFactory.Driver, settingsLanguageLink, 5);
                    settingsLanguageLink.Click();
                }

                Extensions.WaitedForElement(BrowserFactory.Driver, selectLanguageBox, 5);
                selectLanguageBox.Click();
                switch (language)
                {
                    case "ru":
                        russianLanguageOption.Click();
                        break;
                    case "en":
                        englishLanguageOption.Click();
                        break;
                    default:
                        break;
                }
                Extensions.WaitedForElement(BrowserFactory.Driver, sectionChangeLanguage, 5);
                Extensions.WaitedForElement(BrowserFactory.Driver, confirmChangeLanguageBtn, 5);
                confirmChangeLanguageBtn.Click();
                Extensions.WaitedForElement(BrowserFactory.Driver, sectionChangeLanguage, 10);
                //Extensions.ScrollToTheBottom(BrowserFactory.Driver);
                ////Extensions.ScrollToTheTop(BrowserFactory.Driver);
                //Extensions.WaitedForElementPresent(BrowserFactory.Driver, By.XPath("//a[@href='/settings/about']"), 10);
            }
        }
        public bool IsComment(string message)
        {
            OpenLastTweet();
            Extensions.WaitedForElement(BrowserFactory.Driver, firstcommentLink, 5);
            if (message==firstcommentLink.Text)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
        public bool IsCorrectLink(string message,string item)
        {
            OpenLastTweet();
            string url = linkTweet.GetAttribute("title");
            BrowserFactory.OpenNewTab();
            BrowserFactory.GoToUrl(url);
            log.WriteMessagesInFile($"New tab is opened with url {url}");
            switch(item)
            {
                case "correct link":
                    if (url == BrowserFactory.Driver.Url)
                    {
                        if (BasePageObject.FacebookHome.HomePageIsOpened())
                        {
                            BrowserFactory.CloseTab();
                            log.WriteMessagesInFile($"New tab is closed with url {url}");
                            return true;
                        }
                        else
                        {
                            return false;
                        }

                    }
                    else
                    {
                        return false;
                    }
                default:
                     string path = "//div[@id='suggestions-list']//following-sibling::div[@class='error-code']";
                     log.WriteMessagesInFile($"The link {url} was incorrect");
                     Extensions.WaitedForElementPresent(BrowserFactory.Driver, By.XPath(path), 10);
                     BrowserFactory.CloseTab();
                     return false;               


            }


        }
        public void OpenLastTweet()
        {
            if (!singleTweet.Exists())
            {
                lastTweetLink.Click();
            }
            Extensions.WaitedForElement(BrowserFactory.Driver, singleTweet, 5);

        }

        public bool TweetIsDeleted(string message)
        {
            SendTweet(message, "", null);
            Extensions.WaitedForElement(BrowserFactory.Driver, singleTweet, 5);
            optionMoreTweetBtn.Click();            
            deleteTweetBtn.Click();
            Extensions.WaitedForElement(BrowserFactory.Driver, confirmDeleteTweetBtn, 10);
            confirmDeleteTweetBtn.Click();
            if (Extensions.WaitedForElementPresent(BrowserFactory.Driver, By.XPath(alertPath), 10))
            {
                log.WriteMessagesInFile("Tweet was deleted successfully");
                return true;
            }
            else
            {
                log.WriteMessagesInFile("Tweet was not deleted. Smth went wrong");
                return false;
            }                

        }
        //public bool TweetIsDeleted(string message)
        //{
        //    int number = 1;           
        //    List<int> tweets = new List<int>();
        //    for(int i =0;i<number;i++)
        //    {
        //        string tweet = prefixSectionPath + $"[{number}]";
        //        if (Extensions.WaitedForElementPresent(BrowserFactory.Driver, By.XPath(""), 10))
        //        {
        //            tweets.Add(number);
        //        }
        //        number++;
        //    }
            
           
        //    return true;
        //}
        public bool LanguageIsChanged(string language)
        {
            string locator = confirmChangeLanguagePath + "//child::span[text()!='Save']";
            //log.WriteMessagesInFile($"Changing language in User settings to {language}");
            switch (language)
            {
                case "ru":
                    if (Extensions.WaitedForElementPresent(BrowserFactory.Driver, By.XPath(locator), 5))
                    {
                        log.WriteMessagesInFile($"Language in User settings is changed to {language}");
                        return true;
                    }
                    return false;
                default:
                    if (Extensions.WaitedForElementPresent(BrowserFactory.Driver, By.XPath(confirmChangeLanguagePath), 10))
                    log.WriteMessagesInFile($"Language in User settings is changed to {language}");
                    homeLink.Click();
                    return true;
                    
            }
 
        }

    }
    
}
