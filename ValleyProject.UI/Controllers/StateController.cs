using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ValleyProject.Entities.Model;
using ValleyProject.Repositories.Interface;

namespace ValleyProject.UI.Controllers
{
    public class StateController : Controller
    {
        private readonly IStateRepo _stateRepo;
        private readonly ICountryRepo _countryRepo;

        public StateController(IStateRepo stateRepo, ICountryRepo countryRepo)
        {
            _stateRepo = stateRepo;
            _countryRepo = countryRepo;
        }

        public IActionResult Index()
        {
            var states = _stateRepo.GetAllStates();
            return View(states);
        }
        [HttpGet("GetAllStates")]
        public IActionResult GetAllStates()
        {
            var states = _stateRepo.GetAllStates();
            return Ok(states);

        }
        [HttpGet]
        public IActionResult Create()
        {
            var contries= _countryRepo.GetAll();
            ViewBag.CountriesList = new SelectList(contries,"Id","Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(State state)
        {
            if (ModelState.IsValid)
            {
                _stateRepo.AddState(state);
                return RedirectToAction("Index");
            }
            return View(state);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var state = _stateRepo.GetStateById(id);
            var contries = _countryRepo.GetAll();
            ViewBag.CountriesList = new SelectList(contries, "Id", "Name");
            if (state == null)
            {
                return NotFound();
            }
            return View(state);
        }
        [HttpPost]
        public IActionResult Edit(State state)
        {
            if (ModelState.IsValid)
            {
                _stateRepo.UpdateState(state);
                return RedirectToAction("Index");
            }
            return View(state);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var state = _stateRepo.GetStateById(id);
            _stateRepo.DeleteState(id);
            return RedirectToAction("Index");
        }
    }
}
