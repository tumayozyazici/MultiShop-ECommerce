using Microsoft.Extensions.Options;
using MultiShop.Catalog.Services.CategoryServices;
using MultiShop.Catalog.Services.ProductDetailServices;
using MultiShop.Catalog.Services.ProductImageServices;
using MultiShop.Catalog.Services.ProductServices;
using MultiShop.Catalog.Settings;
using System.Reflection;

namespace MultiShop.Catalog.Registrations
{
    public static class CatalogDependencyInjection
    {
        public static void AddCatalogServiceDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            // AppSettings'deki verilerin girisi.
            services.Configure<DatabaseSettings>(configuration.GetSection("DatabaseSettings"));
            services.AddScoped<IDatabaseSettings>(sp =>
            {
                return sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
            });

            // Services
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductDetailService, ProductDetailService>();
            services.AddScoped<IProductImageService, ProductImageService>();

            // AutoMapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}
