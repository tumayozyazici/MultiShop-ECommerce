using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MultiShop.Discount.Context;
using MultiShop.Discount.Services.CouponServices;
using System.Reflection;

namespace MultiShop.Discount.Registrations
{
    public static class DiscountDependencyInjection
    {
        public static void AddDiscountServiceDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            //AppSettings'deki verilerin girisi.
            services.AddDbContext<DapperContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));


            // Services
            services.AddScoped<ICouponService, CouponService>();
        }
    }
}
