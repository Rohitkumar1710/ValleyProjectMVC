using Microsoft.AspNetCore.Mvc;
using ValleyProject.Entities.Model;
using ValleyProject.Repositories.Implementation;
using ValleyProject.Repositories.Interface;

namespace ValleyProject.UI.Controllers
{
    public class CityController : Controller
    {
        private readonly ICityRepositroy _cityRepo;

        public CityController(ICityRepositroy cityRepo)
        {
            _cityRepo = cityRepo;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            City city = new City();
            return View(city);
        }
        [HttpPost]
        public IActionResult Create(City city)
        {
            if (ModelState.IsValid)
            {
                _cityRepo.Save(city);
                return RedirectToAction("Index");
            }
            return View(city);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var city = _cityRepo.GetById(id);
            return View(city);
        }
        [HttpPost]
        public IActionResult Edit(City city)
        {
            if (ModelState.IsValid)
            {
                _cityRepo.Update(city);
                return RedirectToAction("Index");
            }
            return View(city);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var city = _cityRepo.GetById(id);
            return View(city);
        }
    }
}
