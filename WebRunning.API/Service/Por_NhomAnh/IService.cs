using WebRunning.Lib.Interfaces;
using WebRunning.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace WebRunning.API.Service.Por_NhomAnh
{
    public interface IService : IRepositoryBase<Model.Por_NhomAnh>
    {
        Task<List<Model.Por_NhomAnh>> GetDanhMucNhomAnhAsync();
        Task Delete(Guid Id);
    }
}
