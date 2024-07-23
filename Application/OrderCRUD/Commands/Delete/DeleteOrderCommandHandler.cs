using Application.CustomerCRUD.Commands.Delete;
using AutoMapper;
using MediatR;
using Persistence.Contracts.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.OrderCRUD.Commands.Delete
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public DeleteOrderCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {

            await _unitOfWork.OrderItemsRep.BulkDelete(c => c.OrderId == request.id, cancellationToken);
            await _unitOfWork.OrdersRep.DeleteAsync(request.id, cancellationToken);
            await _unitOfWork.SaveAsync();

            return;
        }

    }
}
