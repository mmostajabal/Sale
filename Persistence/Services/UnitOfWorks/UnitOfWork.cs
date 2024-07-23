using Domain.Customers;
using Domain.OrderItems;
using Domain.Orders;
using Domain.Products;
using Persistence.Contracts.Repository;
using Persistence.Contracts.UnitOfWork;
using Persistence.Data;
using Persistence.Services.OrderRep;
using Persistence.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Services.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        private IRepository<Customer> _customerRep;
        private OrderRepository _orderRep;
        private IRepository<OrderItem> _orderItemsRep;
        private IRepository<Product> _productRep;
        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IRepository<Customer> CustomersRep => _customerRep ?? new Repository<Customer>(_dbContext);

        public OrderRepository OrdersRep => _orderRep ?? new OrderRepository(_dbContext);

        public IRepository<OrderItem> OrderItemsRep => _orderItemsRep ?? new Repository<OrderItem>(_dbContext);

        public IRepository<Product> ProductsRep => _productRep ?? new Repository<Product>(_dbContext);

        public void Dispose() =>_dbContext.Dispose();
        
        public async Task<int> SaveAsync() => await _dbContext.SaveChangesAsync();
    }
}
