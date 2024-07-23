using Microsoft.EntityFrameworkCore;
using Persistence.Contracts.Repository;
using Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
        }


        public async Task<int> BulkDelete(Expression<Func<T, bool>> query, CancellationToken cancellationToken = default)
        {
            return await _dbSet.Where(query).ExecuteDeleteAsync();
        }

        public async Task<IEnumerable<T>> GetByCondition(Expression<Func<T, bool>> query)
        {
            return await  _dbSet.Where(query).ToListAsync<T>();
        }

        public async Task<T> GetAsyncWitIncludeAndOrder(Expression<Func<T, bool>> condition, Expression<Func<T, object>>[] includes, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, CancellationToken cancellationToken = default)
        {
            IQueryable<T> query = _dbSet;

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }
            return await query.FirstOrDefaultAsync<T>(condition, cancellationToken);
        }
    }
}
