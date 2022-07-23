namespace PlaywrightExample
{
    public class GoogleTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public async Task Google_Should_Have_Google_Search_Button()
        {
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync();
            var page = await browser.NewPageAsync();
            await page.GotoAsync("https://www.google.com");
            var searchButtonEnabled = await page.Locator("div:not([jsname]) > center > input[value=\"Google Search\"]").IsEnabledAsync();
            Assert.IsTrue(searchButtonEnabled);


        }
    }
}