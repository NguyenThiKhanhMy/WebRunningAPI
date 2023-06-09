using Microsoft.AspNetCore.Http;
using WebRunning.Lib.Interfaces;
using WebRunning.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRunning.API.Service.Sys_File
{
    public interface IService: IRepositoryBase<Model.Sys_File>
    {
        Task<List<FileResult>> Upload(List<IFormFile> files, string objectId, string objectType, string savedPath);
        Task<List<FileResult>> GetByObjectId(string objectId, string objectType);
    }
}
