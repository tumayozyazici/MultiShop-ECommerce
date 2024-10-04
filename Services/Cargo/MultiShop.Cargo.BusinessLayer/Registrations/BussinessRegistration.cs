using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MultiShop.Cargo.BusinessLayer.Abstracts;
using MultiShop.Cargo.BusinessLayer.Concretes;
using MultiShop.Cargo.DataAccessLayer.Abstracts;
using MultiShop.Cargo.DataAccessLayer.Concretes;
using MultiShop.Cargo.DataAccessLayer.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.BusinessLayer.Registrations
{
    public static class BussinessRegistration
    {
        public static void AddBussinessRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CargoContext>();
            services.AddScoped<ICargoCompanyRepository, CargoCompanyRepository>();
            services.AddScoped<ICargoCustomerRepository, CargoCustomerRepository>();
            services.AddScoped<ICargoOperationRepository, CargoOperationRepository>();
            services.AddScoped<ICargoDetailRepository, CargoDetailRepository>();

            services.AddScoped<ICargoCompanyService, CargoCompanyService>();
            services.AddScoped<ICargoCustomerService, CargoCustomerService>();
            services.AddScoped<ICargoOperationService, CargoOperationService>();
            services.AddScoped<ICargoDetailService, CargoDetailService>();
        }
    }
}
