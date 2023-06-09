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
using Microsoft.Extensions.FileProviders;
using WebRunning.API.ViewModel.CauHinhTrangChu;
using static WebRunning.API.Infrastructure.Enums;

namespace WebRunning.API.Controllers
{
    public class Por_CauHinhGiaoDienController : ApiControllerBase<Por_CauHinhGiaoDien>
    {
        private readonly IServiceWrapper _service;
        private readonly ILogger<Por_CauHinhGiaoDienController> _logger;
        public Por_CauHinhGiaoDienController(IServiceWrapper service, ILogger<Por_CauHinhGiaoDienController> logger) : base(service, logger)
        {
            _service = service;
            _logger = logger;
        }
        [HttpGet("TrangChu/KhoiGioiThieu")]
        [AllowAnonymous]
        public async Task<IActionResult> Get_TrangChu_KhoiGioiThieu(string MaNhomTinTuc, int SoLuong)
        {
            try
            {
                _logger.LogInformation("Call Get_TrangChu_KhoiGioiThieu");
                var items = await _service.Por_CauHinhGiaoDien.Get_TrangChu_KhoiGioiThieuAsync(MaNhomTinTuc, SoLuong);
                return ResponseMessage.Success(items);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("Get_TrangChu_KhoiGioiThieu : {0}", ex.Message));
                return ResponseMessage.Error(ex.Message);
            }
        }
        [HttpPost("TrangChu/KhoiMonHoc")]
        [AllowAnonymous]
        public async Task<IActionResult> Get_TrangChu_KhoiMonHoc([FromBody] string[] DsMaMonHoc)
        {
            try
            {
                _logger.LogInformation("Call Get_TrangChu_MonHoc");
                var items = await _service.Por_CauHinhGiaoDien.Get_TrangChu_KhoiMonHocAsync(DsMaMonHoc);
                return ResponseMessage.Success(items);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("Get_TrangChu_MonHoc : {0}", ex.Message));
                return ResponseMessage.Error(ex.Message);
            }
        }
        [HttpPost("TrangChu/KhoiKhoaHoc")]
        [AllowAnonymous]
        public async Task<IActionResult> Get_TrangChu_KhoaHoc([FromBody] KhoiKhoaHocReq[] model)
        {
            try
            {
                _logger.LogInformation("Call Get_TrangChu_KhoaHoc");
                var items = await _service.Por_CauHinhGiaoDien.Get_TrangChu_KhoiKhoaHocAsync(model);
                return ResponseMessage.Success(items);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("Get_TrangChu_KhoaHoc : {0}", ex.Message));
                return ResponseMessage.Error(ex.Message);
            }
        }
        [HttpPost("TrangChu/KhoiSuKien")]
        [AllowAnonymous]
        public async Task<IActionResult> Get_TrangChu_SuKien([FromBody] KhoiSuKienReq model)
        {
            try
            {
                _logger.LogInformation("Call Get_TrangChu_SuKien");
                var items = await _service.Por_CauHinhGiaoDien.Get_TrangChu_SuKienAsync(model.TinhTrang, model.SoLuong);
                return ResponseMessage.Success(items);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("Get_TrangChu_SuKien : {0}", ex.Message));
                return ResponseMessage.Error(ex.Message);
            }
        }
        [HttpGet("TrangChu/KhoiTinTuc")]
        [AllowAnonymous]
        public async Task<IActionResult> Get_TrangChu_TinTuc(string MaNhomTinTuc, int SoLuong)
        {
            try
            {
                _logger.LogInformation("Call Get_TrangChu_TinTuc");
                var items = await _service.Por_CauHinhGiaoDien.Get_TrangChu_TinTucAsync(MaNhomTinTuc, SoLuong);
                return ResponseMessage.Success(items);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("Get_TrangChu_TinTuc : {0}", ex.Message));
                return ResponseMessage.Error(ex.Message);
            }
        }
    }
}