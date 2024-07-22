using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CommonRecords
{
    public record PriceRecord(decimal price, string CurrencyCode)
    {
        public static PriceRecord Create(decimal price, string CurrencyCode) { return new PriceRecord(price, CurrencyCode); }
    }
}
