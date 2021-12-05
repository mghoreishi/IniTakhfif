using _0_Framework.Application;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiscountsAddsManagement.Application.Contracts.DiscountCategory
{
    public interface IDiscountCategoryApplication
    {
        OperationResult Create(CreateDiscountCategory command);
        OperationResult Edit(EditDiscountCategory command);
        EditDiscountCategory GetDetails(long id);
        List<DiscountCategoryViewModel> Search(DiscountCategorySearchModel searchModel);
    }
}
