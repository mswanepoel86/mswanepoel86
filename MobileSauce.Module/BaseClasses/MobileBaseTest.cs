using System;
using Extent.Reporter.Module;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Enums;
using Selenium.Helper.Module;


namespace MobileSauce.Module.BaseClasses
{
    public class MobileBaseTest : MobileTestsBase
    {
        public static string BuildId { get; set; } = DateTime.Now.ToString("F");
        public static ExtentReportsHelper extent;

        [OneTimeSetUp]
        public void SetUpReporter()
        {
            extent = new ExtentReportsHelper();
            _extent = extent;
        }

        [SetUp]
        public void MobileBaseSetup()
        {
            extent.CreateTest(TestContext.CurrentContext.Test.Name);

            MobileOptions = new AppiumOptions();
            MobileOptions.AddAdditionalCapability(MobileCapabilityType.DeviceName, DeviceName);
            MobileOptions.AddAdditionalCapability(MobileCapabilityType.PlatformName, Platform);
            MobileOptions.AddAdditionalCapability(MobileCapabilityType.BrowserName, Browser);
            MobileOptions.AddAdditionalCapability("name", TestContext.CurrentContext.Test.Name);
            MobileOptions.AddAdditionalCapability("newCommandTimeout", 90);
            MobileOptions.AddAdditionalCapability("build", BuildId);
        }

        public readonly string DeviceName;
        public readonly string Platform;
        public readonly string Browser;


        public MobileBaseTest(string deviceName, string platform, string browser)
        {
            DeviceName = deviceName;
            Platform = platform;
            Browser = browser;
        }

        public AppiumOptions MobileOptions { get; set; }

        
        public void UpdateReport<T>(T Driver)
        {
            if (Driver == null) return;
            try
            {
                var status = TestContext.CurrentContext.Result.Outcome.Status;
                var stacktrace = TestContext.CurrentContext.Result.StackTrace;
                var errorMessage = "<pre>" + TestContext.CurrentContext.Result.Message + "</pre>";
                switch (status)
                {
                    case TestStatus.Failed:
                        extent.SetTestStatusFail($"<br>{errorMessage}<br>Stack Trace: <br>{stacktrace}<br>");
                        extent.AddTestFailureScreenshot(WebDiverExtensions.ScreenCaptureAsBase64String(Driver));
                        break;
                    case TestStatus.Skipped:
                        extent.SetTestStatusSkipped();
                        break;
                    default:
                        extent.SetTestStatusPass();
                        break;
                }
            }
            catch (Exception e)
            {
                throw (e);
            }
            
        }

        [OneTimeTearDown]
        public void CloseAll()
        {
            try
            {
                extent.Close();
            }
            catch (Exception e)
            {
                throw (e);
            }
        }
    }
}