using WebRunning.Lib.Interfaces;
using WebRunning.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebRunning.API.ViewModel.Portal;
using WebRunning.API.ViewModel.CauHinhTrangChu;
using static WebRunning.API.Infrastructure.Enums;

namespace WebRunning.API.Service.Por_CauHinhGiaoDien
{
    public interface IService : IRepositoryBase<Model.Por_CauHinhGiaoDien>
    {
        Task<List<KhoiGioiThieu>> Get_TrangChu_KhoiGioiThieuAsync(string MaNhomTinTuc, int SoLuong);
        Task<List<KhoiMonHoc>> Get_TrangChu_KhoiMonHocAsync(string[] DsMaMonHoc);
        Task<List<List<KhoiKhoaHoc>>> Get_TrangChu_KhoiKhoaHocAsync(KhoiKhoaHocReq[] khoiKhoaHocReqs);
        Task<List<KhoiSuKien>> Get_TrangChu_SuKienAsync(SuKienType[] TinhTrang, int SoLuong);
        Task<List<KhoiTinTuc>> Get_TrangChu_TinTucAsync(string MaNhomTinTuc, int SoLuong);
    }
}
