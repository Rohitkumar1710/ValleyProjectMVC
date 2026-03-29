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

        public async Task<IActionResult> Index()
        {
            var cities =await _cityRepo.GetAll();
            return View(cities);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var states =await _stateRepo.GetAllStates();
            ViewBag.StateList = new SelectList(states, "Id", "Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(City city)
        {
            if (ModelState.IsValid)
            {
               await _cityRepo.Save(city);
                return RedirectToAction("Index");
            }
            return View(city);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var city =await _cityRepo.GetById(id);
            var states =await _stateRepo.GetAllStates();
            ViewBag.StateList = new SelectList(states, "Id", "Name");
            return View(city);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(City city)
        {
            if (ModelState.IsValid)
            {
               await _cityRepo.Update(city);
                return RedirectToAction("Index");
            }
            return View(city);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var city =await _cityRepo.GetById(id);
            return View(city);
        }
    }
}
