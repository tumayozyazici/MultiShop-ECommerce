using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.BrandDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class BrandController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BrandController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            @ViewBag.v1 = "Anasayfa";
            @ViewBag.v2 = "Markalar";
            @ViewBag.v3 = "Marka Listesi";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7150/api/Brands");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var brands = JsonConvert.DeserializeObject<List<ResultBrandDto>>(jsonData);
                return View(brands);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateBrand()
        {
            @ViewBag.v1 = "Anasayfa";
            @ViewBag.v2 = "Markalar";
            @ViewBag.v3 = "Marka Listesi";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBrand(CreateBrandDto createBrandDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createBrandDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7150/api/Brands", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index), "Brand", new { Area = "Admin" });
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> DeleteBrand(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7150/api/Brands/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index), "Brand", new { Area = "Admin" });
            }
            return RedirectToAction(nameof(Index), "Brand", new { Area = "Admin" });
        }

        [HttpGet]
        public async Task<IActionResult> UpdateBrand(string id)
        {
            @ViewBag.v1 = "Anasayfa";
            @ViewBag.v2 = "Markalar";
            @ViewBag.v3 = "Marka Listesi";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7150/api/Brands/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var brand = JsonConvert.DeserializeObject<UpdateBrandDto>(jsonData);
                return View(brand);
            }
            return RedirectToAction(nameof(Index), "Brand", new { Area = "Admin" });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBrand(UpdateBrandDto updateBrandDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateBrandDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7150/api/Brands", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index), "Brand", new { Area = "Admin" });
            }
            return View();
        }
    }
}
