using AutoMapper;
using Domain.CommonRecords;
using Domain.Customers;
using MediatR;
using Persistence.Contracts.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CustomerCRUD.Commands.Add
{
    public class AddOrderCommandHandler : IRequestHandler<AddCustomerCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public AddOrderCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<int> Handle(AddCustomerCommand request, CancellationToken cancellationToken)
        {
            Domain.Customers.Customer customer = new Domain.Customers.Customer(request.FirstName, request.LastName, AddressRecord.Create(request.Address, request.PostalCode));
            await _unitOfWork.CustomersRep.AddAsync(customer);
            await _unitOfWork.SaveAsync();

            return customer.Id;
        }
    }
}
