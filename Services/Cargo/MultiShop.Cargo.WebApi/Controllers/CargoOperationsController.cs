using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstracts;
using MultiShop.Cargo.Dto.CargoOperationDtos;
using MultiShop.Cargo.EntityLayer.Entities;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoOperationsController : ControllerBase
    {
        private readonly ICargoOperationService _service;

        public CargoOperationsController(ICargoOperationService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetCargoOperationList()
        {
            var cargoOperations = _service.GetAll();
            return Ok(cargoOperations);
        }

        [HttpPost]
        public IActionResult CreateCargoOperation(CreateCargoOperationDto createCargoOperationDto)
        {
            CargoOperation cargoOperation = new CargoOperation();
            cargoOperation.Barcode = createCargoOperationDto.Barcode;
            cargoOperation.OperationDate = createCargoOperationDto.OperationDate;
            cargoOperation.Description = createCargoOperationDto.Description;
            _service.Insert(cargoOperation);
            return Ok("Kargo işlemi başarıyla eklendi");
        }

        [HttpPut]
        public IActionResult UpdateCargoOperation(UpdateCargoOperationDto updateCargoOperationDto)
        {
            CargoOperation cargoOperation = _service.GetById(updateCargoOperationDto.CargoOperationID);
            cargoOperation.Barcode = updateCargoOperationDto.Barcode;
            cargoOperation.OperationDate = updateCargoOperationDto.OperationDate;
            cargoOperation.Description = updateCargoOperationDto.Description;
            _service.Update(cargoOperation);
            return Ok("Kargo işlemi başarıyla güncellendi");
        }

        [HttpDelete]
        public IActionResult RemoveCargoOperation(int id)
        {
            _service.Delete(id);
            return Ok("Kargo işlemi başarıyla silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoOperationById(int id)
        {
            var cargoOperation = _service.GetById(id);
            return Ok(cargoOperation);
        }
    }
}
