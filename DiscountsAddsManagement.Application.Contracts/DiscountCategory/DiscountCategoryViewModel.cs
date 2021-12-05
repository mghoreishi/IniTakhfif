using System;
using System.Collections.Generic;
using System.Text;

namespace DiscountsAddsManagement.Application.Contracts.DiscountCategory
{
    public class DiscountCategoryViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public DateTime CreationDate { get; set; }
        public long DiscountsCount { get; set; }
    }
}
