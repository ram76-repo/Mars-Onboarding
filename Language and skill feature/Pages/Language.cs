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
using RazorEngine.Compilation.ImpromptuInterface;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Language_and_skill_feature.Pages
{

    
public class Language
    {
        private readonly IWebDriver driver;

        public Language(IWebDriver driver)
        {
            this.driver = driver ?? throw new ArgumentNullException(nameof(driver));
        }

        By AddLangButton = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div");
        By LanguageField = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[1]/input");
        By EditLanguageField = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td/div/div[1]/input");
        By LevelDropdown = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select");
        By EditLevelDropdown = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td/div/div[2]/select");
        By AddButton = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[1]");
        By AddButton1 = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div");
        By LangData = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]");
        By LevelData = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[2]");
        By AlertMsg = By.CssSelector("body > div.ns-box.ns-growl.ns-effect-jelly.ns-type-error");        
        By errormessage = By.CssSelector("body > div.ns-box.ns-growl.ns-effect-jelly.ns-type-error.ns-show");        
        By EditButton = By.XPath($"//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[3]/span[1]/i");
        By UpdateButton = By.XPath($"//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td/div/span/input[1]");
        By BlankLevelDropdown = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td/div/div[2]/select");
        By BlankLevelOption = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td/div/div[2]/select/option[1]");
        By CancelButton = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td/div/span/input[2]");
        By DeleteButton = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[2]/i");
        By Table = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table");
        By AddDescriptionButton = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/div/div/div/h3/span/i");        
        By DescriptionField = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/div/div/form/div/div/div[2]/div[1]/textarea");
        By SaveButton = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/div/div/form/div/div/div[2]/button");
        By DescriptionData = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/div/div/div/span");


        public void AddLanguage(string languageName, string proficiencyLevel)
        {            
            
            // Wait for the Add Language button to be clickable
            Thread.Sleep(3000);

            // Click on the Add Language button
            driver.FindElement(AddLangButton).Click();           

            // Enter the language
            Thread.Sleep(3000);
            driver.FindElement(LanguageField).Click();
            driver.FindElement(LanguageField).SendKeys(languageName);            
            
            // Select the level from the dropdown
            driver.FindElement(LevelDropdown).Click();
            driver.FindElement(LevelDropdown).SendKeys(proficiencyLevel);
            
            // Click on the Save button
            
            driver.FindElement(AddButton).Click();
        }

        public string LangDataValidation()
        {
            Thread.Sleep(3000);

            // Capture the language record
            
            string ActualLang = driver.FindElement(LangData).Text;            
            Console.WriteLine(ActualLang);
            return ActualLang;
        }

        public string LevelDataValidation()
        {

            Thread.Sleep(3000);

            // Capture the level record
            
            string ActualLevel = driver.FindElement(LevelData).Text;
            Console.WriteLine(ActualLevel);
            return ActualLevel;            
        }

        public void BlankLangRecord(string languageName, string proficiencyLevel)
        {
            wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div", 20);
            // Click on the Add Language button
            driver.FindElement(AddLangButton).Click();

            // Enter the language
            Thread.Sleep(3000);
            driver.FindElement(LanguageField).Click();
            driver.FindElement(LanguageField).SendKeys(languageName);

            // Select the level from the dropdown
            driver.FindElement(LevelDropdown).Click();
            driver.FindElement(LevelDropdown).SendKeys(proficiencyLevel);

            // Click on the Save button

            driver.FindElement(AddButton).Click();
           
        }

        public string BlankLangValidation()
        {
            string errormessage = driver.FindElement(AlertMsg).Text;
            Console.WriteLine(errormessage);         
            return errormessage;            
        }

        public void BlankLevelRecord(string languageName, string proficiencyLevel)
        {
           wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div", 20);
            //Click on the Add Language button

            driver.FindElement(AddLangButton).Click();            
            // Enter the language
                Thread.Sleep(3000);
                driver.FindElement(LanguageField).Click();
                driver.FindElement(LanguageField).SendKeys(languageName);
            
            // Select the level from the dropdown
                driver.FindElement(LevelDropdown).Click();
                driver.FindElement(LevelDropdown).SendKeys(proficiencyLevel);

            // Click on the Add button

            driver.FindElement(AddButton).Click();
            //IWebElement AddButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[1]"));
            //AddButton.Click();
            }
        public string BlankLevelValidation()
        {
            IWebElement alert = driver.FindElement(By.CssSelector("body > div.ns-box.ns-growl.ns-effect-jelly.ns-type-error"));
            string errormessage = alert.Text;
            Console.WriteLine(errormessage);
            return errormessage;
        }

        public void InvalidLangData(string languageName, string proficiencyLevel)
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

        public string InvalidLangValidation()
        {
            wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td[1]", 10);

            IWebElement LangData = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td[1]"));
            string InvalidData = LangData.Text;
            return InvalidData;
        }

        public string DuplicateRecordValidation()
        {
            string error = driver.FindElement(errormessage).Text;
            Console.WriteLine(error);
            return error;
        }

        public string ExcessRecord()
        {
            // Check if the AddButton1 is displayed and return its status as a string
            try
            {
                bool isDisplayed = driver.FindElement(AddButton1).Enabled;
                Console.WriteLine(isDisplayed);
                string button = isDisplayed.ToString();
                return button;
            }            
            catch (NoSuchElementException)
            {
                string button = "False";
                return button;
            }
        }

        public void EditLanguage(string languageName, string proficiencyLevel)
        {
            
                Thread.Sleep(3000);
                driver.FindElement(EditButton).Click();

            Thread.Sleep(3000);            
            
            driver.FindElement(EditLanguageField).SendKeys(Keys.Control + "a");
            driver.FindElement(EditLanguageField).SendKeys(Keys.Delete); // Clear the field using Ctrl+A and Delete
            driver.FindElement(EditLanguageField).SendKeys(languageName);
                        
            driver.FindElement(EditLevelDropdown).Click();
            driver.FindElement(EditLevelDropdown).SendKeys(proficiencyLevel);

            // Click on the update button
            driver.FindElement(UpdateButton).Click();               
        }

        public string EditLangDataValidation()
        {
            Thread.Sleep(3000);

            string ActualLang = driver.FindElement(LangData).Text;

            Console.WriteLine(ActualLang);

            return ActualLang;
        }

        public string EditLevelDataValidation()
        {
            Thread.Sleep(3000);

            string ActualLevel = driver.FindElement(LevelData).Text;

            //string ActualLevel = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td[2]")).Text;

            Console.WriteLine(ActualLevel);

            return ActualLevel;
        }

        public void EditWithBlankLangRecord(string languageName, string proficiencyLevel)
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

        public string EditBlankLangValidation()
        {
            Thread.Sleep(3000);

            IWebElement alert = driver.FindElement(By.CssSelector("body > div.ns-box.ns-growl.ns-effect-jelly.ns-type-error.ns-show"));
            string errormessage = alert.Text;
            Console.WriteLine(errormessage);
            return errormessage;
        }

        public void EditWithBlankLevelRecord(string languageName, string proficiencyLevel)
        {
            // Click on the Edit button for the last language record
            wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td[3]/span[1]/i", 10);

            driver.FindElement(EditButton).Click();            

            Thread.Sleep(3000);

            // Clear the existing language and enter the new one

            driver.FindElement(EditLanguageField).Clear();
            driver.FindElement(EditLanguageField).SendKeys(languageName);            

            Thread.Sleep(3000);

            // Select the level from the dropdown

            driver.FindElement(BlankLevelDropdown).Click();
            driver.FindElement(BlankLevelOption).Click();        
          
            // Click on the update button

            driver.FindElement(UpdateButton).Click();
            
            if (driver.FindElement(By.CssSelector("body > div.ns-box.ns-growl.ns-effect-jelly.ns-type-error.ns-show")).Displayed)
            {
                driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td/div/span/input[2]")).Click();
                
            }

        }

        public void EditInvalidData(string languageName, string proficiencyLevel)
        {
            // Click on the Edit button for the last language record
            wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td[3]/span[1]/i", 10);
            IWebElement EditButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table[last()]/tr/td[3]/span[1]/i"));
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

        public string EditInvalidLangValidation()
        {
            Thread.Sleep(3000);

            IWebElement LangData = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
            string InvalidData = LangData.Text;
            Console.WriteLine(InvalidData);
            return InvalidData;
        }

        public void DeleteLanguage()
        {
            // Click on the Delete button for the last language record

            wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[2]/i", 10);
            driver.FindElement(DeleteButton).Click();            
        }

        public string DeleteLangDataValidation()
        {
            Thread.Sleep(3000);
            // Capture the language record from the last row

            var rows = driver.FindElement(Table).FindElements(By.TagName("tr"));

            string ActualLang = rows.Count.ToString();
            return ActualLang;          
            


            //IWebElement LangData = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));

            //string ActualLang = LangData.Text;

            //Console.WriteLine(ActualLang);
            //return ActualLang;
        }

        public string DeleteLevelDataValidation()
        {
            Thread.Sleep(3000);
            // Capture the level record from the last row

            IWebElement LevelData = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[2]"));

            string ActualLevel = LevelData.Text;
            Console.WriteLine(ActualLevel);
            return ActualLevel;
        }

        public void CancelLang(string languageName, string proficiencyLevel)
        {
            // Click on the Edit button for the last language record
            wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td[3]/span[1]/i", 10);
            
            driver.FindElement(EditButton).Click();

            // Wait for the language field to be visible
            wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td/div/div[1]/input", 10);

            // Clear the existing language and enter the new one

            driver.FindElement(EditLanguageField).Click();
            
            driver.FindElement(EditLanguageField).Clear();
            driver.FindElement(EditLanguageField).SendKeys(languageName);

            // Select the level from the dropdown

            driver.FindElement(EditLevelDropdown).Click();
            driver.FindElement(EditLevelDropdown).SendKeys(proficiencyLevel);            
        }

        public string LangDataCancelValidation()
        {
            // capture the language record from the first row
            IWebElement LangData = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td[1]"));
            string ActualLang = LangData.Text;
            Console.WriteLine(ActualLang);
            return ActualLang;
        }

        public string LevelDataCancelValidation()
        {
            // capture the level record from the first row
            IWebElement LevelData = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td[2]"));
            string ActualLevel = LevelData.Text;
            Console.WriteLine(ActualLevel);
            return ActualLevel;
        }

        public void cancelButtonclick()
        {
            driver.FindElement(CancelButton).Click();
           
        }

        public void AddDescription(string profileDescription)
        {

            // Wait for the Add Description button to be clickable
            wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/div/div/div/h3/span/i", 10);

            // Click on the Add Description button
            
            driver.FindElement(AddDescriptionButton).Click();

            Thread.Sleep(3000);

            // Enter the description
            driver.FindElement(DescriptionField).Click();            
            Thread.Sleep(3000);
            driver.FindElement(DescriptionField).Clear(); 
            driver.FindElement(DescriptionField).SendKeys(profileDescription);
            Thread.Sleep(5000);

            // Click on the Save button
            driver.FindElement(SaveButton).Click();            
            Thread.Sleep(3000);
        }

        public string DescriptionValidation()
        {
            Thread.Sleep(3000);
            // Capture the description record
            driver.FindElement(DescriptionData);
            string ActualDescription = driver.FindElement(DescriptionData).Text;
            Console.WriteLine(ActualDescription);
            return ActualDescription;
        }

        public void AddBlankDescription()
        {

            // Wait for the Add Description button to be clickable
            wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/div/div/div/h3/span/i", 10);

            // Click on the Add Description button
            driver.FindElement(AddDescriptionButton).Click();
            Thread.Sleep(3000);

            // Enter the description

            driver.FindElement(DescriptionField).Click();                        
            driver.FindElement(DescriptionField).SendKeys(Keys.Control + "a");
            driver.FindElement(DescriptionField).SendKeys(Keys.Delete);// Clear the field using Ctrl+A and Delete
            driver.FindElement(DescriptionField).SendKeys(""); // Move focus away from the field to trigger validation


            // Click on the Save button

            wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/div/div/form/div/div/div[2]/button", 10);

            driver.FindElement(SaveButton).Click();            

        }

        public string BlankDescriptionValidation()
        {
            Thread.Sleep(3000);
            // Capture the error message when trying to add a blank description
            //IWebElement alert = driver.FindElement(By.CssSelector("body > div.ns-box.ns-growl.ns-effect-jelly.ns-type-error.ns-show"));
            string error = driver.FindElement(errormessage).Text;
            Console.WriteLine(error);
            return error;
        }        

        public string LongDescriptionValidation()
        {
            Thread.Sleep(3000);
            // Capture the description record
            IWebElement DescriptionData = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/div/div/div/span"));
            string ActualDescription = DescriptionData.Text;            
            return ActualDescription;
        }

    }

    
}