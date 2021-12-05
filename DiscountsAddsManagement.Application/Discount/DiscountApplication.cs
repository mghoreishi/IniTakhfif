using _0_Framework.Application;
using DiscountsAddsManagement.Application.Contracts.Discount;
using DiscountsAddsManagement.Domain.DiscountAgg;
using DiscountsAddsManagement.Domain.DiscountCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountsAddsManagement.Application.Discount
{
    public class DiscountApplication : IDiscountApplication
    {

        private readonly IDiscountRepository _discountRepository;
        private readonly IDiscountCategoryRepository _discountCategoryRepository;


        public DiscountApplication(IDiscountRepository discountRepository,
                                   IDiscountCategoryRepository discountCategoryRepository)
        {
            _discountRepository = discountRepository;
            _discountCategoryRepository = discountCategoryRepository;
        }

        public OperationResult Active(long id)
        {
            var operation = new OperationResult();

            var discount = _discountRepository.Get(id);
            if (discount == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            discount.Active();
            _discountRepository.SaveChanges();

            return operation.Succedded();
        }

        public OperationResult Cancel(long id)
        {
            var operation = new OperationResult();

            var discount = _discountRepository.Get(id);
            if (discount == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            discount.Cancel();
            _discountRepository.SaveChanges();

            return operation.Succedded();
        }

        public OperationResult Confirm(long id)
        {
            var operation = new OperationResult();

            var discount = _discountRepository.Get(id);
            if (discount == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            discount.Confirm();
            _discountRepository.SaveChanges();

            return operation.Succedded();
        }

        public OperationResult Create(CreateDiscount command)
        {
            var operation = new OperationResult();

            if (_discountRepository.Exists(q => q.Name == command.Name))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var slug = command.Slug.Slugify();
            var categorySlug = _discountCategoryRepository.GetSlugById(command.CategoryId);
            var path = $"{categorySlug }//{slug}";
            var picturePath = "";
            var discount = new DiscountsAddsManagement.Domain.DiscountAgg.Discount(command.Name,
                command.ShortDescription, command.Description, picturePath,
                command.PictureAlt, command.PictureTitle, command.CategoryId, slug,
                command.Keywords, command.MetaDescription);
            _discountRepository.Create(discount);
            _discountRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Edit(EditDiscount command)
        {
            var operation = new OperationResult();

            var discount = _discountRepository.GetDiscountWithCategory(command.Id);
            if (discount == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (_discountRepository.Exists(q => q.Name == command.Name && q.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var slug = command.Slug.Slugify();
            var path = $"{discount.Category.Slug}/{slug}";

            var picturePath = "";
            discount.Edit(command.Name,
                command.ShortDescription, command.Description, picturePath,
                command.PictureAlt, command.PictureTitle, command.CategoryId, slug,
                command.Keywords, command.MetaDescription,command.Description);

            _discountRepository.SaveChanges();
            return operation.Succedded();


        }

        public EditDiscount GetDetails(long id)
        {
            return _discountRepository.GetDetails(id);
        }

        public List<DiscountViewModel> GetDiscounts()
        {
            return _discountRepository.GetDiscount();
        }

        public OperationResult InActive(long id)
        {
            var operation = new OperationResult();

            var discount = _discountRepository.Get(id);
            if (discount == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            discount.InActive();
            _discountRepository.SaveChanges();

            return operation.Succedded();
        }

        public List<DiscountViewModel> Search(DiscountSearchModel searchModel)
        {
            return _discountRepository.Search(searchModel);
        }
    }
}
