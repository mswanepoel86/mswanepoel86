using System;
using System.Collections.Generic;
using Extent.Reporter.Module;
using Microsoft.Extensions.Configuration;
using MobileSauce.Module.Core.Common;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Remote;

namespace MobileSauce.Module
{
    
    public class MobileTestsBase
    {
        public ExtentReportsHelper _extent;
        
        public IWebDriver Driver { get; set; }

        private static AppiumLocalService _appiumLocalService;
        
        public static IConfigurationBuilder Builder = new ConfigurationBuilder().AddUserSecrets<MobileTestsBase>();
        public static IConfiguration Configuration => Builder.Build();

        //public static string SauceUserName = "oauth-mswanepoel86-d40d7";
        //public static string SauceAccessKey = "15f5375b-7bae-42b7-80b1-a7bbceb67a11";

        public static string SauceUserName = "sso-wintech-sekhar.naidoo";
        public static string SauceAccessKey = "bd2ae175-1068-4f63-9507-21f992d647b0";

        public Dictionary<string, object> SauceOptions;

        public string ScreenerApiKey =>
            Environment.GetEnvironmentVariable("SCREENER_API_KEY", EnvironmentVariableTarget.User);

        public IJavaScriptExecutor JsExecutor => (IJavaScriptExecutor) Driver;

        public IWebDriver GetVisualDriver(ICapabilities capabilities)
        {
            //TimeSpan.FromSeconds(120) = needed so that there isn't a 'The HTTP request to the remote WebDriver server for URL' error
            var driver = new RemoteWebDriver(new Uri("https://hub.screener.io:443/wd/hub"), capabilities,
                TimeSpan.FromSeconds(120));
            //Needed so that Screener 'end' command doesn't timeout
            driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(60);
            _extent.SetStepStatusPass($@"Visual Driver started.");
            return driver;
        }

        public IWebDriver GetDesktopDriver(ICapabilities browserOptions)
        {
            var driver =  new RemoteWebDriver(new Uri("https://ondemand.saucelabs.com/wd/hub"), browserOptions);
            _extent.SetStepStatusPass($@"Desktop Driver started.");
            return driver;
        }

        public AndroidDriver<AndroidElement> GetAndroidDriver(AppiumOptions appiumOptions)
        {
            try
            {
                return new(new SauceLabsEndpoint().EmusimUri(SauceUserName, SauceAccessKey), appiumOptions, TimeSpan
                    .FromSeconds(240));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                _extent.SetTestStatusFail($"Failed to start AndroidDriver: {e.Message}");
                return null;

            }
            
        }

        public AndroidDriver<AppiumWebElement> GetAndroidEmulator(AppiumOptions appiumOptions)
        {
            _appiumLocalService = new AppiumServiceBuilder().UsingAnyFreePort().Build();
            _appiumLocalService.Start();

            return new AndroidDriver<AppiumWebElement>(_appiumLocalService, appiumOptions);
        }

        public IOSDriver<IOSElement> GetIOSDriver(AppiumOptions appiumOptions)
        {
            

            try
            {
                return new(new SauceLabsEndpoint().EmusimUri(SauceUserName, SauceAccessKey), appiumOptions, TimeSpan
                    .FromSeconds(240));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                _extent.SetTestStatusFail($"Failed to start IOSDriver: {e.Message}");
                return null;

            }
        }

        public void ExecuteSauceCleanupSteps(IWebDriver driver)
        {
            var isPassed = TestContext.CurrentContext.Result.Outcome.Status
                           == TestStatus.Passed;
            var script = "sauce:job-result=" + (isPassed ? "passed" : "failed");
            ((IJavaScriptExecutor) driver).ExecuteScript(script);
        }
    }
}