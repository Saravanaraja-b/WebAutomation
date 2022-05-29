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
    public class CartCheckoutInformation : ICartCheckoutInformation
    {
        IDriver webDriver;
        ElementFactory Element = new ElementFactory();
        public string first_Name_Id = "//*[@id='first-name']";
        public string last_Name_Id = "//*[@id='last-name']";
        public string postalcode_Id = "//*[@id='postal-code']";
        public string continue_Id = "//*[@id='continue']";
        public string cancel_Id = "//*[@id='cancel']";


        public ITextBoxElement first_Name_textbox => Element.FindElementByXpath<ITextBoxElement>(first_Name_Id, this.webDriver.getDriver);
        public ITextBoxElement last_Name_textbox => Element.FindElementByXpath<ITextBoxElement>(last_Name_Id, this.webDriver.getDriver);
        public ITextBoxElement postalcode_textbox => Element.FindElementByXpath<ITextBoxElement>(postalcode_Id, this.webDriver.getDriver);

        public IButtonElement continue_Btn => Element.FindElementByXpath<IButtonElement>(continue_Id, this.webDriver.getDriver);
        public IButtonElement cancel_Btn => Element.FindElementByXpath<IButtonElement>(cancel_Id, this.webDriver.getDriver);

        public CartCheckoutInformation(IDriver driver)
        {
            this.webDriver = driver;
        }


        public void fill_Information(string firstName, string lastName, string postalCode)
        {
            first_Name_textbox.Click();
            first_Name_textbox.Entertext(firstName);
            last_Name_textbox.Click();
            last_Name_textbox.Entertext(lastName);
            postalcode_textbox.Click();
            postalcode_textbox.Entertext(postalCode);
        }
        
        public void continue_checkOut()
        {
            continue_Btn.Click();
        }

        public void cancel_checkOut()
        {
           cancel_Btn.Click();
        }
    }
}
