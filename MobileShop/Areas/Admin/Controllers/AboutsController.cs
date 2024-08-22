using BE;
using BLL;
using Microsoft.AspNetCore.Mvc;

namespace MobileShop.Areas.Admin.Controllers
{
    public class AboutsController : BaseController
    {
        private readonly IAboutsService _aboutsService;
        public AboutsController(IAboutsService aboutsService)
        {
            _aboutsService = aboutsService;
        }

        public ActionResult Index()
        {
            var list = _aboutsService.GetAll();
            return View(list);
        }

        public ActionResult Details(int id)
        {
            var model = _aboutsService.GetById(id);
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(AboutUs model)
        {
            if (model.AboutMe == null || model.Phone == null || model.Moblie == null || model.Address == null || model.Email == null)
            {
                return View(model);
            }

            _aboutsService.Add(model);
            return RedirectToAction("Index", "Abouts");
        }

        public ActionResult Edit(int id)
        {
            var model = _aboutsService.GetById(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(AboutUs model)
        {
            if (model.AboutMe == null || model.Phone == null || model.Moblie == null || model.Address == null || model.Email == null)
            {
                return View(model);
            }

            _aboutsService.Edit(model);
            return RedirectToAction("Index", "Abouts");
        }

    }
}
