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
    public class Por_MonHocController : ApiControllerBase<Por_MonHoc>
    {
        private readonly IServiceWrapper _service;
        private readonly ILogger<Por_MonHocController> _logger;
        public Por_MonHocController(IServiceWrapper service, ILogger<Por_MonHocController> logger) : base(service, logger)
        {
            _service = service;
            _logger = logger;
        }
        [HttpGet("CheckDuplicateAttributes")]
        [AuthorizeFilter]
        public async Task<IActionResult> CheckDuplicateAttributes(Guid? id, string ma, Guid idMonHocCha)
        {
            try
            {
                _logger.LogInformation(string.Format("Call CheckDuplicateAttributes params: (id = {0}, ma = {1}, idMonHocCha = {2})", id, ma, idMonHocCha));
                var result = await _service.Por_MonHoc.IsDupicateAttributesAsync(id, ma, idMonHocCha);
                return ResponseMessage.Success(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("CheckDuplicateAttributes : {0}", ex.Message));
                return ResponseMessage.Error(ex.Message);
            }
        }
        [HttpGet("Tree")]
        [AuthorizeFilter]
        public async Task<IActionResult> GetTree()
        {
            try
            {
                _logger.LogInformation("Call GetTree");
                var treeMonHoc = await _service.Por_MonHoc.GetTreeAsync();
                return ResponseMessage.Success(treeMonHoc);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("GetTree : {0}", ex.Message));
                return ResponseMessage.Error(ex.Message);
            }
        }
        [HttpGet("TreeList")]
        [AuthorizeFilter]
        public async Task<IActionResult> GetTreeList()
        {
            try
            {
                _logger.LogInformation("Call GetTreeList");
                var treeMonHoc = await _service.Por_MonHoc.GetTreeListAsync();
                return ResponseMessage.Success(treeMonHoc);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("GetTreeList : {0}", ex.Message));
                return ResponseMessage.Error(ex.Message);
            }
        }
        [HttpGet("TreePortal")]
        [AllowAnonymous]
        public async Task<IActionResult> GetTreePortal()
        {
            try
            {
                _logger.LogInformation("Call GetTreePortal");
                var treeMonHoc = await _service.Por_MonHoc.GetTreePortalAsync();
                return ResponseMessage.Success(treeMonHoc);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("GetTreePortal : {0}", ex.Message));
                return ResponseMessage.Error(ex.Message);
            }
        }
        [HttpGet("List/{idMonHocCha}")]
        [AuthorizeFilter]
        public async Task<IActionResult> GetByPerentId(Guid idMonHocCha)
        {
            try
            {
                _logger.LogInformation(string.Format("Call GetByPerentId params: (idMonHocCha = {0})", idMonHocCha));
                var items = await _service.Por_MonHoc.GetByParentIdAsync(idMonHocCha);
                return ResponseMessage.Success(items);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("GetByPerentId : {0}", ex.Message));
                return ResponseMessage.Error(ex.Message);
            }
        }
        [HttpGet("LayDsKhoaHocTheoMonHocChaPortal")]
        [AllowAnonymous]
        public async Task<IActionResult> LayDsKhoaHocTheoMonHocChaPortal(int monhoclimit = 4, int khoahoclimit = 4, string maMonHocCha = "")
        {
            try
            {
                _logger.LogInformation(string.Format("Call KhoaHocPortal params: (monhoclimit = {0}, khoahoclimit = {1}, maMonHocCha = {2})", monhoclimit, khoahoclimit, maMonHocCha));
                var items = await _service.Por_MonHoc.KhoaHocPortalAsync(monhoclimit, khoahoclimit, maMonHocCha);
                return ResponseMessage.Success(items);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("KhoaHocPortal : {0}", ex.Message));
                return ResponseMessage.Error(ex.Message);
            }
        }
        [HttpGet("MonHocPortal")]
        [AllowAnonymous]
        public async Task<IActionResult> MonHocPortalAsync(string maMonHocCha, int limit = 4)
        {
            try
            {
                _logger.LogInformation(string.Format("Call MonHocPortal params: (maMonHocCha = {0}, limit = {1})", maMonHocCha, limit));
                var items = await _service.Por_MonHoc.MonHocPortalAsync(maMonHocCha, limit);
                return ResponseMessage.Success(items);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("MonHocPortal : {0}", ex.Message));
                return ResponseMessage.Error(ex.Message);
            }
        }
    }
}