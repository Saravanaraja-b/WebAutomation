using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Helpers
{
    public static class ScreenShot
    {
        
        public static void GetScreenShot(IWebDriver webDriver, string MethodName)
        {
            ITakesScreenshot screenshotDriver = webDriver as ITakesScreenshot;

            Screenshot screenshot = screenshotDriver.GetScreenshot();

            string m_exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            screenshot.SaveAsFile(m_exePath + "//" + MethodName+".png" );
        }
    }
}
