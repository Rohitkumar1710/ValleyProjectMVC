using Microsoft.AspNetCore.Mvc;
using ValleyProject.Repositories.Interface;

namespace ValleyProject.UI.Controllers
{
    public class CountryController : Controller
    {
        private readonly ICountryRepo _countryRepo;

        public CountryController(ICountryRepo countryRepo)
        {
            _countryRepo = countryRepo;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
