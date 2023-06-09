using WebRunning.Lib.Interfaces;
using WebRunning.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace WebRunning.API.Service.Por_NhomVideo
{
    public interface IService : IRepositoryBase<Model.Por_NhomVideo>
    {
        Task Delete(Guid Id);
    }
}
