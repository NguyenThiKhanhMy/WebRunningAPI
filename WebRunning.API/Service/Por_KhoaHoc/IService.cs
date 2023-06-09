using WebRunning.Lib.Interfaces;
using WebRunning.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebRunning.API.ViewModel.Portal;
using WebRunning.API.ViewModel.Por_KhoaHoc;

namespace WebRunning.API.Service.Por_KhoaHoc
{
    public interface IService : IRepositoryBase<Model.Por_KhoaHoc>
    {
        Task<List<DsKhoaHoc>> GetDanhSachAsync(int page, int pageSize, int totalLimitItems, string searchBy = "", string orderBy = "");
        Task<List<DsKhoaHoc>> GetItemsTheoMonHocAsync(Guid idMonHoc);
        Task<List<DsKhoaHoc>> GetItemsTheoLoaiKhoaHocAsync(Guid idLoaiKhoaHoc);
        Task<KhoaHocThu> GetKhoaHocThuAsync(Guid idKhoaHoc);
        Task<List<KhoaHocTrongGioHang>> ChonVaoGioHangAsync(List<KhoaHocTrongGioHang> model);
    }
}
