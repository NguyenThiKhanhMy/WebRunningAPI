using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebRunning.API.Infrastructure.Authorization;
using WebRunning.API.Service;
using WebRunning.API.Controllers;
using WebRunning.API.Model;
using WebRunning.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRunning.API.Controllers
{
    public class Sys_NotificationController : ApiControllerBase<Sys_Notification>
    {
        private readonly IServiceWrapper _service;
        private readonly ILogger<Sys_NotificationController> _logger;
        public Sys_NotificationController(IServiceWrapper service, ILogger<Sys_NotificationController> logger) :base(service, logger)
        {
            _service = service;
            _logger = logger;
        }
    }
}
