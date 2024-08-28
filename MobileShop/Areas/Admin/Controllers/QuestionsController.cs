using BE;
using BLL;
using Microsoft.AspNetCore.Mvc;

namespace MobileShop.Areas.Admin.Controllers
{
    public class QuestionsController : BaseController
    {
        private readonly IQuestionService _questionService;

        public QuestionsController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        public ActionResult Index()
        {
            var list = _questionService.GetAll();
            return View(list);
        }

        public ActionResult Details(int id)
        {
            var model = _questionService.GetById(id);
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Question model)
        {
            if (model.Title == null || model.Description == null)
            {
                return View(model);
            }
            _questionService.Add(model);
            return RedirectToAction("Index", "Questions");
        }

        public ActionResult Edit(int id)
        {
            var model = _questionService.GetById(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Question model)
        {
            if (model.Title == null || model.Description == null)
            {
                return View(model);
            }
            _questionService.Edit(model);
            return RedirectToAction("Index", "Questions");
        }

    }
}
