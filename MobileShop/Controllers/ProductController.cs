using BLL;
using Microsoft.AspNetCore.Mvc;
using MobileShop.Areas.Admin.Controllers;

namespace MobileShop.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult All()
        {

            ProductBLL pt = new ProductBLL();
            var list = pt.read();

            return View(list);
        }

    }
}
