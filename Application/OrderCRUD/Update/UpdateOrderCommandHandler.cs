﻿using Application.OrderCRUD.Commands.Add;
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

namespace Application.OrderCRUD.Commands.Update
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateOrderCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            Order order= _mapper.Map<Order>(request.Order);

            _unitOfWork.OrdersRep.Update(order);
            await _unitOfWork.SaveAsync();

            return;
        }
    }
}
