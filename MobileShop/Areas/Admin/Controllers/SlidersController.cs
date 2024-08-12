using BE;
using BLL;
using DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MobileShop.Classes;

namespace MobileShop.Areas.Admin.Controllers
{  
    public class SlidersController : BaseController
    {
        private readonly ISilderService _silderService;

        public SlidersController(ISilderService silderService)
        {
            _silderService = silderService;
        }

        public IActionResult Index()
        {
            var list = _silderService.GetAllSilders();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(IFormFile Up)
        {
            Silder model = new Silder();
            if (Up != null)
            {
                model.pic = SaveFile.SaveFileAndImages("/Upload/Slider", Up);
            }
            model.IsActive = true;
            _silderService.AddSilder(model);
            return RedirectToAction("Index", "Sliders");
        }

    }
}
