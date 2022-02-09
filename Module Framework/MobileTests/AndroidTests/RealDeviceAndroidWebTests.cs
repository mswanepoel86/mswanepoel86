using FluentAssertions;
using MobileSauce.Module.BaseClasses;
using Module_Framework.Config;
using Module_Framework.DesktopTests.DesktopWebPageObjects;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Android;

namespace Module_Framework.MobileTests.AndroidTests
{
    [Category("MostPopularAndroidDevices")]
    [TestFixtureSource(typeof(TestConfigData), nameof(TestConfigData.MostPopularAndroidDevices))]
    [Parallelizable]
    public class RealDeviceAndroidWebTests : MobileBaseTest
    {
        
        [SetUp]
        public void AndroidSetup()
        {
            Driver = GetAndroidDriver(MobileOptions);
        }

        [TearDown]
        public void TearrDown()
        {
            UpdateReport(Driver);
            if (Driver == null) return;

            ExecuteSauceCleanupSteps(Driver);
            Driver.Quit();
        }

        public new AndroidDriver<AndroidElement> Driver { get; set; }

        public RealDeviceAndroidWebTests(string deviceName, string platform, string browser) :
            base(deviceName, platform, browser)
        {
        }

        [Test]
        [Retry(1)]
        public void ShouldOpenHomePage()
        {
            var loginPage = new LoginPage(Driver, extent);
            loginPage.Visit();
            loginPage.IsVisible().Should().NotThrow();
        }
        
    }
}