using MediatR;
using Shared.DTO.Customers;
using Shared.DTO.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.OrderCRUD.Queries.GetAllOrderByCustomerId
{
    public record GetAllOrderByCustomerIdQuery(int CustomerId, int pageNumber, int pageSize) : IRequest<List<OrderDTO>>;
}
