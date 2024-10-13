using Microsoft.Extensions.Options;
using MultiShop.Catalog.Services.BrandSevices;
using MultiShop.Catalog.Services.CategoryServices;
using MultiShop.Catalog.Services.FeatureServices;
using MultiShop.Catalog.Services.FeatureSliderServices;
using MultiShop.Catalog.Services.OfferDiscountServices;
using MultiShop.Catalog.Services.ProductDetailServices;
using MultiShop.Catalog.Services.ProductImageServices;
using MultiShop.Catalog.Services.ProductServices;
using MultiShop.Catalog.Services.SpecialOfferServices;
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
            services.AddScoped<IFeatureSliderService, FeatureSliderService>();
            services.AddScoped<ISpecialOfferService, SpecialOfferService>();
            services.AddScoped<IFeatureService, FeatureService>();
            services.AddScoped<IOfferDiscountService, OfferDiscountService>();
            services.AddScoped<IBrandService, BrandService>();

            // AutoMapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}
