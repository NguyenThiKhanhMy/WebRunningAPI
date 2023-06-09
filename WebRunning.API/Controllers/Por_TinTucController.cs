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
    public class Por_TinTucController : ApiControllerBase<Por_TinTuc>
    {
        private readonly IServiceWrapper _service;
        private readonly ILogger<Por_TinTucController> _logger;
        public Por_TinTucController(IServiceWrapper service, ILogger<Por_TinTucController> logger) : base(service, logger)
        {
            _service = service;
            _logger = logger;
        }
        [HttpGet("TheoChuyenMuc")]
        [AllowAnonymous]
        public async Task<IActionResult> GetItemsTheoChuyenMuc(Guid idChuyenMuc)
        {
            try
            {
                _logger.LogInformation(string.Format("Call GetItemsTheoChuyenMuc params: (idChuyenMuc = {0})", idChuyenMuc));
                var item = await _service.Por_TinTuc.GetItemsTheoChuyenMucAsync(idChuyenMuc);
                return ResponseMessage.Success(item);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("GetItemsTheoChuyenMuc : {0}", ex.Message));
                return ResponseMessage.Error(ex.Message);
            }
        }
        [HttpGet("TinNoiBat")]
        [AllowAnonymous]
        public async Task<IActionResult> GetItemsTinNoiBat(int limit)
        {
            try
            {
                _logger.LogInformation(string.Format("Call GetItemsTinNoiBat_TinMoi params: (limit = {0})", limit));
                var item = await _service.Por_TinTuc.GetItemsTinNoiBatAsync(limit);
                return ResponseMessage.Success(item);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("GetItemsTinNoiBat_TinMoi : {0}", ex.Message));
                return ResponseMessage.Error(ex.Message);
            }
        }
        [HttpGet("DanhSach")]
        [AuthorizeFilter]
        public virtual async Task<IActionResult> GetDanhSachAsync(int page = 1, int pageSize = 10, int totalLimitItems = 500, string searchBy = "", string orderBy = "")
        {
            try
            {
                _logger.LogInformation(string.Format("Call GetDanhSachAsync params: (page = {0}, pageSize = {1}, totalLimitItems = {2}), searchBy = {3}, orderBy = {4}", page, pageSize, totalLimitItems, searchBy, orderBy));
                var items = await _service.Por_TinTuc.GetDanhSachAsync(page, pageSize, totalLimitItems, searchBy, orderBy);
                return ResponseMessage.Success(items);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("GeDanhSachAsync : {0}", ex.Message));
                return ResponseMessage.Error(ex.Message);
            }
        }
        [HttpGet("{id}")]
        [AllowAnonymous]
        public override async Task<IActionResult> GetEntityByIdAsync(Guid id)
        {
            try
            {
                _logger.LogInformation(string.Format("Call GetEntityByIdAsync params: (id = {0})", id));
                var item = await _service.Por_TinTuc.GetEntityByIdAsync(id);
                return ResponseMessage.Success(item);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("GetEntityByIdAsync : {0}", ex.Message));
                return ResponseMessage.Error(ex.Message);
            }
        }
    }
}