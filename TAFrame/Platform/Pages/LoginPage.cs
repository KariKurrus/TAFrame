using TAFrame.Core.Attribute;
using TAFrame.Core.Base;
using TAFrame.Core.Driver;
using TAFrame.Core.Enums;

namespace TAFrame.Platform.Pages
{
    public class LoginPage : BasePage<LoginPage>
    {
        [Locator(How.Id, "username")]
        public BaseElement UsernameField { get; set; }

        [Locator(How.Id, "password")]
        public BaseElement PasswordField { get; private set; }

        [Locator(How.Id, "Login")]
        public BaseElement LoginButton { get; private set; }

        [Locator(How.XPath, "//*[@type='submit']")]
        public BaseElement SubmitButton { get; private set; }

        public void Login(string username, string password)
        {
            LoginButton.WaitUntilElelemntIsClickable();

            UsernameField.SendText(username);
            PasswordField.SendText(password);
            LoginButton.Click();
        }

        public void AssertSubmit()
        {
            SubmitButton.WaitUntilElelemntIsClickable();
            Assert.AreEqual("Підтвердити", SubmitButton.Text, "Submit button text does not match expected value.");
        }
    }
}
