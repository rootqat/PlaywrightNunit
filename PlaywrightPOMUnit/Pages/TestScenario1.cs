using Microsoft.Playwright;
using NUnit.Framework;
using PlaywrightPOMUnit.BasePage;

namespace PlaywrightPOMUnit.Pages
{
    internal class TestScenario1:TestBase
    {
        private ILocator simpleDemoFormLink = page.Locator("//a[contains(.,'Simple Form Demo')]");
        private ILocator msgTextBox = page.Locator("//input[@id='user-message']");
        private ILocator getCheckValuebtn = page.Locator("//button[@id='showInput']");
        private ILocator txtMessage = page.Locator("//p[@id='message']");

        string message = "Welcome to LambdaTest";
        string fomrName = "Simple Form Demo";
       
        public void VerifySimpleDemoFromLinkIsPresent()
        {
            try
            {
                Thread.Sleep(5000);
                string txt = simpleDemoFormLink.TextContentAsync().Result;
                Assert.That(txt, Is.EqualTo(fomrName));
            }
            catch (Exception ex) { Console.WriteLine(ex); }
        }

        public async Task EnterMessageAndVerifyMessageAfterCLickOnCheckValueButtonAsync() 
        {
            try
            {
                _ = simpleDemoFormLink.ClickAsync();
                Thread.Sleep(3000);
                _ = msgTextBox.FillAsync(message);
                _ = getCheckValuebtn.ClickAsync();
                Thread.Sleep(3000);
                string actualMessage = txtMessage.TextContentAsync().Result;
                Console.WriteLine("Your message: " + actualMessage);
                Assert.That(message, Is.EqualTo(actualMessage));
            }
           catch(Exception ex) { Console.WriteLine(ex);}
		
	}
}
}
