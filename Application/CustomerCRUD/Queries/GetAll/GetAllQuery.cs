using MediatR;
using Shared.DTO.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CustomerCRUD.Queries.GetAll
{
    public record GetAllQuery : IRequest<IEnumerable<CustomerDTO>>;
}
