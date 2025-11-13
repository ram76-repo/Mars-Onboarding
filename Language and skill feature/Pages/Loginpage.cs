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


        public void ValidLoginAction(IWebDriver driver)
        {
            
            //Enter valid credentials
            string EmailId = "ram_login@yahoo.co.uk";
            string Pwd = "rithika";

            //click on signin button

            Thread.Sleep(5000);


            IWebElement Signin = driver.FindElement(By.XPath("//*[@id=\"home\"]/div/div/div[1]/div/a"));
            Signin.Click();

            //Enter email
            IWebElement Email = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[1]/input"));
            Email.Click();
            Email.SendKeys(EmailId);

            //Enter password
            IWebElement Password = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[2]/input"));
            Password.Click();
            Password.SendKeys(Pwd);

            //Click on login button
            IWebElement LoginButton = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[4]/button"));
            LoginButton.Click();

        }

        public void InvalidLoginAction(IWebDriver driver,  string email, string password)
        {
            Thread.Sleep(2000);

            IWebElement Signin = driver.FindElement(By.XPath("//*[@id=\"home\"]/div/div/div[1]/div/a"));
            Signin.Click();

            //Enter email
            IWebElement Email = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[1]/input"));
            Email.Click();
            Email.SendKeys(email);

            //Enter password
            IWebElement Password = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[2]/input"));
            Password.Click();
            Password.SendKeys(password);

            //Click on login button
            IWebElement LoginButton = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[4]/button"));
            LoginButton.Click();
        }

        public void EmailFieldBlank()
        {
            IWebElement EmailField = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[1]/div"));

        }

        public void PasswordFieldBlank()
        {
            IWebElement PasswordField = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[2]/div"));

        }
    }
}
