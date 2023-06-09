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
    public class Por_ThongTinChuyenKhoanController : ApiControllerBase<Por_ThongTinChuyenKhoan>
    {
        private readonly IServiceWrapper _service;
        private readonly ILogger<Por_ThongTinChuyenKhoanController> _logger;
        public Por_ThongTinChuyenKhoanController(IServiceWrapper service, ILogger<Por_ThongTinChuyenKhoanController> logger) : base(service, logger)
        {
            _service = service;
            _logger = logger;
        }
    }
}