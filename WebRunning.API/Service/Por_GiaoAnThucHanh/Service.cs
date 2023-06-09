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
using Microsoft.AspNetCore.Hosting;
using WebRunning.API.ViewModel.Por_GiaoAnThucHanh;

namespace WebRunning.API.Service.Por_GiaoAnThucHanh
{
    public class Service : RepositoryBase<Model.Por_GiaoAnThucHanh>, Por_GiaoAnThucHanh.IService
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
        public async Task<string> GetLinkVideo(Guid GiaoAnId, Guid UserId)
        {
            var item = await _dbContext.Por_GiaoAnThucHanhs.FirstOrDefaultAsync(o => o.Id == GiaoAnId);
            if (item == null)
                return null;
            return item.URL_Video;
        }

        public async Task DeleteById(Guid Id)
        {
            var item = await _dbContext.Por_GiaoAnThucHanhs.FirstOrDefaultAsync(o => o.IdGiaoAnThucHanh == Id);
            if (item != null)
            {
                throw new Exception("Vui lòng xóa dữ liệu liên quan trước !");
            }
            item = await _dbContext.Por_GiaoAnThucHanhs.FirstOrDefaultAsync(o => o.Id == Id);
            if (item == null)
            {
                throw new Exception("Giáo án lý thuyết không tồn tại");
            }
            _dbContext.Por_GiaoAnThucHanhs.Remove(item);
            await UnitOfWork.SaveAsync();
        }
        public async Task<List<GiaoAnThucHanhTree>> GetTree(Guid IdKhoaHoc)
        {
            var items = await (from x in _dbContext.Por_KhoaHoc_GiaoAns
                         join y in _dbContext.Por_GiaoAnThucHanhs on x.IdGiaoAn equals y.Id
                         where x.IdKhoaHoc == IdKhoaHoc
                         select new GiaoAnThucHanhTree { Loai = y.Loai, SoThuTu = y.SoThuTu, Id = y.Id.ToString(), Code = y.Id.ToString(), Name = y.TieuDe, ParentId = y.IdGiaoAnThucHanh.ToString() }).ToListAsync();
            var items_GiaoAn = items.Where(o => o.Loai == Enums.LoaiGiaoAnThucHanh.GiaoAn).OrderByDescending(o => o.SoThuTu).ToList();
            var items_ChuongMuc = items.Where(o => o.Loai == Enums.LoaiGiaoAnThucHanh.ChuongMuc).OrderByDescending(o => o.SoThuTu).ToList();
            var items_BaiHoc = items.Where(o => o.Loai == Enums.LoaiGiaoAnThucHanh.BaiHoc).OrderByDescending(o => o.SoThuTu).ToList();
            var items_NoiDung = items.Where(o => o.Loai == Enums.LoaiGiaoAnThucHanh.NoiDung).OrderByDescending(o => o.SoThuTu).ToList();
            for (var i = 0;i < items_GiaoAn.Count;i++)
            {
                for(var j = 0; j < items_ChuongMuc.Count; j++)
                {
                    if (items_GiaoAn[i].Id == items_ChuongMuc[j].ParentId)
                    {
                        items_GiaoAn[i].Children.Add(items_ChuongMuc[j]);
                    }    
                    for(var o = 0; o < items_BaiHoc.Count; o++)
                    {
                        if (items_ChuongMuc[j].Id == items_BaiHoc[o].ParentId)
                        {
                            items_ChuongMuc[j].Children.Add(items_BaiHoc[o]);
                        }
                        for (var k = 0; k < items_NoiDung.Count; k++)
                        {
                            if (items_BaiHoc[o].Id == items_NoiDung[k].ParentId)
                            {
                                items_BaiHoc[o].Children.Add(items_NoiDung[k]);
                            }
                        }
                    }    
                }    
            }    
            return items_GiaoAn;
        }
        public async Task<List<GiaoAnThucHanhTree>> GetTreePortal(Guid IdKhoaHoc)
        {
            var items = await (from x in _dbContext.Por_KhoaHoc_GiaoAns
                               join y in _dbContext.Por_GiaoAnThucHanhs on x.IdGiaoAn equals y.Id
                               where x.IdKhoaHoc == IdKhoaHoc
                               select new GiaoAnThucHanhTree { GhiChu = y.GhiChu, ThoiLuong = y.ThoiLuong, MienPhi = y.MienPhi, Loai = y.Loai, SoThuTu = y.SoThuTu, Id = y.Id.ToString(), Code = y.Id.ToString(), Name = y.TieuDe, ParentId = y.IdGiaoAnThucHanh.ToString() }).ToListAsync();
            var items_GiaoAn = items.Where(o => o.Loai == Enums.LoaiGiaoAnThucHanh.GiaoAn).OrderByDescending(o => o.SoThuTu).ToList();
            var items_ChuongMuc = items.Where(o => o.Loai == Enums.LoaiGiaoAnThucHanh.ChuongMuc).OrderByDescending(o => o.SoThuTu).ToList();
            var items_BaiHoc = items.Where(o => o.Loai == Enums.LoaiGiaoAnThucHanh.BaiHoc).OrderByDescending(o => o.SoThuTu).ToList();
            var items_NoiDung = items.Where(o => o.Loai == Enums.LoaiGiaoAnThucHanh.NoiDung).OrderByDescending(o => o.SoThuTu).ToList();
            for (var i = 0; i < items_GiaoAn.Count; i++)
            {
                for (var j = 0; j < items_ChuongMuc.Count; j++)
                {
                    if (items_GiaoAn[i].Id == items_ChuongMuc[j].ParentId)
                    {
                        items_GiaoAn[i].Children.Add(items_ChuongMuc[j]);
                    }
                    for (var o = 0; o < items_BaiHoc.Count; o++)
                    {
                        if (items_ChuongMuc[j].Id == items_BaiHoc[o].ParentId)
                        {
                            items_ChuongMuc[j].Children.Add(items_BaiHoc[o]);
                        }
                        for (var k = 0; k < items_NoiDung.Count; k++)
                        {
                            if (items_BaiHoc[o].Id == items_NoiDung[k].ParentId)
                            {
                                items_BaiHoc[o].Children.Add(items_NoiDung[k]);
                            }
                        }
                    }
                }
            }
            return items_GiaoAn;
        }
    }
}