using Microsoft.EntityFrameworkCore;
using WebRunning.API.Infrastructure;
using WebRunning.Lib.Constant;
using WebRunning.Lib.Helpers;
using WebRunning.Lib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebRunning.API.Model;
using WebRunning.API.ViewModel.Portal;
using WebRunning.API.ViewModel.CauHinhTrangChu;
using System.Linq.Dynamic.Core;
using static WebRunning.API.Infrastructure.Enums;
using static Humanizer.In;
using Autofac.Features.Metadata;

namespace WebRunning.API.Service.Por_CauHinhGiaoDien
{
    public class Service : RepositoryBase<Model.Por_CauHinhGiaoDien>, Por_CauHinhGiaoDien.IService
    {
        private readonly DomainDbContext _dbContext;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly IUserProvider _userProvider;
        public Service(DomainDbContext dbContext, IDateTimeProvider dateTimeProvider, IUserProvider userService) : base(dbContext, dateTimeProvider, userService)
        {
            _dbContext = dbContext;
            _dateTimeProvider = dateTimeProvider;
            _userProvider = userService;
        }
        public async Task<List<KhoiGioiThieu>> Get_TrangChu_KhoiGioiThieuAsync(string MaNhomTinTuc, int SoLuong)
        {
            var query = from x in _dbContext.Por_TinTucs
                        join y in _dbContext.Por_NhomTinTucs on x.IdNhomTinTuc equals y.Id
                        where x.TrangThaiBanGhi == true && y.TrangThaiBanGhi == true && y.Ma == MaNhomTinTuc
                        select new KhoiGioiThieu() { CreatedDateTime = x.CreatedDateTime, Id = x.Id, TieuDe = x.TieuDe, TieuDeGioiThieu = y.Ten, MoTa = x.MoTa, URL_AnhDaiDien = x.URL_AnhDaiDien };
            var items = await query.OrderByDescending(o => o.CreatedDateTime).Take(SoLuong).ToListAsync();
            return items;
        }
        public async Task<List<KhoiMonHoc>> Get_TrangChu_KhoiMonHocAsync(string[] DsMaMonHoc)
        {
            var items = await _dbContext.Por_MonHocs.Where(o => o.TrangThaiBanGhi == true && DsMaMonHoc.Contains(o.Ma))
            .Select(o => new KhoiMonHoc() { Id = o.Id, TieuDe = o.Ten, MoTa = o.MoTa, URL_AnhDaiDien = o.URL_AnhDaiDien, GiaGiaoDongTu = o.GiaGiaoDongTu, GiaGiaoDongDen = o.GiaGiaoDongDen, CreatedDateTime = o.CreatedDateTime }).OrderByDescending(o => o.CreatedDateTime).ToListAsync();
            return items;
        }
        public async Task<List<List<KhoiKhoaHoc>>> Get_TrangChu_KhoiKhoaHocAsync(KhoiKhoaHocReq[] khoiKhoaHocReqs)
        {
            var items = new List<List<KhoiKhoaHoc>>();
            for(int i = 0;i < khoiKhoaHocReqs.Length;i++)
            {
                var query = (from x in _dbContext.Por_KhoaHocs
                             join y in _dbContext.Por_MonHocs on x.IdMonHoc equals y.Id
                             join z in _dbContext.Por_LoaiKhoaHocs on x.IdLoaiKhoaHoc equals z.Id
                             where x.TrangThaiBanGhi == true && y.TrangThaiBanGhi == true && y.Ma == khoiKhoaHocReqs[i].MaMonHoc && z.Ma == khoiKhoaHocReqs[i].MaLoai
                             select new KhoiKhoaHoc() { CreatedDateTime = x.CreatedDateTime, Id = x.Id, URL_AnhDaiDien = x.URL_AnhDaiDien, TieuDe = x.TieuDe, ThoiHan = x.ThoiHan, ThoiHanTruyCapMienPhi = x.ThoiHanTruyCapMienPhi, TyLeDanhGia = x.TyLeDanhGia, SoLuongNguoiHoc = x.SoLuongNguoiHoc, HocPhiGoc = x.HocPhiGoc, HocPhiGiamGia = x.HocPhiGiamGia, TenMonHoc = y.Ten });
                var item = await query.OrderByDescending(o => o.CreatedDateTime).Take(khoiKhoaHocReqs[i].SoLuong).ToListAsync();
                items.Add(item);
            }
            return items;
        }
        public async Task<List<KhoiSuKien>> Get_TrangChu_SuKienAsync(SuKienType[] TinhTrang, int SoLuong)
        {
            var items = await _dbContext.Por_SuKiens.Where(o => TinhTrang.Contains(o.TrangThai) && o.TrangThaiBanGhi == true)
                                .Select(o => new KhoiSuKien() { CreatedDateTime = o.CreatedDateTime, Id = o.Id, Ten = o.Ten, DiaChi = o.DiaChi, URL_AnhDaiDien = o.URL_AnhDaiDien, ThoiGian = o.ThoiGian, GiaTien = o.GiaTien, TrangThai = o.TrangThai })
                                .OrderByDescending(o => o.CreatedDateTime).Take(SoLuong).ToListAsync();
            return items;
        }
        public async Task<List<KhoiTinTuc>> Get_TrangChu_TinTucAsync(string MaNhomTinTuc, int SoLuong)
        {
            var query = (from x in _dbContext.Por_TinTucs
                         join y in _dbContext.Por_NhomTinTucs on x.IdNhomTinTuc equals y.Id
                         where x.TrangThaiBanGhi == true && y.TrangThaiBanGhi == true && y.Ma == MaNhomTinTuc
                         select new KhoiTinTuc() { Id = x.Id, URL_AnhDaiDien = x.URL_AnhDaiDien, MoTa = x.MoTa, CreatedDateTime = x.CreatedDateTime });
            var items = await query.OrderByDescending(o => o.CreatedDateTime).Take(SoLuong).ToListAsync();
            return items;
        }
    }
}
