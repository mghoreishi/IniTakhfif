using _0_Framework.Infrastructure;
using DiscountsAddsManagement.Application.Contracts.DiscountCategory;
using DiscountsAddsManagement.Domain.DiscountCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DiscountsAddsManagement.Infrastructure.EFCore.Repository
{
    public class DiscountCategoryRepository : RepositoryBase<long, DiscountCategory>, IDiscountCategoryRepository
    {
        private readonly DiscountContext _context;
        public DiscountCategoryRepository(DiscountContext context) : base(context)
        {
            _context = context;
        }

        public EditDiscountCategory GetDetails(long id)
        {
            var discountCategory = _context.DiscountCategories.Where(q => q.Id == id).Select(x=>new EditDiscountCategory
            {
                Id = x.Id,
                Description = x.Description,
                Name = x.Name,
                Keywords = x.Keywords,
                MetaDescription = x.MetaDescription,
                //Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Slug = x.Slug
            });
            return discountCategory.FirstOrDefault();


        }

        public string GetSlugById(long id)
        {
            return _context.DiscountCategories.Where(q => q.Id == id).Select(q => q.Slug).FirstOrDefault();
        }

        public List<DiscountCategoryViewModel> Search(DiscountCategorySearchModel searchModel)
        {
            var query = _context.DiscountCategories.Select(x => new DiscountCategoryViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Picture = x.Picture,
                CreationDate = x.CreationDate
            });

            if (!string.IsNullOrEmpty(searchModel.Name))
                query = query.Where(x => x.Name.Contains(searchModel.Name));

            return query.OrderByDescending(x => x.Name).ToList();
        }
    }
}
