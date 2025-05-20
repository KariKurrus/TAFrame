using OpenQA.Selenium;
using TAFrame.Core.Driver;

namespace TAFrame.Core.Base
{
    [TestFixture]
    public abstract class BaseTest
    {
        protected IWebDriver Driver => DriverFactory.GetDriver();

        [SetUp]
        public void Setup()
        {
            Driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void TearDown()
        {
            DriverFactory.QuitDriver();
        }
    }
}
