using WebRunning.Lib.Interfaces;
using WebRunning.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebRunning.API.ViewModel.Portal;

namespace WebRunning.API.Service.Por_SuKien
{
    public interface IService : IRepositoryBase<Model.Por_SuKien>
    {
        Task<List<DsSuKien>> GetDanhSachAsync(int page, int pageSize, int totalLimitItems, string searchBy = "", string orderBy = "");
        Task<List<DsSuKien>> GetItemsTheoNhomSuKienMoiNhatAsync(int limit);
        Task<List<DsSuKien>> GetItemsTheoNhomSuKienAsync(Guid idNhomSuKien);
    }
}
