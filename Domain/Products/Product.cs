using Domain.CommonRecords;
using Domain.OrderItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Products
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }=string.Empty;
        public PriceRecord Price { get; set; }

        public ICollection<OrderItem>  orderItems { get; set; }
    }
}
