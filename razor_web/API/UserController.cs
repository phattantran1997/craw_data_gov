using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            return Ok("This is login API");
        }

        [Route("api/changeUsernamePassword")]
        [HttpPost]
        public IActionResult changeUsernamePassword(string username, string password)
        {
            return Ok("This is changeUsernamePassword API");
        }


    }
}