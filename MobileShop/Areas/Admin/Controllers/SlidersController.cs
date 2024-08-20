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

        public IActionResult Edit(int id)
        {
            var silder = _silderService.GetSilderById(id);
            return View(silder);
        }
        [HttpPost]
        public IActionResult Edit(Silder model,IFormFile Up)
        {
            if (Up != null)
            {
                if (SaveFile.DeleteFile("/UpLoad/Slider", model.pic))
                {
                    model.pic = SaveFile.SaveFileAndImages("/UpLoad/Slider", Up);

                } 
            }
            _silderService.EditSilder(model);
            return RedirectToAction("Index", "Sliders");
        }
    }
}
