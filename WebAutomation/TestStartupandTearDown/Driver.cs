using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
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
            if(webDriver!=null)
            {
                webDriver.Dispose();
            }
        }

        public void Initialize_Browser()
        {
            string m_exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var test = ("\\Drivers");
            string driver_path = Path.Combine(m_exePath + test);
            webDriver = new ChromeDriver(driver_path);
            //webDriver = new ChromeDriver(@"C:\Users\sarav\Downloads\chromedriver_win32 (3)");
            webDriver.Manage().Window.Maximize();
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }
    }
}
