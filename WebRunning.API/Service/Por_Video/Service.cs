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
using Microsoft.AspNetCore.Hosting;

namespace WebRunning.API.Service.Por_Video
{
    public class Service : RepositoryBase<Model.Por_Video>, Por_Video.IService
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
        public async Task<List<DsVideo>> GetDanhSachAsync(int page, int pageSize, int totalLimitItems, string searchBy, string orderBy)
        {
            return await (from kh in _dbContext.Por_Videos
                          join mh in _dbContext.Por_NhomVideos on kh.IdNhomVideo equals mh.Id into group2
                          from g2 in group2.DefaultIfEmpty()
                          select new DsVideo
                          {
                              Id = kh.Id,
                              NhomVideo = g2 != null ? g2.Ten : "",
                              Ma = kh.Ma,
                              Ten = kh.Ten,
                              ThoiLuong = kh.ThoiLuong
                          }).ToListAsync();

        }
    }
}