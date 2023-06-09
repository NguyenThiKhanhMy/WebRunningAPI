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
using WebRunning.API.ViewModel.Portal;

namespace WebRunning.API.Service.Por_LoaiKhoaHoc
{
    public class Service : RepositoryBase<Model.Por_LoaiKhoaHoc>, Por_LoaiKhoaHoc.IService
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
        public async Task<List<Model.Por_LoaiKhoaHoc>> GetItemsHoatDongPortalAsync()
        {
            return await _dbContext.Por_LoaiKhoaHocs.Where(o => o.TrangThaiBanGhi == true).ToListAsync();
        }
        public async Task Delete(Guid Id)
        {
            var loaiKhoaHoc = await _dbContext.Por_LoaiKhoaHocs.FirstOrDefaultAsync(o => o.Id == Id);
            if (loaiKhoaHoc == null)
            {
                throw new Exception("Mã loại khóa học không tồn tại !");
            }
            var dsKhoaHoc = await _dbContext.Por_KhoaHocs.Where(o => o.IdLoaiKhoaHoc == Id).ToListAsync();
            if (dsKhoaHoc != null && dsKhoaHoc.Count > 0)
            {
                throw new Exception(Sys_Const.Message.SERVICE_DELETE_IS_NOT_EMPTY);
            }
            else
            {
                _dbContext.Por_LoaiKhoaHocs.Remove(loaiKhoaHoc);
                await UnitOfWork.SaveAsync();
            }
        }
    }
}
