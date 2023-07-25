using coreMvcFundamentals.Models;
using Microsoft.AspNetCore.Mvc;

namespace coreMvcFundamentals.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            ProductModel model = new ProductModel();
            return View(model.findAll());
        }
    }
}
