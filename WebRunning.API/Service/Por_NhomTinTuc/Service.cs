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

namespace WebRunning.API.Service.Por_NhomTinTuc
{
    public class Service : RepositoryBase<Model.Por_NhomTinTuc>, Por_NhomTinTuc.IService
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
        public async Task<List<ViewModel.Por_NhomTinTuc.NhomTinTucTree>> GetTreeAsync()
        {
            List<ViewModel.Por_NhomTinTuc.NhomTinTucTree> items = await _dbContext.Por_NhomTinTucs.Select(o =>
                new ViewModel.Por_NhomTinTuc.NhomTinTucTree() { Id = o.Id.ToString(), Code = o.Ma, Name = o.Ten, ParentId = o.IdNhomTinTucCha.ToString() }).ToListAsync();
            List<ViewModel.Por_NhomTinTuc.NhomTinTucTree> trees = TreeHelpers<ViewModel.Por_NhomTinTuc.NhomTinTucTree>.ListToTrees(items);
            return trees;
        }
        public async Task<List<ViewModel.Por_NhomTinTuc.NhomTinTucTree>> GetTreeListAsync()
        {
            List<ViewModel.Por_NhomTinTuc.NhomTinTucTree> items = await _dbContext.Por_NhomTinTucs.Select(o =>
                new ViewModel.Por_NhomTinTuc.NhomTinTucTree() { Id = o.Id.ToString(), Code = o.Ma, Name = o.Ten, ParentId = o.IdNhomTinTucCha.ToString() }).ToListAsync();
            List<ViewModel.Por_NhomTinTuc.NhomTinTucTree> trees = TreeHelpers<ViewModel.Por_NhomTinTuc.NhomTinTucTree>.ListToTrees(items, true);
            trees = trees.Traverse(o => o.Children).ToList();
            foreach (var tree in trees)
            {
                tree.Children = null;
            }
            return trees;
        }
        public async Task<List<ViewModel.Por_NhomTinTuc.NhomTinTucTree>> GetTreePortalAsync()
        {
            List<ViewModel.Por_NhomTinTuc.NhomTinTucTree> items = await _dbContext.Por_NhomTinTucs.Where(o => o.TrangThaiBanGhi == true).Select(o =>
                new ViewModel.Por_NhomTinTuc.NhomTinTucTree() { Id = o.Id.ToString(), Code = o.Ma, Name = o.Ten, ParentId = o.IdNhomTinTucCha.ToString() }).ToListAsync();
            List<ViewModel.Por_NhomTinTuc.NhomTinTucTree> trees = TreeHelpers<ViewModel.Por_NhomTinTuc.NhomTinTucTree>.ListToTrees(items);
            return trees;
        }
        public async Task<List<Model.Por_NhomTinTuc>> GetDSNhomTinTucPortal(Guid IdNhomTinTucCha)
        {
            List<Model.Por_NhomTinTuc> items = await _dbContext.Por_NhomTinTucs.Where(o => o.IdNhomTinTucCha == IdNhomTinTucCha).ToListAsync();
            return items;
        }
        public async Task<List<Model.Por_NhomTinTuc>> GetByParentIdAsync(Guid IdNhomTinTucCha)
        {
            List<Model.Por_NhomTinTuc> items = await _dbContext.Por_NhomTinTucs.Where(o => o.IdNhomTinTucCha == IdNhomTinTucCha).ToListAsync();
            return items;
        }
        public async Task<bool> IsDupicateAttributesAsync(Guid? Id, string Ma, Guid IdNhomTinTucCha)
        {
            bool result = false;
            if (string.IsNullOrEmpty(Ma))
            {
                throw new Exception(Sys_Const.Message.SERVICE_CODE_NOT_EMPTY);
            }
            if (GuidHelpers.IsNullOrEmpty(Id))
            {
                result = await _dbContext.Por_NhomTinTucs.Where(o => o.Ma == Ma && o.IdNhomTinTucCha == IdNhomTinTucCha).AnyAsync();
            }
            else
            {
                var items = await _dbContext.Por_NhomTinTucs.Where(o => o.Ma == Ma && o.IdNhomTinTucCha == IdNhomTinTucCha).ToListAsync();
                if (items.Count >= 1)
                {
                    if (items.Count == 1)
                    {
                        var item = items.FirstOrDefault(o => o.Id == Id);
                        if (item != null)
                        {
                            result = false;
                        }
                        else
                        {
                            result = true;
                        }
                    }
                    else
                    {
                        result = true;

                    }
                }
                else
                {
                    result = false;
                }
            }
            return await Task.FromResult(result);
        }
        public async Task<List<ObjNhomTinTuc>> TinTucPortalAsync(string maNhomTinTuc, int Limit)
        {
            var nhomTinTuc = await _dbContext.Por_NhomTinTucs.FirstOrDefaultAsync(o => o.Ma == maNhomTinTuc);
            if(nhomTinTuc == null)
            {
                throw new Exception("Mã nhóm tin tức không tồn tại !");
            }    
            return await (from nhomtintuc in _dbContext.Por_NhomTinTucs
                                                  where nhomtintuc.Id == nhomTinTuc.Id && nhomtintuc.TrangThaiBanGhi == true
                                                  select new ObjNhomTinTuc
                                                  {
                                                      TenNhomTinTuc = nhomtintuc.Ten,
                                                      IdNhomTinTuc = nhomtintuc.Id,
                                                      DanhSachTinTuc = (List<ObjTinTuc>)(from tintuc in _dbContext.Por_TinTucs.Where(o => o.TrangThaiBanGhi == true && o.IdNhomTinTuc == nhomTinTuc.Id)
                                                                        select new ObjTinTuc
                                                                        {
                                                                            TieuDe = tintuc.TieuDe,
                                                                            MoTa = tintuc.MoTa,
                                                                            URL_AnhDaiDien = tintuc.URL_AnhDaiDien,
                                                                            Id = tintuc.Id
                                                                        }).Take(Limit)
                                                  }).ToListAsync();

        }
        public async Task<List<ObjKienThuc>> KienThucPortalAsync(string maNhomTinTuc, int Limit)
        {
            var nhomTinTuc = await _dbContext.Por_NhomTinTucs.FirstOrDefaultAsync(o => o.Ma == maNhomTinTuc);
            if (nhomTinTuc == null)
            {
                throw new Exception("Mã nhóm tin tức không tồn tại !");
            }
            return await (from nhomtintuc in _dbContext.Por_NhomTinTucs
                          join tintuc in _dbContext.Por_TinTucs on nhomTinTuc.Id equals tintuc.IdNhomTinTuc
                          where nhomtintuc.Id == nhomTinTuc.Id && nhomtintuc.TrangThaiBanGhi == true 
                          select new ObjKienThuc{
                                                                     TieuDe = tintuc.TieuDe,
                                                                     MoTa = tintuc.MoTa,
                                                                     URL_AnhDaiDien = tintuc.URL_AnhDaiDien,
                                                                     TacGia = tintuc.TacGia, 
                                                                     NgayXuatBan = tintuc.NgayXuatBan,
                                                                     Id = tintuc.Id
                                                                 }).Take(Limit).ToListAsync();

        }
        public async Task Delete(Guid Id)
        {
            var nhomTinTuc = await _dbContext.Por_NhomTinTucs.FirstOrDefaultAsync(o => o.Id == Id);
            if (nhomTinTuc == null)
            {
                throw new Exception("Mã nhóm tin tức không tồn tại !");
            }
            var dsTinTuc = await _dbContext.Por_TinTucs.Where(o => o.IdNhomTinTuc == Id).ToListAsync();
            if (dsTinTuc != null && dsTinTuc.Count > 0)
            {
                throw new Exception(Sys_Const.Message.SERVICE_DELETE_IS_NOT_EMPTY);
            }
            else
            {
                _dbContext.Por_NhomTinTucs.Remove(nhomTinTuc);
                await UnitOfWork.SaveAsync();
            }
        }
    }
}
