using WebRunning.Lib.Interfaces;
using WebRunning.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebRunning.API.ViewModel.Portal;

namespace WebRunning.API.Service.Por_TinTuc
{
    public interface IService : IRepositoryBase<Model.Por_TinTuc>
    {
        Task<List<DsTinTuc>> GetDanhSachAsync(int page, int pageSize, int totalLimitItems, string searchBy = "", string orderBy = "");
        Task<List<DsTinTuc>> GetItemsTheoChuyenMucAsync(Guid idChuyenMuc);
        Task<List<DsTinTuc>> GetItemsTinNoiBatAsync(int limit);
    }
}
