using MultiShop.Cargo.DataAccessLayer.Abstracts;
using MultiShop.Cargo.DataAccessLayer.Contexts;
using MultiShop.Cargo.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.DataAccessLayer.Concretes
{
    public class CargoCompanyRepository : GenericRepository<CargoCompany>, ICargoCompanyRepository
    {
        public CargoCompanyRepository(CargoContext context) : base(context)
        {
        }
    }
}
