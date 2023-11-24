using Microsoft.Playwright;
using NUnit.Framework;
using PlaywrightPOMUnit.BasePage;
using PlaywrightPOMUnit.Pages;

namespace PlaywrightPOMUnit.Test
{
    internal class PlaywrightTestCases : TestBase
    {
        IPage page;
        TestScenario1 scenario1;
        TestScenario2 scenario2;
        TestScenario3 scenario3;

        [OneTimeSetUp]
        public async Task Setup()
        {
            scenario1 = new ();
            scenario2 = new ();
            scenario3 = new ();
        }

        [Test,Order(1)]
        public void ScenarioTest1()
        {
            scenario1.VerifySimpleDemoFromLinkIsPresent();
            _ = scenario1.EnterMessageAndVerifyMessageAfterCLickOnCheckValueButtonAsync();
        }

        [Test,Order(2)]
        public void ScenarioTest2()
        {
            scenario2.VerifyAfterValueChangeTo_95_AfterUserDragSliderAsync();
        }

        [Test, Order(3)]
        public void ScenarioTest3()
        {
            scenario3.CheckValidationMessage();
           // scenario3.SubmitDetailsAndVerifySuccessMessage();
        }
    }
}
