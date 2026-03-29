using Microsoft.AspNetCore.Mvc;
using ValleyProject.Repositories.Interface;

namespace ValleyProject.UI.ViewComponents
{
    public class CountCityViewComponent: ViewComponent
    {
        private readonly ICityRepositroy _cityRepositroy;

        public CountCityViewComponent(ICityRepositroy cityRepositroy)
        {
            _cityRepositroy = cityRepositroy;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var cities= await _cityRepositroy.GetAll();
            int totlacities= cities.Count();
            return View(totlacities);
        }
    }
}
