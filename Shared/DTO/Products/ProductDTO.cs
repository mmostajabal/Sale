using Domain.CommonRecords;
using Shared.DTO.OrderItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTO.Products
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public PriceRecordDTO Price { get; set; }

        public ICollection<OrderItemDTO> orderItems { get; set; }
    }
}
