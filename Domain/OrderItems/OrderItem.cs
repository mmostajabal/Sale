using Domain.CommonRecords;
using Domain.Orders;
using Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.OrderItems
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public QuantityRecord Quantity {  get; set; }
        public PriceRecord Price { get; set; }

        public Order order { get; set; }

        public Product products { get; set; }
    }
}
