using WebRunning.Lib.Interfaces;
using WebRunning.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebRunning.API.ViewModel.Portal;

namespace WebRunning.API.Service.Por_NhomTinTuc
{
    public interface IService : IRepositoryBase<Model.Por_NhomTinTuc>
    {
        Task<List<ViewModel.Por_NhomTinTuc.NhomTinTucTree>> GetTreeAsync();
        Task<List<ViewModel.Por_NhomTinTuc.NhomTinTucTree>> GetTreeListAsync();
        Task<List<Model.Por_NhomTinTuc>> GetByParentIdAsync(Guid idNhomTinTucCha);
        Task<bool> IsDupicateAttributesAsync(Guid? Id, string Ma, Guid IdNhomTinTucCha);
        Task<List<ViewModel.Por_NhomTinTuc.NhomTinTucTree>> GetTreePortalAsync();
        Task<List<Model.Por_NhomTinTuc>> GetDSNhomTinTucPortal(Guid idNhomTinTucCha);
        Task<List<ObjNhomTinTuc>> TinTucPortalAsync(string maNhomTinTuc, int Limit);
        Task<List<ObjKienThuc>> KienThucPortalAsync(string maNhomTinTuc, int Limit);
        Task Delete(Guid Id);
    }
}
