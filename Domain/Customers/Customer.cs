using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.CommonRecords;
using Domain.Orders;

namespace Domain.Customers
{
    public class Customer
    {
        public Customer(string firstName , string lastName , AddressRecord address)
        {
            FirstName = firstName;
            LastName = lastName;    
            Address = address;
        }
        public Customer()
        {

        }

        public int Id { get; private set; }
        public string FirstName { get; private set; } = string.Empty;
        public string LastName { get; private set; } = string.Empty;
        public AddressRecord Address { get; private set; }
        public ICollection<Order> Orders { get; init; } 
    }
}
