using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Language_and_skill_feature.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools;
using OpenQA.Selenium.Support.UI;

namespace Language_and_skill_feature.Pages
{
    public class Loginpage
    {
        private IWebDriver driver;

        By SignInButton = By.XPath("//*[@id=\"home\"]/div/div/div[1]/div/a");
        By EmailField = By.XPath("/html/body/div[2]/div/div/div[1]/div/div[1]/input");
        By PasswordField = By.XPath("/html/body/div[2]/div/div/div[1]/div/div[2]/input");
        By LoginButton = By.XPath("/html/body/div[2]/div/div/div[1]/div/div[4]/button");
        By Message = By.XPath("//*[@id=\"account-profile-section\"]/div/div[1]/div[2]/div/span");
        By BlankEmail = By.XPath("/html/body/div[2]/div/div/div[1]/div/div[1]/div");
        By BlankPwd = By.XPath("/html/body/div[2]/div/div/div[1]/div/div[2]/div");
        By VerificationButton = By.XPath("//*[@id=\"submit-btn\"]");
        By VerificationMessage = By.CssSelector("body > div.ns-box.ns-growl.ns-effect-jelly.ns-type-error.ns-show");

        public Loginpage(IWebDriver driver) 
        { 
            this.driver = driver;
        }



        public void ValidLoginAction()
        {
            
            //Enter valid credentials
            string email = "ram_login@yahoo.co.uk";
            string password = "rithika";

            //click on signin button

            Thread.Sleep(5000);

            driver.FindElement(SignInButton).Click();
            driver.FindElement(EmailField).SendKeys(email);
            driver.FindElement(PasswordField).SendKeys(password);
            driver.FindElement(LoginButton).Click();            
        }

        public void InvalidLoginAction(string email, string password)
        {
            Thread.Sleep(2000);

            driver.FindElement(SignInButton).Click();
            driver.FindElement(EmailField).SendKeys(email);
            driver.FindElement(PasswordField).SendKeys(password);
            driver.FindElement(LoginButton).Click();
        }

        public string LoginValidation()
        {
            string WelcomeMessage = driver.FindElement(Message).Text;
            return WelcomeMessage;
        }

        public string EmailFieldBlank()
        {
            string BlankEmailField = driver.FindElement(BlankEmail).Text;
            return BlankEmailField;

        }

        public string PasswordFieldBlank()
        {
            string BlankPasswordField = driver.FindElement(BlankPwd).Text;
            return BlankPasswordField;

        }

        public string EmailVerification()
        {
            driver.FindElement(VerificationButton).Click();

            Thread.Sleep(5000);

            wait.WaitToBeVisible(driver, "CssSelector", "body > div.ns-box.ns-growl.ns-effect-jelly.ns-type-error.ns-show", 10);

            string VerificationMsg = driver.FindElement(VerificationMessage).Text;
            return VerificationMsg;
            
        }

    }
}
