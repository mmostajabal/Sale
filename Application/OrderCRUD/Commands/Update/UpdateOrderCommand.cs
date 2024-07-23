using Domain.CommonRecords;
using MediatR;
using Shared.DTO.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.OrderCRUD.Commands.Update
{
    public record UpdateOrderCommand(UpdateOrderDTO Order) : IRequest
    {
        public static UpdateOrderCommand GetInstance(UpdateOrderDTO order)
        {
            return new UpdateOrderCommand(order);
        }
    }

}
