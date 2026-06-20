using Microsoft.AspNetCore.Mvc;

namespace CarBookNetCore.WebUi.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
