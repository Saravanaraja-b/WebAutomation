using ElementRepositories.ElementFactory;
using Helpers;
//using OpenQA.Selenium;
using PageRepositories.INavigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebAutomation.ITestStartupandTearDown;

namespace PageRepositories.Navigation
{
    public class CheckOutOverviewPage : ICheckOutOverviewPage
    {
        IDriver webDriver;
        ElementFactory Element = new ElementFactory();
        public string checkout_Overview_finish_id = "//*[@id='finish']";
        public string checkout_Overview_cancel_id = "//*[@id='cancel']";
        
        public IButtonElement checkout_Overview_finish_btn => Element.FindElementByXpath<IButtonElement>(checkout_Overview_finish_id, this.webDriver.getDriver);
        public IButtonElement checkout_Overview_cancel_btn => Element.FindElementByXpath<IButtonElement>(checkout_Overview_cancel_id, this.webDriver.getDriver);

        public CheckOutOverviewPage(IDriver driver)
        {
            this.webDriver = driver;
        }


        public void checkOut_overView_Completion()
        {
            checkout_Overview_finish_btn.Click();
        }

        public void checkOut_overView_Cancel()
        {
            checkout_Overview_cancel_btn.Click();
        }

    }
}
