using WebRunning.Lib.Interfaces;
using WebRunning.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebRunning.API.ViewModel.Portal;

namespace WebRunning.API.Service.Por_Anh
{
    public interface IService : IRepositoryBase<Model.Por_Anh>
    {
        public Task<List<Images>> ImageGalleryAsync(string domain, int limit);
        public Task<List<DsAnh>> GetDanhSachAsync(int page, int pageSize, int totalLimitItems, string searchBy = "", string orderBy = "");
    }
}
