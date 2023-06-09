using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication.Cookies;
using WebRunning.API.Infrastructure.Authentication;
using WebRunning.Lib.Interfaces;
using WebRunning.API.Service;
using WebRunning.Lib.Models;
using WebRunning.Lib.Constant;
using System.Security.Claims;
using WebRunning.Lib.Helpers;
using WebRunning.Lib.Core;
using Microsoft.Extensions.Configuration;
using WebRunning.API.Infrastructure.Authorization;
using WebRunning.API.Model;
using Newtonsoft.Json;

namespace WebRunning.API.Controllers
{
    [ApiController]
    [AuthorizeFilter]
    [Route("api/[controller]")]
    public class Sys_DashboardController : ControllerBase
    {                           
        private readonly IServiceWrapper _service;
        private readonly ILogger<Sys_DashboardController> _logger;
        public Sys_DashboardController(IServiceWrapper service, ILogger<Sys_DashboardController> logger)
        {                                            
            _service = service;
            _logger = logger;
        }
    }
}
