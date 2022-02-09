using FluentAssertions;
using MobileSauce.Module.BaseClasses;
using Module_Framework.Config;
using Module_Framework.MobileTests.MobileWebPageObjects.IOS;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.iOS;

namespace Module_Framework.MobileTests.IOSTests
{
    [TestFixture,Category("PopularIOSSimulators")]
    [TestFixtureSource(typeof(TestConfigData), nameof(TestConfigData.PopularIOSSimulators))]
    public class IOSEmusimTests : EmusimBaseTest
    {
        [SetUp]
        public void Setup()
        {
            var appiumOptions = new AppiumOptions();
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.DeviceName, DeviceName);
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformName, "iOS");
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, PlatformVersion);
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.BrowserName, "Safari");
            appiumOptions.AddAdditionalCapability("name", TestContext.CurrentContext.Test.Name);
            appiumOptions.AddAdditionalCapability("build", Constants.BuildId);

            _driver = GetIOSDriver(appiumOptions);
        }

        private IOSDriver<IOSElement> _driver;

        public IOSEmusimTests(string deviceName, string platformVersion) 
            : base(deviceName, platformVersion)
        {
        }

        [Test, Ignore("This was not possible to debug properly with Saucelabs acc")]
        public void LoginPageOpens()
        {
            var loginPage = new LoginPage(_driver, extent);
            loginPage.Visit();
            loginPage.IsVisible().Should().NotThrow();
        }
    }
}