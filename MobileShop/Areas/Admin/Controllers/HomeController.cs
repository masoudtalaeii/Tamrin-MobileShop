using Microsoft.AspNetCore.Mvc;

namespace MobileShop.Areas.Admin.Controllers
{

    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
