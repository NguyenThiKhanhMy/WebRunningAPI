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
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;

namespace WebRunning.API.Service.Por_SuKien
{
    public class Service : RepositoryBase<Model.Por_SuKien>, Por_SuKien.IService
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
        public async Task<List<DsSuKien>> GetItemsTheoNhomSuKienMoiNhatAsync(int limit)
        {
            var query = from kh in _dbContext.Por_SuKiens
                        join mh in _dbContext.Por_NhomSuKiens on kh.IdNhomSuKien equals mh.Id
                        where kh.TrangThaiBanGhi == true && mh.TrangThaiBanGhi == true
                        select new DsSuKien
                        {
                            Id = kh.Id,
                            IdNhomSuKien = mh.Id,
                            NhomSuKien = mh.Ten,
                            URL_AnhDaiDien = kh.URL_AnhDaiDien,
                            Ten = kh.Ten,
                            DiaChi = kh.DiaChi,
                            TrangThai = kh.TrangThai,
                            GiaTien = kh.GiaTien,
                            ThoiGian = kh.ThoiGian,
                            TrangThaiBanGhi = kh.TrangThaiBanGhi,
                            CreatedDateTime = kh.CreatedDateTime
                        };
            return await query.OrderByDescending(o => o.CreatedDateTime).Take(limit).ToListAsync();
        }
        public async Task<List<DsSuKien>> GetItemsTheoNhomSuKienAsync(Guid idNhomSuKien)
        {
            var query = from kh in _dbContext.Por_SuKiens
                        join mh in _dbContext.Por_NhomSuKiens on kh.IdNhomSuKien equals mh.Id
                        where kh.TrangThaiBanGhi == true && mh.TrangThaiBanGhi == true
                        select new DsSuKien
                        {
                            Id = kh.Id,
                            IdNhomSuKien = mh.Id,
                            NhomSuKien = mh.Ten,
                            URL_AnhDaiDien = kh.URL_AnhDaiDien,
                            Ten = kh.Ten,
                            DiaChi = kh.DiaChi,
                            TrangThai = kh.TrangThai,
                            GiaTien = kh.GiaTien,
                            ThoiGian = kh.ThoiGian,
                            TrangThaiBanGhi = kh.TrangThaiBanGhi,
                            CreatedDateTime = kh.CreatedDateTime
                        };
            if (idNhomSuKien != Guid.Empty)
            {
                query = query.Where(o => o.IdNhomSuKien == idNhomSuKien);
            }
            return await query.OrderByDescending(o => o.CreatedDateTime).Take(500).ToListAsync();
        }
        public async Task<List<DsSuKien>> GetDanhSachAsync(int page, int pageSize, int totalLimitItems, string searchBy, string orderBy)
        {
            return await (from kh in _dbContext.Por_SuKiens
                          join mh in _dbContext.Por_NhomSuKiens on kh.IdNhomSuKien equals mh.Id into group2
                          from g2 in group2.DefaultIfEmpty()
                          select new DsSuKien
                          {
                              Id = kh.Id,
                              NhomSuKien = g2 != null ? g2.Ten : "",
                              Ten = kh.Ten,
                              TrangThai = kh.TrangThai,
                              DiaChi = kh.DiaChi,
                              GiaTien = kh.GiaTien,
                              ThoiGian = kh.ThoiGian,
                              TrangThaiBanGhi = kh.TrangThaiBanGhi
                          }).ToListAsync();

        }
    }
}