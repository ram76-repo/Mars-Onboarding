using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using Language_and_skill_feature.Pages;
using Language_and_skill_feature.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools;
using OpenQA.Selenium.DevTools;
using OpenQA.Selenium.Support.UI;
using Reqnroll;
using static System.Collections.Specialized.BitVector32;
using DataTable = Reqnroll.DataTable;

namespace Language_Feature.StepDefinitions
{
    
    [Binding]    

    public class LanguageFeatureStepDefinitions
    {
        private IWebDriver driver;

        public LanguageFeatureStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
        }        

        [Given("I logged into the portal succesfully")]
        public void GivenILoggedIntoThePortalSuccesfully()
        {
           Loginpage loginpage = new Loginpage();
          loginpage.ValidLoginAction(driver);
        }

        [Given("I navigate to the profile page")]
        public void GivenINavigateToTheProfilePage()
        {
            Profilepage profilepage = new Profilepage();
            profilepage.NavigateToProfileTab(driver);

        }



        [When("I create a new language record with valid {string} and {string} data")]
        public void WhenICreateANewLanguageRecordWithValidAndData(string languageName, string proficiencyLevel)
        {
            Language language = new Language();            
            language.AddLanguage(driver, languageName, proficiencyLevel);
        }



        [Then("the new language record with valid {string} and {string} should be created successfully")]
        public void ThenTheNewLanguageRecordWithValidAndShouldBeCreatedSuccessfully(string languageName, string proficiencyLevel)
        {
            Language language = new Language();

            string NewLang = language.LangDataValidation(driver);
            string NewLevel = language.LevelDataValidation(driver);

            if (NewLang == languageName && NewLevel == proficiencyLevel)
            {
                Assert.Pass("Record created successfully");
            }
            else
            {
                Assert.Fail("Record creation unsuccessful");
            }
        }


        [When("I create a new language record with blank {string} and valid {string} data")]

        public void WhenICreateANewLanguageRecordWithBlankAndValidData(string languageName, string proficiencyLevel)
        {
            Language language = new Language();
            language.BlankLangRecord(driver, languageName, proficiencyLevel);
        }

        [Then("I should see an error message for blank language name")]
        public void ThenIShouldSeeAnErrorMessageForBlankLanguageName()
        {
            Language language = new Language();
            string BlankLanguageName = language.BlankLangValidation(driver);


            if (BlankLanguageName == "Please enter language and level")
            {
                Assert.Pass("Blank language record not accepted");
            }

            else
            {
                Assert.Fail("Blank language record is accepted");
            }
        }

        [When("I create a new language record with valid {string} and blank {string} data")]
        public void WhenICreateANewLanguageRecordWithValidAndBlankData(string languageName, string proficiencyLevel)
        {
            Language language = new Language();
            language.BlankLevelRecord(driver, languageName, proficiencyLevel);
        }

        [Then("I should see an error message for blank proficiency level")]
        public void ThenIShouldSeeAnErrorMessageForBlankProficiencyLevel()
        {
            Language language = new Language();
            string BlankProficiencyLevel = language.BlankLevelValidation(driver);


            if (BlankProficiencyLevel == "Please enter language and level")
            {
                Assert.Pass("Blank proficiency record not accepted");
            }

            else
            {
                Assert.Fail("Blank proficiency record is accepted");
            }
        }

        [When("I create a new language record with invalid {string} and valid {string} data")]
        public void WhenICreateANewLanguageRecordWithInvalidAndValidData(string languageName, string proficiencyLevel)
        {
            Language language = new Language();
            language.InvalidLangData(driver, languageName, proficiencyLevel);
        }

        [Then("the new language record with invalid {string} should not be created")]
        public void ThenTheNewLanguageRecordWithInvalidShouldNotBeCreated(string languageName)
        {
            Language language = new Language();
            string InvalidLanguageName = language.InvalidLangValidation(driver);
            if (InvalidLanguageName == "Please enter a valid language name")
            {
                Assert.Pass("Invalid language record not accepted");
            }
            else
            {
                Assert.Fail("Invalid language record is accepted");
            }
        }

        [When("I create a new record with valid data")]
        public void WhenICreateANewRecordWithValidData(DataTable table)
        {
            Language language = new Language();

            
            foreach (var row in table.Rows)
            {
                string languageName = row["languageName"];
                string proficiencyLevel = row["proficiencyLevel"];
                language.AddLanguage(driver, languageName, proficiencyLevel);
            }
        }

        [When("I try to create another record with the same data")]
        public void WhenITryToCreateAnotherRecordWithTheSameData(DataTable dataTable)
        {
            Language language = new Language();

            foreach (var row in dataTable.Rows)
            {
               string languageName = row["languageName"];
                string proficiencyLevel = row["proficiencyLevel"];
                language.AddLanguage(driver, languageName, proficiencyLevel);
            }
        }
              

        [Then("I should see an error message for duplicate record")]
        public void ThenIShouldSeeAnErrorMessageForDuplicateRecord()
        {

            try
            {
                // Wait for the page to load
                wait.WaitToBeVisible(driver, "CssSelector", "body > div.ns-box.ns-growl.ns-effect-jelly.ns-type-error.ns-show", 10);
                IWebElement errormessage = driver.FindElement(By.CssSelector("body > div.ns-box.ns-growl.ns-effect-jelly.ns-type-error.ns-show"));
                string error = errormessage.Text;
                Console.WriteLine(error);

                // Check if the error message is displayed
                if (error == "This language is already exist in your language list.")
                {
                    Assert.Pass("Duplicate language record not accepted");
                }
                else
                {
                    Assert.Fail("Duplicate language record is accepted");
                }

            }
            catch (NoSuchElementException e)
            {

                driver.Quit();
            }
        }
             


        [When("I try to create more than four records")]
        public void WhenITryToCreateMoreThanFourRecords(DataTable table)
        {
            Language language = new Language();


            foreach (var row in table.Rows)
            {
                // Assuming the table has columns "languageName" and "proficiencyLevel"
                string languageName = row["languageName"];
                string proficiencyLevel = row["proficiencyLevel"];

                try
                {
                    IWebElement AddButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div"));

                    if (!AddButton.Displayed)
                    {
                        Console.WriteLine("Add button not displayed. Maximum records reached");
                        break;                   
                        
                    }
                    else
                    {
                        language.AddLanguage(driver, languageName, proficiencyLevel);
                    }

                }
                catch (StaleElementReferenceException e)
                {
                    Console.WriteLine("Element not found");
                }


            }
        } 


        

        [Then("I should not be allowed to create more than four records")]
        public void ThenIShouldNotBeAllowedToCreateMoreThanFourRecords()
        {
            try
            {
                if (driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div")).Displayed)

                {
                    Assert.Fail("Add Language button is still enabled after 4 records");

                }
            }
            catch (NoSuchElementException e)
            {
                Assert.Pass("Add Language button is not displayed after 4 records");

            }
        }

        [When("I add new record to the language module")]
        public void WhenIAddNewRecordToTheLanguageModule(DataTable dataTable)
        {
            Language language = new Language();

            // Assuming the DataTable has columns "languageName" and "proficiencyLevel"
            foreach (var row in dataTable.Rows)
            {
                string languageName = row["languageName"];
                string proficiencyLevel = row["proficiencyLevel"];
                language.AddLanguage(driver, languageName, proficiencyLevel);
            }
        }

        [When("I edit the record with new data")]
        public void WhenIEditTheRecordWithNewData(DataTable dataTable)
        {
            Language language = new Language();

            // Assuming the DataTable has columns "languageName" and "proficiencyLevel"
            foreach (var row in dataTable.Rows)
            {
                string languageName = row["languageName"];
                string proficiencyLevel = row["proficiencyLevel"];
                language.EditLanguage(driver, languageName, proficiencyLevel);
            }
        }

        

        [Then("the language record should be updated with new data")]
        public void ThenTheLanguageRecordShouldBeUpdatedWithNewData(DataTable dataTable)
       
        {
            Language language = new Language();

            string UpdatedLang = language.EditLangDataValidation(driver);
            string UpdatedLevel = language.EditLevelDataValidation(driver);

            // Assuming the DataTable has columns "languageName" and "proficiencyLevel"
            foreach (var row in dataTable.Rows)
            {
                string languageName = row["languageName"];
                string proficiencyLevel = row["proficiencyLevel"];

                
                if (UpdatedLang == languageName && UpdatedLevel == proficiencyLevel)
                {
                    Assert.Pass("Record updated successfully");
                }
                else
                {
                    Assert.Fail("Record update unsuccessful");
                }
            }            

        }

        [When("I create a new language record")]
        public void WhenICreateANewLanguageRecord(DataTable dataTable)
        {
            Language language = new Language();
            foreach (var row in dataTable.Rows)
            {
                string languageName = row["languageName"];
                string proficiencyLevel = row["proficiencyLevel"];
                language.AddLanguage(driver, languageName, proficiencyLevel);
            }
        }


        [When("I edit the record with blank {string} and valid {string}")]
        public void WhenIEditTheRecordWithBlankAndValid(string languageName, string proficiencyLevel)
        {
            Language language = new Language();
            language.EditLanguage(driver, languageName, proficiencyLevel);
        }


        [Then("I should see an error message for blank language field")]
        public void ThenIShouldSeeAnErrorMessageForBlankLanguageField()
        {
            Language language = new Language();
            IWebElement cancelButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td/div/span/input[2]"));
            cancelButton.Click();
            string errormessage = language.BlankLangValidation(driver);


            if (errormessage == "Please enter language and level")
            {
                Assert.Pass("Blank language record not accepted");
                
            }

            else
            {
                Assert.Fail("Blank language record is accepted");
            }
                      
        }

        [When("I edit the record with valid {string} and blank {string} data")]
        public void WhenIEditTheRecordWithValidAndBlankData(string languageName, string proficiencyLevel)
        {
            Language language = new Language();
            language.EditWithBlankLevelRecord(driver, languageName, proficiencyLevel);
            Console.WriteLine(languageName);
            Console.WriteLine(proficiencyLevel);
        }
        

        [Then("I should see an error message for blank proficiency level field")]
        public void ThenIShouldSeeAnErrorMessageForBlankProficiencyLevelField()
        {
            Language language = new Language();
            IWebElement cancelButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td/div/span/input[2]"));
            cancelButton.Click();
            string blankLevelname = language.EditBlankLangValidation(driver);

            if (blankLevelname == "Please enter language and level")
            {
                Assert.Pass("Blank proficiency record not accepted");
            }
            else
            {
                Assert.Fail("Blank proficiency record is accepted");
            }
        }

        [When("I edit the record with invalid {string} and {string} data")]
        public void WhenIEditTheRecordWithInvalidAndData(string languageName, string proficiencyLevel)
        {
            Language language = new Language();
            language.EditLanguage(driver, languageName, proficiencyLevel);
        }

        [Then("I should see an error message for invalid data")]
        public void ThenIShouldSeeAnErrorMessageForInvalidData()
        {
            Language language = new Language();
            string InvalidLanguageName = language.EditInvalidLangValidation(driver);

            Console.WriteLine(InvalidLanguageName);

            if (InvalidLanguageName == "XYZ@456")
            {
                Assert.Fail("Invalid language data accepted");
            }
            else
            {
                Assert.Pass("Invalid language data is not accepted");
            }
        }

        [When("I edit the record with new {string} and {string} data and click cancel")]
        public void WhenIEditTheRecordWithNewAndDataAndClickCancel(string languageName, string proficiencyLevel)
        {
            Language language = new Language();
            language.CancelLang(driver, languageName, proficiencyLevel);

            IWebElement CancelButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td/div/span/input[2]"));
            CancelButton.Click();
        }
                
        
        [Then("the language record should not be updated with new data")]
        public void ThenTheLanguageRecordShouldNotBeUpdatedWithNewData()
        {
            Language language = new Language();
            string CancelLang = language.LangDataCancelValidation(driver);
            string CancelLevel = language.LevelDataCancelValidation(driver);

            if (CancelLang == "Telugu" && CancelLevel == "Conversational")
            {
                Assert.Fail("Record updation not cancelled");
            }
            else
            {
                Assert.Pass("Record updation cancelled");
            }
        }

        [When("I delete the record")]
        public void WhenIDeleteTheRecord()
        {
            Language language = new Language();
            language.DeleteLanguage(driver);
        }
        

        [Then("the language record should be deleted successfully")]
        public void ThenTheLanguageRecordShouldBeDeletedSuccessfully()
        {
            Language language = new Language();
            string dataval = language.DeleteLangDataValidation(driver);

            Console.WriteLine(dataval);

            if (dataval == "1")
            {
                Assert.Pass("Record deleted successfully");
            }
            else
            {
                Assert.Fail("Record not deleted");
            }
            
        }

        [When("I add a profile description with valid {string}")]
        public void WhenIAddAProfileDescriptionWithValid(string profileDescription)
        {
            Language language = new Language();
            language.AddDescription(driver, profileDescription);
        }

        [Then("the profile description should be saved successfully")]
        public void ThenTheProfileDescriptionShouldBeSavedSuccessfully()
        {
            Language language = new Language();
            string Description = language.DescriptionValidation(driver);
            if (Description == "I am a software engineer with 5 years of experience in web development.")
            {
                Assert.Pass("Profile description saved successfully");
            }
            else
            {
                Assert.Fail("Profile description not saved");
            }
            driver.Quit();
        }

        [When("I delete the existing text and leave a blank for the profile description and save")]
        public void WhenIDeleteTheExistingTextAndLeaveABlankForTheProfileDescriptionAndSave()
        {
            Language language = new Language();

            // Attempt to add a blank profile description
            language.AddBlankDescription(driver);
        }

     

        [Then("it should show an error message")]
        public void ThenItShouldShowAnErrorMessage()
        {
            Language language = new Language();
            string BlankDescription = language.BlankDescriptionValidation(driver);

            if (BlankDescription == "Please, a description is required")
            {
                Assert.Pass("Blank profile description not accepted");
            }
            else
            {
                Assert.Fail("Blank profile description is accepted");
            }
        }
        [When("I add a {string} with more than {string} characters")]
        public void WhenIAddAWithMoreThanCharacters(string profileDescription, string p1)
        {
            Language language = new Language();
            language.AddLongDescription(driver, profileDescription);
        }

        [Then("it should not accept additional characters")]
        public void ThenItShouldNotAcceptAdditionalCharacters()
        {
            Language language = new Language();
            string LongDescription = language.LongDescriptionValidation(driver);
            int i = LongDescription.Length;

            if (i > 600)
            {
                Assert.Fail("Profile description accepts more than 600 characters");
            }
            else
            {
                Assert.Pass("Profile description does not accept more than 600 characters");
            }
        }


        




    }

}          



        




