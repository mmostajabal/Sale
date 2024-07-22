using Domain.CommonRecords;
using Domain.Customers;
using Domain.OrderItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Orders
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public PriceRecord TotalPrice { get; set; }
        public Customer customer { get; set; }

        public ICollection<OrderItem> Items { get; set; }
    }
}
