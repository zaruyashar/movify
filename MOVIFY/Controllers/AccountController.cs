using Microsoft.AspNetCore.Mvc;

namespace MOVIFY.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Logout()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
