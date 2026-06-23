using CarBookNetCore.Dtos.AboutDtos;
using CarBookNetCore.Dtos.CarDtos;
using CarBookNetCore.Dtos.CarPricingDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBookNetCore.WebUi.Controllers
{
    public class CarController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CarController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Arabalar";
            ViewBag.v2 = "Aracınızı Seçiniz";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7187/api/CarPricings");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarPrİcingWithCarDto>> (jsonData);
                return View(values);
            }
            return View();
        }
    }
}
