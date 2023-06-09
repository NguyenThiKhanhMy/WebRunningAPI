using WebRunning.Lib.Interfaces;
using WebRunning.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebRunning.API.ViewModel.Portal;

namespace WebRunning.API.Service.Por_MonHoc
{
    public interface IService : IRepositoryBase<Model.Por_MonHoc>
    {
        Task<List<ViewModel.Por_MonHoc.MonHocTree>> GetTreeAsync();
        Task<List<ViewModel.Por_MonHoc.MonHocTree>> GetTreeListAsync();
        Task<List<Model.Por_MonHoc>> GetByParentIdAsync(Guid idMonHocCha);
        Task<bool> IsDupicateAttributesAsync(Guid? Id, string Ma, Guid IdMonHocCha);
        Task<List<ViewModel.Por_MonHoc.MonHocTree>> GetTreePortalAsync();
        Task<List<MonHoc>> KhoaHocPortalAsync(int MonHocLimit, int KhoaHocLimit, string maMonHocCha);
        Task<ObjMonHoc> MonHocPortalAsync(string maMonHocCha, int Limit);
    }
}
