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
using WebRunning.API.Infrastructure.Hubs;
using Microsoft.AspNetCore.SignalR;
using k8s.KubeConfigModels;

namespace WebRunning.API.Controllers
{
    public class Sys_UserController : ApiControllerBase<Sys_User>
    {
        private readonly IServiceWrapper _service;
        private readonly ILogger<Sys_CategoryController> _logger;        
        public Sys_UserController(IServiceWrapper service, ILogger<Sys_CategoryController> logger) :base(service, logger)
        {
            _service = service;
            _logger = logger;            
        }
        [HttpGet("Active")]
        [AllowAnonymous]
        public async Task<IActionResult> ActiveUser(Guid UserId)
        {
            try
            {
                _logger.LogInformation(string.Format("Call ActiveUserAsync UserId: {0}", UserId));
                var result = await _service.Sys_User.ActiveUserAsync(UserId);
                return ResponseMessage.Success(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("ActiveUserAsync : {0}", ex.Message));
                return ResponseMessage.Error(ex.Message);
            }
        }

        [HttpGet("UnActive")]
        [AuthorizeFilter]
        public async Task<IActionResult> UnActiveUser(Guid UserId)
        {
            try
            {
                _logger.LogInformation(string.Format("Call UnActiveUser UserId : {0}", UserId));
                var result = await _service.Sys_User.UnActiveUserAsync(UserId);
                return ResponseMessage.Success(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("UnActiveUser : {0}", ex.Message));
                return ResponseMessage.Error(ex.Message);
            }
        }
        [HttpGet]
        [AuthorizeFilter]
        public async Task<IActionResult> GetListPagedByLoginNameAndIsActive(int page = 1, int pageSize = 10, int totalLimitItems = 500, bool isActive = false, string loginName = "")
        {
            try
            {
                _logger.LogInformation(string.Format("Call GetListPagedByLoginNameAndIsActive params: (page = {0}, pageSize = {1}, totalLimitItems = {2}, loginName = {3}, isActive = {4})", page, pageSize, totalLimitItems, loginName, isActive));
                string search = $"UserName != \"admin\"";
                if(!string.IsNullOrEmpty(loginName))
                {
                    search += $" && (UserName.Contains(\"{loginName}\") || Email.Contains(\"{loginName}\")) ";
                }
                search += $" && IsActive == {isActive}";
                var users = await _service.Sys_User.GetListPagedByLoginNameAndIsActive(page, pageSize, totalLimitItems, search);
                return ResponseMessage.Success(users);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("GetListPagedByLoginNameAndIsActive : {0}", ex.Message));
                return ResponseMessage.Error(ex.Message);
            }
        }
        [HttpGet("CheckDuplicateAttributes")]
        [AuthorizeFilter]
        public async Task<IActionResult> CheckDuplicateAttributes(Guid? id, string userName, string email)
        {
            try
            {
                _logger.LogInformation(string.Format("Call CheckDuplicateAttributes params: (id = {0}, UserName = {1}, Email = {2})", id, userName, email));
                var result = await _service.Sys_User.IsDupicateAttributesAsync(id, userName, email);
                return ResponseMessage.Success(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("CheckDuplicateAttributes : {0}", ex.Message));
                return ResponseMessage.Error(ex.Message);
            }
        }
        [HttpGet("{id}")]
        [AuthorizeFilter]
        public override async Task<IActionResult> GetEntityByIdAsync(Guid id)
        {
            try
            {
                _logger.LogInformation(string.Format("Call GetById params: (id = {0})", id));
                var item = await _service.Sys_User.GetDetailByIdAsync(id);
                return ResponseMessage.Success(item);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("GetById : {0}", ex.Message));
                return ResponseMessage.Error(ex.Message);
            }
        }
        [HttpGet("GetUsersWithRoleOrgan")]
        [AuthorizeFilter]
        public async Task<IActionResult> GetUsersWithRoleOrgan()
        {
            try
            {
                _logger.LogInformation("Call GetUserWithRoleOrgan");
                var item = await _service.Sys_User.GetUsersWithRoleOrgan();
                return ResponseMessage.Success(item);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("GetUserWithRoleOrgan : {0}", ex.Message));
                return ResponseMessage.Error(ex.Message);
            }
        }
        [HttpGet("List/{organId}")]
        [AuthorizeFilter]
        public async Task<IActionResult> GetByOrganId(Guid organId)
        {
            try
            {
                _logger.LogInformation(string.Format("Call GetByOrganId params: (organId = {0})", organId));
                var items = await _service.Sys_User.GetByOrganIdAsync(organId);
                return ResponseMessage.Success(items);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("GetByOrganId : {0}", ex.Message));
                return ResponseMessage.Error(ex.Message);
            }
        }
        [HttpPost("{organId}/{roleId}")]
        [AuthorizeFilter]
        public async Task<IActionResult> CreateWithOrganAndRole([FromBody] Sys_User model, Guid? organId, Guid? roleId)
        {
            try
            {
                _logger.LogInformation(string.Format("Call CreateWithOrganAndRole params: (organId = {0}, roleId = {1}) and body: ({2})", organId, roleId, JsonConvert.SerializeObject(model)));
                var item = await _service.Sys_User.CreateAsync(model, organId, roleId);
                return ResponseMessage.Success(item);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("CreateWithOrganAndRole : {0}", ex.Message));
                return ResponseMessage.Error(ex.Message);
            }
        }
        [HttpPut("{organId}/{roleId}")]
        [AuthorizeFilter]
        public async Task<IActionResult> UpdateWithOrganAndRole([FromBody] Sys_User model, Guid? organId, Guid? roleId)
        {
            try
            {
                _logger.LogInformation(string.Format("Call UpdateWithOrganAndRole params: (organId = {0}, roleId = {1}) and body: ({2})", organId, roleId, JsonConvert.SerializeObject(model)));
                var item = await _service.Sys_User.UpdateAsync(model, organId, roleId);
                return ResponseMessage.Success(item);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("UpdateWithOrganAndRole : {0}", ex.Message));
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
                await _service.Sys_User.DeleteById(Id);
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
