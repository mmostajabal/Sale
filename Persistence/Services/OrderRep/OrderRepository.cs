using Domain.Orders;
using Microsoft.EntityFrameworkCore;
using Persistence.Contracts.OrderRepository;
using Persistence.Contracts.Repository;
using Persistence.Data;
using Persistence.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Services.OrderRep
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public OrderRepository(ApplicationDbContext dbContext) : base(dbContext) {
            _dbContext = dbContext;
        }

        /// <summary>
        /// GetAllOrderByCustomerIdAsync
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<List<Order>> GetAllOrderByCustomerIdAsync(int customerId, int pageNumber, int pageSize)
        {
            return await _dbContext.Orders
                .AsNoTracking()
                .Where(c => c.CustomerId == customerId)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .OrderBy(o => o.OrderDate)
                .Include(order => order.Items)
                .ThenInclude(orderItem => orderItem.products)
                .ToListAsync();
        }

    }
}
