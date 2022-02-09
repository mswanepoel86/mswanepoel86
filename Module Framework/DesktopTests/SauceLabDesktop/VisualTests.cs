using System;
using System.Collections.Generic;
using FluentAssertions;
using MobileSauce.Module;
using Module_Framework.Config;
using Module_Framework.DesktopTests.DesktopWebPageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Module_Framework.DesktopTests.SauceLabDesktop
{
    [TestFixtureSource(typeof(TestConfigData), nameof(TestConfigData.PopularVisualResolutions))]
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class VisualTests : MobileTestsBase
    {
        [SetUp]
        public void VisualSetup()
        {
            SauceOptions = new Dictionary<string, object>
            {
                ["username"] = SauceUserName,
                ["accessKey"] = SauceAccessKey,
                ["name"] = TestContext.CurrentContext.Test.Name
            };

            _visualOptions = new Dictionary<string, object>
            {
                {"apiKey", ScreenerApiKey},
                {"projectName", "Sauce Demo C#"},
                {"viewportSize", _viewportSize}
            };

            if (_browserOptions.BrowserName.Equals("chrome", StringComparison.OrdinalIgnoreCase))
            {
                ((ChromeOptions) _browserOptions).AddAdditionalCapability("sauce:options", SauceOptions, true);
                ((ChromeOptions) _browserOptions).AddAdditionalCapability("sauce:visual", _visualOptions, true);
            }
            else
            {
                _browserOptions.AddAdditionalCapability("sauce:options", SauceOptions);
                _browserOptions.AddAdditionalCapability("sauce:visual", _visualOptions);
            }

            Driver = GetVisualDriver(_browserOptions.ToCapabilities());
        }


        [TearDown]
        public void CleanupVisual()
        {
            if (Driver == null)
                return;

            ExecuteSauceCleanupSteps(Driver);
            Driver.Quit();
        }

        private readonly DriverOptions _browserOptions;
        private readonly string _viewportSize;
        private readonly string _deviceName;
        private Dictionary<string, object> _visualOptions;

        public VisualTests(DriverOptions browserOptions, string viewportSize, string deviceName)
        {
            _browserOptions = browserOptions;
            _viewportSize = viewportSize;
            _deviceName = deviceName;
        }


        [Test]
        public void VisualE2EFlow()
        {
            JsExecutor.ExecuteScript("/*@visual.init*/", _deviceName);

            var loginPage = new LoginPage(Driver);
            loginPage.Visit();
            loginPage.TakeSnapshot();

            loginPage.Login("standard_user");
            new ProductsPage(Driver).TakeSnapshot();

            var result = (Dictionary<string, object>) JsExecutor.ExecuteScript("/*@visual.end*/");
            result["message"].Should().BeNull();
        }
    }
}