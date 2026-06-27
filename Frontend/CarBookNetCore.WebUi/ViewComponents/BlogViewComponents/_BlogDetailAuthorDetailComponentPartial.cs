using CarBookNetCore.Dtos.AuthorDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace CarBookNetCore.WebUi.ViewComponents.BlogViewComponents
{
    public class _BlogDetailAuthorDetailComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _BlogDetailAuthorDetailComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7187/api/Blogs/GetAuthorByBlogAuthorId?id="+id);
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<GetAuthorByBlogAuthorIdDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
