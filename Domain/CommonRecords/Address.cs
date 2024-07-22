using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CommonRecords
{
    public record AddressRecord(string Address, string PostalCode)
    {
        public static AddressRecord Create(string Address, string PostalCode)
        {
            return new AddressRecord(Address, PostalCode);
        }
    }
}
