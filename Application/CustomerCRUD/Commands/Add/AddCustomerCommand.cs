using Domain.CommonRecords;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CustomerCRUD.Commands.Add
{
    public record AddCustomerCommand(string FirstName, string LastName, string Address, string PostalCode) : IRequest<int>
    {
        public static AddCustomerCommand GetInstance(string FirstName, string LastName, string Address, string PostalCode)
        {
            return new AddCustomerCommand(FirstName, LastName, Address, PostalCode);
        }
    }

}
