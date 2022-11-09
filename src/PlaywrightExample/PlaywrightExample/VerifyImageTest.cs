namespace PlaywrightExample
{
    public class VerifyImageTest
    {
        [SetUp]
        public void Setup()
        {
            VerifyPlaywright.Enable();
        }

        [Test]
        public async Task Verify_Whole_Playwright_Dotnet_Page()
        {
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync();
            var page = await browser.NewPageAsync();
            await page.GotoAsync("https://playwright.dev/dotnet/");
            //doesnt seem to work because of random ids in the JavaScript strings
            await Verify(page);
        }

        [Test]
        public async Task Verify_Playwright_Logo_Image()
        {
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync();
            var page = await browser.NewPageAsync();
            await page.GotoAsync("https://playwright.dev/dotnet/");
            var logoLocator = page.GetByRole(AriaRole.Link, 
                new() { NameString = "Playwright logo Playwright for .NET" });
            var logoElement = await logoLocator.ElementHandleAsync();
            await Verify(logoElement!);
        }

        [Test]
        public async Task Verify_Logo_Light_Vs_Dark_Mode()
        {
            using var playwright = await Playwright.CreateAsync();
            BrowserTypeLaunchOptions launchOptions = new BrowserTypeLaunchOptions
            {
                Headless = false,
                SlowMo = 500
            };
            await using var browser = await playwright.Chromium.LaunchAsync(launchOptions);
            var page = await browser.NewPageAsync();
            await page.GotoAsync("https://playwright.dev/dotnet/");
            await page.ClickAsync("div[class*='colorModeToggle'] button[aria-label*='Switch']");
            var logoLocator = page.GetByRole(AriaRole.Link,
                new() { NameString = "Playwright logo Playwright for .NET" });
            var logoElement = await logoLocator.ElementHandleAsync();
            await Verify(logoElement!);
        }
    }
}