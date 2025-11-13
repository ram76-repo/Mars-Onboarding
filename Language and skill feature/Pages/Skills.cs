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
        public IWebDriver driver;
        public void AddValidSkillRecord(IWebDriver driver, string Skill, string Level)
        {
            this.driver = driver;
            IWebElement AddNewButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div"));
            AddNewButton.Click();



            IWebElement skillTextbox = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[1]/input"));
            skillTextbox.Click();
            skillTextbox.SendKeys(Skill);

            IWebElement LevelDropDown = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[2]/select"));
            LevelDropDown.Click();
            LevelDropDown.SendKeys(Level);            


            IWebElement AddButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/span/input[1]"));
            AddButton.Click();

        }

        public string SkillRecordValidation(IWebDriver driver)
        {
            Thread.Sleep(3000);
            IWebElement SkillRecord = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
            string skillText = SkillRecord.Text;
            return skillText;

        }

        public string LevelRecordValidation(IWebDriver driver)
        {
            Thread.Sleep(3000);
            IWebElement LevelRecord = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[2]"));
            string levelText = LevelRecord.Text;
            return levelText;
        }

        public void BlankSkillRecord(IWebDriver driver, string Skill, string Level)
        {
            this.driver = driver;
            IWebElement AddNewButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div"));
            AddNewButton.Click();

            IWebElement SkillTextBox = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[1]/input"));
            SkillTextBox.Click();
            SkillTextBox.SendKeys(Skill);

            IWebElement LevelDropDown = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[2]/select"));
            LevelDropDown.Click();
            LevelDropDown.SendKeys(Level);

            IWebElement AddButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/span/input[1]"));
            AddButton.Click();

        }

        public string BlankSkillRecordValidation(IWebDriver driver)
        {
            Thread.Sleep(3000);
            IWebElement alert = driver.FindElement(By.CssSelector("body > div.ns-box.ns-growl.ns-effect-jelly.ns-type-error.ns-show"));
            string errormessage = alert.Text;
            Console.WriteLine(errormessage);
            return errormessage;

        }
        public void InvalidSkillRecord(IWebDriver driver, string Skill, string Level)
        {
            IWebElement AddNewButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div"));
            AddNewButton.Click();
            IWebElement SkillTextBox = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[1]/input"));
            SkillTextBox.Click();
            SkillTextBox.SendKeys(Skill);
            IWebElement LevelDropDown = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[2]/select"));
            LevelDropDown.Click();
            LevelDropDown.SendKeys(Level);
            IWebElement AddButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/span/input[1]"));
            AddButton.Click();
        }

        public string InvalidSkillRecordValidation(IWebDriver driver)
        {
            Thread.Sleep(3000);
            IWebElement Message = driver.FindElement(By.CssSelector("body > div.ns-box.ns-growl.ns-effect-jelly.ns-type-success.ns-show"));
            string alertMessage = Message.Text;
            Console.WriteLine(alertMessage);
            return alertMessage;
        }

        public void BlankLevelRecord(string Skill, string Level)
        {
            IWebElement AddNewButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div"));
            AddNewButton.Click();
            IWebElement SkillTextBox = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[1]/input"));
            SkillTextBox.Click();
            SkillTextBox.SendKeys(Skill);
            IWebElement LevelDropDown = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[2]/select"));
            LevelDropDown.Click();
            LevelDropDown.SendKeys(Level);
            IWebElement AddButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/span/input[1]"));
            AddButton.Click();
        }

        public string BlankLevelRecordValidation(IWebDriver driver)
        {
            Thread.Sleep(2000);
            IWebElement alert = driver.FindElement(By.CssSelector("body > div.ns-box.ns-growl.ns-effect-jelly.ns-type-error.ns-show"));
            string errormessage = alert.Text;
            Console.WriteLine(errormessage);
            return errormessage;           
            
        }

        public void BlankSkillAndLevelRecord(string Skill, string Level)
        {
            IWebElement AddNewButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div"));
            AddNewButton.Click();
            IWebElement SkillTextBox = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[1]/input"));
            SkillTextBox.Click();
            SkillTextBox.SendKeys(Skill);
            IWebElement LevelDropDown = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[2]/select"));
            LevelDropDown.Click();
            LevelDropDown.SendKeys(Level);
            IWebElement AddButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/span/input[1]"));
            AddButton.Click();
        }

        public string BlankSkillAndLevelRecordValidation(IWebDriver driver)
        {
            Thread.Sleep(3000);
            IWebElement alert = driver.FindElement(By.CssSelector("body > div.ns-box.ns-growl.ns-effect-jelly.ns-type-error.ns-show"));
            string errormessage = alert.Text;
            Console.WriteLine(errormessage);
            return errormessage;
        }

        public string DuplicateSkillRecordValidation(IWebDriver driver)
        {
            Thread.Sleep(3000);
            IWebElement alert = driver.FindElement(By.CssSelector("body > div.ns-box.ns-growl.ns-effect-jelly.ns-type-error.ns-show"));
            string errormessage = alert.Text;
            Console.WriteLine(errormessage);
            return errormessage;
        }

        public void EditSkillRecord(IWebDriver driver, string Skill, string Level)
        {
            // Wait for the Edit button to be clickable
            Thread.Sleep(3000);

            // Click the Edit button for the last skill record

            IWebElement EditButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr[last()]/td[3]/span[1]/i"));
            EditButton.Click();

            // Wait for the skill input field to be visible
            wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td/div/div[1]/input", 10);

            // Clear the existing skill and level, then enter new values

            
            IWebElement SkillTextBox = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td/div/div[1]/input"));
            SkillTextBox.SendKeys(Keys.Control + "a");
            SkillTextBox.SendKeys(Keys.Delete);
            SkillTextBox.SendKeys(Skill);

            // wait for the level dropdown to be visible

            Thread.Sleep(2000);

            IWebElement LevelDropDown = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td/div/div[2]/select"));
            LevelDropDown.Click();
            LevelDropDown.SendKeys(Level);


            //wait for the Update button to be clickable
            Thread.Sleep(3000);

            IWebElement UpdateButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td/div/span/input[1]"));
            UpdateButton.Click();
        }

        public void EditBlankLevelRecord(IWebDriver driver, string Skill, string Level)
        {
            // Wait for the Edit button to be clickable
            Thread.Sleep(3000);
            // Click the Edit button for the last skill record
            IWebElement EditButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr[last()]/td[3]/span[1]/i"));
            EditButton.Click();
            // Wait for the skill input field to be visible
            wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td/div/div[1]/input", 10);
            // Clear the existing skill and level, then enter new values
            IWebElement SkillTextBox = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td/div/div[1]/input"));
            SkillTextBox.Click();
            SkillTextBox.Clear();
            SkillTextBox.SendKeys(Skill);

            Thread.Sleep(2000);

            IWebElement LevelDropDown = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td/div/div[2]/select"));
            LevelDropDown.Click();

            Thread.Sleep(2000);
            IWebElement ChooseOption = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td/div/div[2]/select/option[1]"));
            ChooseOption.Click();            

            IWebElement UpdateButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td/div/span/input[1]"));
            UpdateButton.Click();

        }

        public string NewSkillRecordValidation(IWebDriver driver)
        {
            Thread.Sleep(3000);

            IWebElement SkillRecord = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[1]"));
            string SkillText = SkillRecord.Text;
            return SkillText;
        }
        public string NewLevelRecordValidation(IWebDriver driver)
        {
            Thread.Sleep(3000);
            IWebElement LevelRecord = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[2]"));
            string levelText = LevelRecord.Text;
            return levelText;
        }

        // Method to get the skill text before editing
        public string SkillBeforeEdit(IWebDriver driver)
        {
            // Wait for the skill record to be visible
            Thread.Sleep(2000);
            IWebElement SkillRecord = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
            string skillText = SkillRecord.Text;
            return skillText;
        }
        // Method to get the level text before editing
        public string LevelBeforeEdit(IWebDriver driver)
        {
            // Wait for the level record to be visible
            Thread.Sleep(2000);
            IWebElement LevelRecord = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[2]"));
            string levelText = LevelRecord.Text;
            return levelText;
        }

        // Method for editing a record before cancelling changes
        public void EditRecordForCancel(IWebDriver driver, string Skill, string Level)
        {

            // Wait for the Edit button to be clickable
            Thread.Sleep(3000);

            // Finding and clicking the Edit button for the last skill record
            IWebElement Edit = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[3]/span[1]/i"));
            Edit.Click();

            IWebElement SkillTextBox = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td/div/div[1]/input"));
            SkillTextBox.Click();
            SkillTextBox.Clear();
            SkillTextBox.SendKeys(Skill);

            IWebElement LevelDropDown = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td/div/div[2]/select"));
            LevelDropDown.Click();
            LevelDropDown.SendKeys(Level);

            IWebElement CancelButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td/div/span/input[2]"));
            CancelButton.Click();
        }
        public void CancelChanges (IWebDriver driver)
        {
            IWebElement CancelButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td/div/span/input[2]"));
            CancelButton.Click();
        }

        public string CancelSkillValidation(IWebDriver driver)
            
        {
            IWebElement CurrentSkill = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
            return CurrentSkill.Text;

        }

        public string CancelLevelValidation(IWebDriver driver)
        {
            IWebElement CurrentLevel = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[2]"));
            return CurrentLevel.Text;
        }

        public void DeleteSkillRecord(IWebDriver driver)
        {
            // Wait for the Delete button to be clickable
            Thread.Sleep(3000);
            // Click the Delete button for the last skill record
            IWebElement DeleteButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[2]/i"));
            DeleteButton.Click();
        }

        public string DeleteSkillRecordValidation(IWebDriver driver)
        {
            Thread.Sleep(3000);

            var table = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table"));
            var rows = table.FindElements(By.TagName("tr"));
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
