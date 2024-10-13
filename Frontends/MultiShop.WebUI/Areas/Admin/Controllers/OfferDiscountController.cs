using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.OfferDiscountDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class OfferDiscountController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public OfferDiscountController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            @ViewBag.v1 = "Anasayfa";
            @ViewBag.v2 = "İndirim Teklifleri";
            @ViewBag.v3 = "İndirim Teklif Listesi";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7150/api/OfferDiscounts");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var offerDiscounts = JsonConvert.DeserializeObject<List<ResultOfferDiscountDto>>(jsonData);
                return View(offerDiscounts);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateOfferDiscount()
        {
            @ViewBag.v1 = "Anasayfa";
            @ViewBag.v2 = "İndirim Teklifleri";
            @ViewBag.v3 = "İndirim Teklif Listesi";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateOfferDiscount(CreateOfferDiscountDto createOfferDiscountDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createOfferDiscountDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7150/api/OfferDiscounts", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index), "OfferDiscount", new { Area = "Admin" });
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> DeleteOfferDiscount(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7150/api/OfferDiscounts/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index), "OfferDiscount", new { Area = "Admin" });
            }
            return RedirectToAction(nameof(Index), "OfferDiscount", new { Area = "Admin" });
        }

        [HttpGet]
        public async Task<IActionResult> UpdateOfferDiscount(string id)
        {
            @ViewBag.v1 = "Anasayfa";
            @ViewBag.v2 = "İndirim Teklifleri";
            @ViewBag.v3 = "İndirim Teklif Listesi";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7150/api/OfferDiscounts/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var offerDiscount = JsonConvert.DeserializeObject<UpdateOfferDiscountDto>(jsonData);
                return View(offerDiscount);
            }
            return RedirectToAction(nameof(Index), "OfferDiscount", new { Area = "Admin" });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateOfferDiscount(UpdateOfferDiscountDto updateOfferDiscountDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateOfferDiscountDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7150/api/OfferDiscounts", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index), "OfferDiscount", new { Area = "Admin" });
            }
            return View();
        }
    }
}
