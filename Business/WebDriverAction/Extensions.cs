using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.WebDriverAction
{
    public static class Extensions
    {   
        //check if any WebElement is displayed on the page (for tests)
        public static bool Exists(this IWebElement element)
        {
            try
            {
                var text =element.Displayed;
            }
            catch(Exception e)
            {
                return false;
            }
            return true;
        }
        public static bool WaitedForElement(this IWebDriver driver, IWebElement element, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                try
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                    // wait.Until(drv => drv.FindElement(By.XPath(path)));
                    wait.Until(ExpectedConditions.ElementToBeClickable(element));
                    //WebElement element = wait.until(ExpectedConditions.elementToBeClickable(By.id("submit")));
                    return true;
                }
                catch(Exception e)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
           


        }
        public static bool WaitedForElementDisapear(this IWebDriver driver, By locator, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                try
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                    // wait.Until(drv => drv.FindElement(By.XPath(path)));
                    wait.Until(ExpectedConditions.InvisibilityOfElementLocated(locator));
                    //WebElement element = wait.until(ExpectedConditions.elementToBeClickable(By.id("submit")));
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
     
        }
        public static void TakeScreenShot(this IWebDriver driver, IWebElement element)
        {
            string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string actualPath = pth.Substring(0, pth.LastIndexOf("bin"));
            string projectPath = new Uri(actualPath).LocalPath+"Screenshots\\";
            //string fileName = DateTime.Now.ToString("yyyy-mm-dd")+" "+DateTime.Now.ToString("hh mm ss")+$"{element.TagName}"+".jpg";
            string fileName = DateTime.Now.ToString("ddd, dd MMM yyy HH'h'mm'm'ss's'") +" "+$"{element.TagName}" + ".jpg";
            fileName = $@"{fileName}";
            Byte[] byteArray = ((ITakesScreenshot)driver).GetScreenshot().AsByteArray;
            Bitmap screenshot = new Bitmap(new System.IO.MemoryStream(byteArray));
            Rectangle croppedImage = new Rectangle(element.Location.X, element.Location.Y, element.Size.Width,element.Size.Height);
            screenshot = screenshot.Clone(croppedImage, screenshot.PixelFormat);
            //screenshot.Save(String.Format(fileName,ImageFormat.Jpeg));
            screenshot.Save(Path.Combine(projectPath, fileName),ImageFormat.Jpeg);
            //screenshot.Save(@"E:\Epam_training\GitProjectFinal\Tests\Screenshots"+DateTime.Now.ToString("yyyy-mm-dd HH:mm:ss") + ".jpg", ImageFormat.Jpeg);

        }
        public static void ScrollToTheBottom(this IWebDriver driver)
        {
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            js.ExecuteScript("window.scrollBy(0,document.body.scrollHeight);");
        }
        public static void ScrollToTheTop(this IWebDriver driver)
        {
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            js.ExecuteScript("window.scrollBy(0,-document.body.scrollHeight);");
        }


        //public static void WaitForPageToLoad(this IWebDriver driver)
        //{
        //    TimeSpan timeout = new TimeSpan(0, 0, 30);
        //    WebDriverWait wait = new WebDriverWait(driver, timeout);

        //    IJavaScriptExecutor javascript = driver as IJavaScriptExecutor;
        //    if (javascript == null)
        //        throw new ArgumentException("driver", "Driver must support javascript execution");

        //    wait.Until((d) =>
        //    {
        //        try
        //        {
        //            string readyState = javascript.ExecuteScript(
        //            "if (document.readyState) return document.readyState;").ToString();
        //            return readyState.ToLower() == "complete";
        //        }
        //        catch (InvalidOperationException e)
        //        {
        //            //Window is no longer available
        //            return e.Message.ToLower().Contains("unable to get browser");
        //        }
        //        catch (WebDriverException e)
        //        {
        //            //Browser is no longer available
        //            return e.Message.ToLower().Contains("unable to connect");
        //        }
        //        catch (Exception)
        //        {
        //            return false;
        //        }
        //    });
        //}
    }
}
