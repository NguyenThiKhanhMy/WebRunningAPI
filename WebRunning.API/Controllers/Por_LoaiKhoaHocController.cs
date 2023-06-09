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
    public class Por_LoaiKhoaHocController : ApiControllerBase<Por_LoaiKhoaHoc>
    {
        private readonly IServiceWrapper _service;
        private readonly ILogger<Por_LoaiKhoaHocController> _logger;
        public Por_LoaiKhoaHocController(IServiceWrapper service, ILogger<Por_LoaiKhoaHocController> logger) : base(service, logger)
        {
            _service = service;
            _logger = logger;
        }
        [HttpGet("HoatDong/Portal")]
        [AllowAnonymous]
        public async Task<IActionResult> GetItemsHoatDongPortal()
        {
            try
            {
                _logger.LogInformation("Call GetItemsHoatDongPortal");
                var items = await _service.Por_LoaiKhoaHoc.GetItemsHoatDongPortalAsync();
                return ResponseMessage.Success(items);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("GetItemsHoatDongPortal : {0}", ex.Message));
                return ResponseMessage.Error(ex.Message);
            }
        }
        [HttpDelete("Delete")]
        [AllowAnonymous]
        public async Task<IActionResult> Delete(Guid Id)
        {
            try
            {
                _logger.LogInformation("Call Delete params: (Id ={0}", Id);
                await _service.Por_LoaiKhoaHoc.Delete(Id);
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