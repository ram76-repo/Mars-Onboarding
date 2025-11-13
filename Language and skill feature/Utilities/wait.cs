using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Language_and_skill_feature.Utilities
{
    public class wait()
    {
        public static void WaitToBeClickable(IWebDriver driver, string locatortype, string locatorvalue, int seconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));

            if (locatortype == "XPath")
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(locatorvalue)));
                wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
                wait.Message = "Element not found";
            }

            if (locatortype == "Id")
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id(locatorvalue)));
                wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
                wait.Message = "Element not found";
            }

            if (locatortype == "CssSelector")
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector(locatorvalue)));
                wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
                wait.Message = "Element not found";
            }
        }

            public static void WaitToBeVisible(IWebDriver driver, string locatortype, string locatorvalue, int seconds)
            {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));

            if (locatortype == "XPath")
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(locatorvalue)));
                wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
                wait.Message = "Element not found";
            }

            if (locatortype == "Id")
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(locatorvalue)));
                wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
                wait.Message = "Element not found";
            }

            if (locatortype == "CssSelector")
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(locatorvalue)));
                wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
                wait.Message = "Element not found";
            }
        }

        

        

    }
}
