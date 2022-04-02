using Aquality.Selenium.Browsers;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using IElementFactory = Aquality.Selenium.Elements.Interfaces.IElementFactory;
using Aquality.Selenium.Elements.Interfaces;

namespace task1LVL2.PageObjects
{
    public class MainPage : Form
    {
        public MainPage() : base(By.XPath("//button[@class='start__button' and text()='NO']"), "Button") { }
        
        private ILink _linkToForm = AqualityServices.Get<IElementFactory>().GetLink(By.XPath("//a[contains(@href, 'game.html')]"),
            "Link to 1 card");

        public void ClickToLinkToCard1()
        {
            _linkToForm.Click();            
        }
    }
}
