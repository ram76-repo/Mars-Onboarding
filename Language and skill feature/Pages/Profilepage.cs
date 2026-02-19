using Language_and_skill_feature.Hooks;
using Language_and_skill_feature.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Language_and_skill_feature.Pages
{
    public class Profilepage
    {
        private IWebDriver driver;
        public Profilepage(IWebDriver driver) 
        {
                        this.driver = driver;
        }

        By ProfileTab = By.XPath("//*[@id=\"account-profile-section\"]/div/section[1]/div/a[2]");
        By SkillsTab = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]");
        By LanguagesTab = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[1]");
        By CertificationTab = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[4]");

        public void NavigateToProfileTab(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            wait.Until(ExpectedConditions.ElementIsVisible(ProfileTab));
            driver.FindElement(ProfileTab).Click();           
        }
        public void NavigateToSkillsTab(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(SkillsTab));
            driver.FindElement(SkillsTab).Click();
        }

        public void NavigateToLanguagesTab(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(LanguagesTab));
            driver.FindElement(LanguagesTab).Click();
        }

        public void NavigateToCertification(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(CertificationTab));
            driver.FindElement(CertificationTab).Click();
        }

    }
    
        

    
}
