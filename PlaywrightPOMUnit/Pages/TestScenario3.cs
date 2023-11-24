using Microsoft.Playwright;
using NUnit.Framework;
using PlaywrightPOMUnit.BasePage;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace PlaywrightPOMUnit.Pages
{
    internal class TestScenario3:TestBase
    {
        private ILocator formtextLink = page.Locator("a:text('Input Form Submit')");
        private ILocator submitButton = page.Locator("button:text('Submit')");
        private ILocator nameTextbox = page.Locator("//input[@id='name']");
        private ILocator emailTextBox = page.Locator("//input[@id='inputEmail4']");
        private ILocator pwdTextBox = page.Locator("//input[@id='inputPassword4']");
        private ILocator cmpTextBox = page.Locator("//input[@id='company']");
        private ILocator websiteTextBox = page.Locator("//input[@id='websitename']");
        private ILocator countryDrpdwn = page.Locator("//select[@name='country']");
        private ILocator cityTextBox = page.Locator("//input[@id='inputCity']");
        private ILocator add1TextBox = page.Locator("//input[@id='inputAddress1']");
        private ILocator add2TextBox = page.Locator("//input[@id='inputAddress2']");
        private ILocator stateTextBox = page.Locator("//input[@id='inputState']");
        private ILocator zipcodeTextBox = page.Locator("//input[@id='inputZip']");
        private ILocator successMsg = page.Locator("//p[@class='success-msg hidden']");
        string actualMsg = "Please fill out this field.";
        string submitSuccessMsg = "Thanks for contacting us, we will get back to you shortly.";

        public async void CheckValidationMessage()
        {
            string actualErrorMsg = "Please fill in this field.";

            formtextLink.ClickAsync();
            Thread.Sleep(1000);
            submitButton.ClickAsync();
            try
            {
                IElementHandle nameInput1 = await page.QuerySelectorAsync("//input[@id='name']");
                var validationMessage = nameTextbox.GetAttributeAsync("validationMessage");
                var expectedErrorMsg =  page.EvaluateAsync("input => input.validationMessage", nameInput1);

                //Console.WriteLine(validationMessage);

                /*   //Assert.That(actualMsg, Is.EqualTo(expectedErrorMsg.ToString()));*//*
                   var name =  page.QuerySelectorAsync("//input[name='name']");
                   
                   bool isValid = await page.EvaluateAsync<bool>("(input) => input.checkValidity()", name);
                   string expectedErrorMsg = await page.EvaluateAsync<string>("(input) => input.validationMessage", name);

                   Console.WriteLine("msg = " + expectedErrorMsg);*/

                //Assert.Equal(actualErrorMsg, expectedErrorMsg);

                if (actualErrorMsg.Equals(expectedErrorMsg))
                {
                    Console.WriteLine("Error message validation passed.");
                }
                else
                {
                    Console.WriteLine("Error message validation failed.");
                }

            }
            catch (Exception ex) { 
                Console.WriteLine(ex.Message);
            }
        }

        public void SubmitDetailsAndVerifySuccessMessage()
        {
            try
            {
                nameTextbox.FillAsync("TestUser");
                emailTextBox.FillAsync("testUser@gmail.com");
                pwdTextBox.FillAsync("Test@123");
                cmpTextBox.FillAsync("Abc");
                websiteTextBox.FillAsync("http://www.abc.com");
                countryDrpdwn.SelectOptionAsync("United States");
                cityTextBox.FillAsync("XYZ");
                add1TextBox.FillAsync("xyz");
                add2TextBox.FillAsync("xyz");
                stateTextBox.FillAsync("co");
                zipcodeTextBox.FillAsync("4102");
                submitButton.ClickAsync();

                Thread.Sleep(2000);
                string expectedMessge = successMsg.TextContentAsync().Result;
                Assert.That(submitSuccessMsg, Is.EqualTo(expectedMessge));
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

        }

    }
}
