using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebRunning.API.Infrastructure.Authorization;
using WebRunning.API.Service;
using WebRunning.Lib.Helpers;
using WebRunning.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace WebRunning.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public abstract class ApiControllerBase<TEntity> : ControllerBase
    {        
        private ServiceDecorator<TEntity> _serviceDecorator;
        private readonly ILogger _logger;        
        public ApiControllerBase(IServiceWrapper service, ILogger logger)
        {            
            _logger = logger;
            _serviceDecorator = new ServiceDecorator<TEntity>(service);
        }
        [HttpPost("Search")]
        [AuthorizeFilter]
        public virtual async Task<IActionResult> SearcListEntitiesAsync([FromBody] Lib.Models.Searching modelSearch)
        {
            try
            {
                _logger.LogInformation(string.Format("Call SearcListEntitiesAsync params: (page = {0}, pageSize = {1}, totalLimitItems = {2}), search = {3}", modelSearch.Page, modelSearch.PageSize, modelSearch.TotalLimitItems, JsonConvert.SerializeObject(modelSearch)));
                var items = await _serviceDecorator.SearcListEntitiesAsync(modelSearch.Page, modelSearch.PageSize, modelSearch.TotalLimitItems, modelSearch);
                return ResponseMessage.Success(items);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("SearcListEntitiesAsync : {0}", ex.Message));
                return ResponseMessage.Error(ex.Message);
            }
        }
        [HttpGet("List")]
        [AuthorizeFilter]
        public virtual async Task<IActionResult> GetListEntitiesAsync(int page = 1, int pageSize = 10, int totalLimitItems = 500, string searchBy = "", string orderBy = "")
        {
            try
            {                
                _logger.LogInformation(string.Format("Call GetListEntitiesAsync params: (page = {0}, pageSize = {1}, totalLimitItems = {2}), searchBy = {3}, orderBy = {4}", page, pageSize, totalLimitItems, searchBy, orderBy));
                var items = await _serviceDecorator.GetListEntitiesAsync(page, pageSize, totalLimitItems, searchBy);                
                return ResponseMessage.Success(items);                               
            }
            catch(Exception ex)
            {
                _logger.LogError(string.Format("GetListEntitiesAsync : {0}", ex.Message));
                return ResponseMessage.Error(ex.Message);
            }
        }

        [HttpGet("Categories")]
        [AuthorizeFilter]
        public virtual IActionResult GetItemsCategories()
        {
            try
            {
                _logger.LogInformation("Call GetCategoryEntities");
                var items = _serviceDecorator.GetCategoryEntities();
                return ResponseMessage.Success(items);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("GetCategoryEntities : {0}", ex.Message));
                return ResponseMessage.Error(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [AuthorizeFilter]
        public virtual async Task<IActionResult> GetEntityByIdAsync(Guid id)
        {
            try
            {
                _logger.LogInformation(string.Format("Call GetEntityByIdAsync params: (id = {0})", id));
                var item = await _serviceDecorator.GetEntityByIdAsync(id);                
                return ResponseMessage.Success(item);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("GetEntityByIdAsync : {0}", ex.Message));
                return ResponseMessage.Error(ex.Message);
            }
        }
        [HttpPost]
        [AuthorizeFilter]
        public virtual async Task<IActionResult> CreateEntity([FromBody] TEntity model)
        {
            try
            {
                _logger.LogInformation(string.Format("Call CreateEntity body: ({0})", JsonConvert.SerializeObject(model)));
                var item = await _serviceDecorator.SaveEntityAsync(model);                
                return ResponseMessage.Success(item);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("CreateEntity : {0}", ex.Message));
                return ResponseMessage.Error(ex.Message);
            }
        }

        [HttpPut]
        [AuthorizeFilter]
        public virtual async Task<IActionResult> UpdateEntity([FromBody] TEntity model)
        {
            try
            {
                _logger.LogInformation(string.Format("Call UpdateEntity body: ({0})", JsonConvert.SerializeObject(model)));
                var item = await _serviceDecorator.SaveEntityAsync(model);                
                return ResponseMessage.Success(item);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("UpdateEntity : {0}", ex.Message));
                return ResponseMessage.Error(ex.Message);
            }
        }

        [HttpPost("Save/Multiple")]
        [AuthorizeFilter]
        public virtual async Task<IActionResult> SaveEntitiesAsync([FromBody] TEntity[] models)
        {
            try
            {
                _logger.LogInformation("Call SaveEntitiesAsync");
                var items = await _serviceDecorator.SaveEntitiesAsync(models);
                return ResponseMessage.Success(items);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("SaveEntitiesAsync : {0}", ex.Message));
                return ResponseMessage.Error(ex.Message);
            }
        }

        [HttpDelete]
        [AuthorizeFilter]
        public virtual async Task<IActionResult> DeleteSaveEntities([FromBody] List<TEntity> models)
        {
            try
            {
                _logger.LogInformation("Call DeleteSaveEntities");
                await _serviceDecorator.DeleteSaveEntities(models);                
                return ResponseMessage.Success();
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("DeleteSaveEntities : {0}", ex.Message));
                return ResponseMessage.Error(ex.Message);
            }
        }
    }
}
