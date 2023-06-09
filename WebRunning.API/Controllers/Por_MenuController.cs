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
    public class Por_MenuController : ApiControllerBase<Por_Menu>
    {
        private readonly IServiceWrapper _service;
        private readonly ILogger<Sys_CategoryController> _logger;
        public Por_MenuController(IServiceWrapper service, ILogger<Sys_CategoryController> logger) : base(service, logger)
        {
            _logger = logger;
            _service = service;
        }
        [HttpGet("CheckDuplicateAttributes")]
        [AuthorizeFilter]
        public async Task<IActionResult> CheckDuplicateAttributes(Guid? id, string ma, Guid idMenuCha)
        {
            try
            {
                _logger.LogInformation(string.Format("Call CheckDuplicateAttributes params: (id = {0}, ma = {1}, idMenuCha = {2})", id, ma, idMenuCha));
                var result = await _service.Por_Menu.IsDupicateAttributesAsync(id, ma, idMenuCha);
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
                var treeMenu = await _service.Por_Menu.GetTreeAsync();
                return ResponseMessage.Success(treeMenu);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("GetTree : {0}", ex.Message));
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
                var treeMenu = await _service.Por_Menu.GetTreePortalAsync();
                return ResponseMessage.Success(treeMenu);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("GetTreePortal : {0}", ex.Message));
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
                var treeMenu = await _service.Por_Menu.GetTreeListAsync();
                return ResponseMessage.Success(treeMenu);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("GetTreeList : {0}", ex.Message));
                return ResponseMessage.Error(ex.Message);
            }
        }
        [HttpGet("List/{idMenuCha}")]
        [AuthorizeFilter]
        public async Task<IActionResult> GetByPerentId(Guid idMenuCha)
        {
            try
            {
                _logger.LogInformation(string.Format("Call GetByPerentId params: (idMenuCha = {0})", idMenuCha));
                var items = await _service.Por_Menu.GetByParentIdAsync(idMenuCha);
                return ResponseMessage.Success(items);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("GetByPerentId : {0}", ex.Message));
                return ResponseMessage.Error(ex.Message);
            }
        }
        [HttpDelete("DeleteById/{Id}")]
        [AuthorizeFilter]
        public async Task<IActionResult> DeleteById(Guid Id)
        {
            try
            {
                _logger.LogInformation(string.Format("Call DeleteById params: (Id = {0})", Id));
                await _service.Por_Menu.DeleteById(Id);
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
