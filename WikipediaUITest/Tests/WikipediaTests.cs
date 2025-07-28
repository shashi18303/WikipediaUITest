using NUnit.Framework;
using OpenQA.Selenium;
using WikipediaUITest.Drivers;
using WikipediaUITest.Pages;
using WikipediaUITest.Services;
using System.Threading.Tasks;

namespace WikipediaUITest.Tests
{
    /// <summary>
    /// Contains UI automation tests for verifying Wikipedia content extraction and word count.
    /// </summary>
    [TestFixture]
    public class WikipediaTests
    {
        private IWebDriver driver;
        private WikipediaPage wikiPage;

        /// <summary>
        /// Initializes the WebDriver and sets up the Wikipedia page object before each test.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            driver = WebDriverFactory.CreateDriver();
            wikiPage = new WikipediaPage(driver);
        }

        /// <summary>
        /// Test to navigate to Wikipedia, extract the TDD section text, 
        /// count word frequency, and verify that the word "test" appears in the text.
        /// </summary>
        [Test]
        public async Task ExtractAndCountWords()
        {
            // Step 1: Navigate to the Wikipedia page
            await Task.Run(() => wikiPage.NavigateTo());

            // Step 2: Extract the TDD section text
            var text = await Task.Run(() => wikiPage.GetTddSectionText());

            // Step 3: Process the text for unique words and their counts
            var wordCount = await Task.Run(() => TextProcessor.GetWordCount(text));

            // Step 4: Print extracted text
            TestContext.Out.WriteLine("=== TDD SECTION TEXT ===");
            TestContext.Out.WriteLine(text);

            // Step 5: Print the word frequency
            TestContext.Out.WriteLine("\n=== WORD COUNTS ===");
            foreach (var kv in wordCount)
            {
                TestContext.Out.WriteLine($"{kv.Key} -> {kv.Value}");
            }

            // Step 6: Assert that the word 'test' appears in the text
            Assert.That(wordCount.ContainsKey("test"), Is.True, "Word 'test' should be present.");
        }

        /// <summary>
        /// Cleans up WebDriver resources after each test.
        /// </summary>
        [TearDown]
        public void Teardown()
        {
            driver?.Quit();
            driver?.Dispose();
        }
    }
}
