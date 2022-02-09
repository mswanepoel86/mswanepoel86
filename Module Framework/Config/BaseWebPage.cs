using OpenQA.Selenium;
using Selenium.Helper.Module;

namespace Module_Framework.Config
{
    public class BaseBrowserWebPage
    {
        public readonly IWebDriver Driver;

        public BaseBrowserWebPage(IWebDriver driver)
        {
            Driver = driver;
            BaseUrl = "https://www.saucedemo.com";
        }

        public IJavaScriptExecutor JavaScriptExecutor => (IJavaScriptExecutor) Driver;

        //public SauceJavaScriptExecutor SauceJsExecutor =>
        //    new SauceJavaScriptExecutor(_driver);

        public Wait Wait => new(Driver);
        public string BaseUrl { get; }

        public void TakeSnapshot()
        {
            JavaScriptExecutor.ExecuteScript("/*@visual.snapshot*/", GetType().Name);
        }
    }
}