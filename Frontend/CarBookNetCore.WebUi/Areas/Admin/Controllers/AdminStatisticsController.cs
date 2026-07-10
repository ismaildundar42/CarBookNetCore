using CarBookNetCore.Dtos.StatisticsDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace CarBookNetCore.WebUi.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("/Admin/AdminStatistics/")]
    public class AdminStatisticsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminStatisticsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {

            var client = _httpClientFactory.CreateClient();

            #region ist1
            var responseMessage = await client.GetAsync("https://localhost:7187/api/Statistics/GetCarCount");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
                ViewBag.CarCount = values.carCount;
            }
            #endregion

            #region ist2
            var responseMessage2 = await client.GetAsync("https://localhost:7187/api/Statistics/GetLocationCount");
            if (responseMessage2.IsSuccessStatusCode)
            {
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                var values2 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData2);
                ViewBag.LocationCount = values2.locationCount;
            }
            #endregion

            #region ist3
            var responseMessage3 = await client.GetAsync("https://localhost:7187/api/Statistics/GetAuthorCount");
            if (responseMessage3.IsSuccessStatusCode)
            {
                var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
                var values3 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData3);
                ViewBag.AuthorCount = values3.authorCount;
            }
            #endregion

            #region ist4
            var responseMessage4 = await client.GetAsync("https://localhost:7187/api/Statistics/GetBlogCount");
            if (responseMessage4.IsSuccessStatusCode)
            {
                var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
                var values4 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData4);
                ViewBag.BlogCount = values4.blogCount;
            }
            #endregion

            #region ist5
            var responseMessage5 = await client.GetAsync("https://localhost:7187/api/Statistics/GetBrandCount");
            if (responseMessage5.IsSuccessStatusCode)
            {
                var jsonData5 = await responseMessage5.Content.ReadAsStringAsync();
                var values5 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData5);
                ViewBag.BrandCount = values5.brandCount;
            }
            #endregion

            #region ist6
            var responseMessage6 = await client.GetAsync("https://localhost:7187/api/Statistics/GetAvgRentPriceForDaily");
            if (responseMessage6.IsSuccessStatusCode)
            {
                var jsonData6 = await responseMessage6.Content.ReadAsStringAsync();
                var values6 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData6);
                ViewBag.AvgPriceDaily = values6.avgRentPriceForDaily;
            }
            #endregion

            #region ist7
            var responseMessage7 = await client.GetAsync("https://localhost:7187/api/Statistics/GetAvgRentPriceForWeekly");
            if (responseMessage7.IsSuccessStatusCode)
            {
                var jsonData7 = await responseMessage7.Content.ReadAsStringAsync();
                var values7 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData7);
                ViewBag.AvgPriceWeekly = values7.avgRentPriceForWeekly;
            }
            #endregion

            #region ist8
            var responseMessage8 = await client.GetAsync("https://localhost:7187/api/Statistics/GetAvgRentPriceForMonthly");
            if (responseMessage8.IsSuccessStatusCode)
            {
                var jsonData8 = await responseMessage8.Content.ReadAsStringAsync();
                var values8 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData8);
                ViewBag.AvgPriceMonthly = values8.avgRentPriceForMonthly;
            }
            #endregion

            #region ist9
            var responseMessage9 = await client.GetAsync("https://localhost:7187/api/Statistics/GetCarCountByTransmissionIsAuto");
            if (responseMessage9.IsSuccessStatusCode)
            {
                var jsonData9 = await responseMessage9.Content.ReadAsStringAsync();
                var values9 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData9);
                ViewBag.CountAuto = values9.carCountByTransmissionIsAuto;
            }
            #endregion

            #region ist10
            var responseMessage10 = await client.GetAsync("https://localhost:7187/api/Statistics/GetBrandNameByMaxCar");
            if (responseMessage10.IsSuccessStatusCode)
            {
                var jsonData10 = await responseMessage10.Content.ReadAsStringAsync();
                var values10 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData10);
                ViewBag.BrandNameMaxCar = values10.brandNameByMaxCar;
            }
            #endregion

            #region ist11
            var responseMessage11 = await client.GetAsync("https://localhost:7187/api/Statistics/GetCarCountByKmSmallerThan50k");
            if (responseMessage11.IsSuccessStatusCode)
            {
                var jsonData11 = await responseMessage11.Content.ReadAsStringAsync();
                var values11 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData11);
                ViewBag.KmSmallerThan50k = values11.carCountByKmSmallerThan50k;
            }
            #endregion

            #region ist12
            var responseMessage12 = await client.GetAsync("https://localhost:7187/api/Statistics/GetCarCountByFuelGasolineOrDiesel");
            if (responseMessage12.IsSuccessStatusCode)
            {
                var jsonData12 = await responseMessage12.Content.ReadAsStringAsync();
                var values12 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData12);
                ViewBag.GasOrDiesel = values12.carCountByFuelGasolineOrDiesel;
            }
            #endregion

            #region ist13
            var responseMessage13 = await client.GetAsync("https://localhost:7187/api/Statistics/GetCarCountByFuelElectric");
            if (responseMessage13.IsSuccessStatusCode)
            {
                var jsonData13 = await responseMessage13.Content.ReadAsStringAsync();
                var values13 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData13);
                ViewBag.ElectricCount = values13.carCountByFuelElectric;
            }
            #endregion

            #region ist14
            var responseMessage14 = await client.GetAsync("https://localhost:7187/api/Statistics/GetCarBrandAndModelByRentPriceDailyMax");
            if (responseMessage14.IsSuccessStatusCode)
            {
                var jsonData14 = await responseMessage14.Content.ReadAsStringAsync();
                var values14 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData14);
                ViewBag.PriceDailyMaxCar = values14.carBrandAndModelByRentPriceDailyMax;
            }
            #endregion

            #region ist15
            var responseMessage15 = await client.GetAsync("https://localhost:7187/api/Statistics/GetCarBrandAndModelByRentPriceDailyMin");
            if (responseMessage15.IsSuccessStatusCode)
            {
                var jsonData15 = await responseMessage15.Content.ReadAsStringAsync();
                var values15 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData15);
                ViewBag.PriceDailyMinCar = values15.carBrandAndModelByRentPriceDailyMin;
            }
            #endregion

            #region ist16
            var responseMessage16 = await client.GetAsync("https://localhost:7187/api/Statistics/GetBlogTitleByMaxBlogComment");
            if (responseMessage16.IsSuccessStatusCode)
            {
                var jsonData16 = await responseMessage16.Content.ReadAsStringAsync();
                var values16 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData16);
                ViewBag.MaxCommentBlog = values16.blogTitleByMaxBlogComment;
            }
            #endregion

            return View();
        }
    }
}
