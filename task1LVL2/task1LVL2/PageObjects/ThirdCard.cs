using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace task1LVL2.PageObjects
{
    public class ThirdCard:Form
    {
        public ThirdCard() : base(By.XPath("//div[@class='personal-details']"), "ThirdCard") { }
    }
}
