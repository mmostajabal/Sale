using Application.CustomerCRUD.Commands.Add;
using MediatR;
using Shared.DTO.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ProductCRUD.Commands.Add
{
    public record AddProductCommand(UpdateProductDTO product) : IRequest<int>
    {
        public static AddProductCommand GetInstance(UpdateProductDTO product)
        {
            return new AddProductCommand(product);
        }
    }
}
