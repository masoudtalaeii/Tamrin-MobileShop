using BE;
using BLL;
using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MobileShop.Classes;

namespace MobileShop.Areas.Admin.Controllers
{
    public class ProductsController : BaseController
    {
        private readonly IProducService _producService;
        private readonly IProductGroupService _productGroupService;

        public ProductsController(IProducService producService, IProductGroupService productGroupService)
        {
            _producService = producService;
            _productGroupService = productGroupService;
        }

        public ActionResult Index()
        {
            var list = _producService.GetAll();
            return View(list);
        }
        public ActionResult Create()
        {
            ViewData["ProductGroupId"] = new SelectList(_productGroupService.GetAllProductGroups(), "ProductGroupId", "Name");

            return View();
        }

        [HttpPost]
        public ActionResult Create(Product model, IFormFile Up)
        {
            if (model.Name_Farsi == null || model.Name_English == null || model.Price == null || model.ProductGroupId == null)
            {
                ViewData["ProductGroupId"] = new SelectList(_productGroupService.GetAllProductGroups(), "ProductGroupId", "Name",model.ProductGroupId);
                return View(model);
            }
            if (Up != null)
            {
                model.pic = SaveFile.SaveFileAndImages("/Upload/Product", Up);
            }
            _producService.Add(model);
            return RedirectToAction("Index", "Products");
        }
        public ActionResult Edit(int id)
        {
            var model = _producService.GetById(id);
            ViewData["ProductGroupId"] = new SelectList(_productGroupService.GetAllProductGroups(), "ProductGroupId", "Name", model.ProductGroupId);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Product model, IFormFile Up)
        {
            if (model.Name_Farsi == null || model.Name_English == null || model.Price == null || model.ProductGroupId == null)
            {
                ViewData["ProductGroupId"] = new SelectList(_productGroupService.GetAllProductGroups(), "ProductGroupId", "Name", model.ProductGroupId);
                return View(model);
            }
            if (Up != null)
            {
                if (SaveFile.DeleteFile("/UpLoad/Product", model.pic))
                {
                    model.pic = SaveFile.SaveFileAndImages("/UpLoad/Product", Up);

                }
            }
            _producService.Edit(model);
            return RedirectToAction("Index", "Products");
        }

        public ActionResult Details(int id)
        {
            var model = _producService.GetById(id);
            return View(model);
        }

    }
}
