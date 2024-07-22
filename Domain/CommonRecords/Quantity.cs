using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CommonRecords
{
    public record QuantityRecord(decimal Quantity, string QuantityCode)
    {
        public static QuantityRecord Create(decimal Quantity, string QuantityCode)
        {
            return new QuantityRecord(Quantity, QuantityCode);    
        }
    }
}
