using System;
using System.IO;
using Aquality.Selenium.Browsers;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using AutoItX3Lib;

namespace task1LVL2.PageObjects
{
   public  class SecondCard:Form
    {
        public SecondCard() : base(By.XPath("//div[@class='avatar-and-interests']"), "SecondCard") { }

        private ILink _uploadButton = AqualityServices.Get<IElementFactory>().GetLink(By.XPath("//a[contains(@class,'upload-button')]")
            ,"Upload Button");
        private ILabel _unselectAllLable = AqualityServices.Get<IElementFactory>().GetLabel(By.XPath("//label[contains(@for,'unselectall')]"),
            "Unselect All Lable");
        private IButton _nextButton = AqualityServices.Get<IElementFactory>().GetButton(By.XPath("//button[@name='button' and text()='Next']")
            , "Next Button");
        private By _locatorForIterests(string numberOfInterests) =>
            By.XPath($"//div[contains(@class,'interests-list__item')][{numberOfInterests}]//span[@class='checkbox__box']");

        public void UploadAvatarFromDownloadDirectory(string fileName)
        {
            FileInfo fileInfo = new FileInfo(Path.Combine(AqualityServices.Browser.DownloadDirectory, fileName));
            _uploadButton.Click();

            AutoItX3 autoIt = new AutoItX3();

            autoIt.WinWait("Open");
            autoIt.WinActivate("Open");                       
            autoIt.Send(fileInfo.FullName);            
            autoIt.Send("{ENTER}");
        }

        public void ClickUnselectAllLable()
        {
            _unselectAllLable.Click();
        }
        
        public void PickThreeRandomInterests()
        {
            int[] arrWithNumbersOfIneterests = new int[4];
            arrWithNumbersOfIneterests[0] = 18; //this for checkall
            
            for (int i = 1; i < 4; i++)
            {
                Random rnd = new Random();
                int randomValue = rnd.Next(1, 21);
                bool repeat = false;
                foreach (var item in arrWithNumbersOfIneterests)
                {
                    if (item == randomValue)
                        repeat = true;
                }

                if (!repeat)
                {
                    arrWithNumbersOfIneterests[i] = randomValue;
                    ICheckBox dropButtons = AqualityServices.Get<IElementFactory>().GetCheckBox(_locatorForIterests(randomValue.ToString()),
                        "Check Box");
                    dropButtons.Check();
                }
                else
                    i--;
            }
        }

        public void ClickNextButton()
        {
            _nextButton.Click();
        }
    }
}
