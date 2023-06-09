using WebRunning.Lib.Interfaces;
using WebRunning.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebRunning.API.ViewModel.Portal;
using WebRunning.API.ViewModel.Por_GiaoAnThucHanh;

namespace WebRunning.API.Service.Por_GiaoAnThucHanh
{
    public interface IService : IRepositoryBase<Model.Por_GiaoAnThucHanh>
    {
        Task<string> GetLinkVideo(Guid GiaoAnId, Guid UserId);
        Task<List<GiaoAnThucHanhTree>> GetTreePortal(Guid IdKhoaHoc);
        Task<List<GiaoAnThucHanhTree>> GetTree(Guid IdKhoaHoc);
        Task DeleteById(Guid Id);
    }
}
