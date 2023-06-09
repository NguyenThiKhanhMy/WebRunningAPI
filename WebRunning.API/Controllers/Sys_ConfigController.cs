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
    public class Sys_ConfigController : ApiControllerBase<Sys_Config>
    {
        private readonly IServiceWrapper _service;
        private readonly ILogger<Sys_CategoryController> _logger;
        public Sys_ConfigController(IServiceWrapper service, ILogger<Sys_CategoryController> logger) :base(service, logger)
        {
            _logger = logger;
            _service = service;
        }
        [HttpGet("{page}/{pageSize}/{totalLimitItems}/{type}")]
        [AuthorizeFilter]
        public virtual async Task<IActionResult> GetListPagedByType(int page = 1, int pageSize = 10, int totalLimitItems = 500, int type = 0)
        {
            try
            {
                _logger.LogInformation(string.Format("Call GetListPagedByType params: (page = {0}, pageSize = {1}, totalLimitItems = {2}, type = {3})", page, pageSize, totalLimitItems, type));
                string search = $"type = {type}";
                var items = await _service.Sys_Config.GetListEntitiesAsync(page, pageSize, totalLimitItems, search);
                return ResponseMessage.Success(items);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("GetListPagedByType : {0}", ex.Message));
                return ResponseMessage.Error(ex.Message);
            }
        }
        [HttpGet("CheckDuplicateAttributes")]
        [AuthorizeFilter]
        public async Task<IActionResult> CheckDuplicateAttributes(Guid? id, string code, int type)
        {
            try
            {
                _logger.LogInformation(string.Format("Call CheckDuplicateAttributes params: (id = {0}, code = {1}, type = {2})", id, code, type));
                var result = await _service.Sys_Config.IsDupicateAttributesAsync(id, code, type);
                return ResponseMessage.Success(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("CheckDuplicateAttributes : {0}", ex.Message));
                return ResponseMessage.Error(ex.Message);
            }
        }
    }
}
