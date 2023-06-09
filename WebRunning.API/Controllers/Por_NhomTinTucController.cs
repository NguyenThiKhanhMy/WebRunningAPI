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
    public class Por_NhomTinTucController : ApiControllerBase<Por_NhomTinTuc>
    {
        private readonly IServiceWrapper _service;
        private readonly ILogger<Por_NhomTinTucController> _logger;
        public Por_NhomTinTucController(IServiceWrapper service, ILogger<Por_NhomTinTucController> logger) : base(service, logger)
        {
            _service = service;
            _logger = logger;
        }
        [HttpGet("CheckDuplicateAttributes")]
        [AuthorizeFilter]
        public async Task<IActionResult> CheckDuplicateAttributes(Guid? id, string ma, Guid idNhomTinTucCha)
        {
            try
            {
                _logger.LogInformation(string.Format("Call CheckDuplicateAttributes params: (id = {0}, ma = {1}, idNhomTinTucCha = {2})", id, ma, idNhomTinTucCha));
                var result = await _service.Por_NhomTinTuc.IsDupicateAttributesAsync(id, ma, idNhomTinTucCha);
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
                var treeNhomTinTuc = await _service.Por_NhomTinTuc.GetTreeAsync();
                return ResponseMessage.Success(treeNhomTinTuc);
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
                var treeNhomTinTuc = await _service.Por_NhomTinTuc.GetTreeListAsync();
                return ResponseMessage.Success(treeNhomTinTuc);
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
                var treeNhomTinTuc = await _service.Por_NhomTinTuc.GetTreePortalAsync();
                return ResponseMessage.Success(treeNhomTinTuc);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("GetTreePortal : {0}", ex.Message));
                return ResponseMessage.Error(ex.Message);
            }
        }
        [HttpGet("GetDSNhomTinTucPortal")]
        [AllowAnonymous]
        public async Task<IActionResult> GetDSNhomTinTucPortal(Guid idNhomTinTucCha)
        {
            try
            {
                _logger.LogInformation(string.Format("Call GetDSNhomTinTucPortal params: (idNhomTinTucCha = {0})", idNhomTinTucCha));
                var items = await _service.Por_NhomTinTuc.GetDSNhomTinTucPortal(idNhomTinTucCha);
                return ResponseMessage.Success(items);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("GetDSNhomTinTucPortal : {0}", ex.Message));
                return ResponseMessage.Error(ex.Message);
            }
        }
        [HttpGet("List/{idNhomTinTucCha}")]
        [AuthorizeFilter]
        public async Task<IActionResult> GetByPerentId(Guid idNhomTinTucCha)
        {
            try
            {
                _logger.LogInformation(string.Format("Call GetByPerentId params: (idNhomTinTucCha = {0})", idNhomTinTucCha));
                var items = await _service.Por_NhomTinTuc.GetByParentIdAsync(idNhomTinTucCha);
                return ResponseMessage.Success(items);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("GetByPerentId : {0}", ex.Message));
                return ResponseMessage.Error(ex.Message);
            }
        }
        [HttpGet("TinTucPortal")]
        [AllowAnonymous]
        public async Task<IActionResult> TinTucPortal(string maNhomTinTuc, int limit = 3)
        {
            try
            {
                _logger.LogInformation(string.Format("Call GetTinTucPortal params: (maNhomTinTuc ={0},limit = {1})", maNhomTinTuc, limit));
                var items = await _service.Por_NhomTinTuc.TinTucPortalAsync(maNhomTinTuc, limit);
                return ResponseMessage.Success(items);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("TinTucPortal : {0}", ex.Message));
                return ResponseMessage.Error(ex.Message);
            }
        }
        [HttpGet("KienThucPortal")]
        [AllowAnonymous]
        public async Task<IActionResult> KienThucPortal(string maNhomTinTuc, int limit = 8)
        {
            try
            {
                _logger.LogInformation(string.Format("Call GetKienThucPortal params: (maNhomTinTuc ={0},limit = {1})", maNhomTinTuc, limit));
                var items = await _service.Por_NhomTinTuc.KienThucPortalAsync(maNhomTinTuc, limit);
                return ResponseMessage.Success(items);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("KienThucPortal : {0}", ex.Message));
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
                await _service.Por_NhomTinTuc.Delete(Id);
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