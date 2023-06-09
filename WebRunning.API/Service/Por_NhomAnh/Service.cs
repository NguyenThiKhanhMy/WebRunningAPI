using Microsoft.EntityFrameworkCore;
using WebRunning.API.Infrastructure;
using WebRunning.Lib.Constant;
using WebRunning.Lib.Helpers;
using WebRunning.Lib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRunning.API.Service.Por_NhomAnh
{
    public class Service : RepositoryBase<Model.Por_NhomAnh>, Por_NhomAnh.IService
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
        public async Task<List<Model.Por_NhomAnh>> GetDanhMucNhomAnhAsync()
        {
            List<Model.Por_NhomAnh> items = await _dbContext.Por_NhomAnhs.ToListAsync();
            return items;
        }
        public async Task Delete(Guid Id)
        {
            var nhomAnh = await _dbContext.Por_NhomAnhs.FirstOrDefaultAsync(o => o.Id == Id);
            if (nhomAnh == null)
            {
                throw new Exception("Mã nhóm ảnh không tồn tại !");
            }
            var dsAnh = await _dbContext.Por_Anhs.Where(o => o.IdNhomAnh == Id).ToListAsync();
            if (dsAnh != null && dsAnh.Count > 0)
            {
                throw new Exception(Sys_Const.Message.SERVICE_DELETE_IS_NOT_EMPTY);
            }
            else
            {
                _dbContext.Por_NhomAnhs.Remove(nhomAnh);
                await UnitOfWork.SaveAsync();
            }
        }
    }
}