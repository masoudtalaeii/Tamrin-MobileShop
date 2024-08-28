using BE;
using BLL;
using Microsoft.AspNetCore.Mvc;

namespace MobileShop.Areas.Admin.Controllers
{
    public class RulesController : BaseController
    {
        private readonly IRulesService _rulesService;

        public RulesController(IRulesService rulesService)
        {
            _rulesService = rulesService;
        }

        public ActionResult Index()
        {
            var list = _rulesService.GetAll();
            return View(list);
        }

        public ActionResult Details(int id)
        {
            var model = _rulesService.GetById(id);
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Rules model)
        {
            if (model.Title == null || model.Description == null)
            {
                return View(model);
            }
            _rulesService.Add(model);
            return RedirectToAction("Index", "Rules");
        }

        public ActionResult Edit(int id)
        {
            var model = _rulesService.GetById(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Rules model)
        {
            if (model.Title == null || model.Description == null)
            {
                return View(model);
            }
            _rulesService.Edit(model);
            return RedirectToAction("Index", "Rules");
        }

    }
}
