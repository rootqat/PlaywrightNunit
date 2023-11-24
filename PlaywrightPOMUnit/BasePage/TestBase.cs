
using Microsoft.Playwright;
using NUnit.Framework;
using PlaywrightPOMUnit.Config;
using PlaywrightPOMUnit.Driver;

namespace PlaywrightPOMUnit.BasePage
{
    public class TestBase: PlaywrightDriverInitializer
    {
        private static PlaywrightDriverInitializer _playwrightDriverInitializer;
        private static PlaywrightDriver _playwrightDriver;
        private TestSettings _testSettings;
        public static IPage page;

        [OneTimeSetUp]
        public async Task SetUp()
        {
            _testSettings = ConfigReader.ReadConfig();
            _playwrightDriverInitializer = new();
            _playwrightDriver = new(_testSettings, _playwrightDriverInitializer);
            page = await _playwrightDriver.Page;
            await page.GotoAsync(_testSettings.ApplicationUrl);
        }


        [OneTimeTearDown]
        public void TearDown()
        {
           _playwrightDriver.Dispose();
        }
    }
}
