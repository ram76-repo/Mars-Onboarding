using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Language_and_skill_feature.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Language_and_skill_feature.Pages
{
    public class Language    
    {
      
        public void AddLanguage(IWebDriver driver, string languageName, string proficiencyLevel)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            // Wait for the Add Language button to be clickable
            Thread.Sleep(3000);

            // Click on the Add Language button
            IWebElement AddLanguageButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div"));
            AddLanguageButton.Click();


            // Enter the language
            Thread.Sleep(3000);
            IWebElement LanguageField = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[1]/input"));
            LanguageField.Click();
            LanguageField.SendKeys(languageName);
            
            // Select the level from the dropdown
            IWebElement LevelDropdown = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select"));
            LevelDropdown.Click();
            LevelDropdown.SendKeys(proficiencyLevel);
                        

            // Click on the Save button
            
            IWebElement SaveButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[1]"));
            SaveButton.Click();
        }

        public string LangDataValidation(IWebDriver driver)
        {
            Thread.Sleep(3000);

            // Capture the language record
            IWebElement LangData = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));

            string ActualLang = LangData.Text;
            Console.WriteLine(ActualLang);

            return ActualLang;
        }

        public string LevelDataValidation(IWebDriver driver)
        {

            Thread.Sleep(3000);

            // Capture the level record
            IWebElement LevelData = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[2]"));

            string ActualLevel = LevelData.Text;
            Console.WriteLine(ActualLevel);
            return ActualLevel;

        }




        public void BlankLangRecord(IWebDriver driver, string languageName, string proficiencyLevel)
        {
            wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div", 20);
            // Click on the Add Language button
            IWebElement AddLanguageButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div"));
            AddLanguageButton.Click();
            // Enter the language
            IWebElement LanguageField = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[1]/input"));
            LanguageField.Click();
            LanguageField.SendKeys(languageName);
            // Select the level from the dropdown
            IWebElement LevelDropdown = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select"));
            LevelDropdown.Click();
            LevelDropdown.SendKeys(proficiencyLevel);
            // Click on the Add button
            IWebElement AddButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[1]"));
            AddButton.Click();

        }

        public string BlankLangValidation(IWebDriver driver)
        {
            IWebElement alert = driver.FindElement(By.CssSelector("body > div.ns-box.ns-growl.ns-effect-jelly.ns-type-error"));
            string errormessage = alert.Text;
            Console.WriteLine(errormessage);         

            return errormessage;

            
        }

        public void BlankLevelRecord(IWebDriver driver, string languageName, string proficiencyLevel)
        {
            wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div", 20);
            // Click on the Add Language button
            IWebElement AddLanguageButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div"));
            AddLanguageButton.Click();
            // Enter the language
            IWebElement LanguageField = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[1]/input"));
            LanguageField.Click();
            LanguageField.SendKeys(languageName);
            // Select the level from the dropdown
            IWebElement LevelDropdown = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select"));
            LevelDropdown.Click();
            LevelDropdown.SendKeys(proficiencyLevel);
            // Click on the Add button
            IWebElement AddButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[1]"));
            AddButton.Click();

        }
        public string BlankLevelValidation(IWebDriver driver)
        {
            IWebElement alert = driver.FindElement(By.CssSelector("body > div.ns-box.ns-growl.ns-effect-jelly.ns-type-error"));
            string errormessage = alert.Text;
            Console.WriteLine(errormessage);
            return errormessage;
        }

        public void InvalidLangData(IWebDriver driver, string languageName, string proficiencyLevel)
        {
            wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div", 20);

            // Click on the Add Language button
            IWebElement AddLanguageButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div"));
            AddLanguageButton.Click();
            // Enter the language
            IWebElement LanguageField = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[1]/input"));
            LanguageField.Click();
            LanguageField.SendKeys(languageName);
            // Select the level from the dropdown
            IWebElement LevelDropdown = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select"));
            LevelDropdown.Click();
            LevelDropdown.SendKeys(proficiencyLevel);
            // Click on the Save button
            IWebElement AddButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[1]"));
            AddButton.Click();
        }

        public string InvalidLangValidation(IWebDriver driver)
        {
            wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td[1]", 10);

            IWebElement LangData = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td[1]"));
            string InvalidData = LangData.Text;
            return InvalidData;
        }

        public void EditLanguage(IWebDriver driver, string languageName, string proficiencyLevel)
        {
            
                Thread.Sleep(3000);
                IWebElement EditButton = driver.FindElement(By.XPath($"//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[3]/span[1]/i"));
                EditButton.Click();
                            

                IWebElement LanguageField = driver.FindElement(By.XPath($"//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td/div/div[1]/input"));
            LanguageField.SendKeys(Keys.Control + "a");
            LanguageField.SendKeys(Keys.Delete); // Clear the field using Ctrl+A and Delete
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].value = '';", LanguageField);

            if(!string.IsNullOrEmpty(languageName))
            {
                
                LanguageField.SendKeys(languageName);
            }
                
            // Select the level from the dropdown

            IWebElement LevelDropdown = driver.FindElement(By.XPath($"//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td/div/div[2]/select"));
            LevelDropdown.Click();
            LevelDropdown.SendKeys(proficiencyLevel);

                // Click on the update button
                IWebElement SaveButton = driver.FindElement(By.XPath($"//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td/div/span/input[1]"));
                SaveButton.Click();               
            
            
        }

        public string EditLangDataValidation(IWebDriver driver)
        {
            Thread.Sleep(3000);

            string ActualLang = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td[1]")).Text;

            Console.WriteLine(ActualLang);

            return ActualLang;
        }

        public string EditLevelDataValidation(IWebDriver driver)
        {
            Thread.Sleep(3000);

            string ActualLevel = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td[2]")).Text;
            Console.WriteLine(ActualLevel);

            return ActualLevel;
        }

        public void EditWithBlankLangRecord(IWebDriver driver, string languageName, string proficiencyLevel)
        {
            // Click on the Edit button for the last language record
            wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td[3]/span[1]/i", 10);

            IWebElement EditButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td[3]/span[1]/i"));
            EditButton.Click();

            Thread.Sleep(3000);

            // Clear the existing language and enter the new one
            IWebElement LanguageField = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td/div/div[1]/input"));
            LanguageField.Clear();
            Console.WriteLine(LanguageField.Text);
            LanguageField.SendKeys(languageName);

            Thread.Sleep(2000);

            // Select the level from the dropdown
            IWebElement LevelDropdown = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td/div/div[2]/select"));
            LevelDropdown.Click();
            LevelDropdown.SendKeys(proficiencyLevel);
            Console.WriteLine(LevelDropdown.Text);

            // Click on the update button
            IWebElement SaveButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td/div/span/input[1]"));
            SaveButton.Click();
        }

        public string EditBlankLangValidation(IWebDriver driver)
        {
            Thread.Sleep(3000);

            IWebElement alert = driver.FindElement(By.CssSelector("body > div.ns-box.ns-growl.ns-effect-jelly.ns-type-error.ns-show"));
            string errormessage = alert.Text;
            Console.WriteLine(errormessage);
            return errormessage;
        }

        public void EditWithBlankLevelRecord(IWebDriver driver, string languageName, string proficiencyLevel)
        {
            // Click on the Edit button for the last language record
            wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td[3]/span[1]/i", 10);

            IWebElement EditButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td[3]/span[1]/i"));
            EditButton.Click();

            Thread.Sleep(3000);

            // Clear the existing language and enter the new one
            IWebElement LanguageField = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td/div/div[1]/input"));
            //LanguageField.Click();
            LanguageField.Clear();
            LanguageField.SendKeys(languageName);

            Thread.Sleep(3000);

            // Select the level from the dropdown
            IWebElement LevelDropdown = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td/div/div[2]/select"));
            SelectElement select = new SelectElement(LevelDropdown);
            select.SelectByText("Language Level"); // Select the blank option
                        

            // Click on the update button
            IWebElement SaveButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td/div/span/input[1]"));
            SaveButton.Click();

            if (driver.FindElement(By.CssSelector("body > div.ns-box.ns-growl.ns-effect-jelly.ns-type-error.ns-show")).Displayed)
            {
                driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td/div/span/input[2]")).Click();
            }
            
        }

        public void EditInvalidData(IWebDriver driver, string languageName, string proficiencyLevel)
        {
            // Click on the Edit button for the last language record
            wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td[3]/span[1]/i", 10);
            IWebElement EditButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[1]/i"));
            EditButton.Click();
            Thread.Sleep(3000);

            // Clear the existing language and enter the new one
            IWebElement LanguageField = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td/div/div[1]/input"));
            LanguageField.Click();
            LanguageField.Clear();
            LanguageField.SendKeys(languageName);
            Thread.Sleep(3000);

            // Select the level from the dropdown
            IWebElement LevelDropdown = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td/div/div[2]/select"));
            LevelDropdown.Click();
            LevelDropdown.SendKeys(proficiencyLevel);

            // Click on the update button
            IWebElement SaveButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td/div/span/input[1]"));
            SaveButton.Click();
        }

        public string EditInvalidLangValidation(IWebDriver driver)
        {
            Thread.Sleep(3000);

            IWebElement LangData = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
            string InvalidData = LangData.Text;
            Console.WriteLine(InvalidData);
            return InvalidData;
        }

        public void DeleteLanguage(IWebDriver driver)
        {
            // Click on the Delete button for the last language record

            wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[2]/i", 10);
            IWebElement DeleteButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[2]/i"));
            DeleteButton.Click();
        }

        public string DeleteLangDataValidation(IWebDriver driver)
        {
            Thread.Sleep(3000);
            // Capture the language record from the last row

            IWebElement Table = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table"));
            var rows = Table.FindElements(By.TagName("tr"));

            string ActualLang = rows.Count.ToString();
            return ActualLang;          
            


            //IWebElement LangData = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));

            //string ActualLang = LangData.Text;

            //Console.WriteLine(ActualLang);
            //return ActualLang;
        }

        public string DeleteLevelDataValidation(IWebDriver driver)
        {
            Thread.Sleep(3000);
            // Capture the level record from the last row

            IWebElement LevelData = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[2]"));

            string ActualLevel = LevelData.Text;
            Console.WriteLine(ActualLevel);
            return ActualLevel;
        }

        public void CancelLang(IWebDriver driver, string languageName, string proficiencyLevel)
        {
            // Click on the Edit button for the last language record
            wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td[3]/span[1]/i", 10);

            IWebElement EditButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td[3]/span[1]/i"));
            EditButton.Click();

            // Wait for the language field to be visible
            wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td/div/div[1]/input", 10);

            // Clear the existing language and enter the new one
            IWebElement LanguageField = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td/div/div[1]/input"));
            LanguageField.Click();
            LanguageField.Clear();
            LanguageField.SendKeys(languageName);

            // Select the level from the dropdown
            IWebElement LevelDropdown = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td/div/div[2]/select"));
            LevelDropdown.Click();
            LevelDropdown.SendKeys(proficiencyLevel);
        }

        public string LangDataCancelValidation(IWebDriver driver)
        {
            // capture the language record from the first row
            IWebElement LangData = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td[1]"));
            string ActualLang = LangData.Text;
            Console.WriteLine(ActualLang);
            return ActualLang;
        }

        public string LevelDataCancelValidation(IWebDriver driver)
        {
            // capture the level record from the first row
            IWebElement LevelData = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td[2]"));
            string ActualLevel = LevelData.Text;
            Console.WriteLine(ActualLevel);
            return ActualLevel;
        }

        public void AddDescription( IWebDriver driver, string profileDescription)
        {

            // Wait for the Add Description button to be clickable
            wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/div/div/div/h3/span/i", 10);

            // Click on the Add Description button
            IWebElement AddDescriptionButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/div/div/div/h3/span/i"));
            AddDescriptionButton.Click();

            Thread.Sleep(3000);

            // Enter the description
            IWebElement DescriptionField = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/div/div/form/div/div/div[2]/div[1]/textarea"));
            DescriptionField.Click();
            Thread.Sleep(3000);
            DescriptionField.Clear(); 
            DescriptionField.SendKeys(profileDescription);
            Thread.Sleep(5000);

            // Click on the Save button
            IWebElement SaveButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/div/div/form/div/div/div[2]/button"));
            SaveButton.Click();
            Thread.Sleep(3000);

        }

        public string DescriptionValidation(IWebDriver driver)
        {
            Thread.Sleep(3000);
            // Capture the description record
            IWebElement DescriptionData = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/div/div/div/span"));
            string ActualDescription = DescriptionData.Text;
            Console.WriteLine(ActualDescription);
            return ActualDescription;
        }

        public void AddBlankDescription(IWebDriver driver)
        {

            // Wait for the Add Description button to be clickable
            wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/div/div/div/h3/span/i", 10);

            // Click on the Add Description button
            IWebElement AddDescriptionButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/div/div/div/h3/span/i"));
            AddDescriptionButton.Click();

            Thread.Sleep(3000);

            // Enter the description
            IWebElement DescriptionField = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/div/div/form/div/div/div[2]/div[1]/textarea"));
                        
            DescriptionField.SendKeys(Keys.Control + "a");
            DescriptionField.SendKeys(Keys.Delete);// Clear the field using Ctrl+A and Delete
            DescriptionField.SendKeys(""); // Move focus away from the field to trigger validation


            // Click on the Save button

            wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/div/div/form/div/div/div[2]/button", 10);

            IWebElement SaveButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/div/div/form/div/div/div[2]/button"));
            SaveButton.Click();
            Console.WriteLine(DescriptionField.Text);

        }

        public string BlankDescriptionValidation(IWebDriver driver)
        {
            Thread.Sleep(3000);
            // Capture the error message when trying to add a blank description
            IWebElement alert = driver.FindElement(By.CssSelector("body > div.ns-box.ns-growl.ns-effect-jelly.ns-type-error.ns-show"));
            string errormessage = alert.Text;
            Console.WriteLine(errormessage);
            return errormessage;
        }

        public void AddLongDescription(IWebDriver driver, string profileDescription)
        {
            // Wait for the Add Description button to be clickable
            wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/div/div/div/h3/span/i", 10);

            // Click on the Add Description button
            IWebElement AddDescriptionButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/div/div/div/h3/span/i"));
            AddDescriptionButton.Click();
            Thread.Sleep(3000);

            // Enter a long description
            IWebElement DescriptionField = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/div/div/form/div/div/div[2]/div[1]/textarea"));
            DescriptionField.Click();
            Thread.Sleep(3000);
            DescriptionField.Clear();
            DescriptionField.SendKeys(profileDescription);
            
            // Click on the Save button
            IWebElement SaveButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/div/div/form/div/div/div[2]/button"));
            SaveButton.Click();
        }
        
        public string LongDescriptionValidation(IWebDriver driver)
        {
            Thread.Sleep(3000);
            // Capture the description record
            IWebElement DescriptionData = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/div/div/div/span"));
            string ActualDescription = DescriptionData.Text;            
            return ActualDescription;
        }






    }

    
}