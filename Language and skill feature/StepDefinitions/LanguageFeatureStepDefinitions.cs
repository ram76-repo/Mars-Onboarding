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
        private Loginpage loginpage;
        private Profilepage profilepage;
        private Language language;

        public LanguageFeatureStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
            loginpage = new Loginpage(this.driver);
            profilepage = new Profilepage(this.driver);
            language = new Language(this.driver);
        }        

        [Given("I logged into the portal succesfully")]
        public void GivenILoggedIntoThePortalSuccesfully()
        {
          
          loginpage.ValidLoginAction();
        }

        [Given("I navigate to the profile page")]
        public void GivenINavigateToTheProfilePage()
        {
            
            profilepage.NavigateToProfileTab(driver);

        }



        [When("I create a new language record with valid {string} and {string} data")]
        public void WhenICreateANewLanguageRecordWithValidAndData(string languageName, string proficiencyLevel)
        {
            
            language.AddLanguage(languageName, proficiencyLevel);
        }



        [Then("the new language record with valid {string} and {string} should be created successfully")]
        public void ThenTheNewLanguageRecordWithValidAndShouldBeCreatedSuccessfully(string languageName, string proficiencyLevel)
        {
            

            string NewLang = language.LangDataValidation();
            string NewLevel = language.LevelDataValidation();

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
            language.AddLanguage(languageName, proficiencyLevel);

            //language.BlankLangRecord(languageName, proficiencyLevel);
        }

        [Then("I should see an error message for blank language name")]
        public void ThenIShouldSeeAnErrorMessageForBlankLanguageName()
        {
            
            string BlankLanguageName = language.BlankLangValidation();


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
            language.AddLanguage(languageName, proficiencyLevel);

            // language.BlankLevelRecord(languageName, proficiencyLevel);
        }

        [Then("I should see an error message for blank proficiency level")]
        public void ThenIShouldSeeAnErrorMessageForBlankProficiencyLevel()
        {


            string BlankProficiencyLevel = language.BlankLangValidation();


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
            language.AddLanguage(languageName, proficiencyLevel);

            //language.InvalidLangData(languageName, proficiencyLevel);
        }

        [Then("the new language record with invalid {string} should not be created")]
        public void ThenTheNewLanguageRecordWithInvalidShouldNotBeCreated(string languageName)
        {

            string InvalidLanguageName = language.LangDataValidation();

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
            
            
            foreach (var row in table.Rows)
            {
                string languageName = row["languageName"];
                string proficiencyLevel = row["proficiencyLevel"];
                language.AddLanguage(languageName, proficiencyLevel);
            }
        }

        [When("I try to create another record with the same data")]
        public void WhenITryToCreateAnotherRecordWithTheSameData(DataTable dataTable)
        {
            

            foreach (var row in dataTable.Rows)
            {
               string languageName = row["languageName"];
                string proficiencyLevel = row["proficiencyLevel"];
                language.AddLanguage(languageName, proficiencyLevel);
            }
        }
              

        [Then("I should see an error message for duplicate record")]
        public void ThenIShouldSeeAnErrorMessageForDuplicateRecord()
        {

            try
            {
                // Wait for the page to load
                wait.WaitToBeVisible(driver, "CssSelector", "body > div.ns-box.ns-growl.ns-effect-jelly.ns-type-error.ns-show", 10);

                string error = language.DuplicateRecordValidation();
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
            
            foreach (var row in table.Rows)
            {
                // Assuming the table has columns "languageName" and "proficiencyLevel"
            
                string languageName = row["languageName"];
                string proficiencyLevel = row["proficiencyLevel"];

                try
                {
                    Thread.Sleep(4000); 
                    string Button = language.ExcessRecord();
                   // bool isAddButtonVisible = Convert.ToBoolean(Button);

                    if (Button == "False")
                    {
                        Console.WriteLine("Add button not displayed. Maximum records reached");
                        break;
                    }
                    else
                    {
                        language.AddLanguage(languageName, proficiencyLevel);
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
                string Button = language.ExcessRecord();
                //bool isAddButtonVisible = Convert.ToBoolean(Button);

                if (Button == "True")
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
            

            // Assuming the DataTable has columns "languageName" and "proficiencyLevel"
            foreach (var row in dataTable.Rows)
            {
                string languageName = row["languageName"];
                string proficiencyLevel = row["proficiencyLevel"];
                language.AddLanguage(languageName, proficiencyLevel);
            }
        }

        [When("I edit the record with new data")]
        public void WhenIEditTheRecordWithNewData(DataTable dataTable)
        {
            

            // Assuming the DataTable has columns "languageName" and "proficiencyLevel"
            foreach (var row in dataTable.Rows)
            {
                string languageName = row["languageName"];
                string proficiencyLevel = row["proficiencyLevel"];
                language.EditLanguage(languageName, proficiencyLevel);
            }
        }

        

        [Then("the language record should be updated with new data")]
        public void ThenTheLanguageRecordShouldBeUpdatedWithNewData(DataTable dataTable)
       
        {

            string UpdatedLang = language.EditLangDataValidation();
            string UpdatedLevel = language.EditLevelDataValidation();

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
            foreach (var row in dataTable.Rows)
            {
                string languageName = row["languageName"];
                string proficiencyLevel = row["proficiencyLevel"];
                language.AddLanguage(languageName, proficiencyLevel);
            }
        }


        [When("I edit the record with blank {string} and valid {string}")]
        public void WhenIEditTheRecordWithBlankAndValid(string languageName, string proficiencyLevel)
        {

            language.EditLanguage(languageName, proficiencyLevel);
        }


        [Then("I should see an error message for blank language field")]
        public void ThenIShouldSeeAnErrorMessageForBlankLanguageField()
        {
            language.cancelButtonclick();         
            string errormessage = language.EditBlankLangValidation();

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

            //language.BlankLevelRecord(languageName, proficiencyLevel);
            language.EditWithBlankLevelRecord(languageName, proficiencyLevel);
            Console.WriteLine(languageName);
            Console.WriteLine(proficiencyLevel);
        }
        

        [Then("I should see an error message for blank proficiency level field")]
        public void ThenIShouldSeeAnErrorMessageForBlankProficiencyLevelField()
        {

            language.cancelButtonclick();
            string blankLevelname = language.BlankLangValidation();

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

            language.EditLanguage(languageName, proficiencyLevel);
        }

        [Then("I should see an error message for invalid data")]
        public void ThenIShouldSeeAnErrorMessageForInvalidData()
        {

            string InvalidLanguageName = language.LangDataValidation();

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

            language.CancelLang(languageName, proficiencyLevel);

            Thread.Sleep(2000);

            language.cancelButtonclick();

        }
                
        
        [Then("the language record should not be updated with new data")]
        public void ThenTheLanguageRecordShouldNotBeUpdatedWithNewData()
        {

            string CancelLang = language.LangDataCancelValidation();
            string CancelLevel = language.LevelDataCancelValidation();

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

            language.DeleteLanguage();
        }
        

        [Then("the language record should be deleted successfully")]
        public void ThenTheLanguageRecordShouldBeDeletedSuccessfully()
        {

            string dataval = language.DeleteLangDataValidation();

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

            language.AddDescription(profileDescription);
        }

        [Then("the profile description should be saved successfully")]
        public void ThenTheProfileDescriptionShouldBeSavedSuccessfully()
        {

            string Description = language.DescriptionValidation();
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
            

            // Attempt to add a blank profile description
            language.AddBlankDescription();
        }

     

        [Then("it should show an error message")]
        public void ThenItShouldShowAnErrorMessage()
        {

            string BlankDescription = language.BlankDescriptionValidation();

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

            language.AddDescription(profileDescription);
        }

        [Then("it should not accept additional characters")]
        public void ThenItShouldNotAcceptAdditionalCharacters()
        {

            string LongDescription = language.LongDescriptionValidation();
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



        





