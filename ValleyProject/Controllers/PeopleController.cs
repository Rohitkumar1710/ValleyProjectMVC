using Microsoft.AspNetCore.Mvc;
using ValleyProject.ApplicationConnection;
using ValleyProject.Models;

namespace ValleyProject.Controllers
{
    public class PeopleController : Controller
    {
        private readonly DataContext _context;

        public PeopleController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var people = _context.peoples.ToList();
            return View(people);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Peoples people)
        {
            if (ModelState.IsValid)
            {
                _context.peoples.Add(people);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(people);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var result = _context.peoples.Find(id);
            if (result == null)
            {
                return NotFound();
            }
            return View(result);
        }
        [HttpPost]
        public IActionResult Edit(Peoples people)
        {
            _context.peoples.Update(people);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var result = _context.peoples.Find(id);
            if (result == null)
            {
                return NotFound();
            }
            return View(result);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(Peoples result)
        {
            _context.peoples.Remove(result);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var result = _context.peoples.Find(id);
            if (result == null)
            {
                return NotFound();
            }
            return View(result);
        }
    }
}