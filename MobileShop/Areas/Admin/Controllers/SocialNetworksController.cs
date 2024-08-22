using BE;
using BLL;
using Microsoft.AspNetCore.Mvc;

namespace MobileShop.Areas.Admin.Controllers
{
    public class SocialNetworksController : BaseController
    {
        private readonly ISocialNetworkService _socialNetworkService;
        public SocialNetworksController(ISocialNetworkService socialNetworkService)
        {
            _socialNetworkService = socialNetworkService;
        }

        public ActionResult Index()
        {
            var list = _socialNetworkService.GetAll();
            return View(list);
        }

        public ActionResult Details(int id)
        {
            var model = _socialNetworkService.GetById(id);
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(SocialNetwork model)
        {
            if (model.UrlInstagram == null || model.UrlWhatsUp == null || model.UrlTellgram == null ||
                 model.UrlYoutube == null || model.UrlEita == null || model.UrlAparat == null)
            {
                return View(model);
            }
            _socialNetworkService.Add(model);
            return RedirectToAction("Index", "SocialNetworks");
        }

        public ActionResult Edit(int id)
        {
            var model = _socialNetworkService.GetById(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(SocialNetwork model)
        {
            if (model.UrlInstagram == null || model.UrlWhatsUp == null || model.UrlTellgram == null ||
                          model.UrlYoutube == null || model.UrlEita == null || model.UrlAparat == null)
            {
                return View(model);
            }
            _socialNetworkService.Edit(model);
            return RedirectToAction("Index", "SocialNetworks");
        }

    }
}
