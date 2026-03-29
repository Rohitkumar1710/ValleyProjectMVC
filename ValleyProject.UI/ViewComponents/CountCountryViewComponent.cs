using Microsoft.AspNetCore.Mvc;
namespace ValleyProject.UI.ViewComponents
{
    public class CountCountryViewComponent :ViewComponent       
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
