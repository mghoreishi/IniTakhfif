using DiscountsAddsManagement.Application.Contracts.DiscountCategory;
using DiscountsAddsManagement.Application.DiscountCategory;
using DiscountsAddsManagement.Domain.DiscountCategoryAgg;
using DiscountsAddsManagement.Infrastructure.EFCore;
using DiscountsAddsManagement.Infrastructure.EFCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiscountsAddsManagement.Configuration
{
    public class DiscountsAddsManagementBootstrapper
    {
        public static void Configur(IServiceCollection services,string connectionString)
        {
            services.AddTransient<IDiscountCategoryApplication, DiscountCategoryApplication>();
            services.AddTransient<IDiscountCategoryRepository, DiscountCategoryRepository>();

            services.AddDbContext<DiscountContext>(x => x.UseSqlServer(connectionString));
        }
    }
}
