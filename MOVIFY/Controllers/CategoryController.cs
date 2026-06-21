using Microsoft.AspNetCore.Mvc;

namespace MOVIFY.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
