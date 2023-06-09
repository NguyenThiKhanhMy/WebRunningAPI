using Microsoft.EntityFrameworkCore;
using WebRunning.API.Infrastructure;
using WebRunning.Lib.Constant;
using WebRunning.Lib.Helpers;
using WebRunning.Lib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRunning.API.Service.Sys_Category
{
    public class Service:RepositoryBase<Model.Sys_Category>, Sys_Category.IService
    {
        private readonly DomainDbContext _dbContext;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly IUserProvider _userProvider;
        public Service(DomainDbContext dbContext, IDateTimeProvider dateTimeProvider, IUserProvider userService):base(dbContext, dateTimeProvider, userService)
        {
            _dbContext = dbContext;
            _dateTimeProvider = dateTimeProvider;
            _userProvider = userService;
        }
        public async Task<bool> IsDupicateAttributesAsync(Guid? Id, string Code, int Type)
        {
            bool result = false;
            if (string.IsNullOrEmpty(Code))
            {
                throw new Exception(Sys_Const.Message.SERVICE_CODE_NOT_EMPTY);
            }
            if (GuidHelpers.IsNullOrEmpty(Id))
            {
                result = await _dbContext.Sys_Categories.Where(o => o.Code == Code && o.Type == (Lib.Enums.CategoryType)Type).AnyAsync();
            }
            else
            {
                var items = await _dbContext.Sys_Categories.Where(o => o.Code == Code && o.Type == (Lib.Enums.CategoryType)Type).ToListAsync();
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
        public async Task<Model.Sys_Category> GetItemByCode(Lib.Enums.CategoryType type, string code)
        {
            return await _dbContext.Sys_Categories.Where(o => o.Type == type && o.Code == code).FirstOrDefaultAsync();
        }
        public async Task<Model.Sys_Category> GetItemById(Lib.Enums.CategoryType type, Guid id)
        {
            return await _dbContext.Sys_Categories.Where(o => o.Type == type && o.Id == id).FirstOrDefaultAsync();
        }
    }
}
