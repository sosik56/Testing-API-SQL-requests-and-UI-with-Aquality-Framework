using apiVK.UtilityClasses;
using Aquality.Selenium.Browsers;
using NUnit.Framework;

namespace apiVK.BaseClasses
{
    public abstract class BaseTest
    {
        [SetUp]
        public void SetUp()
        {
            var browser = AqualityServices.Browser;
            browser.Maximize();
            browser.GoTo(UtilityClass.ReturnValue("url"));
        }

        [TearDown]
        public void TearDown()
        {
            AqualityServices.Browser.Quit();
        }
    }
}
