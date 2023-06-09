using WebRunning.Lib.Interfaces;
using WebRunning.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebRunning.API.ViewModel.Portal;
using WebRunning.API.ViewModel.Por_GiaoAnLyThuyet;
using k8s.KubeConfigModels;

namespace WebRunning.API.Service.Por_GiaoAnLyThuyet
{
    public interface IService : IRepositoryBase<Model.Por_GiaoAnLyThuyet>
    {
        Task<string> GetLinkVideo(Guid GiaoAnId, Guid UserId);
        Task<List<GiaoAnLyThuyetTree>> GetTree(Guid IdKhoaHoc);
        Task<List<GiaoAnLyThuyetTree>> GetTreePortal(Guid IdKhoaHoc);
        Task DeleteById(Guid Id);
    }
}
