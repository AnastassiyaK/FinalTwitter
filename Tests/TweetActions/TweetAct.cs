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
using Tests.SetUp;

namespace Tests.TweetActions
{
    [TestFixture]
    class TweetAct: SetUpClass
    {
        [Test]
        [Order(1)]
        [Description("Sending tweets with text, text and correct link, text and incorrect link")]
        [TestCaseSource("Tweets")]
        public void SendTweets(string message,string item)
        {
            if (!(item == "several pics") && !(item == "pic"))
            {
                BasePageObject.Main.SendTweet(message, item, null);
                               
            }
            else
            {
                var fileName = ConfigurationManager.AppSettings["TweetPicPath"];
                string[] images = Directory.GetFiles(fileName, "*.jpg");
                if (images.Count()!=0)
                {
                    switch (item)
                    {
                        case "pic":
                            string[] image = new string[] { $"images.First()" };
                            BasePageObject.Main.SendTweet(message, item, image);
                            break;
                        default:
                            BasePageObject.Main.SendTweet(message, item, images);
                            break;

                    }

                }                             
                
            }
            //Assert.IsTrue(BasePageObject.Main.IsLastTweet(message), $"The last tweet is not {message}");
            if(item=="comment")
            {
                Assert.IsTrue(BasePageObject.Main.IsComment(message+$" {item}"), $"The last tweet is not {message}");
            }
            if (item == "correct link")
            {
                Assert.IsTrue(BasePageObject.Main.IsCorrectLink(message + $" {item}",item), $"The last tweet is not {message}");
            }
            if (item == "incorrect link")
            {
                Assert.IsFalse(BasePageObject.Main.IsCorrectLink(message + $" {item}",item), $"The last tweet is not {message}");
            }

        }

        [Test]
        [Order(2)]
        [Description("Sending tweets with text, text and correct link, text and incorrect link")]
        public void DeleteTweet()
        {
            string tweet = $"Test Tweet {DateTime.Now.ToString("ddd, dd MMM yyy HH'h'mm'm'ss's'")}";
            Assert.IsTrue(BasePageObject.Main.TweetIsDeleted(tweet), "Tweet was not deleted");
        }

        public static object[] Tweets =
        {
        //new object[] { $"Test Tweet {DateTime.Now.ToString("ddd, dd MMM yyy HH'h'mm'm'ss's'")}","" },
        //new object[] { $"Test Tweet {DateTime.Now.ToString("ddd, dd MMM yyy HH'h'mm'm'ss's'")}","gif" },
        //new object[] { $"Test Tweet {DateTime.Now.ToString("ddd, dd MMM yyy HH'h'mm'm'ss's'")}", "pic" },
        //new object[] { $"Test Tweet {DateTime.Now.ToString("ddd, dd MMM yyy HH'h'mm'm'ss's'")}", "several pics" }
        //new object[] { $"Test Tweet {DateTime.Now.ToString("ddd, dd MMM yyy HH'h'mm'm'ss's'")}","comment" },
        //new object[] { $"Test Tweet {DateTime.Now.ToString("ddd, dd MMM yyy HH'h'mm'm'ss's'")} https://www.facebook.com/","correct link" }
        new object[] { $"Test Tweet {DateTime.Now.ToString("ddd, dd MMM yyy HH'h'mm'm'ss's'")} https://vk1.com/","incorrect link" }
        };

        //new object[] { $"Test Tweet {DateTime.Now.ToString("ddd, dd MMM yyy HH'h'mm'm'ss's'")}"};

        
        //new object { "Tweet ", " "};
        //{$"Tweet {DateTime.Now.ToString("dd-mm-yyyy HH:mm:ss")} https://img1.goodfon.ru/original/1920x1080/a/61/leto-solnce-zhara-cvety-makro.jpg"},
        //{$"Tweet {DateTime.Now.ToString("dd-mm-yyyy HH:mm:ss")} https://img1.goodfon.ru/original/1920x1080/a/61/leto-solnce-zhara-cvety-makro.jp"}


    }
}
