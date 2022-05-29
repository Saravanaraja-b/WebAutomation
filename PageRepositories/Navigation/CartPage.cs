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
    public class CartPage : ICartPage
    {
        IDriver webDriver;
        ElementFactory Element = new ElementFactory();
        public string cart_Checkout_Id = "//*[@id='add-to-cart-sauce-labs-backpack']";
        public string cart_ContinueShopping_Id = "//*[@id='checkout']";
        
        public IButtonElement cart_Checkout_btn => Element.FindElementByXpath<IButtonElement>(cart_Checkout_Id, this.webDriver.getDriver);
        public IButtonElement cart_ContinueShopping_btn => Element.FindElementByXpath<IButtonElement>(cart_ContinueShopping_Id, this.webDriver.getDriver);

        public CartPage(IDriver driver)
        {
            this.webDriver = driver;
        }

        public void checkOut_Product()
        {
            cart_ContinueShopping_btn.Click();
            this.webDriver.getDriver.Manage().Timeouts().PageLoad = TimeSpan.FromMilliseconds(5000);
        }

        public void checkOut_ContinueShopping()
        {
            throw new NotImplementedException();
        }
    }
}
