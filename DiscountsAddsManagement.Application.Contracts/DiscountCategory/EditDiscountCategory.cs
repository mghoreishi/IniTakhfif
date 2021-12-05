using System;
using System.Collections.Generic;
using System.Text;

namespace DiscountsAddsManagement.Application.Contracts.DiscountCategory
{
    public class EditDiscountCategory : CreateDiscountCategory
    {
        public long Id { get; set; }
    }
}
