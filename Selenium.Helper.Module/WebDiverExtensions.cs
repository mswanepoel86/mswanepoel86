using OpenQA.Selenium;

namespace Selenium.Helper.Module
{
    public static class WebDiverExtensions
    {
        public static string ScreenCaptureAsBase64String<T>(this T driver)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot screenshot = ts.GetScreenshot();
            return screenshot.AsBase64EncodedString;
        }
    }
}
