
using Microsoft.Playwright;
using NUnit.Framework;
using PlaywrightPOMUnit.BasePage;
using PlaywrightPOMUnit.Config;
using PlaywrightPOMUnit.Driver;

namespace PlaywrightPOMUnit
{
    public class UnitTest1 : TestBase
    {
       
        [Test]
        public async Task Test2()
        {
            //var page = await _playwrightDriver.Page;

          // await page.GotoAsync(_testSettings.ApplicationUrl);

            await page.Locator("[data-test='username']").FillAsync("standard_user");

            await page.Locator("[data-test='password']").FillAsync("secret_sauce");
           
            await page.GetByRole(AriaRole.Button, new() { Name = "LOGIN" }).ClickAsync();

            Thread.Sleep(10000);
           
        }
    }
}