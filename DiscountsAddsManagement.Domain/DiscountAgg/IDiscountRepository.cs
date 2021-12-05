using _0_Framework.Domain;
using _0_Framework.Infrastructure;
using DiscountsAddsManagement.Application.Contracts.Discount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountsAddsManagement.Domain.DiscountAgg
{
    public interface IDiscountRepository : IRepository<long, Discount>
    {
        EditDiscount GetDetails(long id);
        Discount GetDiscountWithCategory(long id);
        List<DiscountViewModel> GetDiscount();
        List<DiscountViewModel> Search(DiscountSearchModel searchModel);
    }
}
