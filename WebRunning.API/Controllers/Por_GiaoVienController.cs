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
    public class Por_GiaoVienController : ApiControllerBase<Por_GiaoVien>
    {
        private readonly IServiceWrapper _service;
        private readonly ILogger<Por_GiaoVienController> _logger;
        public Por_GiaoVienController(IServiceWrapper service, ILogger<Por_GiaoVienController> logger) : base(service, logger)
        {
            _service = service;
            _logger = logger;
        }
    }
}