using TAFrame.Core.Base;
using TAFrame.Core.Driver;
using TAFrame.Platform.Pages;

namespace TAFrame.Test
{
    class LoginTests : BaseTest
    {
        [Test]
        public void ValidLoginTest()
        {
            var loginPage = new LoginPage().NavigateTo();
            loginPage.Login("student", "Password123");

            Assert.IsTrue(DriverFactory.GetDriver().Url.Contains("logged-in-successfully"));
        }
    }
}
