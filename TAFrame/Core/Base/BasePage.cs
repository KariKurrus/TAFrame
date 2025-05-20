using OpenQA.Selenium;
using System.Reflection;
using TAFrame.Core.Attribute;
using TAFrame.Core.Driver;

namespace TAFrame.Core.Base
{
    public abstract class BasePage<T> where T : BasePage<T>
    {
        protected IWebDriver Driver => DriverFactory.GetDriver();
        protected virtual string BaseUrl => "https://practicetestautomation.com/";
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

        public T NavigateTo()
        {
            var urlAttr = GetType().GetCustomAttribute<PageUrlAttribute>();
            if (urlAttr != null)
            {
                Driver.Navigate().GoToUrl(BaseUrl + urlAttr.Url);
                return (T)this;
            }

            throw new InvalidOperationException("Page URL not set via PageUrl attribute.");
        }
    }
}
