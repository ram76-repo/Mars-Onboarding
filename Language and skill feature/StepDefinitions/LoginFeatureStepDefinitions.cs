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
        private readonly Loginpage loginpage;
        private readonly Profilepage profilepage;
        private readonly IWebDriver driver;

        public LoginFeatureStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
            loginpage = new Loginpage(this.driver);
            profilepage = new Profilepage(this.driver);
        }       


        [Given("I get into the homepage")]
        public void GivenIGetIntoTheHomepage()
        {
            
           
        }

        [When("I enter valid credentials")]
        public void WhenIEnterValidCredentials()
        {
            loginpage.ValidLoginAction();
        }
              
        
        [Then("I should be able to login successfully")]
        public void ThenIShouldBeAbleToLoginSuccessfully()
        {
            //Wait for the page to load
            Thread.Sleep(5000);


            //Verify the login is successful by checking the URL

            string welcomeMessage = loginpage.LoginValidation();
                        
            if (welcomeMessage == "Hi Ramkumar")
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
            
            loginpage.InvalidLoginAction(email, password);

        }

        [Then("I should be see an error message for invalid credentials")]
        public void ThenIShouldBeSeeAnErrorMessageForInvalidCredentials()
        {


            //Wait for the page to load
            Thread.Sleep(4000);
                                   

            //Wait for the error message to be displayed
            //wait.WaitToBeVisible(driver, "CssSelector", "body > div.ns-box.ns-growl.ns-effect-jelly.ns-type-error.ns-show", 10);

            string Message = loginpage.EmailVerification();

            if (Message == "Email Verification Failed")
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
            
            loginpage.InvalidLoginAction(email, password);
            Thread.Sleep(3000);
        }

        [Then("I should see an error message for blank {string}")]
        public void ThenIShouldSeeAnErrorMessageForBlank(string email)
        {
            string EmailField = loginpage.EmailFieldBlank();

            if (EmailField == "Please enter a valid email address")
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
            
            loginpage.InvalidLoginAction(email, password);
        }

        [Then("I should see an error message for {string}")]
        public void ThenIShouldSeeAnErrorMessageFor(string password)
        {
            string PasswordField = loginpage.PasswordFieldBlank();
            if (PasswordField == "Password must be at least 6 characters")
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



        




