using TAFrame.Core.Attribute;
using TAFrame.Core.Base;
using TAFrame.Core.Enums;

namespace TAFrame.Platform.Pages
{
    [PageUrl("practice-test-login/")]
    public class LoginPage : BasePage<LoginPage>
    {
        [Locator(How.Id, "username")]
        public BaseElement UsernameField { get; set; }

        [Locator(How.Id, "password")]
        public BaseElement PasswordField { get; private set; }

        [Locator(How.Id, "submit")]
        public BaseElement LoginButton { get; private set; }

        public void Login(string username, string password)
        {
            UsernameField.Type(username);
            PasswordField.Type(password);
            LoginButton.Click();
        }
    }
}
