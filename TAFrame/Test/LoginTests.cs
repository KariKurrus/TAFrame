using TAFrame.Core.Base;
using TAFrame.Platform.Pages;

namespace TAFrame.Test
{
    class LoginTests : BaseTest
    {
        [Test]
        public void ExampleTest()
        {
            var loginPage = new LoginPage().NavigateToBase();
            loginPage.Login("password", "login");
        }
    }
}
