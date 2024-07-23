using Domain.Customers;
using Domain.OrderItems;
using Domain.Orders;
using Domain.Products;
using Persistence.Contracts.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Contracts.UnitOfWork 
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Customer> CustomersRep { get; }
        Persistence.Services.OrderRep.OrderRepository OrdersRep { get; }
        IRepository<OrderItem> OrderItemsRep { get; }
        IRepository<Product> ProductsRep { get; }
        Task<int> SaveAsync();
    }
}
