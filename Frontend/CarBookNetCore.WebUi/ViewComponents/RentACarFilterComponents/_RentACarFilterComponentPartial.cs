using Microsoft.AspNetCore.Mvc;

namespace CarBookNetCore.WebUi.ViewComponents.RentACarFilterComponents
{
    public class _RentACarFilterComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
