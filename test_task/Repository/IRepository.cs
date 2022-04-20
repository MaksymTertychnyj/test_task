using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace test_task.Repository
{
    public interface IRepository<TEntity>
        where TEntity : class
    {
        Task<TEntity> GetByKeyAsync(object key);

        Task<TEntity> AddAsync(TEntity entity);
        
        Task<TEntity> UpdateAsync(TEntity entity);

        Task<int> SaveChangesAsync();

    }
}
