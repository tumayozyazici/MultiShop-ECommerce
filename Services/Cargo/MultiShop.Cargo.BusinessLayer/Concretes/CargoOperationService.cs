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
    public class CargoOperationService : ICargoOperationService
    {
        private readonly ICargoOperationRepository _repository;

        public CargoOperationService(ICargoOperationRepository repository)
        {
            _repository = repository;
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public List<CargoOperation> GetAll()
        {
            return _repository.GetAll();
        }

        public CargoOperation GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Insert(CargoOperation entity)
        {
            _repository.Insert(entity);
        }

        public void Update(CargoOperation entity)
        {
            _repository.Update(entity);
        }
    }
}
