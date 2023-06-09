using WebRunning.Lib.Interfaces;
using WebRunning.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebRunning.API.ViewModel.Portal;

namespace WebRunning.API.Service.Por_NhomSuKien
{
    public interface IService : IRepositoryBase<Model.Por_NhomSuKien>
    {
        Task<bool> IsDupicateAttributesAsync(Guid? Id, string Ma);
        Task<List<Model.Por_NhomSuKien>> GetItemsHoatDongPortalAsync();
        Task Delete(Guid Id);
    }
}
