using Microsoft.AspNetCore.Mvc;

namespace CarBookNetCore.WebUi.ViewComponents.UiLayoutViewComponents
{
    public class _HeadUiLayoutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
