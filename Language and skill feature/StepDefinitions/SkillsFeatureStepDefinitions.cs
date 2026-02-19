using Language_and_skill_feature.Pages;
using Language_and_skill_feature.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.Log;
using OpenQA.Selenium.Chrome;
using Reqnroll;
using System;

namespace Language_and_skill_feature.StepDefinitions
{
    [Binding]
    public class SkillsFeatureStepDefinitions
    {

        private IWebDriver driver;
        private Loginpage loginpage;
        private Language language;
        private Skills skills;

        public SkillsFeatureStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
            loginpage = new Loginpage(this.driver);
            language = new Language(this.driver);
            skills = new Skills(this.driver);
        }

        [Given("I logged into the portal successfully")]
        public void GivenILoggedIntoThePortalSuccessfully()
        {
                       
            loginpage.ValidLoginAction();
        }

        [Given("I navigate to the skills tab")]
        public void GivenINavigateToTheSkillsTab()
        {
            wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]", 10);

            IWebElement SkillsTab = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]"));
            SkillsTab.Click();

        }

        [When("I add a new skill with valid {string} and {string} data")]
        public void WhenIAddANewSkillWithValidAndData(string Skill, string Level)
        {

            skills.AddValidSkillRecord(Skill, Level);
        }

        [Then("the new {string} and {string} should be created successfully")]
        public void ThenTheNewAndShouldBeCreatedSuccessfully(string Skill, string Level)
        {
            
            string ActualSkill = skills.SkillRecordValidation(driver);
            string ActualLevel = skills.LevelRecordValidation(driver);

            if (ActualSkill == Skill && ActualLevel == Level)
            {
                Assert.Pass("Skill and Level are created successfully");
            }
            else
            {
                Assert.Fail("Skill or Level creation failed");
            }
        }

        [When("I add a new skill with blank {string} and valid {string} data")]
        public void WhenIAddANewSkillWithBlankAndValidData(string Skill, string Level)
        {
            
            skills.AddValidSkillRecord(Skill, Level);
        }

        [Then("I should see an error message for blank Skill")]
        public void ThenIShouldSeeAnErrorMessageForBlankSkill()
        {
              skills.cancelEdit(driver);

            string alertMessage = skills.BlankSkillRecordValidation(driver);
                Console.WriteLine(alertMessage);
                if (alertMessage.Contains("Please enter skill and experience level"))
                {
                    Assert.Pass("Error message for blank Skill is displayed successfully");
                }
                else
                {
                    Assert.Fail("Error message for blank Skill is not displayed");
                }
            }        
        

        [When("I add a new skill with invalid {string} and valid {string} data")]
        public void WhenIAddANewSkillWithInvalidAndValidData(string Skill, string Level)
        {
            
            skills.AddValidSkillRecord(Skill, Level);
        }

        [Then("I should see an error message for invalid Skill")]
        public void ThenIShouldSeeAnErrorMessageForInvalidSkill()
        {
            
            string alertMessage = skills.InvalidSkillRecordValidation(driver);
            Console.WriteLine(alertMessage);

            if (alertMessage.Contains("Please enter valid skill name"))
            {
                Assert.Pass("Invalid skill data not accepted");
            }
            else
            {
                Assert.Fail("Invalid skill data is accepted");
            }
        }

        [When("I add a new skill with valid {string} and blank {string} data")]
        public void WhenIAddANewSkillWithValidAndBlankData(string Skill, string Level)
        {
            
            skills.AddValidSkillRecord(Skill, Level);
        }

        [Then("I should see an error message for blank Level")]
        public void ThenIShouldSeeAnErrorMessageForBlankLevel()
        {
            //skills.cancelEdit(driver);

            string alertMessage = skills.BlankSkillRecordValidation(driver);
                Console.WriteLine(alertMessage);
                if (alertMessage.Contains("Please enter skill and experience level"))
                {
                    Assert.Pass("Error message for blank Level is displayed successfully");
                }
                else
                {
                    Assert.Fail("Error message for blank Level is not displayed");
                }            
            
        }

        [When("I add a blank {string} and blank {string} data")]
        public void WhenIAddABlankAndBlankData(string Skill, string Level)
        {
            
            skills.AddValidSkillRecord(Skill, Level);
        }

        [Then("I should see an error message")]
        public void ThenIShouldSeeAnErrorMessage()
        {
            
            string alertMessage = skills.BlankSkillRecordValidation(driver);
            Console.WriteLine(alertMessage);

            if (alertMessage.Contains("Please enter skill and experience level"))
            {
                Assert.Pass("Blank Skill and Level are not accepted");
                
            }
            else
            {
                Assert.Fail("Blank Skill and Level are accepted");
            }

        }

        [Given("I add a new skill")]
        public void GivenIAddANewSkill(DataTable dataTable)
        {
            
            foreach (var row in dataTable.Rows)
            {
                string Skill = row["Skill"];
                string Level = row["Level"];

                skills.AddValidSkillRecord(Skill, Level);
            }
        }

                
            [When("I try to add the same skill again")]
            public void WhenITryToAddTheSameSkillAgain(DataTable dataTable)
            {
            
            foreach (var row in dataTable.Rows)
            {
                string Skill = row["Skill"];
                string Level = row["Level"];

                skills.AddValidSkillRecord(Skill, Level);
            }
        }

        
        [Then("I should see an error message for duplicate")]
        public void ThenIShouldSeeAnErrorMessageForDuplicate()
        {
            
            string alertMessage = skills.BlankSkillRecordValidation(driver);
            Console.WriteLine(alertMessage);

            if (alertMessage.Contains("This skill is already exist in your skill list."))
            {
                Assert.Pass("Duplicate skill is not accepted");
            }
            else
            {
                Assert.Fail("Duplicate skill is accepted");
            }
        }

        [When("I edit this record")]
        public void WhenIEditThisRecord(DataTable dataTable)
        {
            
            foreach (var row in dataTable.Rows)
            {
                string Skill = row["Skill"];
                string Level = row["Level"];
                skills.EditSkillRecord(Skill, Level);
            }
        }

                        

        [Then("the skill record should be updated successfully")]
        public void ThenTheSkillRecordShouldBeUpdatedSuccessfully()
        {
            
            string NewSkill = skills.SkillRecordValidation(driver);
            string NewLevel = skills.LevelRecordValidation(driver);
            Console.WriteLine("Updated Skill: " + NewSkill);
            Console.WriteLine("Updated Level: " + NewLevel);

            if (NewSkill == "Python" && NewLevel == "Beginner")
            {
                Assert.Pass("Skill and Level are updated successfully");
            }
            else
            {
                Assert.Fail("Skill or Level update failed");
            }
        }

        [When("I edit this record with {string} data and blank {string}")]
        public void WhenIEditThisRecordWithDataAndBlank(string Skill, string Level)
        {
            
            skills.EditBlankLevelRecord(Skill, Level);
        }



        [When("I edit this record with valid {string} and blank {string}")]
        public void WhenIEditThisRecordWithValidAndBlank(string Skill, string Level)
        {
            
            skills.EditSkillRecord(Skill, Level);
        }


        [When("I edit this record with blank level")]
        public void WhenIEditThisRecordWithBlankLevel(DataTable dataTable)
        {
            
            foreach (var row in dataTable.Rows)
            {
                string Skill = row["Skill"];
                string Level = row["Level"];
                skills.EditSkillRecord(Skill, Level);
            }
        }


        // Editing skill record with blank skill and valid level data

        [When("I edit this record with blank {string} and valid {string}")]
        public void WhenIEditThisRecordWithBlankAndValid(string Skill, string Level)
        {
            
            skills.EditSkillRecord(Skill, Level);
        }


       
        [When("I edit this record and click on cancel")]
        public void WhenIEditThisRecordAndClickOnCancel(DataTable dataTable)
        {
            
            foreach (var row in dataTable.Rows)
            {
                string Skill = row["Skill"];
                string Level = row["Level"];
                skills.EditRecordForCancel(driver, Skill, Level);
            }
                        
        }
       
        [Then("the changes should not be saved")]
        public void ThenTheChangesShouldNotBeSaved()
        {
            
            string existingSkill = skills.SkillBeforeEdit(driver);
            string existingLevel = skills.LevelBeforeEdit(driver);

            string currentSkill = skills.CancelSkillValidation(driver);
            string currentLevel = skills.CancelLevelValidation(driver);

            if (currentSkill == existingSkill && currentLevel == existingLevel)
            {
                Assert.Pass("Changes are not saved after cancellation.");
            }
            else
            {
                Assert.Fail("Changes are saved after cancellation.");
            }

            Console.WriteLine("Current skill: " + currentSkill);
            Console.WriteLine("Current level: " + currentLevel);

        }

        [When("I delete this record")]
        public void WhenIDeleteThisRecord()
        {
            skills.DeleteSkillRecord(driver);
        }

        [Then("the skill record should be deleted successfully")]
        public void ThenTheSkillRecordShouldBeDeletedSuccessfully()
        {
            
            string deleteValidation = skills.DeleteSkillRecordValidation(driver);

            if (deleteValidation == "0")
            {
                Assert.Pass("Record successfully deleted");
            }
            else
            {
                Assert.Fail("Record not deleted");
            }            

        }

    }
}
