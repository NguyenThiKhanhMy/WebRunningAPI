using Microsoft.EntityFrameworkCore;
using WebRunning.API.Infrastructure;
using WebRunning.Lib.Constant;
using WebRunning.Lib.Core;
using WebRunning.Lib.Helpers;
using WebRunning.Lib.Interfaces;
using WebRunning.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRunning.API.Service.Por_Menu
{
    public class Service : RepositoryBase<Model.Por_Menu>, Por_Menu.IService
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
        public async Task<List<ViewModel.Por_Menu.MenuTree>> GetTreeAsync()
        {
            List<ViewModel.Por_Menu.MenuTree> items = await _dbContext.Por_Menus.Select(o =>
                new ViewModel.Por_Menu.MenuTree() { Id = o.Id.ToString(), Code = o.Ma, Name = o.Ten, ParentId = o.IdMenuCha.ToString() }).ToListAsync();

            List<ViewModel.Por_Menu.MenuTree> trees = TreeHelpers<ViewModel.Por_Menu.MenuTree>.ListToTrees(items);
            return trees;
        }
        public async Task<List<ViewModel.Por_Menu.MenuTree>> GetTreePortalAsync()
        {
         List<ViewModel.Por_Menu.MenuTree> items = await _dbContext.Por_Menus.Where(o => o.TrangThaiBanGhi == true).Select(o =>
             new ViewModel.Por_Menu.MenuTree() { Id = o.Id.ToString(), Code = o.Ma, Name = o.Ten, URL = o.URL, ParentId = o.IdMenuCha.ToString(), ThuTu = o.ThuTu }).OrderBy(o => o.ThuTu).ToListAsync();
         List<ViewModel.Por_Menu.MenuTree> trees = TreeHelpers<ViewModel.Por_Menu.MenuTree>.ListToTrees(items);
         return trees;
        }
        public async Task<List<ViewModel.Por_Menu.MenuTree>> GetTreeListAsync()
        {
            List<ViewModel.Por_Menu.MenuTree> items = await _dbContext.Por_Menus.Select(o =>
                new ViewModel.Por_Menu.MenuTree() { Id = o.Id.ToString(), Code = o.Ma, Name = o.Ten, ParentId = o.IdMenuCha.ToString() }).ToListAsync();
            List<ViewModel.Por_Menu.MenuTree> trees = TreeHelpers<ViewModel.Por_Menu.MenuTree>.ListToTrees(items, true);
            trees = trees.Traverse(o => o.Children).ToList();
            foreach (var tree in trees)
            {
                tree.Children = null;
            }
            return trees;
        }
        public async Task<List<Model.Por_Menu>> GetByParentIdAsync(Guid IdMenuCha)
        {
            List<Model.Por_Menu> items = await _dbContext.Por_Menus.Where(o => o.IdMenuCha == IdMenuCha).ToListAsync();
            return items;
        }
        public async Task<bool> IsDupicateAttributesAsync(Guid? Id, string Ma, Guid IdMenuCha)
        {
            bool result = false;
            if (string.IsNullOrEmpty(Ma))
            {
                throw new Exception(Sys_Const.Message.SERVICE_CODE_NOT_EMPTY);
            }
            if (GuidHelpers.IsNullOrEmpty(Id))
            {
                result = await _dbContext.Por_Menus.Where(o => o.Ma == Ma && o.IdMenuCha == IdMenuCha).AnyAsync();
            }
            else
            {
                var items = await _dbContext.Por_Menus.Where(o => o.Ma == Ma && o.IdMenuCha == IdMenuCha).ToListAsync();
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
        public async Task DeleteById(Guid Id)
        {
            var user = await _dbContext.Sys_Users_Roles.FirstOrDefaultAsync(o => o.MenuId == Id);
            if (user != null)
            {
                throw new Exception(Sys_Const.Message.SERVICE_MENU_EXIST_USER);
            }
            var menu = await _dbContext.Por_Menus.FirstOrDefaultAsync(o => o.Id == Id);
            if (menu == null)
            {
                throw new Exception(Sys_Const.Message.SERVICE_MENU_UNEXISTED);
            }
            var menuChilds = await _dbContext.Por_Menus.Where(o => o.IdMenuCha == Id).ToListAsync();
            if (menuChilds != null && menuChilds.Count > 0)
            {
                throw new Exception(Sys_Const.Message.SERVICE_MENU_EXISTS_ORGAN_CHILD);
            }
            _dbContext.Por_Menus.Remove(menu);
            await UnitOfWork.SaveAsync();
        }
    }
}
