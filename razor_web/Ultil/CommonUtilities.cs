using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace razor_web
{
    public class CommonUtilities
    {
        public static WebElement tryLogin(IWebDriver driver, String username, String password, bool checkAnotherLogin)
        {
            driver.Navigate().GoToUrl(MyProps.LOGINPAGE);
            //CookieUtility.logCookies("Login Page", driver, username);
            WebDriverWait wait = new WebDriverWait(driver, MyProps.WaitSeconds);
            IWebElement formTabElement = wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.CssSelector("a[href$=tab-form]"))).FirstOrDefault();
            formTabElement.Click();
            IWebElement sisterTabElement = wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.CssSelector("a[href$=tab-sister]"))).FirstOrDefault();
            sisterTabElement.Click();
            LOGGER.WriteLogFile("Started with username: " +username);
            IWebElement usernameElement = wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.CssSelector("#username-sister"))).FirstOrDefault();
            usernameElement.Clear();
            usernameElement.SendKeys(username);
            IWebElement passwordElement = wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.CssSelector("#password-sister"))).FirstOrDefault();
            passwordElement.Clear();
            passwordElement.SendKeys(password);
            //passwordElement.Submit();
            //IWebElement logoutElement = wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(MyProps.LOGOUT_XPATH))).FirstOrDefault();
            //if (checkAnotherLogin)
            //{
            //    try
            //    {
            //        WebElement alreadyLoggedInElement = driver.findElement(By.xpath("//*[@id=\"bloccoContenutiAll\"]/div/h1"));
            //        LOGGER.info("User is already logged in : {}", alreadyLoggedInElement.getText());
            //        logoutElement.click();
            //        // wait until hit next request with different username and password.
            //        sleep();
            //        return tryLogin(driver, properties.getUsername(), properties.getPassword(), true);
            //    }
            //    catch (Exception ex)
            //    {
            //        LOGGER.error("User is not logged in. exception {}", ex.getMessage());
            //        CookieUtility.logCookies("Home Page", driver, username);
            //    }
            //}
            return null;
        }

        public static void SLEEP(int milisecond)
        {
            System.Threading.Thread.Sleep(milisecond);
        }
    }
}
