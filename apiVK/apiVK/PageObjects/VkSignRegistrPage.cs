using Aquality.Selenium.Browsers;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace apiVK.PageObjects
{
    public class VkSignRegistrPage:Form
    {
        private IButton _signInButton = AqualityServices.Get<IElementFactory>().
            GetButton(By.XPath("//button[contains(@class,'signInButton')]"), "SignIn Button");

        public VkSignRegistrPage() : base(By.Id("index_login"), "Sign and Register Form") { }

        public void ClickSignInButton()
        {
            _signInButton.Click();
        }
    }
}
