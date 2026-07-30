using CarBookNetCore.Dtos.CarFeatureDtos;
using CarBookNetCore.Dtos.FeatureDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace CarBookNetCore.WebUi.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]")]
    public class AdminCarFeatureDetailController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminCarFeatureDetailController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        [Route("Index/{id}")]
        public async Task<IActionResult> Index(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7187/api/CarFeatures?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarFeatureByCarIdDto>>(jsonData);
                return View(values);
            }
            return View(new List<ResultCarFeatureByCarIdDto>());
        }

        [HttpPost]
        [Route("Index/{id}")]
        public async Task<IActionResult> Index(List<ResultCarFeatureByCarIdDto> resultCarFeatureByCarIdDto)
        {
            if (resultCarFeatureByCarIdDto != null)
            {
                foreach (var item in resultCarFeatureByCarIdDto)
                {
                    var client = _httpClientFactory.CreateClient();
                    if (item.Available)
                    {
                        await client.GetAsync($"https://localhost:7187/api/CarFeatures/CarFeatureChangeAvailableToTrue?id=" + item.CarFeatureId);
                    }
                    else
                    {
                        await client.GetAsync($"https://localhost:7187/api/CarFeatures/CarFeatureChangeAvailableToFalse?id=" + item.CarFeatureId);
                    }
                }
            }

            return RedirectToAction("Index", "AdminCar", new { area = "" });
        }
        [Route("CreateFeatureByCarId/{id}")]
        [HttpGet]
        public async Task<IActionResult> CreateFeatureByCarId(int id)
        {
            ViewBag.carId = id;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7187/api/Features");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        [Route("CreateFeatureByCarId/{id}")]
        public async Task<IActionResult> CreateFeatureByCarId(List<ResultFeatureDto> resultFeatureDto, int id)
        {
            var client = _httpClientFactory.CreateClient();
            if (resultFeatureDto != null)
            {
                foreach (var item in resultFeatureDto)
                {
                    var dto = new CreateCarFeatureByCarDto
                    {
                        CarId = id,
                        FeatureId = item.FeatureId,
                        Available = item.Available
                    };
                    var jsonData = JsonConvert.SerializeObject(dto);
                    StringContent stringContent = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
                    await client.PostAsync("https://localhost:7187/api/CarFeatures", stringContent);
                }
            }

            return RedirectToAction("Index", "AdminCar");
        }
    }
}
