using BLL;
using Microsoft.AspNetCore.Mvc;
using MobileShop.Models;
using System.Diagnostics;

namespace MobileShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAboutsService _aboutsService;
        private readonly IQuestionService _questionService;
        private readonly IRulesService _rulesService;
        private readonly IArticleService _articleService;
        public HomeController(IAboutsService aboutsService, IQuestionService questionService, IRulesService rulesService, IArticleService articleService)
        {
            _aboutsService = aboutsService;
            _questionService = questionService;
            _rulesService = rulesService;
            _articleService = articleService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("about-us")]
        public IActionResult Aboutus()
        {
            var model = _aboutsService.GetAll();
            return View(model);
        }

        [Route("contact-us")]
        public IActionResult ContactUs()
        {
            
            var model = _aboutsService.GetAll();
            return View(model);
        }

        [Route("question")]
        public IActionResult Question()
        {

            var model = _questionService.GetAllForSite();
            return View(model);
        }

        [Route("rules")]
        public IActionResult Rules()
        {

            var model = _rulesService.GetAllForSite();
            return View(model);
        }

        [Route("blogs")]
        public IActionResult blogs()
        {

            var model = _articleService.GetAllForSite();
            return View(model);
        }

        [Route("/blog/{id}")]
        public IActionResult blog(int id)
        {

            var model = _articleService.GetById(id);
            model.SeeCount += 1;
            _articleService.Edit(model);
            return View(model);
        }

        [Route("/blogsByGroup/{id}")]
        public IActionResult blogsByGroup(int id)
        {

            var model = _articleService.GetAllByGroupId(id);
            return View(model);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
