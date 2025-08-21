using TAFrame.Core.Base;
using TAFrame.Platform.Pages;

namespace TAFrame.Test
{
    class LoginTests : BaseTest
    {
        [Test]
        [Description("Example Login Test for OLX")]
        [TestCase("a", "v")]
        [TestCase("a", "v")]
        [TestCase("a", "v")]
        [TestCase("a", "v")]
        public void ExampleTest(string a, string b)
        {
            var homePage = new HomePage()
                .NavigateToBase();
            homePage.ProfileButton.WaitUntilElelemntIsClickable();
            homePage.ProfileButton.Click();

            var loginPage = new LoginPage();
                loginPage.Login(a, b);

            loginPage.AssertSubmit();
        }
    }
}
