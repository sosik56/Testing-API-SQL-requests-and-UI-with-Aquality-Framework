using apiVK.Models;
using Aquality.Selenium.Browsers;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;


namespace apiVK.PageObjects
{
    public class AutorizationPage:Form
    {
        private ITextBox _loginAndPassworField = AqualityServices.Get<IElementFactory>()
            .GetTextBox(By.ClassName("vkc__TextField__input"), "Password and Loggin text field");

        private IButton _enterLoginButton = AqualityServices.Get<IElementFactory>()
            .GetButton(By.XPath("//div[contains(@class,'EnterLogin__button')]//button"), "Enter Login Button");

        private IButton _enterPassButton = AqualityServices.Get<IElementFactory>()
            .GetButton(By.XPath("//div[contains(@class,'EnterPasswordNoUserInfo__buttonWrap')]//button"), "Enter pass button");


        public AutorizationPage() : base(By.ClassName("vkc__PassportBox__container"), "Autorization Container") { }

        public void AutorizationUser(User user)
        {
            ClearAndEnterThePasswordOrLoggin(user.Login);
            ClickEnterLoginButton();
            ClearAndEnterThePasswordOrLoggin(user.Password);
            ClickEnterPassButton();
        }

        public void ClearAndEnterThePasswordOrLoggin(string passOrlog)
        {
            _loginAndPassworField.ClearAndType(passOrlog);
        }

        public void ClickEnterLoginButton()
        {
            _enterLoginButton.Click();
        }

        public void ClickEnterPassButton()
        {
            _enterPassButton.Click();
        }
    }
}
