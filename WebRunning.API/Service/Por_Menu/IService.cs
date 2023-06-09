using WebRunning.Lib.Interfaces;
using WebRunning.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRunning.API.Service.Por_Menu
{
    public interface IService : IRepositoryBase<Model.Por_Menu>
    {
        Task<List<ViewModel.Por_Menu.MenuTree>> GetTreeAsync();
        Task<List<ViewModel.Por_Menu.MenuTree>> GetTreeListAsync();
        Task<List<Model.Por_Menu>> GetByParentIdAsync(Guid idMenuCha);
        Task<bool> IsDupicateAttributesAsync(Guid? Id, string Ma, Guid IdMenuCha);
        Task<List<ViewModel.Por_Menu.MenuTree>> GetTreePortalAsync();
        Task DeleteById(Guid Id);
    }
}
