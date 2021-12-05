using _0_Framework.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountsAddsManagement.Application.Contracts.Discount
{
    public interface IDiscountApplication
    {
        OperationResult Create(CreateDiscount command);
        OperationResult Edit(EditDiscount command);
        EditDiscount GetDetails(long id);
        List<DiscountViewModel> GetDiscounts();
        List<DiscountViewModel> Search(DiscountSearchModel searchModel);
        OperationResult Confirm(long id);
        OperationResult Cancel(long id);
        OperationResult Active(long id);
        OperationResult InActive(long id);
    }
}
