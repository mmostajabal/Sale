using Application.CustomerCRUD.Commands.Update;
using AutoMapper;
using Domain.Customers;
using MediatR;
using Persistence.Contracts.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CustomerCRUD.Commands.Delete
{
    public class DeleteCustomerCommandHandler:IRequestHandler<DeleteCustomerCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public DeleteCustomerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.CustomersRep.DeleteAsync(request.id, cancellationToken);
            await _unitOfWork.SaveAsync();

            return;
        }
    }
}
