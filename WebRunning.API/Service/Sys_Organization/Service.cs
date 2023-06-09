﻿using Microsoft.EntityFrameworkCore;
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

namespace WebRunning.API.Service.Sys_Organization
{
    public class Service : RepositoryBase<Model.Sys_Organization>, Sys_Organization.IService
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
        public async Task<List<ViewModel.Sys_Organization.OrganTree>> GetTreeAsync()
        {
            List<ViewModel.Sys_Organization.OrganTree> items = await _dbContext.Sys_Organizations.Select(o =>
                new ViewModel.Sys_Organization.OrganTree() { Id = o.Id.ToString(), Code = o.Code, Name = o.Name, Type = o.Type, ParentId = o.ParentId.ToString() }).ToListAsync();
            List<ViewModel.Sys_Organization.OrganTree> trees = TreeHelpers<ViewModel.Sys_Organization.OrganTree>.ListToTrees(items);
            return trees;
        }
        public async Task<List<ViewModel.Sys_Organization.OrganTree>> GetTreeListAsync()
        {
            List<ViewModel.Sys_Organization.OrganTree> items = await _dbContext.Sys_Organizations.Select(o =>
                new ViewModel.Sys_Organization.OrganTree() { Id = o.Id.ToString(), Code = o.Id.ToString(), Name = o.Name, ParentId = o.ParentId.ToString() }).ToListAsync();
            List<ViewModel.Sys_Organization.OrganTree> trees = TreeHelpers<ViewModel.Sys_Organization.OrganTree>.ListToTrees(items, true);
            trees = trees.Traverse(o => o.Children).ToList();
            foreach (var tree in trees)
            {
                tree.Children = null;
            }
            return trees;
        }
        public async Task<List<Model.Sys_Organization>> GetByParentIdAsync(Guid ParentId)
        {
            List<Model.Sys_Organization> items = await _dbContext.Sys_Organizations.Where(o => o.ParentId == ParentId).ToListAsync();
            return items;
        }
        public async Task<bool> IsDupicateAttributesAsync(Guid? Id, string Code, Guid ParentId)
        {
            bool result = false;
            if (string.IsNullOrEmpty(Code))
            {
                throw new Exception(Sys_Const.Message.SERVICE_CODE_NOT_EMPTY);
            }
            if (GuidHelpers.IsNullOrEmpty(Id))
            {
                result = await _dbContext.Sys_Organizations.Where(o => o.Code == Code && o.ParentId == ParentId).AnyAsync();
            }
            else
            {
                var items = await _dbContext.Sys_Organizations.Where(o => o.Code == Code && o.ParentId == ParentId).ToListAsync();
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
            var user = await _dbContext.Sys_Users_Roles.FirstOrDefaultAsync(o => o.OrganId == Id);
            if(user != null)
            {
                throw new Exception(Sys_Const.Message.SERVICE_ORGAN_EXIST_USER);
            }
            var organ = await _dbContext.Sys_Organizations.FirstOrDefaultAsync(o => o.Id == Id);
            if (organ == null)
            {
                throw new Exception(Sys_Const.Message.SERVICE_ORGAN_UNEXISTED);
            }
            var organChilds = await _dbContext.Sys_Organizations.Where(o => o.ParentId == Id).ToListAsync();
            if (organChilds != null && organChilds.Count > 0)
            {
                throw new Exception(Sys_Const.Message.SERVICE_ORGAN_EXISTS_ORGAN_CHILD);
            }
            _dbContext.Sys_Organizations.Remove(organ);
            await UnitOfWork.SaveAsync();
        }
    }
}
