using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstracts;
using MultiShop.Cargo.Dto.CargoCompanyDtos;
using MultiShop.Cargo.EntityLayer.Entities;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCompaniesController : ControllerBase
    {
        private readonly ICargoCompanyService _cargoCompanyService;

        public CargoCompaniesController(ICargoCompanyService cargoCompanyService)
        {
            _cargoCompanyService = cargoCompanyService;
        }

        [HttpGet]
        public IActionResult CargoCompanyList()
        {
            var cargoCompanies = _cargoCompanyService.GetAll();
            return Ok(cargoCompanies);
        }

        [HttpPost]
        public IActionResult CreateCargoCompany(CreateCargoCompanyDto createCargoCompanyDto)
        {
            CargoCompany cargoCompany = new CargoCompany();
            cargoCompany.CargoCompanyName = createCargoCompanyDto.CargoCompanyName;
            _cargoCompanyService.Insert(cargoCompany);
            return Ok("Kargo şirketi başarıyla eklendi");
        }

        [HttpPut]
        public IActionResult UpdateCargoCompany(UpdateCargoCompanyDto updateCargoCompanyDto)
        {
            var cargoCompany = _cargoCompanyService.GetById(updateCargoCompanyDto.CargoCompanyID);
            cargoCompany.CargoCompanyName = updateCargoCompanyDto.CargoCompanyName;
            _cargoCompanyService.Update(cargoCompany);
            return Ok("Kargo şirketi başarıyla güncellendi");
        }

        [HttpDelete]
        public IActionResult RemoveCargoCompany(int id)
        {
            _cargoCompanyService.Delete(id);
            return Ok("Kargo şirketi başarıyla silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoCompanyById(int id)
        {
            var cargoCompany = _cargoCompanyService.GetById(id);
            return Ok(cargoCompany);
        }
    }
}
