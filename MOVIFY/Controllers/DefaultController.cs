using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MOVIFY.Data.Data;
using System.Linq;

namespace MOVIFY.Controllers
{
    public class DefaultController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DefaultController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var latestMovies = _context.Movies
                .Include(m => m.Category)
                .Include(m => m.Director)
                .OrderByDescending(m => m.MovieId)
                .Take(6)
                .ToList();

            return View(latestMovies);
        }

        public IActionResult Search(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return RedirectToAction("Index");
            }

            var movies = _context.Movies
                .Include(m => m.Category)
                .Include(m => m.Director)
                .Where(m => m.MovieTitle.Contains(keyword) ||
                            m.Category.CategoryName.Contains(keyword) ||
                            m.Director.DirectorFullName.Contains(keyword))
                .ToList();

            ViewBag.Keyword = keyword;
            return View(movies);
        }
    }
}