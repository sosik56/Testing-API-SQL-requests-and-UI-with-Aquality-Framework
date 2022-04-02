using System;
using Aquality.Selenium.Browsers;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace task1LVL2.PageObjects
{
    public class FirstCard:Form
    {
        public FirstCard() : base(By.XPath("//div[@class='login-form__container']"),"FirstCard") { }

        private ITextBox _passwordTextBox = AqualityServices.Get<IElementFactory>()
            .GetTextBox(By.XPath("//input[@placeholder='Choose Password']"),
            "Password TextBox");

        private ITextBox _mailTextBox = AqualityServices.Get<IElementFactory>().GetTextBox(By.XPath("//input[@placeholder='Your email']"),
            "Email TextBox");

        private ITextBox _domainTextBox = AqualityServices.Get<IElementFactory>().GetTextBox(By.XPath("//input[@placeholder='Domain']"),
            "Domain TextBox");

        private ICheckBox _termsCheckBox = AqualityServices.Get<IElementFactory>().GetCheckBox(By.XPath("//span[@class='checkbox']"),
            "Terms CheckBox");

        private IButton _nextButton = AqualityServices.Get<IElementFactory>().GetButton(By.XPath("//a[text()='Next']"), "Next Button");

        private IButton _dropListButtom = AqualityServices.Get<IElementFactory>()
            .GetButton(By.XPath("//div[contains(@class,'dropdown dropdown')]"),
            "drop list");

        private ILabel _timerOnPageLable = AqualityServices.Get<IElementFactory>().GetLabel(By.XPath("//div[contains(@class,'timer timer--white')]")
            ,"Timer on page Lable");

        private By _locatorForEmailEnd(string value)
            => By.XPath($"//div[@class='dropdown__list']//div[{value}]");

        public void ClearAndEnterThePassword(string pass)
        {
            _passwordTextBox.ClearAndType(pass);
        }

        public void ClearAndEnteTheEmail(string email)
        {
            _mailTextBox.ClearAndType(email);
        }

        public void ClearAndEnterTheDomain(string domain)
        {
            _domainTextBox.ClearAndType(domain);
        }

        public void CheckTermsCheckBox()
        {
            _termsCheckBox.Check();
            
        }

        public void ClickNextButton()
        {
            _nextButton.Click();            
        }

        public void PickRandomEmailEnd()
        {
            _dropListButtom.Click();
            Random rnd = new Random();
            string randomValue = rnd.Next(2, 12).ToString();
            IButton dropButtons = AqualityServices.Get<IElementFactory>().GetButton(_locatorForEmailEnd(randomValue), "drop list");
            dropButtons.Click();
        }  
        
        public string GetTimerOnPageValue()
        {
           return _timerOnPageLable.GetText();
        }
    }
}
