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

        public void Click()
        {
            Log($"Clicking element: {_locator}");
            Element.Click();
        }

        public void Type(string text)
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
