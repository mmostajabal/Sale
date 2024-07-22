using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CustomerCRUD.Commands.Delete
{
    public record DeleteCustomerCommand (int id) :IRequest;
}
