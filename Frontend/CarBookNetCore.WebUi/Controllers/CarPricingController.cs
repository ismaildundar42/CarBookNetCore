using CarBookNetCore.Dtos.CarPricingDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBookNetCore.WebUi.Controllers
{
    public class CarPricingController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CarPricingController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            ViewBag.v1 = "Paketler";
            ViewBag.v2 = "Araç Fiyat Paketleri";

            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync(
                "https://localhost:7187/api/CarPricings/GetCarPricingWithTimePeriod"
            );

            if (!responseMessage.IsSuccessStatusCode)
            {
                return View(new List<ResultCarPricingWithTimePeriodDto>());
            }

            var jsonData = await responseMessage.Content.ReadAsStringAsync();

            var values = JsonConvert.DeserializeObject<
                List<ResultCarPricingWithTimePeriodDto>
            >(jsonData) ?? new List<ResultCarPricingWithTimePeriodDto>();

            const int pageSize = 8;

            var totalCount = values.Count;
            var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

            if (page < 1)
                page = 1;

            if (totalPages > 0 && page > totalPages)
                page = totalPages;

            var pagedValues = values
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;

            return View(pagedValues);
        }
    }
}