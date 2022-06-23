using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace razor_web.API
{
    //[Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [Route("api/login")]
        [HttpGet]
        public IActionResult login()
        {
            LOGGER.WriteLogFile("Call api/login!");
            ObjectResult rp = new ObjectResult(null);

            IWebDriver driver = null;
            try
            {
                var a = MyProps.LOGINPAGE;
                rp.StatusCode = 200;
                rp.Value = "Success";
                driver = new ChromeDriver();
                string user = MyProps.USERNAME;
                string passs = MyProps.PASSWORD;
                CommonUtilities.tryLogin(driver, user, passs, false);
                CommonUtilities.SLEEP(3000);
            }
            catch (Exception ex)
            {
                rp.StatusCode = 401;
                rp.Value = ex.Message;
            }
            finally
            {
                if (driver != null) driver.Quit();
            }
            return rp;

            //return Ok("This is login API");
        }

        [Route("api/changeUsernamePassword")]
        [HttpPost]
        public IActionResult changeUsernamePassword(string username, string password)
        {
            return Ok("This is changeUsernamePassword API");
        }


    }
}