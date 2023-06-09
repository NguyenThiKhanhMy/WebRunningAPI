using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using WebRunning.API.Infrastructure;
using WebRunning.Lib.Helpers;
using WebRunning.Lib.Interfaces;
using WebRunning.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using WebRunning.Lib.Core;
using WebRunning.Lib.Constant;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;
using MailKit.Search;

namespace WebRunning.API.Service
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : AuditEntity
    {
        private readonly DomainDbContext _dbContext;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly IUserProvider _userProvider;
        protected DbSet<T> DbSet => _dbContext.Set<T>();

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _dbContext;
            }
        }

        public RepositoryBase(DomainDbContext dbContext, IDateTimeProvider dateTimeProvider, IUserProvider userService)
        {
            _dbContext = dbContext;
            _dateTimeProvider = dateTimeProvider;            
            _userProvider = userService;
        }
        public async Task<T> SaveEntityAsync(T entity)
        {
            var existingItem = await _dbContext.Set<T>().FirstOrDefaultAsync(o => o.Id == entity.Id);
            DateTimeOffset now = _dateTimeProvider.OffsetNow;
            string userName = string.IsNullOrEmpty(_userProvider.UserName) ? "Guest" : _userProvider.UserName;
            if (existingItem != null)
            {
                entity.UpdatedDateTime = now.AddHours(Sys_Const.TimeZone);
                entity.UpdatedBy = userName;
                _dbContext.Entry(existingItem).CurrentValues.SetValues(entity);
            }
            else
            {
                entity.Id = Guid.NewGuid();
                entity.CreatedDateTime = now.AddHours(Sys_Const.TimeZone);
                entity.CreatedBy = userName;                
                await _dbContext.Set<T>().AddAsync(entity);
            }
            await UnitOfWork.SaveAsync();
            return entity;
        }
        public async Task<T[]> SaveEntitiesAsync(T[] entities)
        {
            foreach (var entity in entities)
            {
                var existingItem = await _dbContext.Set<T>().FirstOrDefaultAsync(o => o.Id == entity.Id);
                DateTimeOffset now = _dateTimeProvider.OffsetNow;
                string userName = string.IsNullOrEmpty(_userProvider.UserName) ? "Guest" : _userProvider.UserName;
                if (existingItem != null)
                {
                    entity.UpdatedDateTime = now.AddHours(Sys_Const.TimeZone);
                    entity.UpdatedBy = userName;
                }
                else
                {
                    entity.Id = Guid.NewGuid();
                    entity.CreatedDateTime = now.AddHours(Sys_Const.TimeZone);
                    entity.CreatedBy = userName;
                    await _dbContext.Set<T>().AddAsync(entity);
                }
            }
            await UnitOfWork.SaveAsync();
            return entities;
        }
        public async Task AddEntityAsync(T entity)
        {
            var existingItem = await _dbContext.Set<T>().FirstOrDefaultAsync(o => o.Id == entity.Id);
            DateTimeOffset now = _dateTimeProvider.OffsetNow;
            string userName = string.IsNullOrEmpty(_userProvider.UserName) ? "Guest" : _userProvider.UserName;
            if (existingItem != null)
            {
                entity.UpdatedDateTime = now.AddHours(Sys_Const.TimeZone);
                entity.UpdatedBy = userName;
            }
            else
            {
                entity.Id = Guid.Empty;
                entity.CreatedDateTime = now.AddHours(Sys_Const.TimeZone);
                entity.CreatedBy = userName;
                await _dbContext.Set<T>().AddAsync(entity);
            }
        }
        public async Task<Paged<T>> GetListEntitiesAsync(int page, int pageSize, int totalLimitItems, string searchBy, string orderBy)
        {
            var query = _dbContext.Set<T>().AsQueryable();
            if (!string.IsNullOrEmpty(searchBy))
            {
                query = query.Where(searchBy);
            }
            Paged<T> result = new Paged<T>(query, page, pageSize, totalLimitItems);
            query = query.Paged(page, pageSize, totalLimitItems);
            if (!string.IsNullOrEmpty(orderBy))
            {
                query = query.OrderBy(orderBy);
            }
            result.Items = await query.ToListAsync();
            return result;
        }
        public async Task<Paged<T>> SearcListEntitiesAsync(int page, int pageSize, int totalLimitItems, Lib.Models.Searching search)
        {
            var query = _dbContext.Set<T>().AsQueryable();
            if (!string.IsNullOrEmpty(search.SearchBy.Query))
            {
                query = query.Where(search.SearchBy.Query, search.SearchBy.Values);
            }
            Paged<T> result = new Paged<T>(query, page, pageSize, totalLimitItems);
            query = query.Paged(page, pageSize, totalLimitItems);
            if (!string.IsNullOrEmpty(search.OrderBy))
            {
                query = query.OrderBy(search.OrderBy);
            }
            result.Items = await query.ToListAsync();
            return result;
        }
        public async Task<T> GetEntityByIdAsync(Guid id)
        {
            return await _dbContext.Set<T>().FirstOrDefaultAsync(o => o.Id == id);
        }
        public List<T> GetCategoryEntities()
        {
            List<string> columnNames = ReflectionUtil.GetColumnNameAttr<T>("category");
            if (columnNames.Count == 0)
                return null;
            string strColumns = ListHelpers.ConcatStrings(columnNames);
            var result = _dbContext.Set<T>().Select(LinQHelpers.DynamicSelectGenerator<T>(strColumns)).ToList();
            return result;
        }
        public async Task DeleteSaveEntities(List<T> entity)
        {
            DbSet.RemoveRange(DbSet.Where(o => entity.Select(o => o.Id).Contains(o.Id)));
            await UnitOfWork.SaveAsync();
        }
        public void DeleteEntities(List<T> entity)
        {
            DbSet.RemoveRange(DbSet.Where(o => entity.Select(o => o.Id).Contains(o.Id)));
        }
    }
}
