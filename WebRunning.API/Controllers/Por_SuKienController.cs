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
    public class Por_SuKienController : ApiControllerBase<Por_SuKien>
    {
        private readonly IServiceWrapper _service;
        private readonly ILogger<Por_SuKienController> _logger;
        public Por_SuKienController(IServiceWrapper service, ILogger<Por_SuKienController> logger) : base(service, logger)
        {
            _service = service;
            _logger = logger;
        }
        [HttpGet("TheoNhomSuKienMoiNhat")]
        [AllowAnonymous]
        public async Task<IActionResult> GetItemsTheoNhomSuKienMoiNhat(int limit)
        {
            try
            {
                _logger.LogInformation(string.Format("Call GetItemsTheoNhomSuKienMoiNhat params: (limit = {0})", limit));
                var item = await _service.Por_SuKien.GetItemsTheoNhomSuKienMoiNhatAsync(limit);
                return ResponseMessage.Success(item);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("GetItemsTheoNhomSuKien : {0}", ex.Message));
                return ResponseMessage.Error(ex.Message);
            }
        }
        [HttpGet("TheoNhomSuKien")]
        [AllowAnonymous]
        public async Task<IActionResult> GetItemsTheoNhomSuKien(Guid idNhomSuKien)
        {
            try
            {
                _logger.LogInformation(string.Format("Call GetItemsTheoNhomSuKien params: (idNhomSuKien = {0})", idNhomSuKien));
                var item = await _service.Por_SuKien.GetItemsTheoNhomSuKienAsync(idNhomSuKien);
                return ResponseMessage.Success(item);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("GetItemsTheoNhomSuKien : {0}", ex.Message));
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
                var items = await _service.Por_SuKien.GetDanhSachAsync(page, pageSize, totalLimitItems, searchBy, orderBy);
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
                var item = await _service.Por_SuKien.GetEntityByIdAsync(id);
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