using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace razor_web.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessController : ControllerBase
    {
        [Route("/")]
        [HttpGet]
        public IActionResult getInfo()
        {
            return Ok("version: "+ MyProps.CODEVERSION );
        }

        [Route("/upload")]
        [HttpPost]
        public IActionResult changeUsernamePassword([Required]IFormFile csvFile, 
                                                    [Required] bool addQuotation, 
                                                    bool documentReport=false,
                                                    bool addLandValuation = false, 
                                                    bool skipDatabase = false, 
                                                    string parentResourceId = "")
        {
            if (csvFile == null) return BadRequest("Selected file is empty.");
            if (Path.GetExtension(csvFile.FileName) != "csv") return BadRequest(" Required extension is csv found "+ Path.GetExtension(csvFile.FileName));


           

            return Ok("This is changeUsernamePassword API");
        }


    }
}