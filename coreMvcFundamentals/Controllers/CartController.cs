using coreMvcFundamentals.Helpers;
using coreMvcFundamentals.Models;
using Microsoft.AspNetCore.Mvc;

namespace coreMvcFundamentals.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            var cart = sessionHelper.getObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            ViewBag.cart = cart;
            return View();
        }

        public IActionResult Buy(int id)
        {
            ProductModel model = new ProductModel();
            if (sessionHelper.getObjectFromJson<List<Item>>(HttpContext.Session, "cart") == null)
            {
                List<Item> cart = new List<Item>();
                cart.Add(new Item() { Product = model.findById(id), Quantity = 1 });
                sessionHelper.setObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                List<Item>? cart = sessionHelper.getObjectFromJson<List<Item>>(HttpContext.Session, "cart");
                int index = isExist(id);
                if(index != -1)
                {
                    cart[index].Quantity++;
                }
                else
                {
                    cart.Add(new Item { Product = model.findById(id), Quantity = 1});
                }
                sessionHelper.setObjectAsJson(HttpContext.Session, "cart", cart);
            }
            return RedirectToAction("Index");
        }

        private int isExist(int id)
        {
            List<Item> cart = sessionHelper.getObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Product.Id == id)
                {
                    return i;
                }
            }
            return -1;
        }
        public IActionResult Remove(int id)
        {
            List<Item> cart = sessionHelper.getObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            int index = isExist(id);
            if(index != -1)
            {
                cart.RemoveAt(index);
                sessionHelper.setObjectAsJson(HttpContext.Session, "cart", cart);
                return RedirectToAction("Index");
            }
            ViewBag.Error = "Item is not added to the cart.";
            return View();
        }
    }
}
