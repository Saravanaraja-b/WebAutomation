using PageRepositories.INavigation;
using PageRepositories.Navigation;
using System;
using TechTalk.SpecFlow;
using WebAutomation.ITestStartupandTearDown;
using WebAutomation.TestStartupandTearDown;
using FluentAssertions;
using Helpers;

namespace LoginPageValidation.Steps
{
    [Binding]
    public class LoginValidationSteps
    {
        private readonly ScenarioContext _scenarioContext;

        public LoginValidationSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        public IDriver webDriver = new Driver();

        public IBasePage basePage => new BasePage(webDriver);
        public IInventoryPage invPage => new InventoryPage(webDriver);
        public ICartPage cartPage => new CartPage(webDriver);
        public ICheckOutOverviewPage checkoutOverviewpage => new CheckOutOverviewPage(webDriver);
        public ICartCheckoutInformation ChekoutInformationpage => new CartCheckoutInformation(webDriver);
        public ICheckOutConfirmationPage checkOutConfirmationPage => new CheckOutConfirmationPage(webDriver);

        [Given(@"User launches the browser")]
        public void GivenUserLaunchesTheBrowser()
        {
            try
            {

                webDriver.Initialize_Browser();
            }
            catch (Exception ex)
            {
                ScreenShot.GetScreenShot(webDriver.getDriver, _scenarioContext.ScenarioInfo.Title.ToString());
                LogWriter.Write(ex.ToString(), _scenarioContext.ScenarioInfo.Title.ToString());
                throw;
            }

        }

        [Given(@"Navigate to ""(.*)""")]
        public void GivenNavigateTo(string webSiteUrl)
        {
            webDriver.Goto(webSiteUrl);
        }

        [Given(@"the user is in login page")]
        public void GivenTheUserIsInLoginPage()
        {
            //  basePage.NavigatetoLoginWindow();
        }

        [Given(@"the user enters username (.*) and password (.*)")]
        public void GivenTheUserEntersUsernameAndPassword(string userName, string password)
        {
            basePage.InputLogin(userName, password);
        }

        [Given(@"the user click Login button")]
        public void GivenTheUserClickLoginButton()
        {
            basePage.proceedToLogin();
            //loginPage.isLoginSuccess().Should().BeFalse();
        }

        //[Then(@"the invalid user error message must display.")]
        //public void ThenTheInvalidUserErrorMessageMustDisplay_()
        //{
        //    //  loginPage.isLoginSuccess().Should().BeFalse();
        //    //   var text = loginPage.errorMessage();
        //}

        [Then(@"user add item to the cart")]
        public void ThenUserAddItemToTheCart()
        {
            try
            {
                invPage.select_Product();
            }

            catch (Exception ex)
            {
                ScreenShot.GetScreenShot(webDriver.getDriver, _scenarioContext.ScenarioInfo.Title.ToString());
                LogWriter.Write(ex.ToString(), _scenarioContext.ScenarioInfo.Title.ToString());
                throw;
            }
        }

        [Then(@"navigate to cart screen")]
        public void ThenNavigateToCartScreen()
        {
            try
            {
                invPage.Navigateto_cartpage();
            }
            catch (Exception ex)
            {
                ScreenShot.GetScreenShot(webDriver.getDriver, _scenarioContext.ScenarioInfo.Title.ToString());
                LogWriter.Write(ex.ToString(), _scenarioContext.ScenarioInfo.Title.ToString());
                throw;
            }
        }
        [Then(@"user checkout the product")]
        public void ThenUserCheckoutTheProduct()
        {
            try
            {
                cartPage.checkOut_Product();
            }
            catch (Exception ex)
            {
                ScreenShot.GetScreenShot(webDriver.getDriver, _scenarioContext.ScenarioInfo.Title.ToString());
                LogWriter.Write(ex.ToString(), _scenarioContext.ScenarioInfo.Title.ToString());
                throw;
            }
        }

        [Then(@"fill the '([^']*)' '([^']*)' and '([^']*)' information")]
        public void ThenFillTheAndInformation(string firstName, string lastName, string postalCode)
        {
            try
            {
                ChekoutInformationpage.fill_Information(firstName, lastName, postalCode);
                ChekoutInformationpage.continue_checkOut();
            }
            catch (Exception ex)
            {
                ScreenShot.GetScreenShot(webDriver.getDriver, _scenarioContext.ScenarioInfo.Title.ToString());
                LogWriter.Write(ex.ToString(), _scenarioContext.ScenarioInfo.Title.ToString());
                throw;
            }
        }

        [When(@"the user finish the transaction")]
        public void WhenTheUserFinishTheTransaction()
        {
            try
            {
                checkoutOverviewpage.checkOut_overView_Completion();
            }
            catch (Exception ex)
            {
                ScreenShot.GetScreenShot(webDriver.getDriver, _scenarioContext.ScenarioInfo.Title.ToString());
                LogWriter.Write(ex.ToString(), _scenarioContext.ScenarioInfo.Title.ToString());
                throw;
            }
        }

        [Then(@"the order confirmation message should be displayed")]
        public void ThenTheOrderConfirmationMessageShouldBeDisplayed()
        {
            try
            {
                checkOutConfirmationPage.get_CheckOut_Confirmation().Should().Be("THANK YOU FOR YOUR ORDER");
                
            }
            catch (Exception ex)
            {
                ScreenShot.GetScreenShot(webDriver.getDriver, _scenarioContext.ScenarioInfo.Title.ToString());
                LogWriter.Write(ex.ToString(), _scenarioContext.ScenarioInfo.Title.ToString());
                throw;
            }

        }


        [AfterScenario]
        public void TestCleanup()
        {
            webDriver.Close();
        }
    }
}
