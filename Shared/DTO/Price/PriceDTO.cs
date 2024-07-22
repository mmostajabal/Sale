using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CommonRecords
{
    public record PriceRecordDTO(decimal price, string CurrencyCode);
}
