using _0_Framework.Domain;
using DiscountsAddsManagement.Application.Contracts.DiscountCategory;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DiscountsAddsManagement.Domain.DiscountCategoryAgg
{
    public interface IDiscountCategoryRepository: IRepository<long, DiscountCategory>
    {
     
        EditDiscountCategory GetDetails(long id);
        List<DiscountCategoryViewModel> Search(DiscountCategorySearchModel searchModel);
        string GetSlugById(long id);
    }
}
