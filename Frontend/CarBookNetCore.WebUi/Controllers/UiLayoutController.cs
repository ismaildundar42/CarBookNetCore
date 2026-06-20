using Microsoft.AspNetCore.Mvc;

namespace CarBookNetCore.WebUi.Controllers
{
    public class UiLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
