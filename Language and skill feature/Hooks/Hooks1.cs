using Gherkin.Ast;
using Io.Cucumber.Messages.Types;
using Language_and_skill_feature.Pages;
using Language_and_skill_feature.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Reqnroll;
using Reqnroll.BoDi;
using static System.Collections.Specialized.BitVector32;
using Exception = System.Exception;

namespace Language_and_skill_feature.Hooks
{
    [Binding]
    public sealed class Hooks1
    {
        private static IWebDriver driver;

        private readonly IObjectContainer _objectContainer;


        public Hooks1(IObjectContainer objectContainer)
        {
            // Register the WebDriver instance in the container
            _objectContainer = objectContainer;

        }


        [Before]

        public void Before()
        {
            driver = new ChromeDriver();
            // Register the WebDriver instance in the container
            _objectContainer.RegisterInstanceAs<IWebDriver>(driver);

            driver.Navigate().GoToUrl("http://localhost:5003/");
            driver.Manage().Window.Maximize();

        }

        [After()]

        public static void After(FeatureContext featureContext)

        {
            
            if (featureContext.FeatureInfo.Tags.Contains("Language"))
            {
                try
                {
                    // Locate the table containing the languages

                    var table = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table"));
                    var rows = table.FindElements(By.TagName("tr"));

                    foreach (var row in rows)
                    {
                        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath($"//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td[3]/span[2]/i")));

                        IWebElement deleteButton = driver.FindElement(By.XPath($"//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td[3]/span[2]/i"));
                        //IWebElement deleteButton = driver.FindElement(By.XPath($"//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr[{x}]/td[3]/span[2]/i"));
                        deleteButton.Click();
                    }

                    Console.WriteLine("Number of rows in the table: " + rows.Count);

                    //for (int x = 1; x < rows.Count; x++)
                    //{
                      // WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                       //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath($"//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr[{x}]/td[3]/span[2]/i")));

                        //IWebElement deleteButton = driver.FindElement(By.XPath($"//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td[3]/span[2]/i"));
                        //IWebElement deleteButton = driver.FindElement(By.XPath($"//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr[{x}]/td[3]/span[2]/i"));
                        //deleteButton.Click();
                       //Console.WriteLine(x + " Language Deleted");
                    //}
                }
                catch (Exception ex)
                {
                    Console.WriteLine("No languages to delete.");
                }
                finally
                {
                    driver.Quit();
                }
            }

            else if (featureContext.FeatureInfo.Tags.Contains("Skills"))
            {
                try
                {

                    var table = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table"));

                    var rows = table.FindElements(By.TagName("tr"));

                    Console.WriteLine("Number of rows in the table: " + rows.Count);

                    for (int x = 1; x < rows.Count; x++)
                    {
                        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath($"//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr[{x}]/td[3]/span[2]/i")));

                        IWebElement deleteButton = driver.FindElement(By.XPath($"//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr[{x}]/td[3]/span[2]/i"));
                        deleteButton.Click();
                        Console.WriteLine("Skill Deleted");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("No skills to delete.");
                }
                finally
                {
                    driver.Quit();
                }
            }

            else if (featureContext.FeatureInfo.Tags.Contains("Login"))
            {

                if (driver != null)
                {
                    driver.Quit();
                }

            }

            }

        }
    

}

        


