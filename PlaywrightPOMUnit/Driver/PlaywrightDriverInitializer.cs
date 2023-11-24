using Microsoft.Playwright;
using PlaywrightPOMUnit.Config;

namespace PlaywrightPOMUnit.Driver;

public class PlaywrightDriverInitializer : IPlaywrightDriverInitializer
{
    public const float DEFAULT_TIMEOUT = 50f;

    public async Task<IBrowser> GetFirefoxDriverAsync(TestSettings testSettings)
    {
        var options = GetParameters(testSettings.Args, testSettings.Timeout, testSettings.Headless,
            testSettings.SlowMo);
        options.Channel = "firefox";
        return await GetBrowserAsync(DriverType.Firefox, options);
    }

    public async Task<IBrowser> GetChromiumDriverAsync(TestSettings testSettings)
    {
        var options = GetParameters(testSettings.Args, testSettings.Timeout, testSettings.Headless,
            testSettings.SlowMo);
        options.Channel = "chromium";
        return await GetBrowserAsync(DriverType.Chromium, options);
    }

    private async Task<IBrowser> GetBrowserAsync(DriverType driverType, BrowserTypeLaunchOptions options)
    {
        var playwright = await Playwright.CreateAsync();
        string btype = driverType.ToString().ToLower();
        return await playwright[driverType.ToString().ToLower()].LaunchAsync(options);
    }

    private BrowserTypeLaunchOptions GetParameters(string[]? args, float? timeout,
        bool? headless, float? slowmo)
    {
        return new BrowserTypeLaunchOptions
        {
            Args = args,
            Timeout = ToMilliseconds(timeout),
            Headless = headless,
            SlowMo = slowmo
        };
    }


    private static float? ToMilliseconds(float? seconds)
    {
        return seconds * 1000;
    }

   
}