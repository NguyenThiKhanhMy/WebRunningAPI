using WebRunning.Lib.Interfaces;
using WebRunning.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebRunning.API.ViewModel.Portal;

namespace WebRunning.API.Service.Por_Video
{
    public interface IService : IRepositoryBase<Model.Por_Video>
    {
        public Task<List<DsVideo>> GetDanhSachAsync(int page, int pageSize, int totalLimitItems, string searchBy = "", string orderBy = "");
    }
}
