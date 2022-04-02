using Aquality.Selenium.Browsers;
using NUnit.Framework;

namespace task1LVL2
{
    public abstract class BaseTest
    {
        [SetUp]
        public void Setup()
        {
            var browser = AqualityServices.Browser;
            browser.Maximize();
            browser.GoTo("https://userinyerface.com/");            
        }

        [TearDown]
        public void End()
        {
            AqualityServices.Browser.Quit();
        }
    }
}
