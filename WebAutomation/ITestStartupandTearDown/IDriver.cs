using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAutomation.ITestStartupandTearDown
{
    public interface IDriver
    {
        IWebDriver getDriver { get; }

        string Title { get; }

        void Initialize_Browser();

        void Goto(string url);

        void Close();
    }
}
