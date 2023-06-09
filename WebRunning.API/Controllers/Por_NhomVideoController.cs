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
    public class Por_NhomVideoController : ApiControllerBase<Por_NhomVideo>
    {
        private readonly IServiceWrapper _service;
        private readonly ILogger<Por_NhomVideoController> _logger;
        public Por_NhomVideoController(IServiceWrapper service, ILogger<Por_NhomVideoController> logger) : base(service, logger)
        {
            _service = service;
            _logger = logger;
        }
        [HttpDelete("Delete")]
        [AllowAnonymous]
        public async Task<IActionResult> Delete(Guid Id)
        {
            try
            {
                _logger.LogInformation("Call Delete params: (Id ={0}", Id);
                await _service.Por_NhomVideo.Delete(Id);
                return ResponseMessage.Success();
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("Delete : {0}", ex.Message));
                return ResponseMessage.Error(ex.Message);
            }
        }
    }
}