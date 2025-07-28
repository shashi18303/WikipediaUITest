using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;

namespace WikipediaUITest.Drivers
{
    public static class WebDriverFactory
    {
        public static IWebDriver CreateDriver()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");

            // Use the Drivers folder in the output directory
            string driverPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Drivers");

            return new ChromeDriver(driverPath, options);
        }
    }
}
