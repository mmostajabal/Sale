using Microsoft.EntityFrameworkCore;
using Persistence.Contracts.Repository;
using Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Services.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<T> _dbSet;
        public Repository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }
        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default) => await _dbSet.ToListAsync();
        public async Task<T> GetAsync(int id, CancellationToken cancellationToken = default) => await _dbSet.FindAsync(id);
        public async Task AddAsync(T entity, CancellationToken cancellationToken = default) => await _dbSet.AddAsync(entity);
        public void Update(T entity, CancellationToken cancellationToken = default) => _dbSet.Update(entity);
        public async Task DeleteAsync(int id, CancellationToken cancellationToken = default) {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
            }
            /*if (id == null) return;

            await _dbSet.Where(c=> (int)typeof(T).GetProperty("Id").GetValue(c) == id).ExecuteDeleteAsync();*/
        }

        public async Task DeleteRangeAsync(IEnumerable<int> ids, CancellationToken cancellationToken = default)
        {
            if (ids == null || !ids.Any())
            {
                return;
            }
            
            await _dbSet.Where(e => ids.Contains((int)typeof(T).GetProperty("Id").GetValue(e)))
                        .ExecuteDeleteAsync();
        }
    }
}
