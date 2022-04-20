using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using test_task.Data.Context;

namespace test_task.Repository
{
    public sealed class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        private readonly MyContext _context;
        private readonly DbSet<TEntity> dbEntities;

        public Repository(MyContext context)
        {
            _context = context;
            dbEntities = _context.Set<TEntity>();
        }
        public async Task<TEntity> GetByKeyAsync(object key)
        {
            return await dbEntities.FindAsync(key);
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            return (await dbEntities.AddAsync(entity)).Entity;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            return (await Task.Run(() => dbEntities.Update(entity).Entity));
        }
    }
}
