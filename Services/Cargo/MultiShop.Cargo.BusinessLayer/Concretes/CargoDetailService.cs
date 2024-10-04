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
    public class CargoDetailService : ICargoDetailService
    {
        private readonly ICargoDetailRepository _cargoDetailRepository;

        public CargoDetailService(ICargoDetailRepository cargoDetailRepository)
        {
            _cargoDetailRepository = cargoDetailRepository;
        }

        public void Delete(int id)
        {
            _cargoDetailRepository.Delete(id);
        }

        public List<CargoDetail> GetAll()
        {
            return _cargoDetailRepository.GetAll();
        }

        public CargoDetail GetById(int id)
        {
            return _cargoDetailRepository.GetById(id);
        }

        public void Insert(CargoDetail entity)
        {
            _cargoDetailRepository.Insert(entity);
        }

        public void Update(CargoDetail entity)
        {
            _cargoDetailRepository.Update(entity);
        }
    }
}
