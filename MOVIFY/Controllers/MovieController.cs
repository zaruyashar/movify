using Microsoft.AspNetCore.Mvc;
using MOVIFY.Data.Data;
using Microsoft.EntityFrameworkCore;

namespace MOVIFY.Controllers
{
    public class MovieController : Controller
    {
        // Connection
        public readonly ApplicationDbContext dbContext;

        public MovieController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var movies = dbContext.Movies
                .Include(m => m.Category)
                .Include(m => m.Director)
                .ToList();

            return View(movies);
        }
    }
}
