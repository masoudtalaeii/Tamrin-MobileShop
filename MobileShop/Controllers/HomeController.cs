using BLL;
using Microsoft.AspNetCore.Mvc;
using MobileShop.Models;
using System.Diagnostics;

namespace MobileShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        //public IActionResult Details(int id)
        //{
        //    ProductBLL pt = new ProductBLL();
        //    var product = pt.readById(id);

        //    return View(product);


        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
