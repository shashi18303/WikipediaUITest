using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;

namespace WikipediaUITest.Pages
{
    public class WikipediaPage : BasePage
    {
        // Constructor: Pass driver and default wait time (in seconds)
        public WikipediaPage(IWebDriver driver) : base(driver, 10) { }

        // Navigate to Wikipedia Test Automation page
        public void NavigateTo() 
            => Driver.Navigate().GoToUrl("https://en.wikipedia.org/wiki/Test_automation");

        // Extracts the "Test-driven development" section and returns its text
        public string GetTddSectionText()
{
    var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));

    // XPath that works with Wikipedia's headline
    string headingXPath = "//*[contains(@id,'Test-driven_development')]";

    // Scroll to the element before waiting
    IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
    js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight/3);");

    // Wait for heading
    var heading = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(headingXPath)));
    js.ExecuteScript("arguments[0].scrollIntoView(true);", heading);

    string title = heading.Text;

    // Get content after the heading until next heading
    var elements = Driver.FindElements(By.XPath($"({headingXPath})/parent::*/following-sibling::*"));

    List<string> text = new List<string> { title };

    foreach (var el in elements)
    {
        if (el.TagName.StartsWith("h")) break;
        if (el.TagName == "p" || el.TagName == "ul" || el.TagName == "ol")
            text.Add(el.Text);
    }

    return string.Join(" ", text);
}

    }
}
