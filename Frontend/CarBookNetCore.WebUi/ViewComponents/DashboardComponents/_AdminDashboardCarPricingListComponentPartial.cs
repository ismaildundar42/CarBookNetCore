using CarBookNetCore.Dtos.CarPricingDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBookNetCore.WebUi.ViewComponents.DashboardComponents
{
    public class _AdminDashboardCarPricingListComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _AdminDashboardCarPricingListComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync(
                "https://localhost:7187/api/CarPricings/GetCarPricingWithTimePeriod"
            );

            if (!responseMessage.IsSuccessStatusCode)
            {
                return View(new List<ResultCarPricingWithTimePeriodDto>());
            }

            var jsonData = await responseMessage.Content.ReadAsStringAsync();

            var values = JsonConvert.DeserializeObject<List<ResultCarPricingWithTimePeriodDto>>(jsonData)
             ?? new List<ResultCarPricingWithTimePeriodDto>();

            values = values
                .TakeLast(6)
                .ToList();

            return View(values);

        }
    }
}
