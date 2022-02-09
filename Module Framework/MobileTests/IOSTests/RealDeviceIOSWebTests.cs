using FluentAssertions;
using MobileSauce.Module.BaseClasses;
using Module_Framework.Config;
using Module_Framework.MobileTests.MobileWebPageObjects.IOS;
using NUnit.Framework;
using OpenQA.Selenium.Appium.iOS;

namespace Module_Framework.MobileTests.IOSTests
{
    [Category("MostPopularIOSDevices")]
    [TestFixtureSource(typeof(TestConfigData), nameof(TestConfigData.MostPopularIOSDevices))]
    [Parallelizable]
    public class RealDeviceIOSWebTests : MobileBaseTest
    {

        [SetUp]
        public void IOSSetup()
        {
            Driver = GetIOSDriver(MobileOptions);
        }

        [TearDown]
        public void TearrDown()
        {
            UpdateReport(Driver);
            if (Driver == null) return;

            ExecuteSauceCleanupSteps(Driver);
            Driver.Quit();
        }

        public new IOSDriver<IOSElement> Driver { get; set; }

        public RealDeviceIOSWebTests(string deviceName, string platform, string browser) :
            base(deviceName, platform, browser)
        {
        }

        [Test]
        public void ShouldOpenHomePage()
        {
            var loginPage = new LoginPage(Driver,extent);
            loginPage.Visit();
            loginPage.IsVisible().Should().NotThrow();
        }
       
    }
}