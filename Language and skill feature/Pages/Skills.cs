using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Language_and_skill_feature.Utilities;
using OpenQA.Selenium;

namespace Language_and_skill_feature.Pages
{
    
    public class Skills
    {
        
        private IWebDriver driver;

        public Skills(IWebDriver driver)
        {
            this.driver = driver;
        }

        By AddNewButton = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div");
        By skillTextbox = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[1]/input");
        By LevelDropDown = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[2]/select");
        By AddButton = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/span/input[1]");
        By SkillRecord = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[1]");
        By LevelRecord = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[2]");
        By alert = By.CssSelector("body > div.ns-box.ns-growl.ns-effect-jelly.ns-type-error.ns-show");
        By EditButton = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr[last()]/td[3]/span[1]/i");        
        By EditSkillTextbox = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td/div/div[1]/input");
        By EditLevelDropDown = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td/div/div[2]/select");
        By UpdateButton = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td/div/span/input[1]");
        By ChooseOption = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td/div/div[2]/select/option[1]");
        By CancelButton = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td/div/span/input[2]");
        By DeleteButton = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[2]/i");
        By table = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table");



        public void AddValidSkillRecord(string Skill, string Level)
        {
            driver.FindElement(AddNewButton).Click();    
            driver.FindElement(skillTextbox).Click();
            driver.FindElement(skillTextbox).SendKeys(Skill);
            
            driver.FindElement(LevelDropDown).Click();
            driver.FindElement(LevelDropDown).SendKeys(Level);            


            driver.FindElement(AddButton).Click();
        }

        public string SkillRecordValidation(IWebDriver driver)
        {
            Thread.Sleep(3000);
            string skillText = driver.FindElement(SkillRecord).Text;
            return skillText;

        }

        public string LevelRecordValidation(IWebDriver driver)
        {
            Thread.Sleep(3000);
            string levelText = driver.FindElement(LevelRecord).Text;
            return levelText;
        }        

        public string BlankSkillRecordValidation(IWebDriver driver)
        {
            Thread.Sleep(3000);
           string errormessage = driver.FindElement(alert).Text;
           Console.WriteLine(errormessage);
           return errormessage;
        }        

        public string InvalidSkillRecordValidation(IWebDriver driver)
        {
            Thread.Sleep(3000);
            try
            {
                string alertMessage = driver.FindElement(alert).Text;
                Console.WriteLine(alertMessage);
                return alertMessage;
            }
            catch (NoSuchElementException)
            {
                string alertMessage = "No alert message found";
                return alertMessage;

            }
        }                                       

        public void EditSkillRecord(string Skill, string Level)
        {
            // Wait for the Edit button to be clickable
            Thread.Sleep(3000);

            // Click the Edit button for the last skill record

            driver.FindElement(EditButton).Click();

            // Wait for the skill input field to be visible
            //wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td/div/div[1]/input", 10);

            // Clear the existing skill and level, then enter new values

            driver.FindElement(EditSkillTextbox).SendKeys(Keys.Control + "a");
            driver.FindElement(EditSkillTextbox).SendKeys(Keys.Delete);
            driver.FindElement(EditSkillTextbox).SendKeys(Skill);           

            // wait for the level dropdown to be visible

            Thread.Sleep(2000);

            driver.FindElement(EditLevelDropDown).Click();
            driver.FindElement(EditLevelDropDown).SendKeys(Level);


            //wait for the Update button to be clickable
            Thread.Sleep(3000);

            driver.FindElement(UpdateButton).Click();            
        }

        public void EditBlankLevelRecord(string Skill, string Level)
        {
            // Wait for the Edit button to be clickable
            Thread.Sleep(3000);
            // Click the Edit button for the last skill record
            driver.FindElement(EditButton).Click();
            // Wait for the skill input field to be visible
            wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td/div/div[1]/input", 10);
            // Clear the existing skill and level, then enter new values
            driver.FindElement(EditSkillTextbox).SendKeys(Keys.Control + "a");
            driver.FindElement(EditSkillTextbox).SendKeys(Keys.Delete);
            driver.FindElement(EditSkillTextbox).SendKeys(Skill);
            Thread.Sleep(2000);

            driver.FindElement(EditLevelDropDown).Click();
                      

            Thread.Sleep(2000);
            driver.FindElement(ChooseOption).Click();            
            driver.FindElement(UpdateButton).Click();           

        }

        public void cancelEdit(IWebDriver driver)
        {
            driver.FindElement(CancelButton).Click();            
        }        

        // Method to get the skill text before editing
        public string SkillBeforeEdit(IWebDriver driver)
        {
            // Wait for the skill record to be visible
            Thread.Sleep(2000);
           string skillText = driver.FindElement(SkillRecord).Text;            
            return skillText;
        }
        // Method to get the level text before editing
        public string LevelBeforeEdit(IWebDriver driver)
        {
            // Wait for the level record to be visible
            Thread.Sleep(2000);
            
            string levelText = driver.FindElement(LevelRecord).Text;
            return levelText;
        }

        // Method for editing a record before cancelling changes
        public void EditRecordForCancel(IWebDriver driver, string Skill, string Level)
        {

            // Wait for the Edit button to be clickable
            Thread.Sleep(3000);

            // Finding and clicking the Edit button for the last skill record
            driver.FindElement(EditButton).Click();

            driver.FindElement(EditSkillTextbox).Click();
            driver.FindElement(EditSkillTextbox).Clear();
            driver.FindElement(EditSkillTextbox).SendKeys(Skill);
            
            driver.FindElement(EditLevelDropDown).Click();
            driver.FindElement(EditLevelDropDown).SendKeys(Level);

            driver.FindElement(CancelButton).Click();            
        }
        public void CancelChanges (IWebDriver driver)
        {
            driver.FindElement(CancelButton).Click();            
        }

        public string CancelSkillValidation(IWebDriver driver)
            
        {
            string CurrentSkill = driver.FindElement(SkillRecord).Text;
            return CurrentSkill;

        }

        public string CancelLevelValidation(IWebDriver driver)
        {
            string CurrentLevel = driver.FindElement(LevelRecord).Text;
            return CurrentLevel;
        }

        public void DeleteSkillRecord(IWebDriver driver)
        {
            // Wait for the Delete button to be clickable
            Thread.Sleep(3000);
            // Click the Delete button for the last skill record
            driver.FindElement(DeleteButton).Click();
        }

        public string DeleteSkillRecordValidation(IWebDriver driver)
        {
            Thread.Sleep(3000);

            var table1 = driver.FindElement(table);
            var rows = table1.FindElements(By.TagName("tr"));
            int rowCount = rows.Count - 1; // Subtract 1 to exclude the header row
            string rowCountString = rowCount.ToString();
            return rowCountString;
            
        }

        public Boolean isAlertPresent()
        {
            try {
                IAlert alert = driver.SwitchTo().Alert();
                alert.Accept();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }
                
    }

}
