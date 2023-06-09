﻿using Microsoft.AspNetCore.Authorization;
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
    public class Sys_OrganizationController : ApiControllerBase<Sys_Organization>
    {
        private readonly IServiceWrapper _service;
        private readonly ILogger<Sys_CategoryController> _logger;
        public Sys_OrganizationController(IServiceWrapper service, ILogger<Sys_CategoryController> logger) :base(service, logger)
        {
            _logger = logger;
            _service = service;
        }
        [HttpGet("CheckDuplicateAttributes")]
        [AuthorizeFilter]
        public async Task<IActionResult> CheckDuplicateAttributes(Guid? id, string code, Guid parentId)
        {
            try
            {
                _logger.LogInformation(string.Format("Call CheckDuplicateAttributes params: (id = {0}, code = {1}, parentId = {2})", id, code, parentId));
                var result = await _service.Sys_Organization.IsDupicateAttributesAsync(id, code, parentId);
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
                var treeOrgan = await _service.Sys_Organization.GetTreeAsync();
                return ResponseMessage.Success(treeOrgan);
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
                var treeOrgan = await _service.Sys_Organization.GetTreeListAsync();
                return ResponseMessage.Success(treeOrgan);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("GetTreeList : {0}", ex.Message));
                return ResponseMessage.Error(ex.Message);
            }
        }
        [HttpGet("List/{ParentId}")]
        [AuthorizeFilter]
        public async Task<IActionResult> GetByPerentId(Guid parentId)
        {
            try
            {
                _logger.LogInformation(string.Format("Call GetByPerentId params: (parentId = {0})", parentId));
                var items = await _service.Sys_Organization.GetByParentIdAsync(parentId);
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
                await _service.Sys_Organization.DeleteById(Id);
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
