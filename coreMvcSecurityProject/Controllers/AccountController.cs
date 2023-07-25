using coreMvcSecurityProject.Models;
using coreMvcSecurityProject.Security;
using Microsoft.AspNetCore.Mvc;

namespace coreMvcSecurityProject.Controllers
{
    public class AccountController : Controller
    {
        SecurityManager securityManager = new SecurityManager();
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            AccountModel model = new AccountModel();
            if (username != null && password != null && model.login(username, password) != null)
            {
                securityManager.SignIn(this.HttpContext, model.find(username));
                return View("welcome");
            }
            else
            {
                ViewBag.error = "Invalid Credentials";
                return View("Index");
            }
        }
        public IActionResult Logout()
        {
            securityManager.SignOut(this.HttpContext);
            return RedirectToAction("Index");
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
