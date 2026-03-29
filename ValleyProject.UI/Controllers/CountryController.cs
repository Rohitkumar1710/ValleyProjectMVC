using Microsoft.AspNetCore.Mvc;
using ValleyProject.Entities.Model;
using ValleyProject.Repositories.Interface;
using ValleyProject.UI.ViewModel;
using ValleyProject.UI.ViewModel.CountryViewModel;

namespace ValleyProject.UI.Controllers
{
    public class CountryController : Controller
    {
        private readonly ICountryRepo _countryRepo;

        public CountryController(ICountryRepo countryRepo)
        {
            _countryRepo = countryRepo;
        }

        public async Task<IActionResult> Index()
        {
            if(HttpContext.Session.GetInt32("Id") != null)
            {
                List<CountryViewModel> countriesList = new List<CountryViewModel>();
                var contries = await _countryRepo.GetAll();
                foreach (var country in contries)
                {
                    CountryViewModel countryViewModel = new CountryViewModel()
                    {
                        Id = country.Id,
                        Name = country.Name
                    };
                    countriesList.Add(countryViewModel);
                }
                return View(countriesList);
            }
           return RedirectToAction("Login","Auth");
        }
        [HttpGet]
        public IActionResult Create()
        {
            CreateCountryViewModel country = new CreateCountryViewModel();
            return View(country);
        }
        [HttpPost]
        public async  Task<IActionResult> Create(CreateCountryViewModel vm)
        {
            var country = new Country()
            {
                Name = vm.Name
            };
            if (ModelState.IsValid)
            {
               await _countryRepo.Save(country);
                return RedirectToAction("Index");
            }
            return View(vm);
        }
        [HttpGet]
        public async  Task<IActionResult> Edit(int id)
        {
            var country =await _countryRepo.GetById(id);
            CountryViewModel countryViewModel = new CountryViewModel()
            {
                Id = country.Id,
                Name = country.Name
            };
            return View(countryViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(CountryViewModel country)
        {
            var countryl = new Country()
            {
                Id = country.Id,
                Name = country.Name
            };
            if (ModelState.IsValid)
            {
                await _countryRepo.Update(countryl);
                return RedirectToAction("Index");
            }
            return View(country);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var country =await _countryRepo.GetById(id);
           await _countryRepo.Delete(country);
            return RedirectToAction("Index");
        }
    }
}
