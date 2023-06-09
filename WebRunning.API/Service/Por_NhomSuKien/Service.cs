using Microsoft.EntityFrameworkCore;
using WebRunning.API.Infrastructure;
using WebRunning.Lib.Constant;
using WebRunning.Lib.Helpers;
using WebRunning.Lib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static WebRunning.API.Infrastructure.Enums;
using WebRunning.API.ViewModel.Portal;

namespace WebRunning.API.Service.Por_NhomSuKien
{
    public class Service : RepositoryBase<Model.Por_NhomSuKien>, Por_NhomSuKien.IService
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
        public async Task<List<Model.Por_NhomSuKien>> GetItemsHoatDongPortalAsync()
        {
            return await _dbContext.Por_NhomSuKiens.Where(o => o.TrangThaiBanGhi == true).ToListAsync();
        }
        public async Task<bool> IsDupicateAttributesAsync(Guid? Id, string Ma)
        {
            bool result = false;
            if (string.IsNullOrEmpty(Ma))
            {
                throw new Exception(Sys_Const.Message.SERVICE_CODE_NOT_EMPTY);
            }
            if (GuidHelpers.IsNullOrEmpty(Id))
            {
                result = await _dbContext.Por_NhomSuKiens.Where(o => o.Ma == Ma).AnyAsync();
            }
            else
            {
                var items = await _dbContext.Por_NhomSuKiens.Where(o => o.Ma == Ma).ToListAsync();
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
        public async Task Delete(Guid Id)
        {
            var nhomSuKien = await _dbContext.Por_NhomSuKiens.FirstOrDefaultAsync(o => o.Id == Id);
            if (nhomSuKien == null)
            {
                throw new Exception("Mã nhóm sự kiện không tồn tại !");
            }
            var dsSuKien = await _dbContext.Por_SuKiens.Where(o => o.IdNhomSuKien == Id).ToListAsync();
            if (dsSuKien != null && dsSuKien.Count > 0)
            {
                throw new Exception(Sys_Const.Message.SERVICE_DELETE_IS_NOT_EMPTY);
            }
            else
            {
                _dbContext.Por_NhomSuKiens.Remove(nhomSuKien);
                await UnitOfWork.SaveAsync();
            }
        }
    }
}
