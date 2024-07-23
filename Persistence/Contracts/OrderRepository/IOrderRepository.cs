using Domain.Orders;
using Persistence.Contracts.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Contracts.OrderRepository
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<List<Order>> GetAllOrderByCustomerIdAsync(int customerId, int pageNumber, int pageSize);
    }
}
