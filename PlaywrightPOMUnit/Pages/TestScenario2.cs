using Microsoft.Playwright;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using NUnit.Framework;
using PlaywrightPOMUnit.BasePage;

namespace PlaywrightPOMUnit.Pages
{
    internal class TestScenario2 : TestBase
    {
        private readonly ILocator dragDropLink = page.Locator("//a[contains(.,'Drag & Drop Sliders')]");
        private ILocator rangeValueLocator = page.Locator("//output[@id='rangeSuccess']");
        private ILocator sliderLocator = page.Locator("(//input[@value='15'])[1]");

        public void VerifyAfterValueChangeTo_95_AfterUserDragSliderAsync()
        {
            try
            {
                _ = dragDropLink.ClickAsync();
                Thread.Sleep(5000);
                _ = DragSlider(sliderLocator, "95");

            }
            catch (Exception ex) { Console.WriteLine(ex); }
        }

        public async Task DragSlider(ILocator sliderStarPosition, string target)
        {
            Thread.Sleep(3000);
            var initialText = rangeValueLocator.InnerTextAsync().Result;
            Console.WriteLine("Initial text: " + initialText);
            var srcBound = await sliderStarPosition.BoundingBoxAsync();
            if (srcBound != null)
            {
                page.Mouse.MoveAsync(srcBound.X + srcBound.Width / 2, srcBound.Y + srcBound.Height / 2);
                page.Mouse.DownAsync();
                page.Mouse.MoveAsync(srcBound.X + 462, srcBound.Y + srcBound.Height / 2);
                page.Mouse.UpAsync();
                var text = rangeValueLocator.InnerTextAsync().Result;
                Assert.That(target, Is.EqualTo(text));
            }

        }
    }
}

