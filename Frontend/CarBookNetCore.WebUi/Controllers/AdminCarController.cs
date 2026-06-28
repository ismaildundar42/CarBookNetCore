using Microsoft.AspNetCore.Mvc;

namespace CarBookNetCore.WebUi.Controllers
{
    public class AdminCarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
