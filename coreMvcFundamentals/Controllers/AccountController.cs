using Microsoft.AspNetCore.Mvc;

namespace coreMvcFundamentals.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if(username !=  null && password != null && username.Equals("admin") && password.Equals("admin"))
            {
                HttpContext.Session.SetString("name", username);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.error = "Invalid Credentials";
                return View("Index");
            }
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("name");
            return RedirectToAction("Index");
        }
    }
}
