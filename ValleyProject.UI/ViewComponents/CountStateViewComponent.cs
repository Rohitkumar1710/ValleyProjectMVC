using Microsoft.AspNetCore.Mvc;

namespace ValleyProject.UI.ViewComponents
{
    public class CountStateViewComponent: ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
