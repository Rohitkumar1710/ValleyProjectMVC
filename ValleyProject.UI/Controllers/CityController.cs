using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ValleyProject.Entities.Model;
using ValleyProject.Repositories.Implementation;
using ValleyProject.Repositories.Interface;

namespace ValleyProject.UI.Controllers
{
    public class CityController : Controller
    {
        private readonly ICityRepositroy _cityRepo;
        private readonly IStateRepo _stateRepo;

        public CityController(ICityRepositroy cityRepo, IStateRepo stateRepo)
        {
            _cityRepo = cityRepo;
            _stateRepo = stateRepo;
        }

        public IActionResult Index()
        {
            var cities = _cityRepo.GetAll().Result;
            return View(cities);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var states = _stateRepo.GetAllStates();
            ViewBag.StateList = new SelectList(states, "Id", "Name");
            return View();
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
            var states = _stateRepo.GetAllStates();
            ViewBag.StateList = new SelectList(states, "Id", "Name");
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
