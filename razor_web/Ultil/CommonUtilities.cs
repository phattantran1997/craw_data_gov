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
        public static IWebElement tryLogin(IWebDriver driver, String username, String password, bool checkAnotherLogin)
        {
            driver.Navigate().GoToUrl(MyProps.LOGINPAGE);

            LOGGER.WriteLogFile_Cookie("Login page",driver,username);
           
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
            passwordElement.Submit();
            IWebElement logoutElement = wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(MyProps.LOGOUT_XPATH))).FirstOrDefault();
            if (checkAnotherLogin)
            {
                try
                {
                    IWebElement alreadyLoggedInElement = driver.FindElement(By.XPath("//*[@id=\"bloccoContenutiAll\"]/div/h1"));
                    LOGGER.WriteLogFile("User is already logged in : "+ alreadyLoggedInElement.Text);
                    logoutElement.Click();
                    // wait until hit next request with different username and password.
                    SLEEP(3000);
                    return tryLogin(driver, MyProps.USERNAME, MyProps.PASSWORD, true);
                }
                catch (Exception ex)
                {
                    LOGGER.WriteLogFile("User is not logged in. exception "+ ex.Message);
                    LOGGER.WriteLogFile_Cookie("Home Page", driver, username);
                }
            }
            return logoutElement;
        }

        public static void SLEEP(int milisecond)
        {
            System.Threading.Thread.Sleep(milisecond);
        }
    }
}
