using System.Collections.Generic;
using MobileSauce.Module;
using NUnit.Framework;

namespace Module_Framework.DesktopTests.SauceLabDesktop
{
    [TestFixture]
    public class WebTestsBase : MobileTestsBase
    {
        [TearDown]
        public void CleanUpAfterEveryTestMethod()
        {
            if (Driver == null)
                return;
            ExecuteSauceCleanupSteps(Driver);
            Driver.Quit();
        }

        [SetUp]
        public void Setup()
        {
            SauceOptions = new Dictionary<string, object>
            {
                ["username"] = SauceUserName,
                ["accessKey"] = SauceAccessKey,
                ["name"] = TestContext.CurrentContext.Test.Name,
                ["build"] = Constants.BuildId
            };
        }
    }
}