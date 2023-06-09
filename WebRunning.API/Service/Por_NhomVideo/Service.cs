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

namespace WebRunning.API.Service.Por_NhomVideo
{
    public class Service : RepositoryBase<Model.Por_NhomVideo>, Por_NhomVideo.IService
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
        public async Task Delete(Guid Id)
        {
            var nhomVideo = await _dbContext.Por_NhomVideos.FirstOrDefaultAsync(o => o.Id == Id);
            if (nhomVideo == null)
            {
                throw new Exception("Mã nhóm video không tồn tại !");
            }
            var dsVideo = await _dbContext.Por_Videos.Where(o => o.IdNhomVideo == Id).ToListAsync();
            if (dsVideo != null && dsVideo.Count > 0)
            {
                throw new Exception(Sys_Const.Message.SERVICE_DELETE_IS_NOT_EMPTY);
            } else
            {
                _dbContext.Por_NhomVideos.Remove(nhomVideo);
                await UnitOfWork.SaveAsync();
            }
        }
    }
}
