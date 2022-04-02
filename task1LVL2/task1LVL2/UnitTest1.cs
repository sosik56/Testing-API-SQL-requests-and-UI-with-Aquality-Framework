using NUnit.Framework;
using task1LVL2.PageObjects;


namespace task1LVL2
{
    public class Tests:BaseTest
    {        
        [Test]
        public void Test1()
        {
            MainPage mainPage = new MainPage();
            FirstCard firstCard = new FirstCard();
            SecondCard secondCard = new SecondCard();
            ThirdCard thirdCard = new ThirdCard();
                       
            Assert.IsTrue(mainPage.State.IsDisplayed, "main page is not open");
            mainPage.ClickToLinkToCard1(); 
            Assert.IsTrue(firstCard.State.IsDisplayed, "first card is not open");
            
            string randomGuid = UtilityClass.GetRandomGuid().ToUpper();

            firstCard.ClearAndEnterThePassword(randomGuid);
            firstCard.ClearAndEnteTheEmail(randomGuid);
            firstCard.ClearAndEnterTheDomain(randomGuid);
            firstCard.CheckTermsCheckBox();
            firstCard.PickRandomEmailEnd();           
            firstCard.ClickNextButton();
            Assert.IsTrue(secondCard.State.IsDisplayed, "second card is not open");

            secondCard.UploadAvatarFromDownloadDirectory("avatar.png");
            secondCard.ClickUnselectAllLable();
            secondCard.PickThreeRandomInterests();
            secondCard.ClickNextButton();
            Assert.IsTrue(thirdCard.State.IsDisplayed, "Third card is not open");            
        }   
        
        [Test]
        public void Test2()
        {
            MainPage mainPage = new MainPage();
            HelpForm helpForm = new HelpForm();

            Assert.IsTrue(mainPage.State.IsDisplayed, "main page is not open");
            mainPage.ClickToLinkToCard1();
            helpForm.ClickSendToBottomHelpFormButton();
            Assert.IsFalse(helpForm.State.IsDisplayed, "Help Form still visibale");           
        }

        [Test]
        public void Test3()
        {
            MainPage mainPage = new MainPage();
            CookiesForm cookiesForm = new CookiesForm();

            Assert.IsTrue(mainPage.State.IsDisplayed, "main page is not open");
            mainPage.ClickToLinkToCard1();
            cookiesForm.AcceptCookies();
            Assert.IsFalse(cookiesForm.State.IsDisplayed, "Help Form still visibale");           
        }

        [Test]
        public void Test4()
        {
            MainPage mainPage = new MainPage();
            FirstCard firstCard = new FirstCard();

            Assert.IsTrue(mainPage.State.IsDisplayed, "main page is not open");
            mainPage.ClickToLinkToCard1();
            Assert.AreEqual(firstCard.GetTimerOnPageValue(), "00:00:00", "Timer starts not with '00:00:00'");           
        }
    }
}