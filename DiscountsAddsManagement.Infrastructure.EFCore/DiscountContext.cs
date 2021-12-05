using DiscountsAddsManagement.Domain.DiscountAgg;
using DiscountsAddsManagement.Domain.DiscountCategoryAgg;
using DiscountsAddsManagement.Infrastructure.EFCore.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountsAddsManagement.Infrastructure.EFCore
{
    public class DiscountContext: DbContext
    {
        public DbSet<DiscountCategory> DiscountCategories { get; set; }
        public DbSet<Discount> Discounts { get; set; }


        public DiscountContext(DbContextOptions<DiscountContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            var assembly = typeof(DiscountCategoryMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
