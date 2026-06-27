using Microsoft.AspNetCore.Mvc;
using MOVIFY.Model;
using MOVIFY.Services;

namespace MOVIFY.Controllers
{
    public class DirectorController : Controller
    {
        private readonly IDirectorService _directorService;

        public DirectorController(IDirectorService directorService)
        {
            _directorService = directorService;
        }

        public IActionResult Index()
        {
            var directors = _directorService.GetAllDirectors();
            return View(directors);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Director director)
        {
            if (ModelState.IsValid)
            {
                _directorService.AddDirector(director);
                return RedirectToAction(nameof(Index));
            }
            return View(director);
        }

        public IActionResult Edit(int id)
        {
            var director = _directorService.GetDirectorById(id);
            if (director == null)
            {
                return NotFound();
            }
            return View(director);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Director director)
        {
            if (id != director.DirectorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _directorService.UpdateDirector(director);
                return RedirectToAction(nameof(Index));
            }
            return View(director);
        }

        public IActionResult Delete(int id)
        {
            var director = _directorService.GetDirectorById(id);
            if (director == null)
            {
                return NotFound();
            }
            return View(director);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _directorService.DeleteDirector(id);
            return RedirectToAction(nameof(Index));
        }
    }
}