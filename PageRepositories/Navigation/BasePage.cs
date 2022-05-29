using ElementRepositories.ElementFactory;
using Helpers;
using OpenQA.Selenium;
using PageRepositories.INavigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebAutomation.ITestStartupandTearDown;
using WebAutomation.TestStartupandTearDown;

namespace PageRepositories.Navigation
{
    public class BasePage : IBasePage
    {

        IDriver webDriver;
        ElementFactory Element = new ElementFactory();
        public string userName_Id = "//*[@id='user-name']";
        public string password_Id = "//*[@id='password']";
        public string login_Btn_Id = "//*[@id='login-button']";
        public string baseWindowHandle => this.webDriver.getDriver.CurrentWindowHandle;
        public ITextBoxElement userNameInput => Element.FindElementByXpath<ITextBoxElement>(userName_Id, this.webDriver.getDriver);
        public ITextBoxElement passWordInput => Element.FindElementByXpath<ITextBoxElement>(password_Id, this.webDriver.getDriver);
        public IButtonElement LoginButton => Element.FindElementByXpath<IButtonElement>(login_Btn_Id, this.webDriver.getDriver);

        public BasePage(IDriver driver)
        {
            this.webDriver = driver;
        }

        public void NavigatetoInventoryScreen()
        {            
            var title = this.webDriver.Title;
            this.LoginButton.Click();
            this.webDriver.getDriver.Manage().Timeouts().PageLoad = TimeSpan.FromMilliseconds(15000);
        }       

        public void InputLogin(string userName, string password)
        {
            this.userNameInput.Click();
            this.userNameInput.Entertext(userName);
            this.passWordInput.Click();
            this.passWordInput.Entertext(password);
        }

        public void proceedToLogin()
        {        
       
            this.LoginButton.Click();
            this.webDriver.getDriver.Manage().Timeouts().PageLoad = TimeSpan.FromMilliseconds(5000);
        }

        //public bool isLoginSuccess()
        //{
        //    Wait.UntilElementVisible(By.XPath(error_message_xpath), this.webDriver, 10);
        //    return !(error_Message.Displayed);
        //}
     
    }
}
