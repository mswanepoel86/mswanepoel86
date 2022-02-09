using Extent.Reporter.Module;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Selenium.Helper.Module;

namespace Module_Framework.DesktopTests.DesktopWebPageObjects
{
    public class Home
    {
        public Home()
        {
            driver = null;
            extentReportsHelper = null;
        }
        public Home(IWebDriver webDriver, ExtentReportsHelper reportsHelper)
        {
            driver = webDriver;
            extentReportsHelper = reportsHelper;
        }
        private IWebDriver driver;
        private ExtentReportsHelper extentReportsHelper;


        [FindsBy(How = How.XPath, Using = "//ul[@class='top-menu notmobile']//a[@href='/computers']")]
        private IWebElement ComputersLink;
        public Home isAt()
        {
            Assert.IsTrue(driver.ValidatePageTitle(extentReportsHelper, "nopCommerce demo store"));
            return this;
        }
        public Home GoToComputers()
        {
            ComputersLink.ClickWrapper(driver, extentReportsHelper, "Computers link");
            return this;
        }
    }
}
