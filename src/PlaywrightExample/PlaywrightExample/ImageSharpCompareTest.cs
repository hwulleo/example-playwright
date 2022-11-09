using Codeuctivity.ImageSharpCompare;
using SixLabors.ImageSharp;

namespace PlaywrightExample
{
    public class ImageSharpCompareTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public async Task Compare_Playwright_Homepage_Image()
        {
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync();
            var page = await browser.NewPageAsync();
            await page.GotoAsync("https://playwright.dev/dotnet/");
            var bytes = await page.ScreenshotAsync();
            using var actual = Image.Load(bytes);
            //using var expected = Image.Load(expected_filename);
            //Assert.IsTrue(ImageSharpCompare.ImagesAreEqual(actual, expected), expected_filename);


        }
    }
}