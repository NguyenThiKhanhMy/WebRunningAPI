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
using WebRunning.API.ViewModel.Por_KhoaHoc;

namespace WebRunning.API.Service.Por_KhoaHoc
{
    public class Service : RepositoryBase<Model.Por_KhoaHoc>, Por_KhoaHoc.IService
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
        public async Task<KhoaHocThu> GetKhoaHocThuAsync(Guid idKhoaHoc)
        {
            KhoaHocThu khoaHocThu = new KhoaHocThu();
            var khoahoc = await _dbContext.Por_KhoaHocs.Where(o => o.TrangThaiBanGhi == true).FirstOrDefaultAsync();
            if(khoahoc != null)
            {
                khoaHocThu.Id = khoahoc.Id;
                khoaHocThu.TieuDe = khoahoc.TieuDe;
            }
            return khoaHocThu;
        }
        public async Task<List<DsKhoaHoc>> GetItemsTheoMonHocAsync(Guid idMonHoc)
        {
            var query = (from kh in _dbContext.Por_KhoaHocs
                         join gv in _dbContext.Por_LoaiKhoaHocs.Where(o => o.TrangThaiBanGhi == true) on kh.IdLoaiKhoaHoc equals gv.Id into group1
                         from g1 in group1.DefaultIfEmpty()
                         join mh in _dbContext.Por_MonHocs.Where(o => o.TrangThaiBanGhi == true) on kh.IdMonHoc equals mh.Id into group2
                         from g2 in group2.DefaultIfEmpty()
                         where kh.TrangThaiBanGhi == true
                         select new DsKhoaHoc
                         {
                             TenLoaiKhoaHoc = g1 != null ? g1.TieuDe : "",
                             TenMonHoc = g2 != null ? g2.Ten : "",
                             TieuDe = kh.TieuDe,
                             ThoiHan = kh.ThoiHan,
                             ThoiHanTruyCapMienPhi = kh.ThoiHanTruyCapMienPhi,
                             URL_AnhDaiDien = kh.URL_AnhDaiDien,
                             HocPhiGoc = kh.HocPhiGoc,
                             HocPhiGiamGia = kh.HocPhiGiamGia,
                             CreatedDateTime = kh.CreatedDateTime,
                             TyLeDanhGia = kh.TyLeDanhGia,
                             SoLuongNguoiHoc = kh.SoLuongNguoiHoc,
                             IdMonHoc = kh.IdMonHoc,
                             Id = kh.Id
                         });
            if (idMonHoc != Guid.Empty)
            {
                List<ViewModel.Por_MonHoc.MonHocTree> items = await _dbContext.Por_MonHocs.Where(o => o.TrangThaiBanGhi == true).Select(o =>
                new ViewModel.Por_MonHoc.MonHocTree() { Id = o.Id.ToString(), Code = o.Ma, Name = o.Ten, ParentId = o.IdMonHocCha.ToString() }).ToListAsync();
                List<ViewModel.Por_MonHoc.MonHocTree> trees = TreeHelpers<ViewModel.Por_MonHoc.MonHocTree>.ListToTrees(items, false);
                var nodeParent = TreeHelpers<ViewModel.Por_MonHoc.MonHocTree>.GetNodeFromTree(trees[0], idMonHoc.ToString());
                var monhocIds = new List<Guid>();
                if (nodeParent != null)
                {
                    var monhocChild = TreeHelpers<ViewModel.Por_MonHoc.MonHocTree>.GetChildNodesByNodeParent(nodeParent);
                    monhocIds = monhocChild.Select(o => Guid.Parse(o.Id)).ToList();
                }    
                monhocIds.Add(idMonHoc);
                query = query.Where(o => monhocIds.Contains(o.IdMonHoc));
            }    
            return await query.OrderByDescending(o => o.CreatedDateTime).Take(500).ToListAsync();
        }
        public async Task<List<DsKhoaHoc>> GetItemsTheoLoaiKhoaHocAsync(Guid idLoaiKhoaHoc)
        {
            var query = (from kh in _dbContext.Por_KhoaHocs
                         join gv in _dbContext.Por_LoaiKhoaHocs.Where(o => o.TrangThaiBanGhi == true) on kh.IdLoaiKhoaHoc equals gv.Id into group1
                         from g1 in group1.DefaultIfEmpty()
                         join mh in _dbContext.Por_MonHocs.Where(o => o.TrangThaiBanGhi == true) on kh.IdMonHoc equals mh.Id into group2
                         from g2 in group2.DefaultIfEmpty()
                         where kh.TrangThaiBanGhi == true && kh.IdLoaiKhoaHoc == idLoaiKhoaHoc
                         select new DsKhoaHoc
                         {
                             TenLoaiKhoaHoc = g1 != null ? g1.TieuDe : "",
                             TenMonHoc = g2 != null ? g2.Ten : "",
                             TieuDe = kh.TieuDe,
                             ThoiHan = kh.ThoiHan,
                             ThoiHanTruyCapMienPhi = kh.ThoiHanTruyCapMienPhi,
                             URL_AnhDaiDien = kh.URL_AnhDaiDien,
                             HocPhiGoc = kh.HocPhiGoc,
                             HocPhiGiamGia = kh.HocPhiGiamGia,
                             CreatedDateTime = kh.CreatedDateTime,
                             TyLeDanhGia = kh.TyLeDanhGia,
                             SoLuongNguoiHoc = kh.SoLuongNguoiHoc,
                             IdMonHoc = kh.IdMonHoc,
                             Id = kh.Id
                         });
            return await query.OrderByDescending(o => o.CreatedDateTime).Take(500).ToListAsync();
        }
        public async Task<List<DsKhoaHoc>> GetDanhSachAsync(int page, int pageSize, int totalLimitItems, string searchBy, string orderBy)
        {
            return await (from kh in _dbContext.Por_KhoaHocs
                    join gv in _dbContext.Por_LoaiKhoaHocs.Where(o => o.TrangThaiBanGhi == true) on kh.IdLoaiKhoaHoc equals gv.Id into group1
                    from g1 in group1.DefaultIfEmpty()
                    join mh in _dbContext.Por_MonHocs.Where(o => o.TrangThaiBanGhi == true) on kh.IdMonHoc equals mh.Id into group2
                    from g2 in group2.DefaultIfEmpty()
                    select new DsKhoaHoc
                    {
                        TenLoaiKhoaHoc = g1 != null ? g1.TieuDe : "",
                        TenMonHoc = g2 != null ? g2.Ten : "",
                        TieuDe = kh.TieuDe,
                        ThoiHan = kh.ThoiHan,
                        GioiThieu = kh.GioiThieu,
                        NoiDung = kh.NoiDung,
                        URL_AnhDaiDien = kh.URL_AnhDaiDien,
                        HocPhiGoc = kh.HocPhiGoc,
                        HocPhiGiamGia = kh.HocPhiGiamGia,
                        TrangThai = kh.TrangThai, 
                        TrangThaiBanGhi =kh.TrangThaiBanGhi,
                        CreatedDateTime = kh.CreatedDateTime,
                        Id = kh.Id
                    }).ToListAsync();

        }

        public async Task<List<KhoaHocTrongGioHang>> ChonVaoGioHangAsync(List<KhoaHocTrongGioHang> model)
        {
            List<Guid> idsKhoaHoc = model.Select(o => o.Id).ToList();
            List<KhoaHocTrongGioHang> items = new List<KhoaHocTrongGioHang>();
            if(idsKhoaHoc != null && idsKhoaHoc.Count > 0)
            {
                items = await _dbContext.Por_KhoaHocs.Where(o => idsKhoaHoc.Contains(o.Id))
                    .Select(o => new KhoaHocTrongGioHang() { Id = o.Id, TieuDe = o.TieuDe, URL_AnhDaiDien = o.URL_AnhDaiDien, HocPhiGoc = o.HocPhiGoc, HocPhiGiamGia = o.HocPhiGiamGia }).ToListAsync();
            }
            return items;
        }
    }
}
