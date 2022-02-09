using System;
using System.Collections.Generic;
using Extent.Reporter.Module;
using Module_Framework.Config;
using OpenQA.Selenium;
using Selenium.Helper.Module;

namespace Module_Framework.DesktopTests.DesktopWebPageObjects
{
    public class LoginPage : BaseBrowserWebPage
    {
        private ExtentReportsHelper _extent;
        public LoginPage(IWebDriver driver, ExtentReportsHelper extent) : base(driver)
        {
            _extent = extent;
        }

        public LoginPage(IWebDriver driver) : base(driver)
        {
            
        }


        private By UsernameLocator { get; } = By.CssSelector("#user-name");

        public LoginPage Visit()
        {
            Driver.Navigate().GoToUrl(BaseUrl);
            _extent.SetStepStatusPass($"Navigated to {BaseUrl}");
            return this;
        }

        internal Dictionary<string, object> GetPerformance()
        {
            var metrics = new Dictionary<string, object>
            {
                ["type"] = "sauce:performance"
            };
            return (Dictionary<string, object>) ((IJavaScriptExecutor) Driver).ExecuteScript("sauce:log", metrics);
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
            _extent.SetStepStatusPass($"Waited for element to be visible {UsernameLocator} on page {Driver.Url}");
        }
    }
}