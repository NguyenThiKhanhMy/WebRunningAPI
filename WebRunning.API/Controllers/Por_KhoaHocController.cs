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
using WebRunning.API.ViewModel.Portal;
using WebRunning.API.ViewModel.Por_KhoaHoc;

namespace WebRunning.API.Controllers
{
    public class Por_KhoaHocController : ApiControllerBase<Por_KhoaHoc>
    {
        private readonly IServiceWrapper _service;
        private readonly ILogger<Por_KhoaHocController> _logger;
        public Por_KhoaHocController(IServiceWrapper service, ILogger<Por_KhoaHocController> logger) : base(service, logger)
        {
            _service = service;
            _logger = logger;
        }
        [HttpPost("ChonVaoGioHang")]
        [AllowAnonymous]
        public virtual async Task<IActionResult> ChonVaoGioHang([FromBody] List<KhoaHocTrongGioHang> model)
        {
            try
            {
                _logger.LogInformation(string.Format("Call ChonVaoGioHang", ""));
                var items = await _service.Por_KhoaHoc.ChonVaoGioHangAsync(model);
                return ResponseMessage.Success(items);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("ChonVaoGioHang : {0}", ex.Message));
                return ResponseMessage.Error(ex.Message);
            }
        }
        [HttpGet("HocThuPortal")]
        [AllowAnonymous]
        public virtual async Task<IActionResult> GetKhoaHocThu(Guid idKhoaHoc)
        {
            try
            {
                _logger.LogInformation(string.Format("Call GetKhoaHocThu params: (idKhoaHoc = {0})", idKhoaHoc));
                var item = await _service.Por_KhoaHoc.GetKhoaHocThuAsync(idKhoaHoc);
                var item_GiaoAnLyThuyet = await _service.Por_GiaoAnLyThuyet.GetTreePortal(idKhoaHoc);
                var item_GiaoAnThucHanh = await _service.Por_GiaoAnThucHanh.GetTreePortal(idKhoaHoc);
                item.GiaoAnLyThuyet = item_GiaoAnLyThuyet;
                item.GiaoAnThucHanh = item_GiaoAnThucHanh;
                return ResponseMessage.Success(item);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("GetKhoaHocThu : {0}", ex.Message));
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
                var items = await _service.Por_KhoaHoc.GetDanhSachAsync(page, pageSize, totalLimitItems, searchBy, orderBy);
                return ResponseMessage.Success(items);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("GeDanhSachAsync : {0}", ex.Message));
                return ResponseMessage.Error(ex.Message);
            }
        }
        [HttpGet("ChiTiet/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetEntityByIdAsync(Guid id)
        {
            try
            {
                _logger.LogInformation(string.Format("Call GetEntityByIdAsync params: (id = {0})", id));
                var item = await _service.Por_KhoaHoc.GetEntityByIdAsync(id);
                return ResponseMessage.Success(item);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("GetEntityByIdAsync : {0}", ex.Message));
                return ResponseMessage.Error(ex.Message);
            }
        }
        [HttpGet("TheoMonHoc")]
        [AllowAnonymous]
        public async Task<IActionResult> GetItemsTheoMonHoc(Guid idMonHoc)
        {
            try
            {
                _logger.LogInformation(string.Format("Call GetItemsTheoMonHoc params: (idMonHoc = {0})", idMonHoc));
                var item = await _service.Por_KhoaHoc.GetItemsTheoMonHocAsync(idMonHoc);
                return ResponseMessage.Success(item);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("GetItemsTheoMonHoc : {0}", ex.Message));
                return ResponseMessage.Error(ex.Message);
            }
        }
        [HttpGet("TheoLoaiKhoaHoc")]
        [AllowAnonymous]
        public async Task<IActionResult> GetItemsTheoLoaiKhoaHoc(Guid idLoaiKhoaHoc)
        {
            try
            {
                _logger.LogInformation(string.Format("Call GetItemsTheoLoaiKhoaHoc params: (idLoaiKhoaHoc = {0})", idLoaiKhoaHoc));
                var item = await _service.Por_KhoaHoc.GetItemsTheoLoaiKhoaHocAsync(idLoaiKhoaHoc);
                return ResponseMessage.Success(item);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("GetItemsTheoLoaiKhoaHoc : {0}", ex.Message));
                return ResponseMessage.Error(ex.Message);
            }
        }
    }
}