using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountsAddsManagement.Application.Contracts.Discount
{
    public class EditDiscount : CreateDiscount
    {
        public long Id { get; set; }
    }
}
