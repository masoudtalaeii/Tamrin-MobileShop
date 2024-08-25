using BE;
using BLL;
using Microsoft.AspNetCore.Mvc;

namespace MobileShop.Areas.Admin.Controllers
{
    public class ProductSpecificationsController : BaseController
    {

        private readonly IProductSpecificationService _productSpecificationService;
        private readonly IProducService _producService;
        public ProductSpecificationsController(IProductSpecificationService productSpecificationService, IProducService producService)
        {
            _productSpecificationService = productSpecificationService;
            _producService = producService;
        }

        public ActionResult AllSpecificationById(int id)
        {
            ViewBag.ProductId = id;
            var list = _productSpecificationService.GetAll(id);
            ViewBag.ProductName = _producService.GetById(id).Name_Farsi;
            return View(list);
        }
        public ActionResult Create(int id)
        {
            ProductSpecification model = new ProductSpecification()
            {
                ProductId = id
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(ProductSpecification model)
        {
            if (model.FeatureTitle == null || model.FeatureValue == null)
            {
                return View(model);
            }
            _productSpecificationService.Add(model);
            return RedirectToAction("AllSpecificationById", "ProductSpecifications", new { id = model.ProductId });
        }
        public ActionResult Edit(int id)
        {
            var model = _productSpecificationService.GetById(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(ProductSpecification model)
        {
            if (model.FeatureTitle == null || model.FeatureValue == null)
            {
                return View(model);
            }

            _productSpecificationService.Edit(model);
            return RedirectToAction("AllSpecificationById", "ProductSpecifications", new { id = model.ProductId });
        }

    }
}
