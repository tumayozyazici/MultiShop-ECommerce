using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.FeatureDtos;
using MultiShop.Catalog.Services.FeatureServices;

namespace MultiShop.Catalog.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly IFeatureService _featureService;

        public FeaturesController(IFeatureService featureService)
        {
            _featureService = featureService;
        }

        [HttpGet]
        public async Task<IActionResult> GetFeatureList()
        {
            var featureSliders = await _featureService.GetAllFeatureAsync();
            return Ok(featureSliders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeatureById(string id)
        {
            var featureSlider = await _featureService.GetFeatureByIdAsync(id);
            return Ok(featureSlider);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeature(CreateFeatureDto createFeatureDto)
        {
            await _featureService.CreateFeatureAsync(createFeatureDto);
            return Ok("Öne çıkan alan başarıyla eklendi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            await _featureService.UpdateFeatureAsync(updateFeatureDto);
            return Ok("Öne çıkan alan başarıyla güncellendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeature(string id)
        {
            await _featureService.DeleteFeatureAsync(id);
            return Ok("Öne çıkan alan başarıyla silindi.");
        }
    }
}
