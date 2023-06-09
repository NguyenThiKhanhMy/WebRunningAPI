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
using System.Linq.Dynamic.Core;
using WebRunning.API.ViewModel.Portal;
using Autofac.Features.Metadata;

namespace WebRunning.API.Service.Por_MonHoc
{
    public class Service : RepositoryBase<Model.Por_MonHoc>, Por_MonHoc.IService
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
        public async Task<List<ViewModel.Por_MonHoc.MonHocTree>> GetTreeAsync()
        {
            List<ViewModel.Por_MonHoc.MonHocTree> items = await _dbContext.Por_MonHocs.Select(o =>
                new ViewModel.Por_MonHoc.MonHocTree() { Id = o.Id.ToString(), Code = o.Ma, Name = o.Ten, ParentId = o.IdMonHocCha.ToString() }).ToListAsync();
            List<ViewModel.Por_MonHoc.MonHocTree> trees = TreeHelpers<ViewModel.Por_MonHoc.MonHocTree>.ListToTrees(items);
            return trees;
        }
        public async Task<List<ViewModel.Por_MonHoc.MonHocTree>> GetTreeListAsync()
        {
            List<ViewModel.Por_MonHoc.MonHocTree> items = await _dbContext.Por_MonHocs.Select(o =>
                new ViewModel.Por_MonHoc.MonHocTree() { Id = o.Id.ToString(), Code = o.Ma, Name = o.Ten, ParentId = o.IdMonHocCha.ToString() }).ToListAsync();
            List<ViewModel.Por_MonHoc.MonHocTree> trees = TreeHelpers<ViewModel.Por_MonHoc.MonHocTree>.ListToTrees(items, true);
            trees = trees.Traverse(o => o.Children).ToList();
            foreach (var tree in trees)
            {
                tree.Children = null;
            }
            return trees;
        }
        public async Task<List<ViewModel.Por_MonHoc.MonHocTree>> GetTreePortalAsync()
        {
            List<ViewModel.Por_MonHoc.MonHocTree> items = await _dbContext.Por_MonHocs.Where(o => o.TrangThaiBanGhi == true).Select(o =>
                new ViewModel.Por_MonHoc.MonHocTree() { Id = o.Id.ToString(), Code = o.Ma, Name = o.Ten, ParentId = o.IdMonHocCha.ToString() }).ToListAsync();
            List<ViewModel.Por_MonHoc.MonHocTree> trees = TreeHelpers<ViewModel.Por_MonHoc.MonHocTree>.ListToTrees(items);
            return trees;
        }
        public async Task<List<Model.Por_MonHoc>> GetByParentIdAsync(Guid IdMonHocCha)
        {
            List<Model.Por_MonHoc> items = await _dbContext.Por_MonHocs.Where(o => o.IdMonHocCha == IdMonHocCha).ToListAsync();
            return items;
        }

        public async Task<bool> IsDupicateAttributesAsync(Guid? Id, string Ma, Guid IdMonHocCha)
        {
            bool result = false;
            if (string.IsNullOrEmpty(Ma))
            {
                throw new Exception(Sys_Const.Message.SERVICE_CODE_NOT_EMPTY);
            }
            if (GuidHelpers.IsNullOrEmpty(Id))
            {
                result = await _dbContext.Por_MonHocs.Where(o => o.Ma == Ma && o.IdMonHocCha == IdMonHocCha).AnyAsync();
            }
            else
            {
                var items = await _dbContext.Por_MonHocs.Where(o => o.Ma == Ma && o.IdMonHocCha == IdMonHocCha).ToListAsync();
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

        public async Task<List<MonHoc>> KhoaHocPortalAsync(int MonHocLimit, int KhoaHocLimit, string maMonHocCha)
        {  
            var monHocCha = await _dbContext.Por_MonHocs.Where(o => o.Ma == maMonHocCha).FirstOrDefaultAsync();
            if(monHocCha == null)
            {
                throw new Exception("Mã môn học không tồn tại !");
            }
            var danhSachMonHoc = await _dbContext.Por_MonHocs.Where(o => o.TrangThaiBanGhi == true && o.IdMonHocCha == monHocCha.Id).Select(o => new MonHoc() { IdMonHoc = o.Id, TenMonHoc = o.Ten}).Take(MonHocLimit).ToListAsync();
            var idsMonHoc = danhSachMonHoc.Select(o => o.IdMonHoc).ToList();
            var danhSachKhoaHoc = await _dbContext.Por_KhoaHocs.Where(o => o.TrangThaiBanGhi == true && idsMonHoc.Contains(o.IdMonHoc)).Select(o => new ObjKhoaHoc { Id = o.Id, IdMonHoc = o.IdMonHoc, GioiThieu = o.GioiThieu, TieuDe = o.TieuDe, ThoiHan = o.ThoiHan, URL_AnhDaiDien = o.URL_AnhDaiDien, HocPhiGoc = o.HocPhiGoc, HocPhiGiamGia = o.HocPhiGiamGia }).ToListAsync();

            foreach(var monhoc in danhSachMonHoc)
            {
                monhoc.DanhSachKhoaHoc = danhSachKhoaHoc.Where(o => o.IdMonHoc == monhoc.IdMonHoc).Take(KhoaHocLimit).ToList();
            }    
            return danhSachMonHoc;
        }


        public async Task<ObjMonHoc> MonHocPortalAsync(string maMonHocCha, int Limit)
        {
            var monHocChaRoot = await _dbContext.Por_MonHocs.Where(o => o.Ma == maMonHocCha).FirstOrDefaultAsync();
            if (monHocChaRoot == null)
            {
                throw new Exception("Mã môn học không tồn tại !");
            }
            ObjMonHoc monHocCha = await _dbContext.Por_MonHocs.Where(o => o.Id == monHocChaRoot.Id && o.TrangThaiBanGhi == true)
                .Select(o => new ObjMonHoc() { Id = o.Id, TenMonHoc = o.Ten, MoTa = o.MoTa, GiaGiaoDongTu = o.GiaGiaoDongTu, GiaGiaoDongDen = o.GiaGiaoDongDen, URL_AnhDaiDien = o.URL_AnhDaiDien, IdMonHocCha = o.IdMonHocCha }).FirstOrDefaultAsync();
            List<ObjMonHoc> monHocCon = await _dbContext.Por_MonHocs.Where(o => o.IdMonHocCha == monHocCha.Id && o.TrangThaiBanGhi == true)
                .Select(o => new ObjMonHoc() { Id = o.Id, TenMonHoc = o.Ten, IdMonHocCha = o.IdMonHocCha, MoTa = o.MoTa, GiaGiaoDongTu = o.GiaGiaoDongTu, GiaGiaoDongDen = o.GiaGiaoDongDen, URL_AnhDaiDien = o.URL_AnhDaiDien }).Take(Limit).ToListAsync();
            monHocCha.DanhSachMonHocCon = monHocCon;

            return monHocCha;
        }
    }
}