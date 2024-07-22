using Domain.Customers;
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
    public interface IUnitOfWork
    {
        IRepository<Customer> CustomersRep { get; }
        IRepository<Order> OrdersRep { get; }
        IRepository<Product> ProductsRep { get; }
        Task<int> SaveAsync();
    }
}
