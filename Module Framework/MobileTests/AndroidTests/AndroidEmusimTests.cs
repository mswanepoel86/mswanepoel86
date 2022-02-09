using FluentAssertions;
using MobileSauce.Module.BaseClasses;
using Module_Framework.Config;
using Module_Framework.MobileTests.MobileWebPageObjects.Android;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;

namespace Module_Framework.MobileTests.AndroidTests
{
    [TestFixture, Category("PopularAndroidSimulators")]
    [TestFixtureSource(typeof(TestConfigData), nameof(TestConfigData.PopularAndroidSimulators))]
    public class AndroidEmusimTests : EmusimBaseTest
    {
        [SetUp]
        public void Setup()
        {
            var appiumOptions = new AppiumOptions();
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.DeviceName, DeviceName);
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformName, "Android");
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, PlatformVersion);
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.BrowserName, "Chrome");
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.AppiumVersion, "1.20.2");
            appiumOptions.AddAdditionalCapability("name", TestContext.CurrentContext.Test.Name);
            appiumOptions.AddAdditionalCapability("build", Constants.BuildId);

            _driver = GetAndroidDriver(appiumOptions);
        }

        
        private AndroidDriver<AndroidElement> _driver;

        public AndroidEmusimTests(string deviceName, string platformVersion) : base(deviceName, platformVersion)
        {
        }

        [TearDown]
        public void TearrDown()
        {
            UpdateReport(Driver);
            if (Driver == null) return;

            ExecuteSauceCleanupSteps(Driver);
            Driver.Quit();
        }

        [Test]
        public void LoginPageOpens()
        {
            var loginPage = new LoginPage(_driver, extent);
            loginPage.Visit();
            loginPage.IsVisible().Should().NotThrow();
        }
    }
}