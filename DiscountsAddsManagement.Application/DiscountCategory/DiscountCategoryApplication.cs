using _0_Framework.Application;
using DiscountsAddsManagement.Application.Contracts.DiscountCategory;
using DiscountsAddsManagement.Domain.DiscountCategoryAgg;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiscountsAddsManagement.Application.DiscountCategory
{
    public class DiscountCategoryApplication : IDiscountCategoryApplication
    {

        private readonly IDiscountCategoryRepository _discountCategoryRepository;

        public DiscountCategoryApplication(IDiscountCategoryRepository discountCategoryRepository)
        {
            _discountCategoryRepository = discountCategoryRepository;
        }
        public OperationResult Create(CreateDiscountCategory command)
        {
            OperationResult result = new OperationResult();

            if (_discountCategoryRepository.Exists(q=>q.Name==command.Name))
                return result.Failed("امکان ثبت رکورد تکراری وجود ندارد");

            var slug = command.Slug.Slugify();
            var discountCategory = new Domain.DiscountCategoryAgg.DiscountCategory(command.Name, command.Description, command.PictureTitle, 
                command.PictureAlt, command.Picture,command.Keywords, command.MetaDescription, slug);

            _discountCategoryRepository.Create(discountCategory);
            _discountCategoryRepository.SaveChanges();

            return result.Succedded();

        }

        public OperationResult Edit(EditDiscountCategory command)
        {
            OperationResult result = new OperationResult();

            var discountCategory = _discountCategoryRepository.Get(command.Id);

            if (discountCategory == null)
                return result.Failed("رکوردی با اطلاعات درخواست شده یافت نشد.");

            if (_discountCategoryRepository.Exists(q => q.Name == command.Name && q.Id != command.Id))
                return result.Failed("امکان ثبت رکورد تکراری وجود ندارد.");

            var slug = command.Slug.Slugify();

            discountCategory.Edit(command.Name, command.Description, command.PictureTitle, command.PictureAlt, command.Picture, 
                command.Keywords, command.MetaDescription, slug);

            _discountCategoryRepository.SaveChanges();

            return result.Succedded();
        }

        public EditDiscountCategory GetDetails(long id)
        {
            return _discountCategoryRepository.GetDetails(id);
        }

        public List<DiscountCategoryViewModel> Search(DiscountCategorySearchModel searchModel)
        {
            return _discountCategoryRepository.Search(searchModel);
        }
    }
}
