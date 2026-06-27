using CarBookNetCore.Dtos.TagCloudDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace CarBookNetCore.WebUi.ViewComponents.BlogViewComponents
{
    public class _BlogDetailCloudeTagByBlogComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _BlogDetailCloudeTagByBlogComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7187/api/TagClouds/GetTagCloudByBlogId?id="+id);
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<GetByBlogIdTagCloudDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
