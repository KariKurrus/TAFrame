using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TAFrame.Core.Logger;

namespace TAFrame.Core.Driver
{
    public static class DriverFactory
    {
        [ThreadStatic]
        private static IWebDriver? _driver;

        public static IWebDriver GetDriver()
        {
            if (_driver == null)
            {
                SimpleLogger.Log("Creating new ChromeDriver instance.", Enums.LogLevel.Debug);
                _driver = new ChromeDriver();
            }
            return _driver;
        }

        public static void QuitDriver()
        {
            if (_driver != null)
            {
                SimpleLogger.Log("Quitting and disposing ChromeDriver instance.", Enums.LogLevel.Debug);
                _driver.Quit();
                _driver.Dispose();
                _driver = null;
            }
        }
    }
}
