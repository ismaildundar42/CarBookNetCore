using Microsoft.AspNetCore.Mvc;

namespace CarBookNetCore.WebUi.Controllers
{
    public class RentACarListController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
