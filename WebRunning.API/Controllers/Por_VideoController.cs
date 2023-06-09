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
using WebRunning.Lib.Helpers;
using Microsoft.Extensions.FileProviders;
using Org.BouncyCastle.Utilities;
using System.IO;
using WebRunning.Lib.Interfaces;
using WebRunning.API.Infrastructure;
using Microsoft.Extensions.Configuration;
using WebRunning.API.ViewModel.Portal;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace WebRunning.API.Controllers
{
    public class Por_VideoController : ApiControllerBase<Por_Video>
    {
        private readonly IServiceWrapper _service;
        private readonly ILogger<Por_VideoController> _logger;
        private readonly IUploadFileProvider _fileProvider;
        private readonly string _savePath;
        private readonly AppSettings appSettings;
        public Por_VideoController(IUploadFileProvider fileProvider, IConfiguration rootConfiguration, IServiceWrapper service, ILogger<Por_VideoController> logger) : base(service, logger)
        {
            appSettings = new AppSettings();
            rootConfiguration.Bind(appSettings);
            _service = service;
            _logger = logger;
            _fileProvider = fileProvider;
            _savePath = appSettings.FileServerConfiguration.SavePath;
        }
        [HttpGet("DanhSach")]
        [AuthorizeFilter]
        public virtual async Task<IActionResult> GetDanhSachAsync(int page = 1, int pageSize = 10, int totalLimitItems = 500, string searchBy = "", string orderBy = "")
        {
            try
            {
                _logger.LogInformation(string.Format("Call GetDanhSachAsync params: (page = {0}, pageSize = {1}, totalLimitItems = {2}), searchBy = {3}, orderBy = {4}", page, pageSize, totalLimitItems, searchBy, orderBy));
                var items = await _service.Por_Video.GetDanhSachAsync(page, pageSize, totalLimitItems, searchBy, orderBy);
                return ResponseMessage.Success(items);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("GeDanhSachAsync : {0}", ex.Message));
                return ResponseMessage.Error(ex.Message);
            }
        }
    }
}