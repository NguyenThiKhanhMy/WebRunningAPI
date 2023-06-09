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
using Newtonsoft.Json;

namespace WebRunning.API.Controllers
{
    public class Por_DangKyTuVanController : ApiControllerBase<Por_DangKyTuVan>
    {
        private readonly IServiceWrapper _service;
        private readonly ILogger<Por_DangKyTuVanController> _logger;
        public Por_DangKyTuVanController(IServiceWrapper service, ILogger<Por_DangKyTuVanController> logger) : base(service, logger)
        {
            _service = service;
            _logger = logger;
        }
        [HttpPost]
        [AllowAnonymous]
        public override async Task<IActionResult> CreateEntity([FromBody] Por_DangKyTuVan model)
        {
            try
            {
                _logger.LogInformation(string.Format("Call CreateEntity body: ({0})", JsonConvert.SerializeObject(model)));
                var item = await _service.Por_DangKyTuVan.SaveEntityAsync(model);
                return ResponseMessage.Success(item);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("CreateEntity : {0}", ex.Message));
                return ResponseMessage.Error(ex.Message);
            }
        }
    }
}