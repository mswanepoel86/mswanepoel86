using Extent.Reporter.Module;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Module_Framework.DesktopTests.DesktopWebPageObjects
{
    public class Computers
    {
        public Computers()
        {
            driver = null;
            extentReportsHelper = null;
        }
        public Computers(IWebDriver webDriver, ExtentReportsHelper reportsHelper)
        {
            driver = webDriver;
            extentReportsHelper = reportsHelper;

        }
        private ExtentReportsHelper extentReportsHelper;
        //Driver
        IWebDriver driver;
        //Locators
        [FindsBy(How = How.Id, Using = "small-searchterms")]
        private IWebElement SearchInput;
        [FindsBy(How = How.XPath, Using = "//input[@value='Search']")]
        private IWebElement SearchButton;
        //Actions
        public Computers isAt()
        {
            Assert.IsTrue(driver.Title.Equals("nopCommerce demo store. Computers"));
            return this;
        }
        public Computers EnterSearchText(string searchText)
        {
            SearchInput.SendKeys(searchText);
            return this;
        }
        public Computers ClickSearch()
        {
            SearchButton.Click();
            return this;
        }
    }
}
