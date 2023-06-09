using WebRunning.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebRunning.Lib.Interfaces
{
    public interface IRepositoryBase<TEntity>
    {
        IUnitOfWork UnitOfWork { get; }

        Task<TEntity> SaveEntityAsync(TEntity entity);
        Task<TEntity[]> SaveEntitiesAsync(TEntity[] entity);        
        Task AddEntityAsync(TEntity entity);
        Task<Paged<TEntity>> GetListEntitiesAsync(int page, int pageSize, int totalLimitItems, string searchBy = "", string orderBy = "");
        Task<Paged<TEntity>> SearcListEntitiesAsync(int page, int pageSize, int totalLimitItems, Lib.Models.Searching search);
        Task<TEntity> GetEntityByIdAsync(Guid id);
        List<TEntity> GetCategoryEntities();
        Task DeleteSaveEntities(List<TEntity> entity);
        void DeleteEntities(List<TEntity> entity);
    }
}
