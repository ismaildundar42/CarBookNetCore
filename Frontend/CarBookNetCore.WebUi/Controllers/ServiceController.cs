using CarBookNetCore.Dtos.ServiceDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBookNetCore.WebUi.Controllers
{
    public class ServiceController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.v1 = "Hizmetler";
            ViewBag.v2 = "Hizmetlerimiz";
            return View();
        }
    }
}
