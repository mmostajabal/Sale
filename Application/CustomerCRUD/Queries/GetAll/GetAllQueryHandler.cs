using AutoMapper;
using MediatR;
using Persistence.Contracts.UnitOfWork;
using Shared.DTO.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CustomerCRUD.Queries.GetAll
{
    public class GetAllQueryHandler : IRequestHandler<GetAllQuery, IEnumerable<CustomerDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetAllQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CustomerDTO>> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<CustomerDTO>>(await _unitOfWork.CustomersRep.GetAllAsync());
        }
    }
}
