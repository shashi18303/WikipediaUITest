using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace WikipediaUITest.Pages
{
    public abstract class BasePage
    {
        protected IWebDriver Driver;
        protected WebDriverWait Wait;

        protected BasePage(IWebDriver driver, int waitSeconds)
        {
            Driver = driver;
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitSeconds));
        }

        protected IWebElement WaitUntilVisible(By locator)
            => Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
    }
}
