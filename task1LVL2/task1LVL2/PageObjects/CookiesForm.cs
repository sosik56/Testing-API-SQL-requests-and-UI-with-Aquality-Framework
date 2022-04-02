using Aquality.Selenium.Browsers;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace task1LVL2.PageObjects
{
    public class CookiesForm:Form
    {
        public CookiesForm():base(By.XPath("//div[@class='cookies']"),"Cookies Form") { }

        private IButton _acceptCookiesButton = AqualityServices.Get<IElementFactory>()
            .GetButton(By.XPath("//div[@class='cookies']//button[contains(text(),'Not really')]")
            , "Accept Cookies button");

        public void AcceptCookies()
        {
            _acceptCookiesButton.WaitAndClick();
        }
    }
}
