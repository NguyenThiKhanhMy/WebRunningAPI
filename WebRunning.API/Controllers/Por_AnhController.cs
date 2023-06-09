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
    public class Por_AnhController : ApiControllerBase<Por_Anh>
    {
        private readonly IServiceWrapper _service;
        private readonly ILogger<Por_AnhController> _logger;
        private readonly IUploadFileProvider _fileProvider;
        private readonly string _savePath;
        private readonly AppSettings appSettings;
        public Por_AnhController(IUploadFileProvider fileProvider, IConfiguration rootConfiguration, IServiceWrapper service, ILogger<Por_AnhController> logger) : base(service, logger)
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
                var items = await _service.Por_Anh.GetDanhSachAsync(page, pageSize, totalLimitItems, searchBy, orderBy);
                return ResponseMessage.Success(items);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("GeDanhSachAsync : {0}", ex.Message));
                return ResponseMessage.Error(ex.Message);
            }
        }
        [HttpGet("ImageGallery")]
        [AllowAnonymous]
        public async Task<IActionResult> ImageGallery(int limit = 100)
        {
            try
            {
                _logger.LogInformation("Call ImageGallery");
                var domain = HttpContext.Request.Scheme + "://" + HttpContext.Request.Host; 
                var items = await _service.Por_Anh.ImageGalleryAsync(domain, limit);
                return new ObjectResult(new ImageGallery() { statusCode = 200, result = items });
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("ImageGallery : {0}", ex.Message));
                return ResponseMessage.Error(ex.Message);
            }
        }
        [HttpPost("UploadAnh")]
        [AuthorizeFilter]
        public async Task<IActionResult> UploadAnh()
        {
            try
            {
                _logger.LogInformation("Call UploadAnh");
                Por_Anh item = null;
                if (Request.Form.TryGetValue("data", out var jsonData))
                {
                    item = JsonConvert.DeserializeObject<Por_Anh>(jsonData);
                    byte[] bytes = null;
                    foreach (var file in Request.Form.Files)
                    {
                        string FileName = file.ContentDisposition.Split("\"")[3];
                        string ContentDispositionName = file.ContentDisposition.Split("\"")[1];
                        string ContentType = file.ContentType;
                        string savePath = String.Empty;
                        if (file.Length > 0)
                        {
                            bytes = new byte[file.Length];
                            savePath = Path.Combine(_fileProvider.BuildSavePathYYYYMMDD(Path.Combine(_savePath, "Images")), FileName);
                            using (var stream = new FileStream(savePath, FileMode.Create))
                            {
                                file.CopyTo(stream);
                            }
                            item.URL_Anh = savePath;
                        }
                    }
                    item = await _service.Por_Anh.SaveEntityAsync(item);
                }
                return ResponseMessage.Success(item);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("UploadAnh : {0}", ex.Message));
                return ResponseMessage.Error(ex.Message);
            }
        }

        [HttpPost("UploadAnhEdtior")]
        [AuthorizeFilter]
        public async Task<IActionResult> UploadAnhEdtior()
        {
            try
            {
                _logger.LogInformation("Call UploadAnhEdtior");
                byte[] bytes = null;
                string savePath = String.Empty;
                foreach (var file in Request.Form.Files)
                {
                    string FileName = file.ContentDisposition.Split("\"")[3];
                    string ContentDispositionName = file.ContentDisposition.Split("\"")[1];
                    string ContentType = file.ContentType;
                    if (file.Length > 0)
                    {
                        bytes = new byte[file.Length];
                        savePath = Path.Combine(_fileProvider.BuildSavePathYYYYMMDD(Path.Combine(_savePath, "ImagesEdtior")), FileName);
                        using (var stream = new FileStream(savePath, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }
                    }
                }
                string src = HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + "/" + savePath.Replace("\\", "/"); ;
                return ResponseMessage.Success(src);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("UploadAnhEdtior : {0}", ex.Message));
                return ResponseMessage.Error(ex.Message);
            }
        }
    }
}