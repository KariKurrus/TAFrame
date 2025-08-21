using TAFrame.Core.Attribute;
using TAFrame.Core.Base;
using TAFrame.Core.Enums;

namespace TAFrame.Platform.Pages
{
    public class BaseLayoutPage : BasePage<BaseLayoutPage>
    {
        [Locator(How.XPath, "//a[contains(@href,'/account/')]")]
        public BaseElement ProfileButton { get; set; }
    }
}
