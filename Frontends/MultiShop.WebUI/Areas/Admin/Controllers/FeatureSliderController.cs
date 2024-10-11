using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.FeatureSliderDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class FeatureSliderController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public FeatureSliderController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            @ViewBag.v1 = "Anasayfa";
            @ViewBag.v2 = "Öne Çıkan Görseller";
            @ViewBag.v3 = "Öne Çıkan Görseller Listesi";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7150/api/FeatureSliders");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var featureSliders = JsonConvert.DeserializeObject<List<ResultFeatureSliderDto>>(jsonData);
                return View(featureSliders);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateFeatureSlider()
        {
            @ViewBag.v1 = "Anasayfa";
            @ViewBag.v2 = "Öne Çıkan Görseller";
            @ViewBag.v3 = "Öne Çıkan Görseller Listesi";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeatureSlider(CreateFeatureSliderDto createFeatureSliderDto)
        {
            createFeatureSliderDto.Status = false;
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createFeatureSliderDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7150/api/FeatureSliders", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index), "FeatureSlider", new { Area = "Admin" });
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> DeleteFeatureSlider(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7150/api/FeatureSliders/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index), "FeatureSlider", new { Area = "Admin" });
            }
            return RedirectToAction(nameof(Index), "FeatureSlider", new { Area = "Admin" });
        }

        [HttpGet]
        public async Task<IActionResult> UpdateFeatureSlider(string id)
        {
            @ViewBag.v1 = "Anasayfa";
            @ViewBag.v2 = "Öne Çıkan Görseller";
            @ViewBag.v3 = "Öne Çıkan Görseller Listesi";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7150/api/FeatureSliders/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var featureSlider = JsonConvert.DeserializeObject<UpdateFeatureSliderDto>(jsonData);
                return View(featureSlider);
            }
            return RedirectToAction(nameof(Index), "FeatureSlider", new { Area = "Admin" });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateFeatureSlider(UpdateFeatureSliderDto updateFeatureSliderDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateFeatureSliderDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7150/api/FeatureSliders", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index), "FeatureSlider", new { Area = "Admin" });
            }
            return View();
        }
    }
}
