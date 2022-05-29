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
    public class CheckOutConfirmationPage : ICheckOutConfirmationPage
    {
        IDriver webDriver;
        ElementFactory Element = new ElementFactory();
        public string checkout_confirmation_msg = "/html[1]/body[1]/div[1]/div[1]/div[1]/div[2]/h2[1]";


        public ITextBoxElement checkOut_Confirmation_Txt => Element.FindElementByXpath<ITextBoxElement>(checkout_confirmation_msg, this.webDriver.getDriver);
        //public IButtonElement checkout_Overview_cancel_btn => Element.FindElementByXpath<IButtonElement>(checkout_Overview_cancel_id, this.webDriver.getDriver);

        public CheckOutConfirmationPage(IDriver driver)
        {
            this.webDriver = driver;
        }

        public string get_CheckOut_Confirmation()
        {
            return this.checkOut_Confirmation_Txt.GetValue();
        }
    }
}
