using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieStoreApi.Data.Repository.v1
{
    public interface IRepository<TEntity> where TEntity : class, new()
    {
        ValueTask<TEntity> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}
