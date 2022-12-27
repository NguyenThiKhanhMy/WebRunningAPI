﻿using Microsoft.AspNetCore.Mvc;

namespace WebRunning.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpGet("/")]
        public IActionResult Index()
        {
            
            return new RedirectResult("~/swagger");
        }
    }
}