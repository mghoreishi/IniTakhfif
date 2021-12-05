using _0_Framework.Domain;
using _0_Framework.Infrastructure;
using DiscountsAddsManagement.Application.Contracts.Discount;
using DiscountsAddsManagement.Domain.DiscountAgg;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DiscountsAddsManagement.Infrastructure.EFCore.Repository
{
    public class DiscountRepository : RepositoryBase<long, Discount>, IDiscountRepository
    {
        private readonly DiscountContext _context;

        public DiscountRepository(DiscountContext context) : base(context)
        {
            _context = context;
        }

        public EditDiscount GetDetails(long id)
        {
            return _context.Discounts.Select(x => new EditDiscount
            {
                Id = x.Id,
                Name = x.Name,
                Slug = x.Slug,
                CategoryId = x.CategoryId,
                Description = x.Description,
                Keywords = x.Keywords,
                MetaDescription = x.MetaDescription,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                ShortDescription = x.ShortDescription,
                IsActived=x.IsActived,
                IsConfirmed=x.IsConfirmed,
                IsCanceled=x.IsCanceled
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<DiscountViewModel> GetDiscount()
        {
            return _context.Discounts.Select(x => new DiscountViewModel
            {
                Id = x.Id,
                Name = x.Name,
                IsCanceled=x.IsCanceled,
                IsConfirmed=x.IsConfirmed,
                IsActived=x.IsActived
            }).ToList();
        }

        public Discount GetDiscountWithCategory(long id)
        {
            return _context.Discounts.Include(x => x.Category).FirstOrDefault(x => x.Id == id);
        }

        public List<DiscountViewModel> Search(DiscountSearchModel searchModel)
        {
            var query = _context.Discounts
                .Include(x => x.Category)
                .Select(x => new DiscountViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Category = x.Category.Name,
                    CategoryId = x.CategoryId,
                    Picture = x.Picture,
                    CreationDate = x.CreationDate.ToString(),
                    IsCanceled = x.IsCanceled,
                    IsConfirmed = x.IsConfirmed,
                    IsActived = x.IsActived
                });

            if (!string.IsNullOrWhiteSpace(searchModel.Name))
                query = query.Where(x => x.Name.Contains(searchModel.Name));


            if (searchModel.CategoryId != 0)
                query = query.Where(x => x.CategoryId == searchModel.CategoryId);

            return query.OrderByDescending(x => x.Id).ToList();
        }

      
    }
}
