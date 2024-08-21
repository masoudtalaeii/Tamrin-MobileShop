using BE;
using BLL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MobileShop.Classes;

namespace MobileShop.Areas.Admin.Controllers
{
    public class ArticlesController : BaseController
    {
        private readonly IArticleService _articleService;
        private readonly IArticleGroupService _articleGroupService;
        public ArticlesController(IArticleService articleService, IArticleGroupService articleGroupService)
        {
            _articleService = articleService;
            _articleGroupService = articleGroupService;
        }

        public ActionResult Index()
        {
            var list = _articleService.GetAll();
            return View(list);
        }

        public ActionResult Details(int id)
        {
            var model = _articleService.GetById(id);
            return View(model);
        }

        public ActionResult Create()
        {
            ViewData["ArticleGroupId"] = new SelectList(_articleGroupService.GetAll(), "ArticleGroupId", "Name");

            return View();
        }

        [HttpPost]
        public ActionResult Create(Article model, IFormFile Up)
        {
            if (model.shortDescription == null || model.totallDescription == null || model.Tag == null || model.Author == null)
            {
                ViewData["ArticleGroupId"] = new SelectList(_articleGroupService.GetAll(), "ArticleGroupId", "Name", model.ArticleGroupId);
                return View(model);
            }
            if (Up != null)
            {
                model.pic = SaveFile.SaveFileAndImages("/Upload/Article", Up);
            }
            _articleService.Add(model);
            return RedirectToAction("Index", "Articles");
        }

        public ActionResult Edit(int id)
        {
            var model = _articleService.GetById(id);
            ViewData["ArticleGroupId"] = new SelectList(_articleGroupService.GetAll(), "ArticleGroupId", "Name", model.ArticleGroupId);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Article model, IFormFile Up)
        {
            if (model.shortDescription == null || model.totallDescription == null || model.Tag == null || model.Author == null)
            {
                ViewData["ArticleGroupId"] = new SelectList(_articleGroupService.GetAll(), "ArticleGroupId", "Name", model.ArticleGroupId);
                return View(model);
            }
            if (Up != null)
            {
                if (SaveFile.DeleteFile("/UpLoad/Article", model.pic))
                {
                    model.pic = SaveFile.SaveFileAndImages("/UpLoad/Article", Up);

                }
            }
            model.date = DateTime.Now;
            _articleService.Edit(model);
            return RedirectToAction("Index", "Articles");
        }

    }
}
