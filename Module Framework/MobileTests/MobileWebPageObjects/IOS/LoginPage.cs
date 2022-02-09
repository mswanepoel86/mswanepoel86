using System;
using Extent.Reporter.Module;
using Module_Framework.DesktopTests.DesktopWebPageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.iOS;
using Selenium.Helper.Module;

namespace Module_Framework.MobileTests.MobileWebPageObjects.IOS
{
    public class LoginPage
    {
        private ExtentReportsHelper _extent;
        public LoginPage(IOSDriver<IOSElement> driver, ExtentReportsHelper extent)
        {
            Driver = driver;
            Wait = new Wait(Driver);
            _extent = extent;
        }

        private By UsernameLocator { get; } = By.CssSelector("#user-name");

        public IOSDriver<IOSElement> Driver { get; }
        public Wait Wait { get; }

        public LoginPage Visit()
        {
            Driver.Navigate().GoToUrl(Constants.BaseUrl);
            _extent.SetStepStatusPass($"Navigated and loaded page {Driver.Url}");
            return this;
        }

        public ProductsPage Login(string username)
        {
            //SauceJsExecutor.LogMessage(
            //    $"Start login with user=>{username} and pass=>{password}");
            var usernameField = Wait.UntilIsVisible(UsernameLocator);
            _extent.SetStepStatusPass($"Waited for locator username: {UsernameLocator}");
            usernameField.SendKeys(username);
            _extent.SetStepStatusPass($"Entered username: {username}");
            Driver.FindElement(By.CssSelector("#password")).SendKeys("secret_sauce");
            _extent.SetStepStatusPass($"Entered Password");
            Driver.FindElement(By.CssSelector(".btn_action")).Click();
            _extent.SetStepStatusPass($"Clicked Login");

            //SauceJsExecutor.LogMessage($"{MethodBase.GetCurrentMethod().Name} success");
            return new ProductsPage(Driver);
        }

        public Action IsVisible()
        {
            return IsElementVisible;
        }

        private void IsElementVisible()
        {
            new Wait(Driver).UntilIsVisible(UsernameLocator);
        }
    }
}