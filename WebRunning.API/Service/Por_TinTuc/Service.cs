using Microsoft.EntityFrameworkCore;
using WebRunning.API.Infrastructure;
using WebRunning.Lib.Constant;
using WebRunning.Lib.Helpers;
using WebRunning.Lib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebRunning.API.ViewModel.Portal;
using Autofac.Features.Metadata;

namespace WebRunning.API.Service.Por_TinTuc
{
    public class Service : RepositoryBase<Model.Por_TinTuc>, Por_TinTuc.IService
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
        public async Task<List<DsTinTuc>> GetItemsTinNoiBatAsync(int limit)
        {
            var tintucs = await (from kh in _dbContext.Por_TinTucs
                                 where kh.TrangThaiBanGhi == true && kh.TinNoiBat
                                 select new DsTinTuc
                                 {
                                     Id = kh.Id,
                                     IdNhomTinTuc = kh.IdNhomTinTuc,
                                     URL_AnhDaiDien = kh.URL_AnhDaiDien,
                                     TieuDe = kh.TieuDe,
                                     MoTa = kh.MoTa,
                                     TacGia = kh.TacGia,
                                     NgayXuatBan = kh.NgayXuatBan,
                                     TinNoiBat = kh.TinNoiBat,
                                     CreatedDateTime = kh.CreatedDateTime,
                                     TrangThaiBanGhi = kh.TrangThaiBanGhi
                                 }).OrderByDescending(o => o.CreatedDateTime).Take(limit).ToListAsync();
            return tintucs;
        }
        public async Task<List<DsTinTuc>> GetItemsTheoChuyenMucAsync(Guid idChuyenMuc)
        {
            var query = (from kh in _dbContext.Por_TinTucs
                         where kh.TrangThaiBanGhi == true
                         select new DsTinTuc
                         {
                             Id = kh.Id,
                             IdNhomTinTuc = kh.IdNhomTinTuc,
                             URL_AnhDaiDien = kh.URL_AnhDaiDien,
                             TieuDe = kh.TieuDe,
                             MoTa = kh.MoTa,
                             TacGia = kh.TacGia,
                             NgayXuatBan = kh.NgayXuatBan,
                             CreatedDateTime = kh.CreatedDateTime,
                             TrangThaiBanGhi = kh.TrangThaiBanGhi
                         });
            if (idChuyenMuc != Guid.Empty)
            {
                List<ViewModel.Por_NhomTinTuc.NhomTinTucTree> items = await _dbContext.Por_NhomTinTucs.Where(o => o.TrangThaiBanGhi == true).Select(o =>
                new ViewModel.Por_NhomTinTuc.NhomTinTucTree() { Id = o.Id.ToString(), Code = o.Ma, Name = o.Ten, ParentId = o.IdNhomTinTucCha.ToString() }).ToListAsync();
                List<ViewModel.Por_NhomTinTuc.NhomTinTucTree> trees = TreeHelpers<ViewModel.Por_NhomTinTuc.NhomTinTucTree>.ListToTrees(items, false);
                var nodeParent = TreeHelpers<ViewModel.Por_NhomTinTuc.NhomTinTucTree>.GetNodeFromTree(trees[0], idChuyenMuc.ToString());
                var chuyenmucIds = new List<Guid>();
                if (nodeParent != null)
                {
                    var chuyenmucChild = TreeHelpers<ViewModel.Por_NhomTinTuc.NhomTinTucTree>.GetChildNodesByNodeParent(nodeParent);
                    chuyenmucIds = chuyenmucChild.Select(o => Guid.Parse(o.Id)).ToList();
                }    
                chuyenmucIds.Add(idChuyenMuc);
                query = query.Where(o => chuyenmucIds.Contains(o.IdNhomTinTuc));
            }
            return await query.OrderByDescending(o => o.CreatedDateTime).Take(500).ToListAsync();
        }
        public async Task<List<DsTinTuc>> GetDanhSachAsync(int page, int pageSize, int totalLimitItems, string searchBy, string orderBy)
        {
            return await (from kh in _dbContext.Por_TinTucs
                          join mh in _dbContext.Por_NhomTinTucs on kh.IdNhomTinTuc equals mh.Id into group2
                          from g2 in group2.DefaultIfEmpty()
                          select new DsTinTuc
                          {
                              Id = kh.Id,
                              NhomTinTuc = g2 != null ? g2.Ten : "",
                              TieuDe = kh.TieuDe,
                              TacGia = kh.TacGia,
                              NgayXuatBan = kh.NgayXuatBan,
                              TrangThaiBanGhi = kh.TrangThaiBanGhi 
                          }).ToListAsync();

        }
    }
}