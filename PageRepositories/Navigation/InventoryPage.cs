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
    public class InventoryPage : IInventoryPage
    {
        IDriver webDriver;
        ElementFactory Element = new ElementFactory();
        public string backpack_addtoCart_Id = "//*[@id='add-to-cart-sauce-labs-backpack']";
        public string backpack_addtoCart_remove_Id = "//*[@id='remove-sauce-labs-backpack']";
        public string cart_id = "//*[@id ='shopping_cart_container']";
        public IButtonElement addProduct_btn => Element.FindElementByXpath<IButtonElement>(backpack_addtoCart_Id, this.webDriver.getDriver);
        public IButtonElement removeProduct_btn => Element.FindElementByXpath<IButtonElement>(backpack_addtoCart_remove_Id, this.webDriver.getDriver);
        public IButtonElement cart_btn => Element.FindElementByXpath<IButtonElement>(cart_id, this.webDriver.getDriver);
              

        public InventoryPage(IDriver driver)
        {
            this.webDriver = driver;
        }

        public void select_Product()
        {
            Wait.UntilElementVisible(this.backpack_addtoCart_Id, this.webDriver.getDriver, 5);
            this.addProduct_btn.Click();
            Wait.UntilElementVisible(this.backpack_addtoCart_remove_Id, this.webDriver.getDriver, 5);
           // Wait.UntilElementVisible( "hellow", this.webDriver.getDriver, 5);

        }

        public void Navigateto_cartpage()
        {
            this.cart_btn.Click();
            this.webDriver.getDriver.Manage().Timeouts().PageLoad = TimeSpan.FromMilliseconds(5000);
        }

        //public void InputLogin(string userName, string password)
        //{            
        //    this.userNameInput.Click();
        //    this.userNameInput.Entertext(userName);            
        //    this.passWordInput.Click();
        //    this.passWordInput.SendKeys(password);                      
        //}

        //public void proceedToLogin()
        //{
        //    Wait.UntilElementClickable(By.XPath(login_button_Id), this.webDriver, 15);
        //    this.login_button.Click();
        //}

        //public bool isLoginSuccess()
        //{
        //    Wait.UntilElementVisible(By.XPath(error_message_xpath), this.webDriver, 10);
        //    return !(error_Message.Displayed);
        //}

        //public string errorMessage()
        //{

        //    return error_Message.GetAttribute("innerText");
        //}

    }
}
