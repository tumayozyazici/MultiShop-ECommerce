using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstracts;
using MultiShop.Cargo.BusinessLayer.Concretes;
using MultiShop.Cargo.Dto.CargoCompanyDtos;
using MultiShop.Cargo.Dto.CargoCustomerDtos;
using MultiShop.Cargo.EntityLayer.Entities;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCustomersController : ControllerBase
    {
        private readonly ICargoCustomerService _cargoCustomerService;

        public CargoCustomersController(ICargoCustomerService cargoCustomerService)
        {
            _cargoCustomerService = cargoCustomerService;
        }

        [HttpGet]
        public IActionResult CargoCustomerList()
        {
            var cargoCustomers = _cargoCustomerService.GetAll();
            return Ok(cargoCustomers);
        }

        [HttpPost]
        public IActionResult CreateCargoCustomer(CreateCargoCustomerDto createCargoCustomerDto)
        {
            CargoCustomer cargoCustomer = new CargoCustomer();
            cargoCustomer.Name = createCargoCustomerDto.Name;
            cargoCustomer.Address = createCargoCustomerDto.Address;
            cargoCustomer.Phone = createCargoCustomerDto.Phone;
            cargoCustomer.Surame = createCargoCustomerDto.Surame;
            cargoCustomer.Email = createCargoCustomerDto.Email;
            cargoCustomer.City = createCargoCustomerDto.City;
            cargoCustomer.District = createCargoCustomerDto.District;
            _cargoCustomerService.Insert(cargoCustomer);
            return Ok("Kargo müşterisi başarıyla eklendi");
        }

        [HttpPut]
        public IActionResult UpdateCargoCustomer(UpdateCargoCustomerDto updateCargoCustomerDto)
        {
            var cargoCustomer = _cargoCustomerService.GetById(updateCargoCustomerDto.CargoCustomerID);
            cargoCustomer.Name = updateCargoCustomerDto.Name;
            cargoCustomer.Address = updateCargoCustomerDto.Address;
            cargoCustomer.Phone = updateCargoCustomerDto.Phone;
            cargoCustomer.Surame = updateCargoCustomerDto.Surame;
            cargoCustomer.Email = updateCargoCustomerDto.Email;
            cargoCustomer.City = updateCargoCustomerDto.City;
            cargoCustomer.District = updateCargoCustomerDto.District;
            _cargoCustomerService.Update(cargoCustomer);
            return Ok("Kargo müşterisi başarıyla güncellendi");
        }

        [HttpDelete]
        public IActionResult RemoveCargoCustomer(int id)
        {
            _cargoCustomerService.Delete(id);
            return Ok("Kargo müşterisi başarıyla silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoCustomerById(int id)
        {
            var cargoCustomer = _cargoCustomerService.GetById(id);
            return Ok(cargoCustomer);
        }
    }
}
