using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Reflection;
using TAFrame.Core.Attribute;
using TAFrame.Core.Driver;

namespace TAFrame.Core.Base
{
    public abstract class BasePage<T> where T : BasePage<T>
    {
        protected IWebDriver Driver => DriverFactory.GetDriver();
        protected virtual string BaseUrl => "https://www.olx.ua/uk/";
        protected BasePage()
        {
            InitElements();
        }

        private void InitElements()
        {
            var props = GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            foreach (var prop in props)
            {
                var locatorAttr = prop.GetCustomAttribute<LocatorAttribute>();
                if (locatorAttr != null && prop.PropertyType == typeof(BaseElement))
                {
                    var element = new BaseElement(locatorAttr.Locator);
                    prop.SetValue(this, element);
                }
            }
        }

        public T NavigateToBase()
        {
            Driver.Navigate().GoToUrl(BaseUrl);
            WaitForPageLoad();
            return (T)this;
        }

        public T NavigateTo()
        {
            var urlAttr = GetType().GetCustomAttribute<PageUrlAttribute>();

            if (urlAttr != null)
            {
                Driver.Navigate().GoToUrl(BaseUrl + urlAttr.Url);
                WaitForPageLoad();
                return (T)this;
            }

            throw new InvalidOperationException("Page URL not set via PageUrl attribute.");
        }

        private void WaitForPageLoad(int timeoutSeconds = 10)
        {
            var js = (IJavaScriptExecutor)Driver;
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeoutSeconds))
            {
                PollingInterval = TimeSpan.FromMilliseconds(500)
            };
            wait.Until(d => js.ExecuteScript("return document.readyState").ToString() == "complete");
        }
    }
}
