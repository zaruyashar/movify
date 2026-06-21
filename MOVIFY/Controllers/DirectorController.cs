using Microsoft.AspNetCore.Mvc;

namespace MOVIFY.Controllers
{
    public class DirectorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
