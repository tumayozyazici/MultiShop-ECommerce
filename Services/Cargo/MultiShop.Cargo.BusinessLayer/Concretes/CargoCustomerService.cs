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
    public class CargoCustomerService : ICargoCustomerService
    {
        private readonly ICargoCustomerRepository _cargoCustomerRepository;

        public CargoCustomerService(ICargoCustomerRepository cargoCustomerRepository)
        {
            _cargoCustomerRepository = cargoCustomerRepository;
        }

        public void Delete(int id)
        {
            _cargoCustomerRepository.Delete(id);
        }

        public List<CargoCustomer> GetAll()
        {
            return _cargoCustomerRepository.GetAll();
        }

        public CargoCustomer GetById(int id)
        {
            return _cargoCustomerRepository.GetById(id);
        }

        public void Insert(CargoCustomer entity)
        {
            _cargoCustomerRepository.Insert(entity);
        }

        public void Update(CargoCustomer entity)
        {
            _cargoCustomerRepository.Update(entity);
        }
    }
}
