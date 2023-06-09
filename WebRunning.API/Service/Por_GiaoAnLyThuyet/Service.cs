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
using WebRunning.API.ViewModel.Por_GiaoAnLyThuyet;

namespace WebRunning.API.Service.Por_GiaoAnLyThuyet
{
    public class Service : RepositoryBase<Model.Por_GiaoAnLyThuyet>, Por_GiaoAnLyThuyet.IService
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
            var item = await _dbContext.Por_GiaoAnLyThuyets.FirstOrDefaultAsync(o => o.Id == GiaoAnId);
            if(item == null)
                return null;
            return item.URL_Video;
        }
        public async Task DeleteById(Guid Id)
        {
            var item = await _dbContext.Por_GiaoAnLyThuyets.FirstOrDefaultAsync(o => o.IdGiaoAnLyThuyet == Id);
            if (item != null)
            {
                throw new Exception("Vui lòng xóa dữ liệu liên quan trước !");
            }
            item = await _dbContext.Por_GiaoAnLyThuyets.FirstOrDefaultAsync(o => o.Id == Id);
            if (item == null)
            {
                throw new Exception("Giáo án lý thuyết không tồn tại");
            }
            _dbContext.Por_GiaoAnLyThuyets.Remove(item);
            await UnitOfWork.SaveAsync();
        }
        public async Task<List<GiaoAnLyThuyetTree>> GetTree(Guid IdKhoaHoc)
        {
            var items = await (from x in _dbContext.Por_KhoaHoc_GiaoAns
                         join y in _dbContext.Por_GiaoAnLyThuyets on x.IdGiaoAn equals y.Id
                         where x.IdKhoaHoc == IdKhoaHoc
                         select new GiaoAnLyThuyetTree { Loai = y.Loai, SoThuTu = y.SoThuTu, Id = y.Id.ToString(), Code = y.Id.ToString(), Name = y.TieuDe, ParentId = y.IdGiaoAnLyThuyet.ToString() }).ToListAsync();
            var items_GiaoAn = items.Where(o => o.Loai == Enums.LoaiGiaoAnLyThuyet.GiaoAn).OrderByDescending(o => o.SoThuTu).ToList();
            var items_ChuongMuc = items.Where(o => o.Loai == Enums.LoaiGiaoAnLyThuyet.ChuongMuc).OrderByDescending(o => o.SoThuTu).ToList();
            var items_NoiDung = items.Where(o => o.Loai == Enums.LoaiGiaoAnLyThuyet.NoiDung).OrderByDescending(o => o.SoThuTu).ToList();
            for (var i = 0;i < items_GiaoAn.Count;i++)
            {
                for(var j = 0; j < items_ChuongMuc.Count; j++)
                {
                    if (items_GiaoAn[i].Id == items_ChuongMuc[j].ParentId)
                    {
                        items_GiaoAn[i].Children.Add(items_ChuongMuc[j]);
                    }    
                    for(var o = 0; o < items_NoiDung.Count; o++)
                    {
                        if (items_ChuongMuc[j].Id == items_NoiDung[o].ParentId)
                        {
                            items_ChuongMuc[j].Children.Add(items_NoiDung[o]);
                        }
                    }    
                }    
            }    
            return items_GiaoAn;
        }
        public async Task<List<GiaoAnLyThuyetTree>> GetTreePortal(Guid IdKhoaHoc)
        {
            var items = await (from x in _dbContext.Por_KhoaHoc_GiaoAns
                               join y in _dbContext.Por_GiaoAnLyThuyets on x.IdGiaoAn equals y.Id
                               where x.IdKhoaHoc == IdKhoaHoc
                               select new GiaoAnLyThuyetTree { ThoiLuong = y.ThoiLuong, MienPhi = y.MienPhi, Loai = y.Loai, SoThuTu = y.SoThuTu, Id = y.Id.ToString(), Code = y.Id.ToString(), Name = y.TieuDe, ParentId = y.IdGiaoAnLyThuyet.ToString() }).ToListAsync();
            var items_GiaoAn = items.Where(o => o.Loai == Enums.LoaiGiaoAnLyThuyet.GiaoAn).OrderByDescending(o => o.SoThuTu).ToList();
            var items_ChuongMuc = items.Where(o => o.Loai == Enums.LoaiGiaoAnLyThuyet.ChuongMuc).OrderByDescending(o => o.SoThuTu).ToList();
            var items_NoiDung = items.Where(o => o.Loai == Enums.LoaiGiaoAnLyThuyet.NoiDung).OrderByDescending(o => o.SoThuTu).ToList();
            for (var i = 0; i < items_GiaoAn.Count; i++)
            {
                for (var j = 0; j < items_ChuongMuc.Count; j++)
                {
                    if (items_GiaoAn[i].Id == items_ChuongMuc[j].ParentId)
                    {
                        items_GiaoAn[i].Children.Add(items_ChuongMuc[j]);
                    }
                    for (var o = 0; o < items_NoiDung.Count; o++)
                    {
                        if (items_ChuongMuc[j].Id == items_NoiDung[o].ParentId)
                        {
                            items_ChuongMuc[j].Children.Add(items_NoiDung[o]);
                        }
                    }
                }
            }
            return items_GiaoAn;
        }
    }
    
}