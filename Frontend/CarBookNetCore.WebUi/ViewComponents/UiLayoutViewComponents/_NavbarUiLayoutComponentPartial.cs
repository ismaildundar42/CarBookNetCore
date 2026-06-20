using Microsoft.AspNetCore.Mvc;

namespace CarBookNetCore.WebUi.ViewComponents.UiLayoutViewComponents
{
    public class _NavbarUiLayoutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
