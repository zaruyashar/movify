using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MOVIFY.Data.Data;
using MOVIFY.Model;
using MOVIFY.Services;
using System.Linq;

namespace MOVIFY.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly ApplicationDbContext _context;

        public MovieController(IMovieService movieService, ApplicationDbContext context)
        {
            _movieService = movieService;
            _context = context;
        }

        public IActionResult Index()
        {
            var movies = _movieService.GetAllMovies();
            return View(movies);
        }


        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(_context.Categories.ToList(), "CategoryId", "CategoryName");
            ViewBag.Directors = new SelectList(_context.Directors.ToList(), "DirectorId", "DirectorFullName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _movieService.AddMovie(movie);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Categories = new SelectList(_context.Categories.ToList(), "CategoryId", "CategoryName", movie.CategoryId);
            ViewBag.Directors = new SelectList(_context.Directors.ToList(), "DirectorId", "DirectorFullName", movie.DirectorId);
            return View(movie);
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var movie = _movieService.GetMovieById(id);
            if (movie == null)
            {
                return NotFound();
            }

            // The 4th parameter pre-selects the existing value in the dropdown
            ViewBag.Categories = new SelectList(_context.Categories.ToList(), "CategoryId", "CategoryName", movie.CategoryId);
            ViewBag.Directors = new SelectList(_context.Directors.ToList(), "DirectorId", "DirectorFullName", movie.DirectorId);

            return View(movie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Movie movie)
        {
            if (id != movie.MovieId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _movieService.UpdateMovie(movie);
                return RedirectToAction(nameof(Index));
            }

            // If validation fails, repopulate the dropdowns and return the view
            ViewBag.Categories = new SelectList(_context.Categories.ToList(), "CategoryId", "CategoryName", movie.CategoryId);
            ViewBag.Directors = new SelectList(_context.Directors.ToList(), "DirectorId", "DirectorFullName", movie.DirectorId);

            return View(movie);
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var movie = _movieService.GetMovieById(id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _movieService.DeleteMovie(id);
            return RedirectToAction(nameof(Index));
        }
    }
}