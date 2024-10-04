using MultiShop.Cargo.BusinessLayer.Abstracts;
using MultiShop.Cargo.DataAccessLayer.Abstracts;
using MultiShop.Cargo.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.BusinessLayer.Concretes
{
    public class CargoCompanyService : ICargoCompanyService
    {
        private readonly ICargoCompanyRepository _cargoCompanyRepository;

        public CargoCompanyService(ICargoCompanyRepository cargoCompanyRepository)
        {
            _cargoCompanyRepository = cargoCompanyRepository;
        }

        public void Delete(int id)
        {
            _cargoCompanyRepository.Delete(id);
        }

        public List<CargoCompany> GetAll()
        {
            return _cargoCompanyRepository.GetAll();
        }

        public CargoCompany GetById(int id)
        {
            return _cargoCompanyRepository.GetById(id);
        }

        public void Insert(CargoCompany entity)
        {
            _cargoCompanyRepository.Insert(entity);
        }

        public void Update(CargoCompany entity)
        {
            _cargoCompanyRepository.Update(entity);
        }
    }
}
