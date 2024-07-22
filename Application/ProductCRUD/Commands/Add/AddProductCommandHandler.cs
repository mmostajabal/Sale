using Application.CustomerCRUD.Commands.Add;
using AutoMapper;
using Domain.CommonRecords;
using Domain.Products;
using MediatR;
using Persistence.Contracts.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ProductCRUD.Commands.Add
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<int> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            Product product = _mapper.Map<Product>(request.product);
            await _unitOfWork.ProductsRep.AddAsync(product);
            await _unitOfWork.SaveAsync();

            return product.Id;
        }
    }
}
