using Microsoft.AspNetCore.Mvc;
using ValleyProject.Entities.Model;
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
            var contries= _countryRepo.GetAll();
            return View(contries);
        }
        [HttpGet]
        public IActionResult Create()
        {
            Country country = new Country();
            return View(country);
        }
        [HttpPost]
        public IActionResult Create(Country country)
        {
            if (ModelState.IsValid)
            {
                _countryRepo.Save(country);
                return RedirectToAction("Index");
            }
            return View(country);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var country = _countryRepo.GetById(id);
            return View(country);
        }
        [HttpPost]
        public IActionResult Edit(Country country)
        {
            if (ModelState.IsValid)
            {
                _countryRepo.Update(country);
                return RedirectToAction("Index");
            }
            return View(country);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var country = _countryRepo.GetById(id);
            _countryRepo.Delete(country);
            return RedirectToAction("Index");
        }
    }
}
