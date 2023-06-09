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

namespace WebRunning.API.Service.Por_Anh
{
    public class Service : RepositoryBase<Model.Por_Anh>, Por_Anh.IService
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
        public async Task<List<DsAnh>> GetDanhSachAsync(int page, int pageSize, int totalLimitItems, string searchBy, string orderBy)
        {
            return await (from kh in _dbContext.Por_Anhs
                          join mh in _dbContext.Por_NhomAnhs on kh.IdNhomAnh equals mh.Id into group2
                          from g2 in group2.DefaultIfEmpty()
                          select new DsAnh
                          {
                              Id = kh.Id,
                              NhomAnh = g2 != null ? g2.Ten : "",
                              Ma = kh.Ma,
                              Ten = kh.Ten
                          }).ToListAsync();

        }
        public async Task<List<Images>> ImageGalleryAsync(string domain, int limit)
        {
            List<Images> results = await (from x in _dbContext.Por_Anhs
                                          join y in _dbContext.Por_NhomAnhs on x.IdNhomAnh equals y.Id
                                          select new Images { name = x.Ten, src = x.URL_Anh, alt = x.Ten, tag = y.Ten }).ToListAsync();
            for (var i = 0; i < results.Count; i++)
            {
                results[i].src = domain + "/" + results[i].src.Replace("\\", "/");
            }
            return results;
        }
    }
}