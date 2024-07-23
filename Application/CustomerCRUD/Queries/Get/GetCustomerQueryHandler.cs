using AutoMapper;
using Domain.Customers;
using Domain.Orders;
using MediatR;
using Persistence.Contracts.UnitOfWork;
using Shared.DTO.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.CustomerCRUD.Queries.Get
{
    public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, CustomerDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetCustomerQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CustomerDTO?> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            var customer = await _unitOfWork.CustomersRep.GetAsync(request.CustomerId, cancellationToken);
            //Expression<Func<Customer, object>>[] includes = { c => c.Orders};
            //Func<IQueryable<Order>, IOrderedQueryable<Order>> orderBy = q => q.OrderBy(o => o.OrderDate);
            //Func<IQueryable<Order>, IOrderedQueryable<Order>> orderBy = q => q.OrderBy(o => o.OrderDate);
            //var customer = await _unitOfWork.CustomersRep.GetAsyncWitIncludeAndOrder(c => c.Id == request.CustomerId, includes, null, cancellationToken);

            return _mapper.Map<CustomerDTO>(customer);

        }
    }
}
