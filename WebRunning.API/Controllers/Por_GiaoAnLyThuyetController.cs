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
    public class Por_GiaoAnLyThuyetController : ApiControllerBase<Por_GiaoAnLyThuyet>
    {
        private readonly IServiceWrapper _service;
        private readonly ILogger<Por_GiaoAnLyThuyetController> _logger;
        public Por_GiaoAnLyThuyetController(IServiceWrapper service, ILogger<Por_GiaoAnLyThuyetController> logger) : base(service, logger)
        {
            _service = service;
            _logger = logger;
        }
        //[HttpGet("TreePortal/{IdKhoaHoc}")]
        //[AllowAnonymous]
        //public virtual async Task<IActionResult> GetTreePortal(Guid IdKhoaHoc)
        //{
        //    try
        //    {
        //        _logger.LogInformation(string.Format("Call GetTreePortal IdKhoaHoc: {0}", IdKhoaHoc));
        //        var item = await _service.Por_GiaoAnLyThuyet.GetTreePortal(IdKhoaHoc);
        //        return ResponseMessage.Success(item);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(string.Format("GetTreePortal : {0}", ex.Message));
        //        return ResponseMessage.Error(ex.Message);
        //    }
        //}
        [HttpGet("LinkVideo/GiaoAn/{GiaoAnId}")]
        [AllowAnonymous]
        public virtual async Task<IActionResult> GetLinkVideo(Guid GiaoAnId)
        {
            try
            {
                _logger.LogInformation(string.Format("Call GetLinkVideo GiaoAnId: {0}", GiaoAnId));
                var UserId = Guid.Empty;
                var item = await _service.Por_GiaoAnLyThuyet.GetLinkVideo(GiaoAnId, UserId);
                return ResponseMessage.Success(item);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("GetLinkVideo : {0}", ex.Message));
                return ResponseMessage.Error(ex.Message);
            }
        }
        [HttpGet("Tree/{IdKhoaHoc}")]
        [AuthorizeFilter]
        public virtual async Task<IActionResult> GetTree(Guid IdKhoaHoc)
        {
            try
            {
                _logger.LogInformation(string.Format("Call GetTree IdKhoaHoc: {0}", IdKhoaHoc));
                var item = await _service.Por_GiaoAnLyThuyet.GetTree(IdKhoaHoc);
                return ResponseMessage.Success(item);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("GetTree : {0}", ex.Message));
                return ResponseMessage.Error(ex.Message);
            }
        }
        [HttpPost("{IdKhoaHoc}")]
        [AuthorizeFilter]
        public virtual async Task<IActionResult> CreateGiaoAnLyThuyet([FromBody] Por_GiaoAnLyThuyet model, Guid IdKhoaHoc)
        {
            try
            {
                _logger.LogInformation(string.Format("Call CreateGiaoAnLyThuyet body: ({0})", JsonConvert.SerializeObject(model)));
                var itemGiaoAnLyThuyet = await _service.Por_GiaoAnLyThuyet.SaveEntityAsync(model);
                Por_KhoaHoc_GiaoAn khoaHoc_GiaoAn = new Por_KhoaHoc_GiaoAn();
                khoaHoc_GiaoAn.IdGiaoAn = itemGiaoAnLyThuyet.Id;
                khoaHoc_GiaoAn.IdKhoaHoc = IdKhoaHoc;
                khoaHoc_GiaoAn.LoaiGiaoAnLy = Infrastructure.Enums.LoaiGiaoAn.GiaoAnLyThuyet;
                var itemKhoaHoc_GiaoAn = await _service.Por_KhoaHoc_GiaoAn.SaveEntityAsync(khoaHoc_GiaoAn);
                return ResponseMessage.Success(khoaHoc_GiaoAn);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("CreateGiaoAnLyThuyet : {0}", ex.Message));
                return ResponseMessage.Error(ex.Message);
            }
        }
        [HttpDelete("DeleteById/{Id}")]
        [AuthorizeFilter]
        public async Task<IActionResult> DeleteById(Guid Id)
        {
            try
            {
                _logger.LogInformation(string.Format("Call DeleteById params: (id = {0})", Id));
                await _service.Por_GiaoAnLyThuyet.DeleteById(Id);
                return ResponseMessage.Success();
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("DeleteById : {0}", ex.Message));
                return ResponseMessage.Error(ex.Message);
            }
        }
    }
}