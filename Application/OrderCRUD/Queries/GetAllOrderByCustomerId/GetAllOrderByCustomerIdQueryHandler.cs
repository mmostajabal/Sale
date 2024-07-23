using AutoMapper;
using MediatR;
using Persistence.Contracts.UnitOfWork;
using Shared.DTO.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.OrderCRUD.Queries.GetAllOrderByCustomerId
{
    internal class GetAllOrderByCustomerIdQueryHandler : IRequestHandler<GetAllOrderByCustomerIdQuery, List<OrderDTO>>

    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetAllOrderByCustomerIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<OrderDTO>> Handle(GetAllOrderByCustomerIdQuery request, CancellationToken cancellationToken)
        {
            var t = await _unitOfWork.OrdersRep.GetAllOrderByCustomerIdAsync(request.CustomerId, request.pageNumber, request.pageSize);
            return t.Select(s => _mapper.Map<OrderDTO>(s)).ToList();
            //return (await _unitOfWork.OrdersRep.GetAllOrderByCustomerIdAsync(request.CustomerId, request.pageNumber, request.pageSize));
        }
    }
}
