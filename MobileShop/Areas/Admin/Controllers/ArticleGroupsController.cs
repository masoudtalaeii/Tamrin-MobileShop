using BE;
using BLL;
using Microsoft.AspNetCore.Mvc;

namespace MobileShop.Areas.Admin.Controllers
{
    public class ArticleGroupsController : BaseController
    {
        private readonly IArticleGroupService _articleGroupService;
        public ArticleGroupsController(IArticleGroupService articleGroupService)
        {
            _articleGroupService = articleGroupService;
        }



        public ActionResult Index()
        {
            var list = _articleGroupService.GetAll();
            return View(list);
        }



        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ArticleGroup model)
        {
            if (model.Name != null)
            {
                _articleGroupService.Add(model);
                return RedirectToAction("Index", "ArticleGroups");
            }
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var model = _articleGroupService.GetById(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(ArticleGroup model)
        {
            if (model.Name != null)
            {
                _articleGroupService.Edit(model);
                return RedirectToAction("Index", "ArticleGroups");
            }
            return View(model);
        }

    }
}
