using Application.OrderCRUD.Commands.Update;
using AutoMapper;
using Domain.CommonRecords;
using Domain.Orders;
using MediatR;
using Persistence.Contracts.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.OrderCRUD.Commands.Add
{
    public class UpdateOrderCommandHandler : IRequestHandler<AddOrderCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateOrderCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<int> Handle(AddOrderCommand request, CancellationToken cancellationToken)
        {
            Order order= _mapper.Map<Order>(request.Order);

            await _unitOfWork.OrdersRep.AddAsync(order);
            await _unitOfWork.SaveAsync();

            return order.Id;
        }
    }
}
