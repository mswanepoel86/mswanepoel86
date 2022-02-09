
using System;
using Extent.Reporter.Module;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using Selenium.Helper.Module;

namespace MobileSauce.Module.BaseClasses
{
    public class EmusimBaseTest : MobileTestsBase
    {
        public string DeviceName;
        public string PlatformVersion;

        public static ExtentReportsHelper extent;

        [OneTimeSetUp]
        public void SetUpReporter()
        {
            extent = new ExtentReportsHelper();
            _extent = extent;
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
        public EmusimBaseTest(string deviceName, string platformVersion)
        {
            DeviceName = deviceName;
            PlatformVersion = platformVersion;
        }
    }
}