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
    public class Por_GioHangController : ApiControllerBase<Por_GioHang>
    {
        private readonly IServiceWrapper _service;
        private readonly ILogger<Por_GioHangController> _logger;
        public Por_GioHangController(IServiceWrapper service, ILogger<Por_GioHangController> logger) : base(service, logger)
        {
            _service = service;
            _logger = logger;
        }
    }
}