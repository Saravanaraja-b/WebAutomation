using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WebAutomation.ITestStartupandTearDown;

namespace WebAutomation.TestStartupandTearDown
{
    public class Driver : IDriver
    {

        public string Title => webDriver.Title;

        public IWebDriver getDriver => webDriver;

        public IWebDriver webDriver;

        //public void Initialize_Browser()
        //{
        //    webDriver = new ChromeDriver();
        //    webDriver.Manage().Window.Maximize();
        //}
        public void Goto(string url)
        {
            webDriver.Url = url;
            this.webDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
        }
        public void Close()
        {
            webDriver.Close();
            webDriver.Quit();
            if (webDriver != null)
            {
                webDriver.Dispose();
            }
        }

        public void Initialize_Browser( string browser)
        {
            string m_exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var driver_exepath = ("\\Drivers");
            string driver_path = Path.Combine(m_exePath + driver_exepath);

            switch (browser)
            {
                case "Chrome":
                    {
                        webDriver = new ChromeDriver(driver_path);                        
                       
                        break;
                    }
                case "Edge":
                    {
                        webDriver = new EdgeDriver(driver_path);

                        break;
                    }
                case "Firefox":
                    {
                        webDriver = new FirefoxDriver(driver_path);

                        break;
                    }
                default:
                    break;
            }
            webDriver.Manage().Window.Maximize();
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            ////C: \Users\sarav\Downloads\edgedriver_win64

            //// webDriver = new EdgeDriver(@"C:\Users\sarav\Downloads\edgedriver_win64");

            //webDriver = new FirefoxDriver(@"C:\Users\sarav\Downloads\geckodriver-v0.31.0-win64");



        }
    }
}
