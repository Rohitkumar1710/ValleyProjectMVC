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

        public async Task<IActionResult> Index()
        {
            var states =await _stateRepo.GetAllStates();
            return View(states);
        }
        [HttpGet("GetAllStates")]
        public async Task<IActionResult> GetAllStates()
        {
            var states =await _stateRepo.GetAllStates();
            return Ok(states);

        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var contries=await _countryRepo.GetAll();
            ViewBag.CountriesList = new SelectList(contries,"Id","Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(State state)
        {
            if (ModelState.IsValid)
            {
               await _stateRepo.AddState(state);
                return RedirectToAction("Index");
            }
            return View(state);
        }
        [HttpGet]
        public async  Task<IActionResult> Edit(int id)
        {
            var state =await _stateRepo.GetStateById(id);
            var contries = await _countryRepo.GetAll();
            ViewBag.CountriesList = new SelectList(contries, "Id", "Name");
            if (state == null)
            {
                return NotFound();
            }
            return View(state);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(State state)
        {
            if (ModelState.IsValid)
            {
                await _stateRepo.UpdateState(state);
                return RedirectToAction("Index");
            }
            return View(state);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var state =await _stateRepo.GetStateById(id);
           await _stateRepo.DeleteState(id);
            return RedirectToAction("Index");
        }
    }
}
