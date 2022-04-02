using Aquality.Selenium.Browsers;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace task1LVL2.PageObjects
{
    public class HelpForm:Form
    {
        public HelpForm() : base(By.XPath("//div[@class='help-form']"), "Help Form") { }

        private IButton _sendToBottomHelpFormButton = AqualityServices.Get<IElementFactory>()
            .GetButton(By.XPath("//div[@class='help-form']//button[contains(@class,'send-to-bottom')]")
            , "Send to bottom help form button");

        public void ClickSendToBottomHelpFormButton()
        {
            _sendToBottomHelpFormButton.ClickAndWait();
        }
    }
}
