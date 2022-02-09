using OpenQA.Selenium;

namespace Module_Framework.DesktopTests.DesktopWebPageObjects
{
    public class CartComponent
    {
        private readonly IWebDriver _driver;

        public CartComponent(IWebDriver driver)
        {
            _driver = driver;
        }

        private string CartItemCounterText
        {
            get
            {
                try
                {
                    return _driver.FindElement(By.XPath("//*[@class='fa-layers-counter shopping_cart_badge']")).Text;
                }
                catch (NoSuchElementException)
                {
                    return "0";
                }
            }
        }

        public bool HasItems => int.Parse(CartItemCounterText) > 0;

        public int ItemCount => int.Parse(CartItemCounterText);

        public CartComponent InjectUserWithItems()
        {
            ((IJavaScriptExecutor) _driver).ExecuteScript(
                "window.sessionStorage.setItem('session-username', 'standard-user')");
            ((IJavaScriptExecutor) _driver).ExecuteScript("window.sessionStorage.setItem('cart-contents', '[4,1]')");
            _driver.Navigate().Refresh();
            return this;
        }
    }
}