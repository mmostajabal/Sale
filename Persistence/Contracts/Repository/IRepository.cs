using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Contracts.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<T> GetAsync(int id, CancellationToken cancellationToken = default);
        Task<T> GetAsyncWitIncludeAndOrder(Expression<Func<T, bool>> condition, Expression<Func<T, object>>[] includes, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, CancellationToken cancellationToken = default);
        Task AddAsync(T entity, CancellationToken cancellationToken = default);
        Task DeleteAsync(int id, CancellationToken cancellationToken = default);
        Task<int> BulkDelete(Expression<Func<T, bool>> query, CancellationToken cancellationToken = default);

        void Update(T entity, CancellationToken cancellationToken = default);

        Task<IEnumerable<T>> GetByCondition(Expression<Func<T, bool>> query);
    }
}
