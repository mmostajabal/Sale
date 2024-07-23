using Domain.CommonRecords;
using MediatR;
using Shared.DTO.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.OrderCRUD.Commands.Add
{
    public record AddOrderCommand(UpdateOrderDTO Order) : IRequest<int>
    {
        public static AddOrderCommand GetInstance(UpdateOrderDTO order)
        {
            return new AddOrderCommand(order);
        }
    }

}
