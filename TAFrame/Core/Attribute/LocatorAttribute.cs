using OpenQA.Selenium;
using TAFrame.Core.Enums;

namespace TAFrame.Core.Attribute
{
    [AttributeUsage(AttributeTargets.Property)]
    public class LocatorAttribute : System.Attribute
    {
        public By Locator { get; }

        public LocatorAttribute(How how, string usingValue)
        {
            Locator = how switch
            {
                How.Id => By.Id(usingValue),
                How.XPath => By.XPath(usingValue),
                How.CssSelector => By.CssSelector(usingValue),
                How.Name => By.Name(usingValue),
                _ => throw new ArgumentException("Unsupported locator type")
            };
        }
    }
}
