using BE;
using BLL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MobileShop.Classes;

namespace MobileShop.Areas.Admin.Controllers
{
    public class ProductFeaturesController : BaseController
    {
        private readonly IProductFeatureService _productFeatureService;
        private readonly IProducService _producService;

        public ProductFeaturesController(IProductFeatureService productFeatureService, IProducService producService)
        {
            _productFeatureService = productFeatureService;
            _producService = producService;
        }

        public ActionResult AllFeatureById(int id)
        {
            ViewBag.ProductId = id;
            var list = _productFeatureService.GetAll(id);
            ViewBag.ProductName = _producService.GetById(id).Name_Farsi;
            return View(list);
        }
        public ActionResult Create(int id)
        {
            ProductFeature model =new ProductFeature()
            {
                ProductId=id
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(ProductFeature model)
        {
            if (model.FeatureTitle == null || model.FeatureValue == null)
            {
                return View(model);
            }
            _productFeatureService.Add(model);
            return RedirectToAction("AllFeatureById", "ProductFeatures" , new {id=model.ProductId});
        }
        public ActionResult Edit(int id)
        {
            var model = _productFeatureService.GetById(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(ProductFeature model)
        {
            if (model.FeatureTitle == null || model.FeatureValue == null)
            {
                return View(model);
            }
            
            _productFeatureService.Edit(model);
            return RedirectToAction("AllFeatureById", "ProductFeatures", new { id = model.ProductId });
        }

    }
}
