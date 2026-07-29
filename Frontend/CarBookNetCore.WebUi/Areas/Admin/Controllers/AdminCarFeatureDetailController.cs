using CarBookNetCore.Dtos.CarFeatureDtos;
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
    }
}
