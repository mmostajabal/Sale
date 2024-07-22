using Domain.CommonRecords;
using Shared.DTO.Customers;
using Shared.DTO.OrderItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTO.Orders
{
    public class UpdateOrderDTO
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public PriceRecordDTO TotalPrice { get; set; }

        public ICollection<UpdateOrderItemDTO> Items { get; set; }
    }
}
