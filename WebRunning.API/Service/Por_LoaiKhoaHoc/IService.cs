using WebRunning.Lib.Interfaces;
using WebRunning.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebRunning.API.ViewModel.Portal;

namespace WebRunning.API.Service.Por_LoaiKhoaHoc
{
    public interface IService : IRepositoryBase<Model.Por_LoaiKhoaHoc>
    {
        Task<List<Model.Por_LoaiKhoaHoc>> GetItemsHoatDongPortalAsync();
        Task Delete(Guid Id);
    }
}
