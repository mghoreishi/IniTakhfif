﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountsAddsManagement.Application.Contracts.Discount
{
    public class DiscountSearchModel
    {
        public string Name { get; set; }
        public long CategoryId { get; set; }
    }
}
