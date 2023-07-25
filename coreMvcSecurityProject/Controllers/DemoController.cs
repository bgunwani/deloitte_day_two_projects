using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace coreMvcSecurityProject.Controllers
{
    public class DemoController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        public IActionResult Privacy()
        {
            return View();
        }
        [Authorize(Roles = "admin")]
        public IActionResult Operations()
        {
            return View();
        }
        [Authorize(Roles = "admin, employee")]
        public IActionResult Catalog()
        {
            return View();
        }
    }
}
