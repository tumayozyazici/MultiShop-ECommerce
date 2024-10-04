using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstracts;
using MultiShop.Cargo.Dto.CargoDetailDtos;
using MultiShop.Cargo.EntityLayer.Entities;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoDetailsController : ControllerBase
    {
        private readonly ICargoDetailService _cargoDetailService;

        public CargoDetailsController(ICargoDetailService cargoDetailService)
        {
            _cargoDetailService = cargoDetailService;
        }

        [HttpGet]
        public IActionResult GetCargoDetailList()
        {
            var cargoDetails = _cargoDetailService.GetAll();
            return Ok(cargoDetails);
        }

        [HttpPost]
        public IActionResult CreateCargoDetail(CreateCargoDetailDto createCargoDetailDto)
        {
            CargoDetail cargoDetail = new CargoDetail();
            cargoDetail.SenderCustomer = createCargoDetailDto.SenderCustomer;
            cargoDetail.Barcode = createCargoDetailDto.Barcode;
            cargoDetail.CargoCompanyID = createCargoDetailDto.CargoCompanyID;
            cargoDetail.RecieverCustomer = createCargoDetailDto.RecieverCustomer;
            _cargoDetailService.Insert(cargoDetail);
            return Ok("Kargo detayı başarıyla eklendi");
        }

        [HttpPut]
        public IActionResult UpdateCargoDetail(UpdateCargoDetailDto updateCargoDetailDto)
        {
            CargoDetail cargoDetail = _cargoDetailService.GetById(updateCargoDetailDto.CargoDetailID);
            cargoDetail.SenderCustomer = updateCargoDetailDto.SenderCustomer;
            cargoDetail.Barcode = updateCargoDetailDto.Barcode;
            cargoDetail.CargoCompanyID = updateCargoDetailDto.CargoCompanyID;
            cargoDetail.RecieverCustomer = updateCargoDetailDto.RecieverCustomer;
            _cargoDetailService.Update(cargoDetail);
            return Ok("Kargo detayı başarıyla güncellendi");
        }

        [HttpDelete]
        public IActionResult RemoveCargoDetail(int id)
        {
            _cargoDetailService.Delete(id);
            return Ok("Kargo detayı başarıyla silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoDetailById(int id)
        {
            var cargoDetail = _cargoDetailService.GetById(id);
            return Ok(cargoDetail);
        }
    }
}
