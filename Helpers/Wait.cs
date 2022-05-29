using ElementRepositories.ElementFactory;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers
{
    public static class Wait
    {
        public static IWebElement UntilElementClickable(By elementLocator, IWebDriver Driver, int timeout = 10)
        {
            try
            {
                var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeout));
                return wait.Until(ExpectedConditions.ElementToBeClickable(elementLocator));

            }
            catch (NoSuchElementException)
            {
                //ITakesScreenshot screenshotDriver = Driver as ITakesScreenshot;

                //Screenshot screenshot = screenshotDriver.GetScreenshot();

                //screenshot.SaveAsFile("c:/test.png");

                // Console.WriteLine("Element with locator: '" + elementLocator + "' was not found in current context page.");
                throw;
            }
        }

        public static IWebElement UntilElementClickable(IElementBase webElement, IWebDriver Driver, int timeout = 10)
        {
            try
            {
                var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeout));
                return wait.Until(ExpectedConditions.ElementToBeClickable(webElement as IWebElement));
            }
            catch (NoSuchElementException)
            {
                // Console.WriteLine("Element with locator: '" + elementLocator + "' was not found in current context page.");
                throw;
            }
        }

        public static IWebElement UntilElementVisible(By elementLocator, IWebDriver Driver, int timeout = 10)
        {
            try
            {
                var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeout));
                return wait.Until(ExpectedConditions.ElementIsVisible(elementLocator));
            }
            catch (NoSuchElementException)
            {

                // Console.WriteLine("Element with locator: '" + elementLocator + "' was not found in current context page.");
                throw;
            }
        }

        public static IWebElement UntilElementVisible(string Xpath_text, IWebDriver Driver, int timeout = 10)
        {
            try
            {
                var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeout));
                return wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(Xpath_text)));

            }
            catch (Exception e)
            {
                //ITakesScreenshot screenshotDriver = Driver as ITakesScreenshot;

                //Screenshot screenshot = screenshotDriver.GetScreenshot();

                //screenshot.SaveAsFile("d:/test.png");
                //// Console.WriteLine("Element with locator: '" + elementLocator + "' was not found in current context page.");
                throw;
            }
        }

        public static bool UntilTextValueChanges(IElementBase webElement, string expected_text, IWebDriver Driver, int timeout = 10)
        {
            try
            {
                var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeout));
                return wait.Until(ExpectedConditions.TextToBePresentInElementValue(webElement as IWebElement, expected_text));

            }
            catch (NoSuchElementException)
            {
                // Console.WriteLine("Element with locator: '" + elementLocator + "' was not found in current context page.");
                throw;
            }
        }
    }
}
