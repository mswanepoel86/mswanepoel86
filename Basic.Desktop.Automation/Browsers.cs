using System;
using System.Configuration;
using System.IO;
using System.Reflection;
using Extent.Reporter.Module;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;

namespace Basic.Desktop.Automation
{
    public class Browsers
    {
        public Browsers(ExtentReportsHelper reportsHelper)
        {
            //baseURL = ConfigurationManager.AppSettings["url"];000.00...

            baseURL = "https://demo.nopcommerce.com";
            browser = ConfigurationManager.AppSettings["browser"];
            extentReportsHelper = reportsHelper;
        }
        private IWebDriver webDriver;
        private string baseURL;
        private string browser;
        private ExtentReportsHelper extentReportsHelper;

        
        public void Init()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("incognito");

            
            switch (browser)
            {
                case "Chrome":
                    webDriver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), chromeOptions);
                    break;
                case "CromeRemote":
                    webDriver = new RemoteWebDriver(new Uri("http://127.0.0.1:4444/wd/hub"), chromeOptions);
                    break;
                case "Firefox":
                    webDriver = new FirefoxDriver();
                    break;
                default:
                    webDriver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), chromeOptions);
                    break;
            }
            extentReportsHelper.SetStepStatusPass("Browser started.");
            webDriver.Manage().Window.Maximize();
            extentReportsHelper.SetStepStatusPass("Browser maximized.");
            Goto(baseURL);

        }
        public string Title
        {
            get { return webDriver.Title; }
        }
        public IWebDriver getDriver
        {
            get { return webDriver; }
        }
        public void Goto(string url)
        {
            webDriver.Url = url;
            extentReportsHelper.SetStepStatusPass($"Browser navigated to the url [{url}].");
        }
        public void Close()
        {
            webDriver.Quit();
            extentReportsHelper.SetStepStatusPass($"Browser closed.");
        }
    }
}