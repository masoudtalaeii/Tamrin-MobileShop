using BE;
using BLL;
using Microsoft.AspNetCore.Mvc;

namespace MobileShop.Areas.Admin.Controllers
{
    public class ProductGroupsController : BaseController
    {
        private readonly IProductGroupService _productGroupService;
        public ProductGroupsController(IProductGroupService productGroupService)
        {
            _productGroupService = productGroupService;
        }



        public ActionResult Index()
        {
            var list = _productGroupService.GetAllProductGroups();
            return View(list);
        }



        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ProductGroup productGroup)
        {
            if (productGroup.Name != null)
            {
                _productGroupService.AddProductGroup(productGroup);
                return RedirectToAction("Index", "ProductGroups");
            }
            return View(productGroup);
        }

        public ActionResult Edit(int id)
        {
            var model = _productGroupService.GetProductGroupById(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(ProductGroup productGroup)
        {
            if (productGroup.Name != null)
            {
                _productGroupService.EditProductGroup(productGroup);
                return RedirectToAction("Index", "ProductGroups");
            }
            return View(productGroup);
        }

    }
}
