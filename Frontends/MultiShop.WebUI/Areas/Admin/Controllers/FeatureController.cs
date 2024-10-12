using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.FeatureDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class FeatureController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public FeatureController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            @ViewBag.v1 = "Anasayfa";
            @ViewBag.v2 = "Öne Çıkan Alanlar";
            @ViewBag.v3 = "Öne Çıkan Alanlar Listesi";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7150/api/Features");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var features = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(jsonData);
                return View(features);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateFeature()
        {
            @ViewBag.v1 = "Anasayfa";
            @ViewBag.v2 = "Öne Çıkan Alanlar";
            @ViewBag.v3 = "Öne Çıkan Alanlar Listesi";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeature(CreateFeatureDto createFeatureDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createFeatureDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7150/api/Features", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index), "Feature", new { Area = "Admin" });
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> DeleteFeature(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7150/api/Features/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index), "Feature", new { Area = "Admin" });
            }
            return RedirectToAction(nameof(Index), "Feature", new { Area = "Admin" });
        }

        [HttpGet]
        public async Task<IActionResult> UpdateFeature(string id)
        {
            @ViewBag.v1 = "Anasayfa";
            @ViewBag.v2 = "Öne Çıkan Alanlar";
            @ViewBag.v3 = "Öne Çıkan Alanlar Listesi";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7150/api/Features/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var feature = JsonConvert.DeserializeObject<UpdateFeatureDto>(jsonData);
                return View(feature);
            }
            return RedirectToAction(nameof(Index), "Feature", new { Area = "Admin" });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateFeatureDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7150/api/Features", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index), "Feature", new { Area = "Admin" });
            }
            return View();
        }
    }
}
