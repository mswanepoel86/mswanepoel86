using NUnit.Framework;

namespace Module_Framework.DesktopTests.BasicBrowserTests
{
    [TestFixture, Category("BasicBrowsertest")]
    public class BasicBrowserTest : TestBase
    {

        [Test]
        public void NopCommerceDummyTest()
        {
            Pages.Home.isAt();
            Pages.Home.GoToComputers();
            Pages.Computers.isAt();
            Pages.Computers.EnterSearchText("Search for me");
            Pages.Computers.ClickSearch();
        }
    }
}