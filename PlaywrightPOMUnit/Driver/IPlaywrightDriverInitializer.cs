using Microsoft.Playwright;
using PlaywrightPOMUnit.Config;

namespace PlaywrightPOMUnit.Driver
{
    public interface IPlaywrightDriverInitializer
    {
        Task<IBrowser> GetChromiumDriverAsync(TestSettings testSettings);
        Task<IBrowser> GetFirefoxDriverAsync(TestSettings testSettings);
    }
}