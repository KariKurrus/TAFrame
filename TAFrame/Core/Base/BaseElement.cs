using OpenQA.Selenium;
using TAFrame.Core.Driver;
using static TAFrame.Core.Logger.SimpleLogger;

namespace TAFrame.Core.Base
{
    public class BaseElement
    {
        private readonly By _locator;
        private IWebDriver Driver => DriverFactory.GetDriver();

        public BaseElement(By locator)
        {
            _locator = locator;
            Log($"Created {GetType().Name} with locator: {_locator}");
        }

        private IWebElement Element
        {
            get
            {
                var el = Driver.FindElement(_locator);
                Log($"Located element: {_locator}");
                return el;
            }
        }
        public IWebElement WaitUntilElelemntIsVisible(int timeoutInSeconds = 10)
        {
            Log($"Waiting for element to be visible: {_locator} for up to {timeoutInSeconds} seconds");
            var wait = new OpenQA.Selenium.Support.UI.WebDriverWait(Driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_locator));
            Log($"Element is now visible: {_locator}");
            return Element;
        }

        public IWebElement WaitUntilElelemntIsClickable(int timeoutInSeconds = 10)
        {
            Log($"Waiting for element to be visible: {_locator} for up to {timeoutInSeconds} seconds");
            var wait = new OpenQA.Selenium.Support.UI.WebDriverWait(Driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(_locator));
            Log($"Element is now visible: {_locator}");
            return Element;
        }


        public void Click()
        {
            Log($"Clicking element: {_locator}");
            Element.Click();
        }

        public void SendText(string text)
        {
            Log($"Typing '{text}' into element: {_locator}");
            Element.SendKeys(text);
        }

        public string Text
        {
            get
            {
                var value = Element.Text;
                Log($"Getting text from element: {_locator} -> '{value}'");
                return value;
            }
        }

        public bool IsDisplayed
        {
            get
            {
                var displayed = Element.Displayed;
                Log($"Checking if element is displayed: {_locator} -> {displayed}");
                return displayed;
            }
        }
    }
}
