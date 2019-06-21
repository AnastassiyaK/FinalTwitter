using Business.PageObjects;
using Business.TestBases;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.TweetActions
{
    [TestFixture]
    class TweetAct: TestBase
    {
        [SetUp]
        public static void LogIn()
        {
            //Cred
            //UserActions.UserLogIn.Cred;
            //tweet2_test", "epamJune6"
            BasePageObject.Login.SignIn("LogInCorrectCreds");
        }

        [TearDown]
        public static void LogOut()
        {
            BasePageObject.Main.LogOut();
        }

        [Test]
        [Order(1)]
        [Description("Sending tweets with text, text and correct link, text and incorrect link")]
        [TestCaseSource("Tweets")]
        public void SendTweets(string message,string item)
        {
            if (!(item == "several pics"))
            {
                BasePageObject.Main.SendTweet(message, item, null);
                               
            }
            else
            {
                var fileName = ConfigurationManager.AppSettings["TweetPicPath"];
                string[] images = Directory.GetFiles(fileName, "*.jpg");
                BasePageObject.Main.SendTweet(message, item, images);

            }
            Assert.IsTrue(BasePageObject.Main.IsLastTweet(message), $"The last tweet is not {message}");
        }
        public static object[] Tweets =
        {
        //new object[] { $"Test Tweet {DateTime.Now.ToString("ddd, dd MMM yyy HH'h'mm'm'ss's'")}","" },
        //new object[] { $"Test Tweet {DateTime.Now.ToString("ddd, dd MMM yyy HH'h'mm'm'ss's'")}","gif" }
        //new object[] { $"Test Tweet {DateTime.Now.ToString("ddd, dd MMM yyy HH'h'mm'm'ss's'")}", "pic" }
        new object[] { $"Test Tweet {DateTime.Now.ToString("ddd, dd MMM yyy HH'h'mm'm'ss's'")}", "several pics" }
        //new object[] { $"Test Tweet {DateTime.Now.ToString("ddd, dd MMM yyy HH'h'mm'm'ss's'")}","comment" }
        };

        //new object[] { $"Test Tweet {DateTime.Now.ToString("ddd, dd MMM yyy HH'h'mm'm'ss's'")}"};

        
        //new object { "Tweet ", " "};
        //{$"Tweet {DateTime.Now.ToString("dd-mm-yyyy HH:mm:ss")} https://img1.goodfon.ru/original/1920x1080/a/61/leto-solnce-zhara-cvety-makro.jpg"},
        //{$"Tweet {DateTime.Now.ToString("dd-mm-yyyy HH:mm:ss")} https://img1.goodfon.ru/original/1920x1080/a/61/leto-solnce-zhara-cvety-makro.jp"}


    }
}
