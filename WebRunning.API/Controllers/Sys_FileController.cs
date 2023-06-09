using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using WebRunning.API;
using WebRunning.API.Infrastructure.Authorization;
using WebRunning.API.Service;
using WebRunning.API.Controllers;
using WebRunning.API.Model;
using WebRunning.Lib.Constant;
using WebRunning.Lib.Core;
using WebRunning.Lib.Interfaces;
using WebRunning.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebRunning.API.Infrastructure;

namespace WebRunning.API.Controllers
{
    public class Sys_FileController : ApiControllerBase<Sys_File>
    {
        private readonly IUploadFileProvider _fileProvider;
        private readonly IServiceWrapper _service;        
        private readonly ILogger<Sys_CategoryController> _logger;
        private readonly string _savePath;
        public Sys_FileController(IConfiguration rootConfiguration, IServiceWrapper service, IUploadFileProvider fileProvider, ILogger<Sys_CategoryController> logger) :base(service, logger)
        {
            AppSettings appSettings = new AppSettings();
            rootConfiguration.Bind(appSettings);
            _service = service;
            _fileProvider = fileProvider;            
            _logger = logger;            
            _savePath = appSettings.FileServerConfiguration.SavePath;
        }
        [HttpPost("Upload")]
        [AuthorizeFilter]        
        public async Task<IActionResult> UploadFile(List<IFormFile> files, string objectId, string objectType)
        {
            try
            {
                _logger.LogInformation(string.Format("Call UploadFile params: (totalFiles = {0}, objectId = {1}, objectType = {2})", files.Count, objectId, objectType));
                if (files == null || files.Count == 0)
                {
                    return ResponseMessage.Error(Sys_Const.Message.SERVICE_FILE_NOT_EMPTY);
                }
                List<Lib.Models.FileResult> items = await _service.Sys_File.Upload(files, objectId, objectType, _fileProvider.BuildSavePathYYYYMMDD(_savePath));
                return ResponseMessage.Success(items);
            }
            catch(Exception ex)
            {
                _logger.LogError(string.Format("UploadFile : {0}", ex.Message));
                return ResponseMessage.Error(ex.Message);
            }
        }

        [HttpGet("{objectId}/{objectType}")]
        [AuthorizeFilter]        
        public async Task<IActionResult> GetByObjectId(string objectId, string objectType)
        {
            try
            {
                _logger.LogInformation(string.Format("Call GetByObjectId params: (objectId = {0}, objectType = {1})", objectId, objectType));
                var items = await _service.Sys_File.GetByObjectId(objectId, objectType);
                return ResponseMessage.Success(items);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("GetByObjectId : {0}", ex.Message));
                return ResponseMessage.Error(ex.Message);
            }
        }
    }
}
