using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using Language_and_skill_feature.Pages;
using Language_and_skill_feature.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools;
using OpenQA.Selenium.Support.UI;
using Reqnroll;
using static System.Collections.Specialized.BitVector32;

namespace Login_Feature.StepDefinitions
{
    
    [Binding]    

    public class LoginFeatureStepDefinitions
    {
        private IWebDriver driver;

        public LoginFeatureStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
        }


        [Given("I get into the homepage")]
        public void GivenIGetIntoTheHomepage()
        {
            
        }

        [When("I enter valid credentials")]
        public void WhenIEnterValidCredentials()
        {
            Loginpage loginpage = new Loginpage();
            loginpage.ValidLoginAction(driver);

        }

        [Then("I should be able to login successfully")]
        public void ThenIShouldBeAbleToLoginSuccessfully()
        {
            //Wait for the page to load
            Thread.Sleep(5000);


            //Verify the login is successful by checking the URL

            IWebElement WelcomeMessage = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/div[1]/div[2]/div/span"));

            if (WelcomeMessage.Text == "Hi Ramkumar")
            {
                Assert.Pass("Login successful");
            }
            else
            {
                Assert.Fail("Login failed");
            }

        }

        [When("I enter invalid {string} and {string}")]
        public void WhenIEnterInvalidAnd(string email, string password)
        {
            Loginpage loginpage = new Loginpage();
            loginpage.InvalidLoginAction(driver, email, password);

        }

        [Then("I should be see an error message for invalid credentials")]
        public void ThenIShouldBeSeeAnErrorMessageForInvalidCredentials()
        {


            //Wait for the page to load
            Thread.Sleep(10000);

            IWebElement VerificationButton = driver.FindElement(By.XPath("//*[@id=\"submit-btn\"]"));
            VerificationButton.Click();

            //Wait for the error message to be displayed
            wait.WaitToBeVisible(driver, "CssSelector", "body > div.ns-box.ns-growl.ns-effect-jelly.ns-type-error.ns-show", 10);

            IWebElement Message = driver.FindElement(By.CssSelector("body > div.ns-box.ns-growl.ns-effect-jelly.ns-type-error.ns-show"));
            Console.WriteLine(Message.Text);
            if (Message.Text == "Email Verification Failed")
            {
                Assert.Pass("Error message displayed for invalid credentials");
            }
            else
            {
                Assert.Fail("No error message displayed for invalid credentials");
            }            
        }


        [When("I enter blank {string} and valid {string}")]
        public void WhenIEnterBlankAndValid(string email, string password)
        {
            Loginpage loginpage = new Loginpage();
            loginpage.InvalidLoginAction(driver, email, password);
            Thread.Sleep(3000);
        }

        [Then("I should see an error message for blank {string}")]
        public void ThenIShouldSeeAnErrorMessageForBlank(string email)
        {
            IWebElement EmailField = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[1]/div"));

            if (EmailField.Text == "Please enter a valid email address")
            {
                Assert.Pass("Error message displayed for blank email");
            }
            else
            {
                Assert.Fail("No error message displayed for blank email field");
            }
        }

        [When("I enter valid {string} and blank {string}")]
        public void WhenIEnterValidAndBlank(string email, string password)
        {
            Loginpage loginpage = new Loginpage();
            loginpage.InvalidLoginAction(driver, email, password);
        }

        [Then("I should see an error message for {string}")]
        public void ThenIShouldSeeAnErrorMessageFor(string password)
        {
            IWebElement PasswordField = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[2]/div"));
            if (PasswordField.Text == "Password must be at least 6 characters")
            {
                Assert.Pass("Error message displayed for blank password");
            }
            else
            {
                Assert.Fail("No error message displayed for blank password field");
            }

        }

       
    }    

}          



        




