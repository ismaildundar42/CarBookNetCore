using Microsoft.AspNetCore.Mvc;

namespace CarBookNetCore.WebUi.ViewComponents.DefaultViewComponents
{
    public class _DefaultStatisticComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
