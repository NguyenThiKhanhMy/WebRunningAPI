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
    public class Por_NhomSuKienController : ApiControllerBase<Por_NhomSuKien>
    {
        private readonly IServiceWrapper _service;
        private readonly ILogger<Por_NhomSuKienController> _logger;
        public Por_NhomSuKienController(IServiceWrapper service, ILogger<Por_NhomSuKienController> logger) : base(service, logger)
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
                var items = await _service.Por_NhomSuKien.GetItemsHoatDongPortalAsync();
                return ResponseMessage.Success(items);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("GetItemsHoatDongPortal : {0}", ex.Message));
                return ResponseMessage.Error(ex.Message);
            }
        }
        [HttpGet("CheckDuplicateAttributes")]
        [AuthorizeFilter]
        public async Task<IActionResult> CheckDuplicateAttributes(Guid? id, string ma)
        {
            try
            {
                _logger.LogInformation(string.Format("Call CheckDuplicateAttributes params: (id = {0}, ma = {1})", id, ma));
                var result = await _service.Por_NhomSuKien.IsDupicateAttributesAsync(id, ma);
                return ResponseMessage.Success(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("CheckDuplicateAttributes : {0}", ex.Message));
                return ResponseMessage.Error(ex.Message);
            }
        }
        [HttpGet("ListHoatDong")]
        [AllowAnonymous]
        public virtual async Task<IActionResult> GetListHoatDongAsync(int page = 1, int pageSize = 10, int totalLimitItems = 500, string searchBy = "", string orderBy = "")
        {
            try
            {
                _logger.LogInformation(string.Format("Call GetListHoatDongAsync params: (page = {0}, pageSize = {1}, totalLimitItems = {2}), searchBy = {3}, orderBy = {4}", page, pageSize, totalLimitItems, searchBy, orderBy));
                var items = await _service.Por_NhomSuKien.GetListEntitiesAsync(page, pageSize, totalLimitItems, searchBy);
                return ResponseMessage.Success(items);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("GetListHoatDongAsync : {0}", ex.Message));
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
                await _service.Por_NhomSuKien.Delete(Id);
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
