using Microsoft.EntityFrameworkCore;
using WebRunning.API.Infrastructure;
using WebRunning.Lib.Constant;
using WebRunning.Lib.Helpers;
using WebRunning.Lib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRunning.API.Service.Sys_AuthToken
{
    public class Service : RepositoryBase<Model.Sys_AuthToken>, Sys_AuthToken.IService
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
        public async Task SaveByUserNameAsync(string UserName, Model.Sys_AuthToken authToken)
        {
            var tokenOld = await _dbContext.Sys_AuthTokens.Where(o => o.UserName == UserName).FirstOrDefaultAsync();
            if (tokenOld == null)
            {
                Model.Sys_AuthToken authTokenNew = new Model.Sys_AuthToken();                
                authTokenNew.AccessToken = authToken.AccessToken;
                authTokenNew.RefeshToken = authToken.RefeshToken;
                authTokenNew.UserName = UserName;
                await AddEntityAsync(authTokenNew);
            }
            else
            {
                ObjectHelpers.Mapping<Model.Sys_AuthToken, Model.Sys_AuthToken>(authToken, tokenOld, new string[] { "id" });
                tokenOld.UserName = UserName;
            }
            await UnitOfWork.SaveAsync();
        }
        public async Task<Model.Sys_AuthToken> GetByUserNameAsync(string UserName)
        {
            return await _dbContext.Sys_AuthTokens.Where(o => o.UserName == UserName).FirstOrDefaultAsync();
        }
    }
}
