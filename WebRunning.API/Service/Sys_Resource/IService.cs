using WebRunning.Lib.Interfaces;
using WebRunning.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRunning.API.Service.Sys_Resource
{
    public interface IService: IRepositoryBase<Model.Sys_Resource>
    {
        Task<List<Model.Sys_Resource>> InitFunctionAsync();
        Task<List<Model.Sys_Resource>> InitMenuAsync(List<MenuConfig> menu);
        Task<List<ViewModel.Sys_Resource.ResourceTree>> GetFunctionTreeAsync();
        Task<List<ViewModel.Sys_Resource.ResourceTree>> GetMenuTreeAsync();
        Task DeleteAllMenu();
        Task DeleteAllFunction();
    }
}
