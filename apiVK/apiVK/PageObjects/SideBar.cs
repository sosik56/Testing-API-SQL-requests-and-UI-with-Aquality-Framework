using apiVK.Models;
using Aquality.Selenium.Browsers;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace apiVK.PageObjects
{
    public class SideBar:Form
    {
        private IButton _myPageButton = AqualityServices.Get<IElementFactory>()
            .GetButton(By.Id("l_pr"), "My page Button");

        public SideBar() : base(By.Id("side_bar"),"side bar") { }

        public void ClickMyPageButton()
        {
            _myPageButton.Click();
        }
    }
}
