using Domain.CommonRecords;
using Shared.DTO.Orders;
using Shared.DTO.Products;
using Shared.DTO.Quantity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTO.OrderItems
{
    public class OrderItemDTO
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public QuantityRecordDTO Quantity { get; set; }
        public PriceRecordDTO Price { get; set; }

        public ProductDTO products { get; set; }
    }
}
