using Microsoft.AspNetCore.Mvc;

namespace CarBookNetCore.WebUi.ViewComponents.UiLayoutViewComponents
{
    public class _MainCoverUiLayoutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
